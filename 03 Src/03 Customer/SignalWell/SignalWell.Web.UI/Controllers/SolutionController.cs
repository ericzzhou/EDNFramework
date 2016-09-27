using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalWell.Web.UI.Controllers
{
    public class SolutionController : Controller
    {
        //
        // GET: /Solution/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View(int? id)
        {
            //IList<Models.EDNF_Product_Class> categories = Business.EDNF_Product_Class.GetAll() ?? new List<Models.EDNF_Product_Class>();
            var entity = Business.Bus_Product_Item.GetModel(id.Value) ?? new Models.Entity_Product_Item()
            {
                PName = "",
                Description = "信息不存在或已被删除!"
            };

            int classID = entity.ClassID;
            IList<Models.Entity_Product_Item> list = Business.Bus_Product_Item.GetAll(classID) ?? new List<Models.Entity_Product_Item>();

            ViewBag.entity = entity;
            ViewBag.list = list;
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

    }
}
