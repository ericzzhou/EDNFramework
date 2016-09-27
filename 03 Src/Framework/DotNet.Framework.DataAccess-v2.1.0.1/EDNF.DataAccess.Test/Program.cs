using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DotNet.Framework.DataAccess;
using EDNF.DataAccess.Test.Entity;
using System.Diagnostics;
namespace EDNF.DataAccess.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //DotNet.Framework.DataAccess
            Stopwatch swt = new Stopwatch();
            swt.Start();
            for (int i = 0; i < 1000; i++)
            {
                Stopwatch swReaer = new Stopwatch();
                swReaer.Start();
                RunReader();
                swReaer.Stop();

                Stopwatch swDataSet = new Stopwatch();
                swDataSet.Start();
                RunDatSet();
                swDataSet.Stop();


                Console.WriteLine("========第{0}次:{1}毫秒-Reader", i + 1, swReaer.ElapsedMilliseconds);
                Console.WriteLine("========第{0}次:{1}毫秒-DataSet", i + 1, swDataSet.ElapsedMilliseconds);
            }
            swt.Stop();
            Console.WriteLine("总时间:{0}毫秒", swt.ElapsedMilliseconds);
            Console.ReadKey();
        }

        private static void RunDatSet()
        {
            Command cmd = CommandManager.CreateCommand("SELECT * FROM EDNF_SYS_ErrorLog WITH(NOLOCK)");
            IList<Entity_SYS_ErrorLog> list = cmd.ExecuteEntities<Entity_SYS_ErrorLog>();
            //            Command cmd = CommandManager.CreateCommand("SELECT TOP 1 * FROM [EDNF_SYS_ConfigContent] ");
            //            Entity_ConfigContent entity = cmd.ExecuteEntity<Entity.Entity_ConfigContent>();
            //            //Entity_ConfigContent entity = cmd.ExecuteEntityByDataReader<Entity.Entity_ConfigContent>();
            //            Console.WriteLine(entity.ID);
            //            Console.WriteLine(entity.Keyname);
            //            Console.WriteLine(entity.Value);


            //            //cmd = CommandManager.CreateCommand("SELECT * FROM [EDNF_SYS_ConfigContent] WHERE KeyType = @KeyType ");
            //            cmd = CommandManager.CreateCommand("SELECT * FROM [EDNF_SYS_ConfigContent]");
            //            cmd.SetParamter("@KeyType", -2);
            //            //IList<Entity_ConfigContent> list = cmd.ExecuteEntitiesByDataReader<Entity_ConfigContent>();
            //            IList<Entity_ConfigContent> list = cmd.ExecuteEntities<Entity_ConfigContent>();

            //            cmd = CommandManager.CreateCommand(@"
            //SELECT @TOTAL = COUNT(*) FROM [EDNF_SYS_ConfigContent]
            //SELECT TOP 1 @TOPVALUE = [Keyname] FROM [EDNF_SYS_ConfigContent]
            //SELECT * FROM [EDNF_SYS_ConfigContent]  WHERE KeyType = @KeyType #StrWhere#");
            //            cmd.SetParamter("@KeyType", -2);
            //            cmd.SetOutParameter("@TOTAL", System.Data.DbType.Int32, null);
            //            cmd.SetOutParameter("@TOPVALUE", System.Data.DbType.String, 200);
            //            cmd.SetReplaceParamter("#StrWhere#", " AND 1=1 AND 'A'='A'");
            //            //list = cmd.ExecuteEntitiesByDataReader<Entity_ConfigContent>();
            //            list = cmd.ExecuteEntities<Entity_ConfigContent>();
            //            int total = cmd.GetOutParameter<Int32>("@TOTAL");
            //            string topValue = cmd.GetOutParameter<string>("@TOPVALUE");
        }

        private static void RunReader()
        {
            Command cmd = CommandManager.CreateCommand("SELECT * FROM EDNF_SYS_ErrorLog");
            IList<Entity_SYS_ErrorLog> list = cmd.ExecuteEntitiesByDataReader<Entity_SYS_ErrorLog>();
            Console.WriteLine(list.Count);
//            Command cmd = CommandManager.CreateCommand("SELECT TOP 1 * FROM [EDNF_SYS_ConfigContent] ");
//            //Entity_ConfigContent entity = cmd.ExecuteEntity<Entity.Entity_ConfigContent>();
//            Entity_ConfigContent entity = cmd.ExecuteEntityByDataReader<Entity.Entity_ConfigContent>();
//            Console.WriteLine(entity.ID);
//            Console.WriteLine(entity.Keyname);
//            Console.WriteLine(entity.Value);


//            //cmd = CommandManager.CreateCommand("SELECT * FROM [EDNF_SYS_ConfigContent] WHERE KeyType = @KeyType ");
//            cmd = CommandManager.CreateCommand("SELECT * FROM [EDNF_SYS_ConfigContent]");
//            cmd.SetParamter("@KeyType", -2);
//            IList<Entity_ConfigContent> list = cmd.ExecuteEntitiesByDataReader<Entity_ConfigContent>();

//            cmd = CommandManager.CreateCommand(@"
//SELECT @TOTAL = COUNT(*) FROM [EDNF_SYS_ConfigContent]
//SELECT TOP 1 @TOPVALUE = [Keyname] FROM [EDNF_SYS_ConfigContent]
//SELECT * FROM [EDNF_SYS_ConfigContent]  WHERE KeyType = @KeyType #StrWhere#");
//            cmd.SetParamter("@KeyType", -2);
//            cmd.SetOutParameter("@TOTAL", System.Data.DbType.Int32, null);
//            cmd.SetOutParameter("@TOPVALUE", System.Data.DbType.String, 200);
//            cmd.SetReplaceParamter("#StrWhere#", " AND 1=1 AND 'A'='A'");
//            list = cmd.ExecuteEntitiesByDataReader<Entity_ConfigContent>();
//            int total = cmd.GetOutParameter<Int32>("@TOTAL");
//            string topValue = cmd.GetOutParameter<string>("@TOPVALUE");
        }
    }
}

