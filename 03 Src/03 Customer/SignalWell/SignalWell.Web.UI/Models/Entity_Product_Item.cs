using DotNet.Framework.DataAccess.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalWell.Web.UI.Models
{
    public class Entity_Product_Item_Pager
    {
        [DataMapping("ID")]
        public int ID { get; set; }

        [DataMapping("ClassID")]
        public int ClassID { get; set; }

        [DataMapping("ClassName")]
        public string ClassName { get; set; }

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
    }
    public class Entity_Product_Item
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

    public class Entity_Product
    {
        [DataMapping("ID")]
        public int ID { get; set; }
        [DataMapping("ImageUrl")]
        public string ImageUrl { get; set; }
        [DataMapping("ClassID")]
        public int ClassID { get; set; }
        [DataMapping("PName")]
        public string PName { get; set; }
        [DataMapping("Summary")]
        public string Summary { get; set; }

        [DataMapping("Description")]
        public string Description { get; set; }
    }
}