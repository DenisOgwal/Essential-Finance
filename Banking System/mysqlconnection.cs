using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace Banking_System
{
    public partial class mysqlconnection
    {

        public string MysqlDBConn = ConfigurationManager.ConnectionStrings["Mysql_DBConnectionString"].ConnectionString;
    }
}
