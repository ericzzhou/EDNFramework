using DotNet.Framework.DataAccess.Attribute;
using System;

namespace DotNet.Framework.MVC.Extend.Entity
{
    [Serializable]
    public class Entity_Product
    {
        [DataMapping("ID")]
        public Int32 ID { get; set; }

        [DataMapping("PName")]
        public String PName { get; set; }

        [DataMapping("SubPName")]
        public String SubPName { get; set; }

        [DataMapping("Summary")]
        public String Summary { get; set; }

        [DataMapping("Description")]
        public String Description { get; set; }

        [DataMapping("ImageUrl")]
        public String ImageUrl { get; set; }

        [DataMapping("ThumbImageUrl")]
        public String ThumbImageUrl { get; set; }

        [DataMapping("NormalImageUrl")]
        public String NormalImageUrl { get; set; }

        [DataMapping("Price")]
        public Decimal Price { get; set; }

        [DataMapping("DiscountPrice")]
        public Decimal DiscountPrice { get; set; }

        [DataMapping("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [DataMapping("CreatedUserID")]
        public Int32 CreatedUserID { get; set; }

        [DataMapping("LastEditUserID")]
        public Int32 LastEditUserID { get; set; }

        [DataMapping("LastEditDate")]
        public DateTime LastEditDate { get; set; }

        [DataMapping("LinkUrl")]
        public String LinkUrl { get; set; }

        [DataMapping("PvCount")]
        public Int32 PvCount { get; set; }

        [DataMapping("Deleted")]
        public Boolean Deleted { get; set; }

        [DataMapping("ClassID")]
        public Int32 ClassID { get; set; }

        [DataMapping("Keywords")]
        public String Keywords { get; set; }

        [DataMapping("Sequence")]
        public Int32 Sequence { get; set; }

        [DataMapping("IsRecomend")]
        public Boolean IsRecomend { get; set; }

        [DataMapping("IsHot")]
        public Boolean IsHot { get; set; }

        [DataMapping("IsColor")]
        public Boolean IsColor { get; set; }

        [DataMapping("IsTop")]
        public Boolean IsTop { get; set; }

        [DataMapping("Attachment")]
        public String Attachment { get; set; }

        [DataMapping("Remary")]
        public String Remary { get; set; }

        [DataMapping("TotalComment")]
        public Int32 TotalComment { get; set; }

        [DataMapping("TotalSupport")]
        public Int32 TotalSupport { get; set; }

        [DataMapping("TotalFav")]
        public Int32 TotalFav { get; set; }

        [DataMapping("TotalShare")]
        public Int32 TotalShare { get; set; }

        [DataMapping("BeFrom")]
        public String BeFrom { get; set; }

        [DataMapping("FileName")]
        public String FileName { get; set; }

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

        [DataMapping("StaticUrl")]
        public String StaticUrl { get; set; }
    }
}
