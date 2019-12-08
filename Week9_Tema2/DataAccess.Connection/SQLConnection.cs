using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess.Connection
{
    public class DBConnection
    {
        private DBConnection() { }
        private static SqlConnection conn = null;

        public static SqlConnection GetConnection()
        {
            if (conn == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
                conn = new SqlConnection(connectionString);
                conn.Open();
            }
            return conn;
        }

    }
}
