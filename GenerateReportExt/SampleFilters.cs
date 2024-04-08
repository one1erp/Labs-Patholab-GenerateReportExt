using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Patholab_Common;
using word = Microsoft.Office.Interop.Word;
using Oracle.DataAccess.Client;
using System.IO;
//////using BloodBank_General;

namespace GenerateReportExt
{
    public partial class SampleFiltersFrm : Form
    {
        #region members
       // public string selectionFormula = "";
        public string paramName;
        public string reportPath = "";
        public string server;
        public string user;
        public string pass;
        public OracleCommand CMD;
        public string SQL;
        public OracleDataReader READER;
        private Boolean createdOnChanged = false;
        private Boolean completedOnChanged = false;
        private List<Dictionary<string, string>> samples = new List<Dictionary<string, string>>();
        #endregion
        public SampleFiltersFrm(string Path, string paramname, OracleCommand cmd, string serverName, string userName, string password)
        {
            InitializeComponent();
            reportPath = Path;
            paramName = "{" + paramname + "}";
            server = serverName;
            user = userName;
            pass = password;
            CMD = cmd;
            initControls();
            //WriteToLogTable.WriteLog(CMD, "SampleFiltersFrm constractor", "GenerateReportExt", "SampleFiltersFrm", "OK");
        }
      
