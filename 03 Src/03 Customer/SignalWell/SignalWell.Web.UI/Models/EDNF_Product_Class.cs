using DotNet.Framework.DataAccess.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalWell.Web.UI.Models
{
    public class EDNF_Product_Class
    {
        [DataMapping("ParentId")]
        public int? ParentId { get; set; }

        [DataMapping("ClassID")]
        public int ClassID { get; set; }

        [DataMapping("ClassName")]
        public string ClassName { get; set; }

        [DataMapping("Sequence")]
        public int Sequence { get; set; }
    }
}