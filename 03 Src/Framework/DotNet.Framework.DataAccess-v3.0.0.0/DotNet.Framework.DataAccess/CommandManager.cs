using System.Configuration;
using System.Collections.Generic;
namespace DotNet.Framework.DataAccess
{
    using DataCommandHashtable = Dictionary<string, Command>;
    public class CommandManager
    {
        static string connectionString = ConfigurationManager.AppSettings["EDNFrameworkConnectionString"];//从 config 文件中读取 connectionString
        public CommandManager()
        {
        }

        public static Command CreateCommand(string sqlString)
        {
            Connection conn = new Connection();
            conn.ConnectionString = connectionString;
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

        //public static Command GetDataCommand(string name)
        //{
        //    Connection conn = new Connection();
        //    conn.ConnectionString = connectionString;
        //    return null;
        //}
    }
}
