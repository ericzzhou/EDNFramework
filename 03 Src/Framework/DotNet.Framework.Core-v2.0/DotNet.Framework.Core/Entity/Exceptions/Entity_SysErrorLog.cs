using DotNet.Framework.DataAccess;
using DotNet.Framework.DataAccess.Attribute;
using System;

namespace DotNet.Framework.Core.Entity.Exceptions
{
    public class Entity_SysErrorLog
    {
        [DataMapping("ID")]
        public int ID { get; set; }

        [DataMapping("OPTime")]
        public DateTime OPTime { get; set; }

        [DataMapping("Url")]
        public string Url { get; set; }

        [DataMapping("Loginfo")]
        public string Loginfo { get; set; }

        [DataMapping("StackTrace")]
        public string StackTrace { get; set; }

        [DataMapping("ErrorType")]
        public string ErrorType { get; set; }

        [DataMapping("Domain")]
        public string Domain { get; set; }

        public static bool InsertLog(Entity_SysErrorLog entity)
        {
            string sqlString = @"
INSERT INTO [EDNF_SYS_ErrorLog]
           ([OPTime]
           ,[Url]
           ,[Loginfo]
           ,[StackTrace]
           ,[ErrorType]
           ,[Domain])
     VALUES
           (@OPTime
           ,@Url
           ,@Loginfo
           ,@StackTrace
           ,@ErrorType
           ,@Domain)
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@OPTime", entity.OPTime);
            cmd.SetParamter("@Url", entity.Url);
            cmd.SetParamter("@Loginfo", entity.Loginfo);
            cmd.SetParamter("@StackTrace", entity.StackTrace);
            cmd.SetParamter("@ErrorType", entity.ErrorType);
            cmd.SetParamter("@Domain", entity.Domain);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
