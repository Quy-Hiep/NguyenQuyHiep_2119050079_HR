using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class DBConnection
    {
        public DBConnection() { }

        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=HIEP\SQLEXPRESS;
                                    Initial Catalog=HR; User Id = sa; Password = sa";

            return conn;
        }
    }
}
