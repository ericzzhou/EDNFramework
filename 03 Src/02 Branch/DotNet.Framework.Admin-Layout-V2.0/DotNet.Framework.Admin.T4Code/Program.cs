using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.T4Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("text");


            string connectionString = "Data Source=localhost;Initial Catalog=EDNFramework;User ID=sa;pwd=as";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            System.Data.DataTable schema = conn.GetSchema("TABLES");
            string selectQuery = "select * from @tableName";
            SqlCommand command = new SqlCommand(selectQuery, conn);
            SqlDataAdapter ad = new SqlDataAdapter(command);
            System.Data.DataSet ds = new DataSet();

            foreach (System.Data.DataRow row in schema.Rows)
            {
                ds.Tables.Clear();
                command.CommandText = selectQuery.Replace("@tableName", row["TABLE_NAME"].ToString());
                ad.FillSchema(ds, SchemaType.Mapped, row["TABLE_NAME"].ToString());
            }
            Console.ReadKey();
        }
    }
}
