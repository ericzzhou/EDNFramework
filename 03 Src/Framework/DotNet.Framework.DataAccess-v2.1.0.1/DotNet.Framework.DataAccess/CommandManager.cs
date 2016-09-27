using System.Configuration;

namespace DotNet.Framework.DataAccess
{
    public class CommandManager
    {
        public static Command CreateCommand(string sqlString)
        {
            Connection conn = new Connection();
            string connString = ConfigurationManager.AppSettings["EDNFrameworkConnectionString"];//从 config 文件中读取 connectionString

            conn.ConnectionString = connString;
            conn.SqlString = sqlString;
            return new Command(conn);
        }

        public static Command CreateCommand(string connectionString, string sqlString)
        {
            Connection conn = new Connection();
            conn.ConnectionString = connectionString;
            conn.SqlString = sqlString;
            return new Command(conn);
        }
    }
}
