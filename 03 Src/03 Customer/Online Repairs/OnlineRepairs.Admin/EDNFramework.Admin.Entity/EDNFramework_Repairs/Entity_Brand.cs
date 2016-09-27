using DotNet.Framework.DataAccess.Attribute;
using System;

namespace DotNet.Framework.Admin.Entity.EDNFramework_Repairs
{
    [Serializable]
    public class Entity_Brand
    {
        [DataMapping("ID")]
        public Int32 ID { get; set; }

        [DataMapping("Name")]
        public String Name { get; set; }

        [DataMapping("Descriptino")]
        public String Descriptino { get; set; }
    }
}
