using DotNet.Framework.DataAccess.Attribute;
using System;
using System.Collections.Generic;

namespace DotNet.Framework.Admin.Entity.EDNFramework_Account
{
    [Serializable]
    public class Entity_RolePermissionAction_Table
    {
        [DataMapping("Checked")]
        public bool Checked { get; set; }

        [DataMapping("PermissionName")]
        public string PermissionName { get; set; }

        [DataMapping("PermissionCode")]
        public string PermissionCode { get; set; }

        [DataMapping("ARPID")]
        public Guid? ARPID { get; set; }

        [DataMapping("ParentID")]
        public int ParentID { get; set; }

        [DataMapping("ID")]
        public int ID { get; set; }

        public IList<Entity_PermissionAction> Actions { get; set; }
        public IList<Entity_RolePermissionsAction> RightActions { get; set; }

    }

    /// <summary> 
    /// Entity_Account_PermissionActions的注释
    /// </summary> 
    [Serializable]
    public class Entity_PermissionAction
    {
        [DataMapping("ActionID")]
        public Int32 ActionID { get; set; }

        [DataMapping("ActionCode")]
        public String ActionCode { get; set; }

        [DataMapping("Description")]
        public String Description { get; set; }

        [DataMapping("PermissionCode")]
        public String PermissionCode { get; set; }
    }

    /// <summary> 
    /// Entity_Account_PermissionActions的注释
    /// </summary> 
    [Serializable]
    public class Entity_PermissionAction_Edit
    {
        [DataMapping("PermissionName")]
        public string PermissionName { get; set; }

        [DataMapping("ActionID")]
        public Int32 ActionID { get; set; }

        [DataMapping("ActionCode")]
        public String ActionCode { get; set; }

        [DataMapping("Description")]
        public String Description { get; set; }

        [DataMapping("PermissionCode")]
        public String PermissionCode { get; set; }
    } 
}
