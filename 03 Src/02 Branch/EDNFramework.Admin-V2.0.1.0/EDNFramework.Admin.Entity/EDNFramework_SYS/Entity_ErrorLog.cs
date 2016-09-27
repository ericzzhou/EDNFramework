using DotNet.Framework.DataAccess.Attribute;
using System;

namespace DotNet.Framework.Admin.Entity.EDNFramework_SYS
{
    public class Entity_ErrorLog
    {
        [DataMapping("ID")]
        public int ID { get; set; }

        [DataMapping("OPTime")]
        public string OPTime { get; set; }

        [DataMapping("Url")]
        public string Url { get; set; }

        [DataMapping("Loginfo")]
        public string Loginfo { get; set; }

        [DataMapping("ErrorType")]
        public string ErrorType { get; set; }

        [DataMapping("Domain")]
        public string Domain { get; set; }

        [DataMapping("StackTrace")]
        public string StackTrace { get; set; }
    }
}
