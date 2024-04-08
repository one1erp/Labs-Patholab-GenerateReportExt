using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace GenerateReportExt
{
    internal class Common
    {


        public static string workStationName;



        public static string GetPathFromPhrase(string phraseHeaderName, string phraseEntryName, OracleCommand cmd)
        {
            string sql = "select phrase_description from lims_sys.phrase_entry where phrase_id in" +
                         "(select phrase_id from lims_sys.phrase_header  where name ='" + phraseHeaderName +
                         "') and phrase_name='" + phraseEntryName + "'";
            cmd.CommandText = sql;
            var path = cmd.ExecuteScalar();
            cmd.Dispose();
            if (path != null)
            {
                return path.ToString();
            }
            return null;
        }

        public static string CreateSavedPath(string rptPath, OracleCommand CMD)
        {

            string pathId = string.Format("{0:dd_MM_yyyy HH_mm_ss}", DateTime.Now);
            pathId = workStationName + "_" + pathId;
            string wordPath = rptPath.Replace(".rpt", pathId + ".rtf");
            string startPath = GetPathFromPhrase("Lims System Paths", "Reports", CMD);
            string endPath = wordPath.Substring(wordPath.LastIndexOf(@"\") + 1);
            var fullPath = startPath + endPath;
            return fullPath;
        }

        internal static void SetWorkStationName(LSSERVICEPROVIDERLib.INautilusUser _nu)
        {
            workStationName = _nu.GetWorkstationName();
        }


    }


 
}
