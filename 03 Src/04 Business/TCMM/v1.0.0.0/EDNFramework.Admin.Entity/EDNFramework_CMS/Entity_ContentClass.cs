
using DotNet.Framework.DataAccess.Attribute;
namespace DotNet.Framework.Admin.Entity.EDNFramework_CMS
{
    public class Entity_ContentClass_Model
    {
        [DataMapping("ClassID")]
        public int ClassID { get; set; }

        [DataMapping("ClassName")]
        public string ClassName { get; set; }

        [DataMapping("ClassTypeID")]
        public int ClassTypeID { get; set; }

        [DataMapping("ParentId")]
        public int? ParentId { get; set; }

        [DataMapping("Sequence")]
        public int Sequence { get; set; }

        [DataMapping("State")]
        public bool State { get; set; }

        [DataMapping("AllowAddContent")]
        public bool AllowAddContent { get; set; }

        [DataMapping("Description")]
        public string Description { get; set; }

        [DataMapping("Meta_Title")]
        public string Meta_Title { get; set; }

        [DataMapping("SeoUrl")]
        public string SeoUrl { get; set; }

        [DataMapping("Meta_Keywords")]
        public string Meta_Keywords { get; set; }

        [DataMapping("Meta_Description")]
        public string Meta_Description { get; set; }

        [DataMapping("CreatedUserID")]
        public int CreatedUserID { get; set; }
    }
    public class Entity_ContentClass_DropDownList
    {
        [DataMapping("ClassID")]
        public int ClassID { get; set; }

        [DataMapping("ClassName")]
        public string ClassName { get; set; }

        [DataMapping("AllowAddContent")]
        public bool AllowAddContent { get; set; }
    }
    public class Entity_ContentClass_GetList
    {
        [DataMapping("ClassID")]
        public int ClassID { get; set; }

        [DataMapping("ClassName")]
        public string ClassName { get; set; }

        [DataMapping("ClassTypeName")]
        public string ClassTypeName { get; set; }

        [DataMapping("Sequence")]
        public int Sequence { get; set; }

        [DataMapping("State")]
        public string State { get; set; }

        [DataMapping("AllowAddContent")]
        public string AllowAddContent { get; set; }

        [DataMapping("Description")]
        public string Description { get; set; }

        [DataMapping("Meta_Title")]
        public string Meta_Title { get; set; }

        [DataMapping("SeoUrl")]
        public string SeoUrl { get; set; }

        [DataMapping("Meta_Keywords")]
        public string Meta_Keywords { get; set; }

        [DataMapping("Meta_Description")]
        public string Meta_Description { get; set; }
    }

   
}
