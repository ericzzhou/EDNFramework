
using DotNet.Framework.DataAccess.Attribute;
using System;
namespace DotNet.Framework.Admin.Entity.EDNFramework_Account
{
    public class Entity_Permission
    {
        [DataMapping("ID")]
        public int ID { get; set; }

        [DataMapping("ParentID")]
        public int ParentID { get; set; }

        [DataMapping("CategoryID")]
        public int CategoryID { get; set; }

        [DataMapping("PermissionCode")]
        public string PermissionCode { get; set; }

        [DataMapping("PermissionName")]
        public string PermissionName { get; set; }

        [DataMapping("Description")]
        public string Description { get; set; }

        [DataMapping("Sequence")]
        public int Sequence { get; set; }

        [DataMapping("CreateDate")]
        public DateTime CreateDate { get; set; }

        [DataMapping("RequestUrl")]
        public string RequestUrl { get; set; }
    }

    public class Entity_Permission_Full
    {
        [DataMapping("ID")]
        public int ID { get; set; }

        [DataMapping("ParentID")]
        public int ParentID { get; set; }

        [DataMapping("ParentName")]
        public string ParentName { get; set; }

        [DataMapping("CategoryID")]
        public int CategoryID { get; set; }

        [DataMapping("PermissionCode")]
        public string PermissionCode { get; set; }

        [DataMapping("PermissionName")]
        public string PermissionName { get; set; }

        [DataMapping("Description")]
        public string Description { get; set; }

        [DataMapping("Sequence")]
        public int Sequence { get; set; }

        [DataMapping("CreateDate")]
        public DateTime CreateDate { get; set; }

        [DataMapping("RequestUrl")]
        public string RequestUrl { get; set; }
    }
}
