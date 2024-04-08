using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Data.EntityClient;
using System.Drawing;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using LSExtensionWindowLib;
using LSSERVICEPROVIDERLib;
using System.Runtime.InteropServices;
using Patholab_Common;
using word = Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.IO;
//using BloodBank_General;


namespace GenerateReportExt
{
    [ComVisible(true)]
    [ProgId("NautilusExtensions.GenerateReportExt")]
    public partial class GenerateReportCtrl : UserControl, IExtensionWindow
    {
        #region C'tor
        public GenerateReportCtrl()
        {
            InitializeComponent();
            BackColor = Color.FromName("Control");

        }
        #endregion

        #region Private Members

        private IExtensionWindowSite _ntlsSite;
        private INautilusProcessXML _processXml;
        private INautilusServiceProvider _sp;
        private INautilusUser _nu;
        private OracleConnection _connection;
        private static string sql = "";
        private static OracleCommand cmd;
        private static OracleDataReader reader;
        private static string _connectionString;
        private static string _sessionId;
        private static string ServerName;
        private static string NautilusUserName;
        private static string NautilusPassword;
        private List<Dictionary<string, string>> reportsNames = new List<Dictionary<string, string>>();
        private Dictionary<string, string> reportToGenerate;
        private List<Dictionary<string, string>> reportsParams = new List<Dictionary<string, string>>();
        private string Role = "";
        private string _generalReportPath;
        #endregion

        #region implementing IExtensionWindow
        public bool CloseQuery()
        {
            if (_connection != null && _connection.State != ConnectionState.Closed)
                _connection.Close();
            this.Dispose();
            return true;
        }

        public WindowRefreshType DataChange()
        {
            return LSExtensionWindowLib.WindowRefreshType.windowRefreshNone;
        }

        public WindowButtonsType GetButtons()
        {
            return LSExtensionWindowLib.WindowButtonsType.windowButtonsNone;
        }

        public void Internationalise()
        {
        }

        public static OracleConnection GetConnection(INautilusDBConnection ntlsCon)
        {
            OracleConnection connection = null;
            if (ntlsCon != null)
            {
                //initialize variables
                string rolecommand;
                //try catch block
                try
                {
                    _connectionString = ntlsCon.GetADOConnectionString();
                    var splited = _connectionString.Split(';');
                    _connectionString = "";
                    for (int i = 1; i < splited.Count(); i++)
                    {
                        _connectionString += splited[i] + ';';
                    }

                    //create connection
                    connection = new OracleConnection(_connectionString);

                    //open the connection
                    connection.Open();

                    //get lims user password
                    string limsUserPassword = ntlsCon.GetLimsUserPwd();

                    //getDatailsToRunCrystalReports
                    ServerName = ntlsCon.GetServerDetails();
                    NautilusUserName = ntlsCon.GetUsername();
                    NautilusPassword = ntlsCon.GetPassword();

                    //set role lims user
                    if (limsUserPassword == "")
                    {
                        //lims_user is not password protected 
                        rolecommand = "set role lims_user";
                    }
                    else
                    {
                        //lims_user is password protected
                        rolecommand = "set role lims_user identified by " + limsUserPassword;
                    }

                    //set the oracle user for this connection
                    OracleCommand command = new OracleCommand(rolecommand, connection);

                    //try/catch block
                    try
                    {
                        //execute the command
                        command.ExecuteNonQuery();
                    }
                    catch (Exception f)
                    {
                        //throw the exeption
                        MessageBox.Show("Inconsistent role Security : " + f.Message);
                    }

                    //get session id
                    double sessionId = ntlsCon.GetSessionId();
                    _sessionId = sessionId.ToString();

                    //connect to the same session 
                    string sSql = string.Format("call lims.lims_env.connect_same_session({0})", sessionId);

                    //Build the command 
                    command = new OracleCommand(sSql, connection);

                    //execute the command
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    //throw the exeption
                    MessageBox.Show("Err At GetConnection: " + e.Message);
                }
            }
            return connection;
        }

