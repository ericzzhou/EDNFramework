using DotNet.Framework.DataAccess.Attribute;

namespace DotNet.Framework.Admin.Entity.EDNFramework_Product
{
    public class Entity_Product_Item_Edit
    {
        [DataMapping("ID")]
        public int ID { get; set; }

        [DataMapping("ClassID")]
        public int ClassID { get; set; }

        [DataMapping("Deleted")]
        public bool Deleted { get; set; }

        [DataMapping("IsTop")]
        public bool IsTop { get; set; }

        [DataMapping("IsHot")]
        public bool IsHot { get; set; }

        [DataMapping("IsRecomend")]
        public bool IsRecomend { get; set; }

        [DataMapping("PName")]
        public string PName { get; set; }

        [DataMapping("Price")]
        public decimal? Price { get; set; }

        [DataMapping("DiscountPrice")]
        public decimal? DiscountPrice { get; set; }

        [DataMapping("ImageUrl")]
        public string ImageUrl { get; set; }

        [DataMapping("Summary")]
        public string Summary { get; set; }

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

    public class Entity_Product_Item_Add
    {
        //[DataMapping("ID")]
        //public int ID { get; set; }
        [DataMapping("ClassID")]
        public int ClassID { get; set; }

        [DataMapping("Deleted")]
        public bool Deleted { get; set; }

        [DataMapping("IsTop")]
        public bool IsTop { get; set; }

        [DataMapping("IsHot")]
        public bool IsHot { get; set; }

        [DataMapping("IsRecomend")]
        public bool IsRecomend { get; set; }

        [DataMapping("PName")]
        public string PName { get; set; }

        [DataMapping("Price")]
        public decimal? Price { get; set; }

        [DataMapping("DiscountPrice")]
        public decimal? DiscountPrice { get; set; }

        [DataMapping("ImageUrl")]
        public string ImageUrl { get; set; }

        [DataMapping("Summary")]
        public string Summary { get; set; }

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
    public class Entity_Product_Item
    {
    }
    public class Entity_Product_ItemGrid
    {
        [DataMapping("ID")]
        public int ID { get; set; }

        [DataMapping("PName")]
        public string PName { get; set; }

        [DataMapping("Price")]
        public decimal? Price { get; set; }

        [DataMapping("DiscountPrice")]
        public decimal? DiscountPrice { get; set; }

        [DataMapping("ImageUrl")]
        public string ImageUrl { get; set; }

        [DataMapping("CreatedDate")]
        public string CreatedDate { get; set; }

        [DataMapping("ClassID")]
        public int ClassID { get; set; }

        [DataMapping("ClassName")]
        public string ClassName { get; set; }

        [DataMapping("Deleted")]
        public bool Deleted { get; set; }

        [DataMapping("IsTop")]
        public bool IsTop { get; set; }

        [DataMapping("IsHot")]
        public bool IsHot { get; set; }

        [DataMapping("IsRecomend")]
        public bool IsRecomend { get; set; }

    }
}
