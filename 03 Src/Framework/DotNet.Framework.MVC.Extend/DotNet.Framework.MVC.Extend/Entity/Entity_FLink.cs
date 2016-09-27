using DotNet.Framework.DataAccess.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.MVC.Extend.Entity
{
    [Serializable]
    public class Entity_FLink
    {
        [DataMapping("ID")]
        public Int32 ID { get; set; }

        [DataMapping("Name")]
        public String Name { get; set; }

        [DataMapping("ImgUrl")]
        public String ImgUrl { get; set; }

        [DataMapping("LinkUrl")]
        public String LinkUrl { get; set; }

        [DataMapping("LinkDesc")]
        public String LinkDesc { get; set; }

        [DataMapping("State")]
        public Boolean State { get; set; }

        [DataMapping("OrderID")]
        public Int32 OrderID { get; set; }

        [DataMapping("ContactPerson")]
        public String ContactPerson { get; set; }

        [DataMapping("Email")]
        public String Email { get; set; }

        [DataMapping("TelPhone")]
        public String TelPhone { get; set; }

        [DataMapping("TypeID")]
        public Int16 TypeID { get; set; }

        [DataMapping("IsDisplay")]
        public Boolean IsDisplay { get; set; }

        [DataMapping("ImgWidth")]
        public Int32 ImgWidth { get; set; }

        [DataMapping("ImgHeight")]
        public Int32 ImgHeight { get; set; }
    }
}
