using DotNet.Framework.DataAccess.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.Entity.Hospital
{
    public class Entity_Hospital_NormItem
    {

        [DataMapping("ID")]
        public int ID { get; set; }

        [DataMapping("ItemCode")]
        public string ItemCode { get; set; }

        [DataMapping("ItremName")]
        public string ItremName { get; set; }

        [DataMapping("ItemCategory")]
        public int ItemCategory { get; set; }

        [DataMapping("ItemCategoryName")]
        public string ItemCategoryName { get; set; }

        [DataMapping("ItemCreateTime")]
        public string ItemCreateTime { get; set; }

        [DataMapping("ItemStopTime")]
        public string ItemStopTime { get; set; }

        [DataMapping("ItemStatus")]
        public string ItemStatus { get; set; }
    }
}
