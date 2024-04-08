using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Patholab_Common;
using word = Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.IO;
//using BloodBank_General;
using Oracle.DataAccess.Client; 

namespace GenerateReportExt
{
    public partial class DatesFrm : Form
    {
        //to run the report with no prompt fields then cancel the setParameters and use selectionFormula.
        //public string selectionFormula = "";
        public string paramName;
        public string reportPath = "";
        public string server;
        public string user;
        public string pass;
        public OracleCommand CMD;
        public DateTime fromDate;
        public DateTime toDate;
        public Boolean toDateChange = false;
        public Boolean fromDateChange = false;
        public DatesFrm(string Path, string paramname, OracleCommand cmd, string serverName, string userName, string password)
        {

           
            InitializeComponent();
            reportPath = Path;
            paramName = "{" + paramname + "}";
            server = serverName;
            user = userName;
            pass = password;
            CMD = cmd;
            //WriteToLogTable.WriteLog(CMD, "DatesFrm constractor", "GenerateReportExt", "DatesFrm", "OK");
        }
        private void monthCalendarFrom_DateSelected(object sender, DateRangeEventArgs e)
        {
            fromDateChange = true;
            fromDate = monthCalendarFrom.SelectionRange.Start;
            monthCalendarTo.SelectionStart = fromDate;
        }
        private void monthCalendarTo_DateSelected(object sender, DateRangeEventArgs e)
        {
           toDateChange = true;
           toDate = monthCalendarTo.SelectionRange.Start;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!fromDateChange)
            {
                fromDate = DateTime.Today;
            }
            if (!toDateChange)
            {
               toDate= fromDate;
            }
            if (toDate < fromDate)
            {
                MessageBox.Show("'עד תאריך' צריך להיות גדול או שווה ל 'מ תאריך'");
            }
            else 
            {
                if(toDate == fromDate)
                {
                    toDate = toDate.AddHours(23);
                    toDate = toDate.AddMinutes(59);
                    toDate = toDate.AddSeconds(59); //end of the day...
                }
                //selectionFormula = "(" + paramName + ">=#" + fromDate.ToString()+"#";
                //selectionFormula += " and " + paramName + "<=#" + toDate.ToString() + "#)";
                btnOK.Enabled = false;
                //WriteToLogTable.WriteLog(CMD, "DatesFrm btnOK_Click and call runReport", "GenerateReportExt", "btnOK_Click", "OK");
                RunReport(string.Format("{0:dd/MM/yyyy}", fromDate), string.Format("{0:dd/MM/yyyy}", toDate));   
                this.Close();
            }
        }
        private void RunReport(string dFrom,string dTo)
        {
            try
            {
                var crp = new CrystalReport(server,user,pass,reportPath);
                crp.Load();
                crp.SetReportParameterValue("From Date", dFrom);
                crp.SetReportParameterValue("To Date", dTo);
                crp.Login();
                string rp=  Common.CreateSavedPath(reportPath,CMD);
                string pathId = string.Format("{0:dd_MM_yyyy HH_mm_ss}", DateTime.Now);
                string wordPath = reportPath.Replace(".rpt", pathId+".rtf");
                //save word & pdf to global folder P:\LimsReports
                wordPath = @"\\Lims-srv\lims\LimsReports" + wordPath.Substring(wordPath.LastIndexOf(@"\"));
                crp.exportCrystalToWordRTFAndSave(rp);
                crp.close();
                string pdfPath = rp.Replace("rtf", "pdf");
                crp.exportWordRtfToPdf(rp, pdfPath);
                crp.showFile(pdfPath);
               
                //delete word file
                //crp.deleteFile(wordPath);
                //delete pdf file
                //crp.deleteFile(pdfPath);
                //WriteToLogTable.WriteLog(CMD, "DatesFrm Report created successfully", "GenerateReportExt", "RunReport", "OK");
            }
            catch (Exception e)
            {
                //WriteToLogTable.WriteLog(CMD, "Error on RunReport : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on RunReport : " + e.Message);
            }
        }
    }
}
