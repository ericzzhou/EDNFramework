using DotNet.Framework.DataAccess.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDNF.DataAccess.Test.Entity
{
    public class Entity_SYS_ErrorLog
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

        [DataMapping("test")]
        public string Test { get; set; }

        public int testNoAttr { get; set; }

        [DataMapping("testInt")]
        public int testInt { get; set; }
        [DataMapping("testInt2")]
        public int? testInt2 { get; set; }
    }
}
