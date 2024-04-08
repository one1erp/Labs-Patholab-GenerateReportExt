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


namespace GenerateReportExt
{
    public partial class PlateFiltersFrm : Form
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
        private Boolean completedOnChanged = false;
        private Boolean authorisedOnChanged = false;
        private Boolean labChanged = false;
        private List< Dictionary<string, string>> plates = new List<Dictionary<string, string>>();
        #endregion 
        public PlateFiltersFrm(string Path, string paramname, OracleCommand cmd, string serverName, string userName, string password)
        {
            InitializeComponent();
            reportPath = Path;
            paramName = "{" + paramname + "}";
            server = serverName;
            user = userName;
            pass = password;
            CMD = cmd;
            initControls();
         //   WriteToLogTable.WriteLog(CMD, "PlateFiltersFrm constractor", "GenerateReportExt", "PlateFiltersFrm", "OK");
        }
        #region private methodes
        private void initControls()
        {
            listViewPlates.Columns.Add("Name");
            int xAWidth = listViewPlates.Width / 15 == 0 ? 1 : listViewPlates.Width / 15 * 4;
            listViewPlates.Columns[0].Width = xAWidth * 4;
            LoadOperators();
            LoadLabs();
            cmbLab.Text = cmbLab.Items[0].ToString();
            LoadTests();
        }
        private void LoadOperators()
        {
            try
            {
                SQL = "select Full_Name from LIMS_SYS.operator ";
                CMD.CommandText = SQL;
                READER = CMD.ExecuteReader();
                if (READER.HasRows)
                {
                    while (READER.Read())
                    {
                        listBoxAuthorisedBy.Items.Add(READER["FULL_NAME"].ToString());
                    }
                }
                READER.Close();
                CMD.Dispose();
            }
            catch (Exception e)
            {
                ////WriteToLogTable.WriteLog(CMD, "Error on PlateFiltersFrm LoadOperators : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on LoadOperators : " + e.Message);
            }
        }
        private void LoadLabs() 
        {
            try
            {
                SQL = "select pe.phrase_name NAME from LIMS_SYS.phrase_entry pe, LIMS_SYS.phrase_header ph where ph.phrase_id=pe.phrase_id and ph.name='Lab Names'";
                CMD.CommandText = SQL;
                READER = CMD.ExecuteReader();
                if (READER.HasRows)
                {
                    while (READER.Read())
                    {
                        cmbLab.Items.Add(READER["NAME"].ToString());
                    }
                }
                READER.Close();
                CMD.Dispose();
            }
            catch (Exception e)
            {
                //WriteToLogTable.WriteLog(CMD, "Error on PlateFiltersFrm LoadLabs : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on LoadLabs : " + e.Message);
            }
        }
        private void LoadTests()
        {
            try
            {
                SQL = "select name from LIMS_SYS.test_template";
                CMD.CommandText = SQL;
                READER = CMD.ExecuteReader();
                if (READER.HasRows)
                {
                    while (READER.Read())
                    {
                        listBoxTests.Items.Add(READER["NAME"].ToString());
                    }
                }
                READER.Close();
                CMD.Dispose();
            }
            catch (Exception e)
            {
                //WriteToLogTable.WriteLog(CMD, "Error on PlateFiltersFrm LoadTests : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on LoadTests : " + e.Message);
            }
        }
        private void GetPlatesByFilters() 
        {
            try
            {
                SQL = "select distinct(p.name), p.plate_id from lims_sys.plate p ,lims_sys.plate_user pu, lims_sys.operator o, lims_sys.aliquot a, lims_sys.test t, lims_sys.test_template tt where p.plate_id=pu.plate_id and p.status <> 'X' and p.authorised_by = o.operator_id(+) and a.plate_id =p.plate_id and t.aliquot_id =a.aliquot_id and t.test_template_id=tt.test_template_id ";
                //if (completedOnChanged )
                if(checkBoxCompletedOn.Checked)
                {
                    SQL += " and p.completed_on >= TO_DATE('" + string.Format("{0:dd/MM/yyyy}", dTPickerCompletedOn.Value) + "','DD/MM/YYYY')";
                    SQL+=" and p.completed_on < TO_DATE('" + string.Format("{0:dd/MM/yyyy}", dTPickerCompletedOn.Value.AddDays(1)) + "','DD/MM/YYYY')";
                }
                //if (authorisedOnChanged)
                if(checkBoxAuthorisedOn.Checked)
                {
                    SQL += " and p.authorised_on >= TO_DATE('" + string.Format("{0:dd/MM/yyyy}", dTPickerAuthorisedOn.Value) + "','DD/MM/YYYY')";
                    SQL += " and p.authorised_on < TO_DATE('" + string.Format("{0:dd/MM/yyyy}", dTPickerAuthorisedOn.Value.AddDays(1)) + "','DD/MM/YYYY')";
                }
                if ((listBoxAuthorisedBy.SelectedItems.Count > 0) && (checkBoxAuthorisedBy.Checked))
                {
                    SQL += " and o.full_name  in ('" + listBoxAuthorisedBy.SelectedItems[0].ToString() + "'";
                    for (int i = 1; i < listBoxAuthorisedBy.SelectedItems.Count; i++)
                    {
                        SQL += ",'" + listBoxAuthorisedBy.SelectedItems[i].ToString() + "'";
                    }
                    SQL += ")";
                }
                //if (labChanged)
                if(checkBoxLab.Checked)
                {
                    SQL += " and p.name like '%" + cmbLab.Text + "%'";
                }
                if ((txtPlateName.Text != "" )&& (checkBoxPlateName.Checked))
                {
                    SQL += " and p.name like '%" + txtPlateName.Text + "%'";
                }
                if( (listBoxTests.SelectedItems.Count > 0)&&(checkBoxTests.Checked))
                {
                    SQL += " and tt.name in ('" + listBoxTests.SelectedItems[0].ToString() + "'";
                    for (int i = 1; i < listBoxTests.SelectedItems.Count; i++)
                    {
                        SQL += ",'" + listBoxTests.SelectedItems[i].ToString() + "'";
                    }
                    SQL += ")";
                }
                CMD.CommandText = SQL;
                READER = CMD.ExecuteReader();
                Dictionary<string, string> ReaderRow;
                plates.Clear();

                if (READER.HasRows)
                {
                    while (READER.Read())
                    {
                        ReaderRow = new Dictionary<string, string>();
                        ReaderRow.Add("NAME", READER["NAME"].ToString());
                        ReaderRow.Add("ID", READER["PLATE_ID"].ToString());
                        plates.Add(ReaderRow);
                    }
                }
                READER.Close();
                CMD.Dispose();
            }
            catch (Exception e)
            {
                //WriteToLogTable.WriteLog(CMD, "Error on PlateFiltersFrm GetPlatesByFilters : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on GetPlatesByFilters : " + e.Message);
            }
        }
        private void RunReport(string plate_id)
        {
            try
            {
                var crp = new CrystalReport(server, user, pass, reportPath);
                crp.Load();
                crp.SetReportParameterValue("plateId", plate_id);
                crp.Login();
                //string pathId = string.Format("{0:dd_MM_yyyy HH_mm_ss}", DateTime.Now);
                //string wordPath = reportPath.Replace(".rpt", pathId + ".rtf");
                ////save word & pdf to global folder P:\LimsReports
                //wordPath =@"\\Lims-srv\lims\LimsReports" + wordPath.Substring(wordPath.LastIndexOf(@"\"));
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
              
                //WriteToLogTable.WriteLog(CMD, "PlateFilters runReport successfully", "GenerateReportExt", "RunReport", "OK");
            }
            catch (Exception e)
            {

                //WriteToLogTable.WriteLog(CMD, "Error on PlateFiltersFrm RunReport : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on RunReport : " + e.Message);
            }
        }
        #endregion
        #region events
        private void listViewPlates_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listViewPlates.Sorting == SortOrder.Ascending)
            {
                listViewPlates.Sorting = SortOrder.Descending;
            }
            else
            {
                listViewPlates.Sorting = SortOrder.Ascending;
            }
        }
        private void dTPickerCompletedOn_ValueChanged(object sender, EventArgs e)
        {
            completedOnChanged = true;
        }
        private void dTPickerAuthorisedOn_ValueChanged(object sender, EventArgs e)
        {
            authorisedOnChanged = true;
        }
        private void cmbLab_MouseClick(object sender, MouseEventArgs e)
        {
            labChanged = true;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetPlatesByFilters();
                ListViewItem li = null;
                foreach (Dictionary<string, string> plate in plates) 
                {
                    li = new ListViewItem(plate["NAME"],0);
                    listViewPlates.Items.Add(li);
                }
                if (plates.Count == 0) 
                {
                    MessageBox.Show("לא נמצאו פלטות מתאימות .");
                }
                else
                {
                    //WriteToLogTable.WriteLog(CMD, "PlateFilters loaded plates", "GenerateReportExt", "btnSearch_Click", "OK");
                    btnSearch.Enabled = false;
                    btnGenerateReport.Enabled = true;
                }
            }
            catch (Exception e1) 
            {
                //WriteToLogTable.WriteLog(CMD, "Error on PlateFiltersFrm btnSearch_Click : " + e1.Message, e1.Source, e1.TargetSite.Name, "Error");
                MessageBox.Show("Error on btnSearch_Click : " + e1.Message);
            }
        }
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
             try
            {
                if (listViewPlates.SelectedItems.Count > 0)
                {
                    string plate_id = "";
                    foreach (ListViewItem item in listViewPlates.SelectedItems)
                    {
                        //get plate_id by name
                        foreach (Dictionary<string, string> plate in plates)
                        {
                            if (plate["NAME"] == item.Text)
                            {
                                plate_id = plate["ID"];
                            }
                        }
                    }
                   // selectionFormula = paramName + "=" + plate_id;
                    //WriteToLogTable.WriteLog(CMD, "PlateFilters plate selected and call runReport", "GenerateReportExt", "btnGenerateReport_Click", "OK");
                    btnGenerateReport.Enabled = false;
                    RunReport(plate_id);
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("יש לבחור פלטה ולאשר / או לצאת");
                }
            }
             catch (Exception e1)
             {
                 //WriteToLogTable.WriteLog(CMD, "Error on PlateFiltersFrm btnGenerateReport_Click : " + e1.Message, e1.Source, e1.TargetSite.Name, "Error");
                 MessageBox.Show("Error on btnGenerateReport_Click : " + e1.Message);
             }
        }
        private void checkBoxCompletedOn_CheckedChanged(object sender, EventArgs e)
        {
            dTPickerCompletedOn.Enabled = checkBoxCompletedOn.Checked;
        }
        private void checkBoxAuthorisedOn_CheckedChanged(object sender, EventArgs e)
        {
            dTPickerAuthorisedOn.Enabled = checkBoxAuthorisedOn.Checked;
        }
        private void checkBoxAuthorisedBy_CheckedChanged(object sender, EventArgs e)
        {
            listBoxAuthorisedBy.Enabled = checkBoxAuthorisedBy.Checked;
        }
        private void checkBoxLab_CheckedChanged(object sender, EventArgs e)
        {
            cmbLab.Enabled = checkBoxLab.Checked;
        }
        private void checkBoxPlateName_CheckedChanged(object sender, EventArgs e)
        {
            txtPlateName.Enabled = checkBoxPlateName.Checked;
        }
        private void checkBoxTests_CheckedChanged(object sender, EventArgs e)
        {
            listBoxTests.Enabled = checkBoxTests.Checked;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //WriteToLogTable.WriteLog(CMD, "PlateFilters cancel", "GenerateReportExt", "btnCancel_Click", "OK");
            this.Close();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
            listViewPlates.Items.Clear();

            checkBoxCompletedOn.Checked = false;
            dTPickerCompletedOn.Value = DateTime.Today;

            checkBoxAuthorisedOn.Checked = false;
            dTPickerAuthorisedOn.Value = DateTime.Today;

            checkBoxAuthorisedBy.Checked = false;
            listBoxAuthorisedBy.SelectedItems.Clear();

            checkBoxLab.Checked = false;
            cmbLab.Text = cmbLab.Items[0].ToString();

            checkBoxPlateName.Checked = false;
            txtPlateName.Clear();

            checkBoxTests.Checked = false;
            listBoxTests.SelectedItems.Clear();

            btnSearch.Enabled = true;

            btnGenerateReport.Enabled = false;
            //WriteToLogTable.WriteLog(CMD, "PlateFilters refresh filters", "GenerateReportExt", "btnRefresh_Click", "OK");
        }
        #endregion

      

    }
}
