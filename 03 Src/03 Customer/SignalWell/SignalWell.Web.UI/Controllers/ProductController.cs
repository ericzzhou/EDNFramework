using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNet.Framework.Core.Extends;

namespace SignalWell.Web.UI.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int? cid = 0)
        {
            ViewBag.CID = cid.Value;
            var cName = Business.Bus_Product_Class.GetCategoryName(cid.Value);
            ViewBag.CName = cName;
            return View();
        }

        public ActionResult Listview(int? cid = 0, int? cc = 0, int? page = 1)
        {
            int totalCount = 0;
            int PageSize = 10;
            
            var cName = Business.Bus_Product_Class.GetCategoryName(cid.Value);
          
            var c2Name = Business.Bus_Product_Class.GetCategoryName(cc.Value);
            ViewBag.CID = cid.Value;
            ViewBag.CName = cName;
            ViewBag.c2Name = c2Name;
            ViewBag.cc = cc.Value;
            IList<Models.Entity_Product_Item_Pager> products = new List<Models.Entity_Product_Item_Pager>();

            //取单个CID下的所有商品
            products = Business.Bus_Product_Item.GetPagerData(cc.Value, page.Value, PageSize, out totalCount) ?? new List<Models.Entity_Product_Item_Pager>();

            ViewBag.PageSize = PageSize;
            ViewBag.PageIndex = page.Value;
            ViewBag.TotalCount = totalCount;
           
            ViewBag.Products = products;
            return View();
        }

        public ActionResult Details(int? id = 0, int? cid = 0, int? cc = 0)
        {
           
            var cName = Business.Bus_Product_Class.GetCategoryName(cid.Value);
           
            var c2Name = Business.Bus_Product_Class.GetCategoryName(cc.Value);
            ViewBag.CID = cid.Value;
            ViewBag.CName = cName;
            ViewBag.c2Name = c2Name;
            ViewBag.ID = id.Value;
            return View();
        }
    }
}
