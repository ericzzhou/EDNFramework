using DotNet.Framework.DataAccess.Attribute;
using System;

namespace DotNet.Framework.MVC.Extend.Entity
{
    [Serializable]
    public class Entity_ContentCategory
    {
        [DataMapping("ClassID")]
        public Int32 ClassID { get; set; }

        [DataMapping("ClassName")]
        public String ClassName { get; set; }

        [DataMapping("ClassIndex")]
        public String ClassIndex { get; set; }

        [DataMapping("Sequence")]
        public Int32 Sequence { get; set; }

        [DataMapping("ParentId")]
        public Int32 ParentId { get; set; }

        [DataMapping("State")]
        public Boolean State { get; set; }

        [DataMapping("AllowSubclass")]
        public Boolean AllowSubclass { get; set; }

        [DataMapping("AllowAddContent")]
        public Boolean AllowAddContent { get; set; }

        [DataMapping("ImageUrl")]
        public String ImageUrl { get; set; }

        [DataMapping("Description")]
        public String Description { get; set; }

        [DataMapping("Keywords")]
        public String Keywords { get; set; }

        [DataMapping("ClassTypeID")]
        public Int32 ClassTypeID { get; set; }

        [DataMapping("ClassModel")]
        public Int16 ClassModel { get; set; }

        [DataMapping("PageModelName")]
        public String PageModelName { get; set; }

        [DataMapping("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [DataMapping("CreatedUserID")]
        public Int32 CreatedUserID { get; set; }

        [DataMapping("Path")]
        public String Path { get; set; }

        [DataMapping("Depth")]
        public Int32 Depth { get; set; }

        [DataMapping("Remark")]
        public String Remark { get; set; }

        [DataMapping("Meta_Title")]
        public String Meta_Title { get; set; }

        [DataMapping("Meta_Description")]
        public String Meta_Description { get; set; }

        [DataMapping("Meta_Keywords")]
        public String Meta_Keywords { get; set; }

        [DataMapping("SeoUrl")]
        public String SeoUrl { get; set; }

        [DataMapping("SeoImageAlt")]
        public String SeoImageAlt { get; set; }

        [DataMapping("SeoImageTitle")]
        public String SeoImageTitle { get; set; }

        [DataMapping("IndexChar")]
        public String IndexChar { get; set; }

    }
}
