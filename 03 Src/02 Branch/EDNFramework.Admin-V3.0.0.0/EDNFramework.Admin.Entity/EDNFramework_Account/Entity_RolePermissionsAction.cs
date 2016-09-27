using DotNet.Framework.DataAccess.Attribute;
using System;

namespace DotNet.Framework.Admin.Entity.EDNFramework_Account
{
    [Serializable]
    public class Entity_RolePermissionsAction
    {
        [DataMapping("ARPAID")]
        public Guid? ARPAID { get; set; }

        [DataMapping("ARPID")]
        public Guid ARPID { get; set; }

        [DataMapping("ActionCode")]
        public String ActionCode { get; set; }

        [DataMapping("RoleID")]
        public int RoleID { get; set; }

    }
}
