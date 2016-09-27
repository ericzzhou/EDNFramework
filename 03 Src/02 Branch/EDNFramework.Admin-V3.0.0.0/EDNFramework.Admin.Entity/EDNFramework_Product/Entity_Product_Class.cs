using DotNet.Framework.DataAccess.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.Entity.EDNFramework_Product
{
    public class Entity_Product_Class_Edit
    {
        [DataMapping("ParentId")]
        public int ParentId { get; set; }

         [DataMapping("ClassID")]
        public int ClassID { get; set; }

        [DataMapping("ClassName")]
        public string ClassName { get; set; }

        [DataMapping("Sequence")]
        public int Sequence { get; set; }

        [DataMapping("Activity")]
        public bool Activity { get; set; }

        [DataMapping("AllowAddContent")]
        public bool AllowAddContent { get; set; }

        [DataMapping("Description")]
        public string Description { get; set; }

        [DataMapping("Domain")]
        public string Domain { get; set; }
    }
    public class Entity_Product_Class_Add
    {
        [DataMapping("ParentId")]
        public int ParentId { get; set; }

        [DataMapping("ClassName")]
        public string ClassName { get; set; }

        [DataMapping("Sequence")]
        public int Sequence { get; set; }

        [DataMapping("Activity")]
        public bool Activity { get; set; }

        [DataMapping("AllowAddContent")]
        public bool AllowAddContent { get; set; }

        [DataMapping("Description")]
        public string Description { get; set; }

        [DataMapping("Domain")]
        public string Domain { get; set; }
    }
    public class Entity_Product_Class
    {
    }
    public class Entity_Product_Class_Dropdownlist
    {
        [DataMapping("ClassID")]
        public int ClassID { get; set; }

        [DataMapping("ClassName")]
        public string ClassName { get; set; }

        [DataMapping("Domain")]
        public string Domain { get; set; }
    }
    public class Entity_Product_Class_PagerGrid
    {
        [DataMapping("ClassID")]
        public int ClassID { get; set; }

        [DataMapping("ClassName")]
        public string ClassName { get; set; }

        [DataMapping("ParentName")]
        public string ParentName { get; set; }

        [DataMapping("Sequence")]
        public int Sequence { get; set; }

        [DataMapping("Activity")]
        public string Activity { get; set; }

        [DataMapping("AllowAddContent")]
        public string AllowAddContent { get; set; }

        [DataMapping("ImageUrl")]
        public string ImageUrl { get; set; }

        [DataMapping("Description")]
        public string Description { get; set; }

        [DataMapping("Keywords")]
        public string Keywords { get; set; }
    }
}
