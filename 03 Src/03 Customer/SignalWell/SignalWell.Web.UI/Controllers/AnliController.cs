using SignalWell.Web.UI.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SignalWell.Web.UI.Controllers
{
    public class AnliController : Controller
    {
        int caseClassID = 18;
        //
        // GET: /Anli/

        public ActionResult Index(int? id = 0)
        {
           
            ViewBag.CaseCategories = Business.Bus_Product_Class.GetAll(caseClassID) ?? new List<Models.EDNF_Product_Class>();

            //查询 当前类别下 所有 案例信息，如果参数 id=0 ，则查询 经典案例下（包括子类别）的所有案例信息

            if (id.HasValue && id.Value > 0)
            {
                caseClassID = id.Value;
            }

            var result = Business.Bus_Product_Item.GetAllList(caseClassID) ?? new List<Entity_Product>() { 
                new Entity_Product(){ ClassID=0, ImageUrl="/images/01.jpg",PName="展示数据"},
                new Entity_Product(){ ClassID=0, ImageUrl="/images/02.jpg",PName="展示数据"},
                new Entity_Product(){ ClassID=0, ImageUrl="/images/03.jpg",PName="展示数据"}
            };
            ViewBag.Case = result;


            return View();
        }

        public ActionResult List(int? id = 0, int? page = 1)
        {
            int totalCount = 0;
            int PageSize = 10;
            IList<Models.Entity_Product_Item_Pager> products = new List<Models.Entity_Product_Item_Pager>();
            products = Business.Bus_Product_Item.GetPagerData(id.Value, page.Value, PageSize, out totalCount) ?? new List<Models.Entity_Product_Item_Pager>();


            ViewBag.entityCategories = Business.Bus_Product_Class.GetAll(caseClassID) ?? new List<Models.EDNF_Product_Class>();
            ViewBag.PageSize = PageSize;
            ViewBag.PageIndex = page.Value;
            ViewBag.Products = products;
            string cName = Business.Bus_Product_Class.GetCategoryName(id.Value);
            if (string.IsNullOrWhiteSpace(cName))
            {
                cName = "经典案例";
            }
            ViewBag.CategoryName = cName;
            return View();
        }

        public ActionResult Detail(int id = 0)
        {
            ViewBag.entityCategories = Business.Bus_Product_Class.GetAll(caseClassID) ?? new List<Models.EDNF_Product_Class>();
            Entity_Product_Item entity = new Entity_Product_Item();
            if (id > 0)
            {
                entity = Business.Bus_Product_Item.GetModel(id) ?? new Entity_Product_Item();
            }
            ViewBag.entity = entity;
            return View();
        }

    }
}
