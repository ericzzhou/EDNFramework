using DotNet.Framework.DataAccess.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.Entity.Hospital
{
    public class Entity_Hospital_NormCategoryTree
    {
        [DataMapping("ID")]
        public int id { get; set; }

        [DataMapping("ParentID")]
        public int pid { get; set; }

        [DataMapping("CategoryName")]
        public string name { get; set; }

        public bool open { get; set; }

        [DataMapping("CategoryCode")]
        public string file { get; set; }

        public Entity_Hospital_NormCategoryTree()
        {
            this.open = false;
        }
    }

    public class Entity_Hospital_NormCategory
    {
        [DataMapping("ID")]
        public int ID { get; set; }

        [DataMapping("CategoryName")]
        public string CategoryName { get; set; }

        [DataMapping("CategoryCode")]
        public string CategoryCode { get; set; }

        [DataMapping("ParentID")]
        public int? ParentID { get; set; }

        [DataMapping("ParentName")]
        public string ParentName { get; set; }

        [DataMapping("Deleted")]
        public string Deleted { get; set; }

       
    }
}
