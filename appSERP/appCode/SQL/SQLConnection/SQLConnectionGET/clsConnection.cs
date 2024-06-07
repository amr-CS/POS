using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.SQL.SQLConnection.SQLConnectionGET
{
    public class clsConnection
    {
        public static string vAppConnectionLocal = @"\appCode\SQL\SQLConnection\SQLConnectionFiles\appConnLocal.txt";
        public static string vAppConnectionOnline = @"\appCode\SQL\SQLConnection\SQLConnectionFiles\appConnOnline.txt";


        // Connection
        public static SqlConnection vSQLConnection;

        // Connection Parameters
        public static string vServerIP;
        public static string vDBName;
        public static bool vIntegratedSecurity;
        public static string vUserId;
        public static string vPassword;


        // SYS CONNECTION
        public static void funGetSQLConnection()
        {
            try
            {
              string s=  HttpRuntime.AppDomainAppPath;
                //// Connection String
                //string[] vConnectionStr = System.IO.File.ReadAllLines(HttpRuntime.AppDomainAppPath + funCheckRequestIsLocal());
                //// Check If NOT NULL
                //if (vConnectionStr != null)
                //{
                //    // Get Data
                //    vServerIP = vConnectionStr[0];
                //    vDBName = vConnectionStr[1];
                //    vIntegratedSecurity = bool.Parse(vConnectionStr[2]);
                //    vUserId = vConnectionStr[3];
                //    vPassword = vConnectionStr[4];
                //    // Connection String
                //    string vConnectionString = "Server=" + vServerIP + ";Database=" + vDBName + (vIntegratedSecurity == true ? "; Integrated Security=True;" : " ; User Id=" + vUserId + "; password= " + vPassword) + " ; Connection Timeout=60";
                //    // SQL Connection
                //    string connectionStr = ConfigurationManager
                //.ConnectionStrings["dbERPConnectionString"].ConnectionString;
                //    vSQLConnection = new SqlConnection(connectionStr);
                //}

                string connectionStr = ConfigurationManager
            .ConnectionStrings["dbERPConnectionString"].ConnectionString;
                vSQLConnection = new SqlConnection(connectionStr);
            }
            catch (Exception ex)
            {

            }
        }

        // Check Online and Offline Request Status
        public static string funCheckRequestIsLocal()
        {
            // Local
            bool vIsLocal = HttpContext.Current.Request.IsLocal;

            if (vIsLocal)
            {
                return vAppConnectionLocal;
            }
            else
            {
                return vAppConnectionLocal;
            }
        }
    }
}