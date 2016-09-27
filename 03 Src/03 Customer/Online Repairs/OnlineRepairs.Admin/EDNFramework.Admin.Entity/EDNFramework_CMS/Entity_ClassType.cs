
using DotNet.Framework.DataAccess.Attribute;
namespace DotNet.Framework.Admin.Entity.EDNFramework_CMS
{
    public class Entity_ClassType
    {
        [DataMapping("ClassTypeID")]
        public int ClassTypeID { get; set; }

        [DataMapping("ClassTypeName")]
        public string ClassTypeName { get; set; }
    }
}
