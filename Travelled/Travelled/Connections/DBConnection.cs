using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Linq;
using System.Web;

namespace Travelled.Connections
{
    public class DBConnection
    {
        static string RDS_DB_NAME  = "database1";
        static string RDS_USERNAME = "admin";
        static string RDS_PASSWORD = "Dade_02201";
        static string RDS_HOSTNAME = "database1.ch9njb977wgk.us-east-2.rds.amazonaws.com";
        static string RDS_PORT = "3306";

        public static string getConnection()
        {
            var appConfig = ConfigurationManager.AppSettings;

            string dbname = appConfig[RDS_DB_NAME];

            if (string.IsNullOrEmpty(dbname)) return null;

            string username = appConfig[RDS_USERNAME];
            string password = appConfig[RDS_PASSWORD];
            string hostname = appConfig[RDS_HOSTNAME];
            string port = appConfig[RDS_PORT];

            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
        }
    }

}
