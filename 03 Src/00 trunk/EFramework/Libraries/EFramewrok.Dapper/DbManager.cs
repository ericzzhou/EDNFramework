using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EFramewrok.Dapper
{
    public class DbManager
    {
        static string _connectionString = string.Empty;
        private DbManager() { }
        static DbManager()
        {
            var conn = ConfigurationManager.ConnectionStrings["EFrameworkConnectionString"];//从 config 文件中读取 connectionString
            if (conn != null)
            {
                _connectionString = conn.ToString();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbType">SqlServer/MySql/Oracle</param>
        /// <returns></returns>
        public static IDbConnection Create(string connectionString = "", string dbType = "SqlServer")
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                connectionString = _connectionString;
            }
            IDbConnection conn;
            switch (dbType)
            {
                case "SqlServer":
                    conn = new SqlConnection();
                    break;
                default:
                    conn = new SqlConnection();
                    break;
            }
            conn.ConnectionString = connectionString;
            return conn;
        }
    }
}
