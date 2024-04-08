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
//using BloodBank_General;

namespace GenerateReportExt
{
    public partial class ParamListFrm : Form
    {
        // public string selectionFormula="";
        public string paramName;
        public string reportPath = "";
        public string server;
        public string user;
        public string pass;
        public OracleCommand CMD;
        public string SQL;
        public OracleDataReader READER;
        public List<int> Ids;
        public ParamListFrm(string Path, string reportLable, string paramname, OracleCommand cmd, string serverName, string userName, string password)
        {
            InitializeComponent();
            reportPath = Path;
            lblTitleReport.Text = reportLable;
            paramName = "{" + paramname + "}";
            server = serverName;
            user = userName;
            pass = password;
            CMD = cmd;
            initControls();
            //WriteToLogTable.WriteLog(CMD, "ParamListFrm constractor", "GenerateReportExt", "ParamListFrm", "OK");
        }
        private void initControls()
        {
            listViewIds.Columns.Add("");
            int xAWidth = listViewIds.Width / 15 == 0 ? 1 : listViewIds.Width / 15 * 4;
            listViewIds.Columns[0].Width = xAWidth * 3;
            txtBarcode.Focus();
        }
        private void GetIds()
        {
            try
            {
                Ids = new List<int>();
                int currId;
                for (int i = 0; i < listViewIds.Items.Count; i++)
                {
                    currId = GetSampleId(listViewIds.Items[i].Text, i + 1);
                    if (currId > 0)
                    {
                        Ids.Add(currId);
                    }
                }
            }
            catch (Exception e)
            {
                //WriteToLogTable.WriteLog(CMD, "Error on ParamListFrm GetIds : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on GetIds : " + e.Message);
            }
        }
        private int GetSampleId(string sampleName, int order)
        {
            int sampleId = 0;
            try
            {
                SQL = "select sample_id from lims_sys.sample where name='" + sampleName + "'";
                CMD.CommandText = SQL;
                READER = CMD.ExecuteReader();
                if (READER.HasRows)
                {
                    READER.Read();
                    sampleId = int.Parse(READER["SAMPLE_ID"].ToString());
                }
                READER.Close();
                //Update Report order
                if (sampleId > 0)
                {
                    SQL = "Update lims_sys.Sample_User Set u_report_order='" + order + "' where sample_id='" + sampleId + "'";
                    CMD.CommandText = SQL;
                    CMD.ExecuteNonQuery();
                }
                CMD.Dispose();
            }
            catch (Exception e)
            {
                //WriteToLogTable.WriteLog(CMD, "Error on ParamListFrm GetSampleId : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on GetSampleId : " + e.Message);
            }
            return sampleId;
        }
        private void RunReport()
        {
            try
            {
                var crp = new CrystalReport(server, user, pass, reportPath);
                crp.Load();
                crp.SetReportParameterValue("sampleIds", Ids.ToArray());
                crp.Login();

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

                //WriteToLogTable.WriteLog(CMD, "ParamListFrm RunReport successfully", "GenerateReportExt", "RunReport", "OK");
            }
            catch (Exception e)
            {
                //WriteToLogTable.WriteLog(CMD, "Error on RunReport : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on RunReport : " + e.Message);
            }
        }

        private bool ListViewContains(string barcode)
        {
            bool retval = false;
            try
            {
                if (listViewIds.Items.Count > 0)
                {
                    foreach (ListViewItem item in listViewIds.Items)
                    {
                        if (item.SubItems[0].Text == barcode)
                        {
                            retval = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //WriteToLogTable.WriteLog(CMD, "Error on ParamListFrm ListViewContains : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("EROR at ListViewContains : " + e.Message);
            }
            return retval;
        }
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && txtBarcode.Text != "")//case enterKey
            {
                ListViewItem li = null;

                string input = txtBarcode.Text;
                //Takes only  14 charters
                if (input.Length >= 14)
                    input = input.Substring(0, 14);
                //check if item already in list view
                // if (ListViewContains(txtBarcode.Text))
                var upperInput = input.ToUpper();
                if (ListViewContains(upperInput))
                {
                    MessageBox.Show("ברקוד כבר נמצא ברשימה!");
                }
                else//add item to listView 
                {
                    li = new ListViewItem(upperInput, 0);
                    listViewIds.Items.Add(li);
                }
                txtBarcode.Clear();
                txtBarcode.Focus();
            }

        }
        private void btnListOK_Click(object sender, EventArgs e)
        {
            if (listViewIds.Items.Count > 0)
            {
                GetIds();
                if (Ids.Count > 0)
                {
                    //selectionFormula = "(" + paramName + "=" + Ids[0];
                    //for (int i = 1; i < Ids.Count; i++)
                    //{
                    //    selectionFormula += " or " + paramName + "=" + Ids[i];
                    //}
                    //selectionFormula += ")";   
                    btnListOK.Enabled = false;
                    //WriteToLogTable.WriteLog(CMD, "ParamListFrm btnListOK_Click and call runReport ", "GenerateReportExt", "btnListOK_Click", "OK");
                    RunReport();
                }
                else
                {
                    MessageBox.Show("! לא ניתן לייצר דוח, מנות אינם קיימות");
                }
                this.Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //WriteToLogTable.WriteLog(CMD, "ParamListFrm btnCancel_Click ", "GenerateReportExt", "btnCancel_Click", "OK");
            this.Close();
        }

    }
}