        public void PreDisplay()
        {
            INautilusDBConnection dbConnection;
            if (_sp != null)
            {
                dbConnection = _sp.QueryServiceProvider("DBConnection") as NautilusDBConnection;
                _nu = _sp.QueryServiceProvider("User") as INautilusUser;
            }
            else
            {
                dbConnection = null;
            }
            if (dbConnection != null)
            {
                // _username= dbConnection.GetUsername();
                _connection = GetConnection(dbConnection);
            }
            Common.SetWorkStationName(_nu);
        }

        public void RestoreSettings(int hKey)
        {

        }

        public bool SaveData()
        {
            return false;
        }

        public void SaveSettings(int hKey)
        {

        }

        public void SetParameters(string parameters)
        {
            InitControls();
        }

        public void SetServiceProvider(object serviceProvider)
        {
            _sp = serviceProvider as NautilusServiceProvider;
            if (_sp != null)
            {
                _processXml = _sp.QueryServiceProvider("ProcessXML") as NautilusProcessXML;
            }
            else
            {
                _processXml = null;
            }
        }

        public void SetSite(object site)
        {
            _ntlsSite = (IExtensionWindowSite)site;
            _ntlsSite.SetWindowInternalName("Generate Report");
            _ntlsSite.SetWindowRegistryName("Generate Report");
            _ntlsSite.SetWindowTitle("Generate Report");
        }

        public void Setup()
        {
            //set oracleCommand's connection
            cmd = _connection.CreateCommand();
            //WriteToLogTable.WriteLog(cmd, "start run", "GenerateReportExt ", "Setup", "OK");
            //get Rol and Reports
            GetRole();
            GetReportsNames();
            LoadReportsLables();

            _generalReportPath = GetPhraseEntry("System Parameters", "Crystal");
        }

        public WindowRefreshType ViewRefresh()
        {
            return LSExtensionWindowLib.WindowRefreshType.windowRefreshNone;
        }

        public void refresh()
        {

        }
        #endregion

        #region private methods