        private void initControls()
        {
            listViewSamples.Columns.Add("Name");
            int xAWidth = listViewSamples.Width / 15 == 0 ? 1 : listViewSamples.Width / 15 * 4;
            listViewSamples.Columns[0].Width = xAWidth * 3;
            LoadStatus();
        }
        private void LoadStatus()
        {
            try
            {
                SQL = "select pe.phrase_name NAME from LIMS_SYS.phrase_entry pe, LIMS_SYS.phrase_header ph where ph.phrase_id=pe.phrase_id and ph.name='Blood Unit Status'";
                CMD.CommandText = SQL;
                READER = CMD.ExecuteReader();
                if (READER.HasRows)
                {
                    while (READER.Read())
                    {
                        listBoxStatus.Items.Add(READER["NAME"].ToString());
                    }
                }
                READER.Close();
                CMD.Dispose();
            }
            catch (Exception e)
            {
                //WriteToLogTable.WriteLog(CMD, "Error on SampleFiltersFrm LoadStatus : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on LoadStatus : " + e.Message);
            }
        }
        private void GetSamplesByFilters()
        {
            try
            {
                SQL = "select distinct(s.name), s.sample_id from lims_sys.sample s ,lims_sys.sample_user su , LIMS_SYS.u_blood_unit b, LIMS_SYS.u_blood_unit_user bu where s.sample_id=su.sample_id and s.status <> 'X' and b.name like s.name||'%' and b.u_blood_unit_id=bu.u_blood_unit_id ";
                //if (createdOnChanged)
                if(checkBoxCreatedOn.Checked)
                {
                    SQL += " and s.created_on >= TO_DATE('" + string.Format("{0:dd/MM/yyyy}", dTPickerCreatedOn.Value) + "','DD/MM/YYYY')";
                    SQL += " and s.created_on < TO_DATE('" + string.Format("{0:dd/MM/yyyy}", dTPickerCreatedOn.Value.AddDays(1)) + "','DD/MM/YYYY')";
                }
                //if (completedOnChanged)
                if(checkBoxCompletedOn.Checked)
                {
                    SQL += " and s.completed_on >= TO_DATE('" + string.Format("{0:dd/MM/yyyy}", dTPickerCompletedOn.Value) + "','DD/MM/YYYY')";
                    SQL += " and s.completed_on < TO_DATE('" + string.Format("{0:dd/MM/yyyy}", dTPickerCompletedOn.Value.AddDays(1)) + "','DD/MM/YYYY')";
                }  
                if ((txtSampleName.Text != "" )&&( checkBoxSampleName.Checked))
                {
                    SQL += " and s.name like '%" + txtSampleName.Text + "%'";
                }
                //validate standart/positive samples              
                if (radioButtonPositive.Checked) 
                {
                    SQL += "and LIMS.BLOOD_BANK_REPORTS.IMERGENCY_LABELING(s.sample_id) <> 'T'";
                }
                if (radioButtonStandart.Checked) 
                {
                    SQL += "and LIMS.BLOOD_BANK_REPORTS.IMERGENCY_LABELING(s.sample_id) = 'T'";
                }
                if ((listBoxStatus.SelectedItems.Count > 0)&&(checkBoxStatus.Checked))
                {
                    SQL += " and bu.u_status in ('" + listBoxStatus.SelectedItems[0].ToString() + "'";
                    for (int i = 1; i < listBoxStatus.SelectedItems.Count; i++)
                    {
                        SQL += ",'" + listBoxStatus.SelectedItems[i].ToString() + "'";
                   }
                   SQL += ")";
                }
                CMD.CommandText = SQL;
                READER = CMD.ExecuteReader();
                Dictionary<string, string> ReaderRow;
                samples.Clear();
                if (READER.HasRows)
                {
                    while (READER.Read())
                    {
                        ReaderRow = new Dictionary<string, string>();
                        ReaderRow.Add("NAME", READER["NAME"].ToString());
                        ReaderRow.Add("ID", READER["Sample_ID"].ToString());
                        samples.Add(ReaderRow);
                    }
                }
                READER.Close();
                CMD.Dispose();
            }
            catch (Exception e)
            {
                //WriteToLogTable.WriteLog(CMD, "Error on SampleFiltersFrm GetSamplesByFilters : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on GetSamplesByFilters : " + e.Message);
            }
        }
        private void RunReport(string sample_id)
        {
            try
            {
                var crp = new CrystalReport(server, user, pass, reportPath);
                crp.Load();
                crp.SetReportParameterValue("sampleId", sample_id);
                crp.Login();
                //string pathId = string.Format("{0:dd_MM_yyyy HH_mm_ss}", DateTime.Now);
                //string wordPath = reportPath.Replace(".rpt", pathId + ".rtf");
                ////save word & pdf to global folder P:\LimsReports
                //wordPath = @"\\Lims-srv\lims\LimsReports" + wordPath.Substring(wordPath.LastIndexOf(@"\"));

                string wordPath = Common.CreateSavedPath(reportPath, CMD);
                crp.exportCrystalToWordRTFAndSave(wordPath);
                crp.close();
                string pdfPath = wordPath.Replace("rtf", "pdf");
                crp.exportWordRtfToPdf(wordPath, pdfPath);
                crp.showFile(pdfPath);
                
                //delete word file
                //crp.deleteFile(wordPath);
                //delete pdf file
                //crp.deleteFile(pdfPath);
             
                //WriteToLogTable.WriteLog(CMD, "SampleFiltersFrm runReport successfully", "GenerateReportExt", "RunReport", "OK");
            }
            catch (Exception e)
            {
                //WriteToLogTable.WriteLog(CMD, "Error on SampleFiltersFrm RunReport : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on RunReport : " + e.Message);
            }
        }
        #region events
        private void dTPickerCreatedOn_ValueChanged(object sender, EventArgs e)
        {
            createdOnChanged = true;
        }
        private void dTPickerCompletedOn_ValueChanged(object sender, EventArgs e)
        {
            completedOnChanged = true;
        }
        private void listViewSamples_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listViewSamples.Sorting == SortOrder.Ascending)
            {
                listViewSamples.Sorting = SortOrder.Descending;
            }
            else
            {
                listViewSamples.Sorting = SortOrder.Ascending;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetSamplesByFilters();
                ListViewItem li = null;
                foreach (Dictionary<string, string> sample in samples)
                {
                    li = new ListViewItem(sample["NAME"], 0);
                    listViewSamples.Items.Add(li);
                }
                if (samples.Count == 0)
                {
                    MessageBox.Show("לא נמצאו מנות מתאימות .");
                }
                else
                {
                    //WriteToLogTable.WriteLog(CMD, "PlateFilters loaded samples", "GenerateReportExt", "btnSearch_Click", "OK");
                    btnSearch.Enabled = false;
                    btnGenerateReport.Enabled = true;
                }
            }
            catch (Exception e1)
            {
                //WriteToLogTable.WriteLog(CMD, "Error on SampleFiltersFrm btnSearch_Click : " + e1.Message, e1.Source, e1.TargetSite.Name, "Error");
                MessageBox.Show("Error on btnSearch_Click : " + e1.Message);
            }
        }
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewSamples.SelectedItems.Count > 0)
                {
                string sample_id = "";
                foreach (ListViewItem item in listViewSamples.SelectedItems)
                {
                    //get sample_id by name
                    foreach (Dictionary<string, string> sample in samples)
                    {
                        if (sample["NAME"] == item.Text)
                        {
                            sample_id = sample["ID"];
                        }
                    }
                }
                //selectionFormula = paramName + "=" + sample_id;
                //WriteToLogTable.WriteLog(CMD, "SampleFilters sample selected and call runReport", "GenerateReportExt", "btnGenerateReport_Click", "OK");
                btnGenerateReport.Enabled = false;
                RunReport(sample_id);
                this.Close();
                }
              else 
                {
                    MessageBox.Show("יש לבחור מנה ולאשר / או לצאת");
                }
            }
            catch (Exception e1)
            {
                //WriteToLogTable.WriteLog(CMD, "Error on SampleFiltersFrm btnGenerateReport_Click : " + e1.Message, e1.Source, e1.TargetSite.Name, "Error");
                MessageBox.Show("Error on btnGenerateReport_Click : " + e1.Message);
            }

        }
        private void checkBoxCreatedOn_CheckedChanged(object sender, EventArgs e)
        {
            dTPickerCreatedOn.Enabled = checkBoxCreatedOn.Checked;
        }
        private void checkBoxCompletedOn_CheckedChanged(object sender, EventArgs e)
        {
            dTPickerCompletedOn.Enabled = checkBoxCompletedOn.Checked;
        }
        private void checkBoxSampleName_CheckedChanged(object sender, EventArgs e)
        {
            txtSampleName.Enabled = checkBoxSampleName.Checked;
        }
        private void checkBoxStatus_CheckedChanged(object sender, EventArgs e)
        {
            listBoxStatus.Enabled = checkBoxStatus.Checked;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //WriteToLogTable.WriteLog(CMD, "SampleFilters cancel", "GenerateReportExt", "btnCancel_Click", "OK");
            this.Close();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {

            listViewSamples.Items.Clear();

            checkBoxCompletedOn.Checked = false;
            dTPickerCompletedOn.Value = DateTime.Today;

            checkBoxCreatedOn.Checked = false;
            dTPickerCreatedOn.Value = DateTime.Today;

            checkBoxSampleName.Checked = false;
            txtSampleName.Clear();

            radioButtonStandart.Checked = false;
            radioButtonPositive.Checked = false;

            checkBoxStatus.Checked = false;
            listBoxStatus.SelectedItems.Clear();

            btnSearch.Enabled = true;

            btnGenerateReport.Enabled = false;
            //WriteToLogTable.WriteLog(CMD, "SampleFilters refresh filters", "GenerateReportExt", "btnRefresh_Click", "OK");
        }
        #endregion

      


    }
}
