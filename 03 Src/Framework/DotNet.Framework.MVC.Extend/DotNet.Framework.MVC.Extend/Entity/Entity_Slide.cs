using DotNet.Framework.DataAccess.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.MVC.Extend.Entity
{
    [Serializable]
    public class Entity_Slide
    {
        [DataMapping("ID")]
        public int ID { get; set; }
        [DataMapping("Height")]
        public int Height { get; set; }
        [DataMapping("Width")]
        public int Width { get; set; }
        [DataMapping("Description")]
        public string Description { get; set; }
        [DataMapping("FilePath")]
        public string FilePath { get; set; }
        [DataMapping("Href")]
        public string Href { get; set; }
        [DataMapping("ItemType")]
        public string ItemType { get; set; }
        [DataMapping("Name")]
        public string Name { get; set; }
        [DataMapping("sequence")]
        public int sequence { get; set; }
        [DataMapping("delay")]
        public int delay { get; set; }

    }
}
