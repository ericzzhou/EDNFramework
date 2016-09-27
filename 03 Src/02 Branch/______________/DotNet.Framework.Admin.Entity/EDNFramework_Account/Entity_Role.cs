using DotNet.Framework.DataAccess.Attribute;

namespace DotNet.Framework.Admin.Entity.EDNFramework_Account
{
    public class Entity_Role
    {
        [DataMapping("RoleID")]
        public int RoleID { get; set; }

        [DataMapping("RoleName")]
        public string RoleName { get; set; }

        [DataMapping("Description")]
        public string Description { get; set; }
    }

    public class Entity_RoleList
    {
        [DataMapping("RoleID")]
        public int RoleID { get; set; }

        [DataMapping("RoleName")]
        public string RoleName { get; set; }

        [DataMapping("Description")]
        public string Description { get; set; }

        [DataMapping("UserCount")]
        public int UserCount { get; set; }
    }
}
