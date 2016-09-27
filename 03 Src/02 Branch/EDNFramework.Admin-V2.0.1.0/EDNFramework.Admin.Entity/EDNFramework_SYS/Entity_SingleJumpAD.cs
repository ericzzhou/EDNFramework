using DotNet.Framework.DataAccess.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.Entity.EDNFramework_SYS
{
    public class Entity_SingleJumpAD
    {
        [DataMapping("ID")]
        public Int32 ID { get; set; }

        [DataMapping("Name")]
        public String Name { get; set; }

        [DataMapping("Width")]
        public Int32 Width { get; set; }

        [DataMapping("Height")]
        public Int32 Height { get; set; }

        [DataMapping("Enable")]
        public Boolean Enable { get; set; }

        [DataMapping("ContentType")]
        public String ContentType { get; set; }

        [DataMapping("Content")]
        public String Content { get; set; }
    }
}
