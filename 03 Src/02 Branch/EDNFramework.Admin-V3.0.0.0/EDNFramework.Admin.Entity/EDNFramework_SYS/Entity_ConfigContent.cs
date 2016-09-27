using DotNet.Framework.DataAccess.Attribute;
using System;

namespace DotNet.Framework.Admin.Entity.EDNFramework_SYS
{
    [Serializable]
    public class Entity_ConfigContent
    {
        [DataMapping("ID")]
        public int ID { get; set; }

        [DataMapping("Keyname")]
        public string Keyname { get; set; }

        [DataMapping("Value")]
        public string Value { get; set; }

        [DataMapping("KeyType")]
        public int KeyType { get; set; }

        [DataMapping("Description")]
        public string Description { get; set; }
    }
}