        private void InitControls()
        {
            listViewA.Columns.Add("");
            int xAWidth = listViewA.Width / 15 == 0 ? 1 : listViewA.Width / 15 * 4;
            listViewA.Columns[0].Width = xAWidth * 3;
            listViewB.Columns.Add("");
            int xBWidth = listViewB.Width / 15 == 0 ? 1 : listViewB.Width / 15 * 4;
            listViewB.Columns[0].Width = xBWidth * 3;
        }
        private void GetRole()
        {
            try
            {
                //sql = "select r.name from  LIMS_SYS.lims_session s , lims_sys.operator o, lims_sys.lims_role r where s.session_id ='" + _sessionId + "' and s.operator_id= o.operator_id  and o.role_id = r.role_id";
                // cmd.CommandText = sql;
                // reader = cmd.ExecuteReader();
                // if (reader.HasRows)
                // {
                //     reader.Read();
                //    Role = reader["NAME"].ToString();
                // }
                //reader.Close();
                // cmd.Dispose();
                Role = _nu.GetRoleName(); // get current role , insted the query above return default role of user
            }
            catch (Exception e)
            {
                Logger.WriteLogFile(e);
                //WriteToLogTable.WriteLog(cmd, "Error on GetRole : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on GetRole : " + e.Message);
            }
        }
        private void GetReportsNames()
        {
            try
            {




                //sql = "select rn.u_reports_names_id ID, rn.name , rn.description, rnu.u_lable, rnu.u_roll_aloud , rnu.u_colmn, rnu.u_bold";
                //sql += " from lims_sys.u_reports_names rn, lims_sys.u_reports_names_user rnu";
                //sql += " where rn.u_reports_names_id=rnu.u_reports_names_id";
                //sql += " order by rnu.u_colmn, rnu.u_order_in_screen";


                Debugger.Launch();
                string sql =
                    "SELECT RN.U_CRYSTAL_REPORT_ID ID, RN.NAME , RN.DESCRIPTION, RNU.U_LABEL, RNU.U_ROLE_ALLOWED , " +
                    "RNU.U_COLUMN, RNU.U_BOLD FROM LIMS_SYS.U_CRYSTAL_REPORT RN, LIMS_SYS.U_CRYSTAL_REPORT_USER RNU" +
                    " WHERE RN.U_CRYSTAL_REPORT_ID=RNU.U_CRYSTAL_REPORT_ID";
                cmd.CommandText = sql;
                reader = cmd.ExecuteReader();
                Dictionary<string, string> ReaderRow;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ReaderRow = new Dictionary<string, string>();
                        ReaderRow.Add("ID", reader["ID"].ToString());
                        ReaderRow.Add("NAME", reader["NAME"].ToString());
                        ReaderRow.Add("DESCRIPTION", reader["DESCRIPTION"].ToString());
                        ReaderRow.Add("LABLE", reader["U_LABEL"].ToString());
                        ReaderRow.Add("U_ROLE_ALLOWED", reader["U_ROLE_ALLOWED"].ToString());
                        ReaderRow.Add("COL", reader["U_COLUMN"].ToString());
                        ReaderRow.Add("BOLD", reader["U_BOLD"].ToString());
                        reportsNames.Add(ReaderRow);
                    }
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                Logger.WriteLogFile(e);
                //WriteToLogTable.WriteLog(cmd, "Error on ReadTests : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on ReadTests : " + e.Message);
            }
        }
        private void LoadReportsLables()
        {
            ListViewItem li = null;
            for (int i = 0; i < reportsNames.Count(); i++)
            {
                if (reportsNames[i]["U_ROLE_ALLOWED"].Contains(Role) || reportsNames[i]["U_ROLE_ALLOWED"] == "")
                {
                    li = new ListViewItem(reportsNames[i]["LABLE"], 0);
                    if (reportsNames[i]["BOLD"] == "T")
                    {
                        li.Font = new Font(li.Font.FontFamily, 10, FontStyle.Bold);
                    }
                    if (reportsNames[i]["NAME"].Contains("Space"))
                    {
                        li.Font = new Font(li.Font.FontFamily, 10, FontStyle.Bold);
                    }
                    if (reportsNames[i]["COL"] == "A")
                    {
                        listViewA.Items.Add(li);
                    }
                    else
                    {
                        listViewB.Items.Add(li);
                    }
                }
            }
        }
        private void GetReportToGenerate(string lable)
        {
            try
            {
                for (int i = 0; i < reportsNames.Count(); i++)
                {
                    if (reportsNames[i]["LABLE"] == lable)
                    {
                        reportToGenerate = reportsNames[i];
                    }
                }
            }
            catch (Exception e)
            {
                Logger.WriteLogFile(e);
                //WriteToLogTable.WriteLog(cmd, "Error on GetReportToGenerate : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on GetReportToGenerate : " + e.Message);
            }
        }
        private void GetReportParams()
        {
            try
            {
                reportsParams.Clear();
                //sql = "select urp.description Param_Name,urpu.u_param_type type, pe.phrase_description type_des";
                //sql += " from LIMS_SYS.u_report_params urp, LIMS_SYS.u_report_params_user urpu, LIMS_SYS.phrase_header ph, LIMS_SYS.phrase_entry pe";
                //sql += " where urp.u_report_params_id=urpu.u_report_params_id and urpu.u_report_name= '" + reportToGenerate["ID"] + "' and ph.phrase_id=pe.phrase_id";
                //sql += " and ph.name = 'Crystal field Type' and pe.phrase_name = urpu.u_param_type order by urp.name";


                string sql = "select urp.description Param_Name,urpu.u_field_type type, pe.phrase_description type_des from LIMS_SYS.u_report_params urp, LIMS_SYS.u_report_params_user urpu, LIMS_SYS.phrase_header ph, " +
                             "LIMS_SYS.phrase_entry pe where urp.u_report_params_id=urpu.u_report_params_id and urpu.u_report_id= '" + reportToGenerate["ID"] + "' and ph.phrase_id=pe.phrase_id and ph.name = 'Crystal field Type' and pe.phrase_name = urpu.u_field_type order by urp.name";
                cmd.CommandText = sql;
                reader = cmd.ExecuteReader();
                Dictionary<string, string> ReaderRow;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ReaderRow = new Dictionary<string, string>();
                        ReaderRow.Add("PARAM_NAME", reader["PARAM_NAME"].ToString());
                        ReaderRow.Add("TYPE", reader["TYPE"].ToString());
                        ReaderRow.Add("TYPE_DES", reader["TYPE_DES"].ToString());
                        reportsParams.Add(ReaderRow);
                    }
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                Logger.WriteLogFile(e);
                //WriteToLogTable.WriteLog(cmd, "Error on GetReportParams : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on GetReportParams : " + e.Message);
            }
        }
        private void GenerateReport()
        {
            try
            {


                //  string reportPath = reportToGenerate["DESCRIPTION"] + reportToGenerate["NAME"];
                string reportPath = _generalReportPath + reportToGenerate["NAME"];
                string pathId = string.Format("{0:dd_MM_yyyy HH_mm_ss}", DateTime.Now);
                string wortRtfPath = reportPath.Replace(".rpt", pathId + ".rtf");
                //save word & pdf to global folder P:\LimsReports
                wortRtfPath = @"C:\Crystal" + wortRtfPath.Substring(wortRtfPath.LastIndexOf(@"\"));
                string pdfPath = wortRtfPath.Replace("rtf", "pdf");
                var crp = new CrystalReport(ServerName, NautilusUserName, NautilusPassword, reportPath);
                crp.Load();
                crp.Login();
                crp.exportCrystalToWordRTFAndSave(wortRtfPath);
                crp.close();
                crp.exportWordRtfToPdf(wortRtfPath, pdfPath);
                crp.showFile(pdfPath);

                //delete word file
                //crp.deleteFile(wortRtfPath);
                //delete pdf file
                //crp.deleteFile(pdfPath);
            }
            catch (Exception e)
            {
                Logger.WriteLogFile(e);
                //WriteToLogTable.WriteLog(cmd, "Error on GenerateReport : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on GenerateReport : " + e.Message);
            }
        }
        private void GetParamsListValues()
        {
            try
            {

                /*string reportPath = reportToGenerate["DESCRIPTION"] + reportToGenerate["NAME"]*/
                string reportPath = _generalReportPath + reportToGenerate["NAME"];
                ParamListFrm frm = new ParamListFrm(reportPath, reportToGenerate["LABLE"], reportsParams[0]["PARAM_NAME"], cmd, ServerName, NautilusUserName, NautilusPassword);
                frm.Show();
            }
            catch (Exception e)
            {
                Logger.WriteLogFile(e);
                //WriteToLogTable.WriteLog(cmd, "Error on GetParamsValues : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on GetParamsValues : " + e.Message);
            }
        }
        private void GetParamsDateValues()
        {
            try
            {
                string reportPath = _generalReportPath + reportToGenerate["NAME"];
                DatesFrm frm = new DatesFrm(reportPath, reportsParams[0]["PARAM_NAME"], cmd, ServerName, NautilusUserName, NautilusPassword);
                frm.Show();
            }
            catch (Exception e)
            {
                Logger.WriteLogFile(e);
                //WriteToLogTable.WriteLog(cmd, "Error on GetParamsDateValues : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on GetParamsDateValues : " + e.Message);
            }
        }
        private void GetParamsPlate()
        {
            try
            {
                string reportPath = _generalReportPath + reportToGenerate["NAME"];
                PlateFiltersFrm frm = new PlateFiltersFrm(reportPath, reportsParams[0]["PARAM_NAME"], cmd, ServerName, NautilusUserName, NautilusPassword);
                frm.Show();
            }
            catch (Exception e)
            {
                Logger.WriteLogFile(e);
                //WriteToLogTable.WriteLog(cmd, "Error on GetParamsPlate : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on GetParamsPlate : " + e.Message);
            }
        }
        private void GetParamsSample()
        {
            try
            {
                string reportPath = _generalReportPath + reportToGenerate["NAME"];
                SampleFiltersFrm frm = new SampleFiltersFrm(reportPath, reportsParams[0]["PARAM_NAME"], cmd, ServerName, NautilusUserName, NautilusPassword);
                frm.Show();
            }
            catch (Exception e)
            {
                Logger.WriteLogFile(e);
                //WriteToLogTable.WriteLog(cmd, "Error on GetParamsSample : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on GetParamsSample : " + e.Message);
            }
        }
        private void handleSelcetedItem(ListViewItem item)
        {
            try
            {
                GetReportToGenerate(item.Text);
                //-----messagebox for debug
                //path
                // MessageBox.Show(reportToGenerate["DESCRIPTION"] + reportToGenerate["NAME"]);
                //rpt ID 
                //MessageBox.Show( "rpt Id" + reportToGenerate["ID"]);
                //--end debug
                GetReportParams();
                if (reportsParams.Count() == 0) //no params for report
                {
                    GenerateReport();
                }
                //get param values and generate report
                else if (reportsParams[0]["TYPE"] == "L")// samples names list
                {
                    GetParamsListValues();
                }
                else if (reportsParams[0]["TYPE"] == "D")//  between dates
                {
                    GetParamsDateValues();
                }
                else if (reportsParams[0]["TYPE"] == "E")//  Sample filters/plate filters
                {
                    if (reportsParams[0]["PARAM_NAME"].Contains("Plate"))
                    {
                        GetParamsPlate();
                    }
                    else if (reportsParams[0]["PARAM_NAME"].Contains("Sample"))
                    {
                        GetParamsSample();
                    }
                }
            }
            catch (Exception e)
            {
                Logger.WriteLogFile(e);

                //WriteToLogTable.WriteLog(cmd, "Error on handleSelcetedItem : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on handleSelcetedItem : " + e.Message);
            }
        }
        #endregion

        #region Events methods
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //WriteToLogTable.WriteLog(cmd, " בלחיצת כפתור הפעל call handleSelcetedItem", "GenerateReportExt", "btnOK_Click", "OK");

                foreach (ListViewItem Aitem in listViewA.SelectedItems)
                {
                    handleSelcetedItem(Aitem);
                }
                foreach (ListViewItem Bitem in listViewB.SelectedItems)
                {
                    handleSelcetedItem(Bitem);
                }
            }
            catch (Exception e1)
            {
                Logger.WriteLogFile(e1);
                //WriteToLogTable.WriteLog(cmd, "Error on btnOK_Click : " + e1.Message, e1.Source, e1.TargetSite.Name, "Error");
                MessageBox.Show("Error on btnOK_Click : " + e1.Message);
            }
        }
        private void listViewA_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewA.SelectedItems)
            {
                //deSelect title item
                if (item.Font.Bold == true)
                {
                    item.Selected = false;
                }
            }
            foreach (ListViewItem Bitem in listViewB.SelectedItems)
            {
                //deSelect listViewB item
                Bitem.Selected = false;
            }
        }
        private void listViewB_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewB.SelectedItems)
            {
                //deSelect title item
                if (item.Font.Bold == true)
                {
                    item.Selected = false;
                }
            }
            foreach (ListViewItem Aitem in listViewA.SelectedItems)
            {
                //deSelect listViewA item
                Aitem.Selected = false;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("האם אתה בטוח שברצונך לצאת ממסך זה ?", "Close", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //WriteToLogTable.WriteLog(cmd, "clear reports listView and call _ntlsSite.CloseWindow();", "GenerateReportExt", "btnClose_Click", "OK");
                listViewA = null;
                listViewB = null;
                _ntlsSite.CloseWindow();
            }
        }
        private void listView_DoubleClick(object sender, EventArgs e)
        {
            ListView currListView = (ListView)sender;
            foreach (ListViewItem item in currListView.SelectedItems)
            {
                btnOK_Click(null, null);
            }
        }
        public string GetPhraseEntry(string phraseHeaderName, string phraseEntryName)
        {
            try
            {


                string sql = "select phrase_description from lims_sys.phrase_entry where phrase_id in" +
                            "(select phrase_id from lims_sys.phrase_header  where name ='" + phraseHeaderName + "') and phrase_name='" + phraseEntryName + "'";
                cmd.CommandText = sql;
                var path = cmd.ExecuteScalar();
                cmd.Dispose();
                if (path != null)
                {
                    return path.ToString();
                }
            }
            catch (Exception e)
            {
                //WriteToLogTable.WriteLog(cmd, "Error on GetPhraseEntry : " + e.Message, e.Source, e.TargetSite.Name, "Error");
                MessageBox.Show("Error on GetPhraseEntry : " + e.Message);
                Logger.WriteLogFile(e);
            }
            return null;
        }
        #endregion

        private void GenerateReportCtrl_Resize(object sender, EventArgs e)
        {

        }
    }
}
