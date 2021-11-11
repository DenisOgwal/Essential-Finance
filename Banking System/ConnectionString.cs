using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Banking_System
{
    class ConnectionString
    {
        public static string userconnection = Properties.Settings.Default.realcon;
        public string DBConn = userconnection;
        // public static string userName = "Denia";
        //public static string userName = Environment.UserName;
        //public static string filePath1 = @"C:\\Users\" + userName + "\\My Documents\\Dither Technologies\\MoneyLender";
        //public static string connectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + filePath1 + "\\BS.mdf;Integrated Security=True;Connect Timeout=60";
        //public string DBConn = connectionString;
        //public static string connectionString = "Data Source=SERVER\\SQLEXPRESS,1433;Initial Catalog=BS;User ID=sa;Password=jesus@lord1";
        //public static string connectionString = "Data Source=DENIS\\SQLEXPRESS;Initial Catalog=BS;User ID=sa;Password=jesus@lord1";
        //public static string connectionString = "Data Source=DESKTOP-PJ3PMQR\\SQLEXPRESS;Initial Catalog=BS;User ID=sa;Password=jesus@lord1";
        //public string DBConn = connectionString;

        //public static string connectionString = "Data Source=DENIS\\SQLEXPRESS;Initial Catalog=MoneyLender;User ID=sa;Password=jesus@lord1";
        //public string DBConn = connectionString;
        //public string DBConn = ConfigurationManager.ConnectionStrings["CMS_DBConnectionString"].ConnectionString;
        //public string DBConn = ConfigurationManager.ConnectionStrings["CMS_DBConnectionString"].ConnectionString;
        public string MysqlDBConn = "Server=localhost;Database=bs;Uid=root;Password=''";
        public string branchname = ConfigurationManager.AppSettings.Get("branches");
        
    }
}
