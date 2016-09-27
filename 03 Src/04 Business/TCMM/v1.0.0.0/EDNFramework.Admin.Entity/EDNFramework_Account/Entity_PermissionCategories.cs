using DotNet.Framework.DataAccess.Attribute;

namespace DotNet.Framework.Admin.Entity.EDNFramework_Account
{
    public class Entity_PermissionCategories
    {
        [DataMapping("CategoryID")]
        public int CategoryID { get; set; }

        [DataMapping("Description")]
        public string Description { get; set; }
    }
}
