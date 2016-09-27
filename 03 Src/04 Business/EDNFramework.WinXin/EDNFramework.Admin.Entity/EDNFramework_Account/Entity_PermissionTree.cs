using DotNet.Framework.DataAccess.Attribute;

namespace DotNet.Framework.Admin.Entity.EDNFramework_Account
{
    public class Entity_PermissionTree
    {
        [DataMapping("ico")]
        public string Ico { get; set; }

        [DataMapping("ID")]
        public int id { get; set; }

        [DataMapping("ParentID")]
        public int pid { get; set; }

        [DataMapping("PermissionName")]
        public string name { get; set; }

        public bool open { get; set; }

        [DataMapping("RequestUrl")]
        public string file { get; set; }

        public Entity_PermissionTree()
        {
            this.open = false;
        }
    }
}
