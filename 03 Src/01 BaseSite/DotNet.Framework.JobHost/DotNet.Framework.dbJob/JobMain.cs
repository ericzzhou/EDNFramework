using DotNet.Framework.DataAccess;
using DotNet.Framework.JobInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.dbJob
{
    public class JobMain : IJob
    {
        public void Run(JobContext context)
        {
            string sql = @"
INSERT INTO [EDNF_SYS_Log]
           ([datetime]
           ,[loginfo]
           ,[Particular])
     VALUES
           (GETDATE()
           ,'Job Test'
           ,@Particular)
";

            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@Particular", DateTime.Now.ToString("F"));
            cmd.ExecuteNonQuery();
        }


        public void Stop(JobContext context)
        {
            throw new NotImplementedException();
        }


        public void Pause(JobContext context)
        {
            throw new NotImplementedException();
        }

        public void Continue(JobContext context)
        {
            throw new NotImplementedException();
        }
    }
}
