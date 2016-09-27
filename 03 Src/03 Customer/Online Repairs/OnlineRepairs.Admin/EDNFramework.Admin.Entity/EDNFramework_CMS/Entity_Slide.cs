using DotNet.Framework.DataAccess.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.Entity.EDNFramework_CMS
{
    [Serializable]
    public class Entity_Slide
    {
        [DataMapping("ID")]
        public Int32 ID { get; set; }

        [DataMapping("Name")]
        public String Name { get; set; }

        [DataMapping("delay")]
        public int delay { get; set; }

        [DataMapping("Width")]
        public Decimal Width { get; set; }

        [DataMapping("Height")]
        public Decimal Height { get; set; }

        [DataMapping("ItemCount")]
        public int ItemCount { get; set; }

        [DataMapping("EnableCount")]
        public int EnableCount { get; set; }

        [DataMapping("ItemType")]
        public String ItemType { get; set; }
        
    }

    [Serializable]
    public class Entity_Slide_Item
    {
        [DataMapping("ID")]
        public Int32 ID { get; set; }

        [DataMapping("SlideID")]
        public Int32 SlideID { get; set; }

        [DataMapping("Name")]
        public String Name { get; set; }

        [DataMapping("Description")]
        public String Description { get; set; }

        [DataMapping("Href")]
        public String Href { get; set; }

        [DataMapping("FilePath")]
        public String FilePath { get; set; }

        [DataMapping("Enable")]
        public Boolean Enable { get; set; }

        [DataMapping("sequence")]
        public Int32 sequence { get; set; }

        [DataMapping("GroupName")]
        public String GroupName { get; set; }

    }  
}
