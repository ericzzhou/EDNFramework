using DotNet.Framework.Core.Web.Data.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalWell.Web.UI.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/

        public ActionResult Index(int? page = 1)
        {
            int PageSize = 10;
            dynamic condition = new { cid = "58,59" };
            ViewQueryCondition<dynamic> query = new ViewQueryCondition<dynamic>();
            query.PagingInfo = new ViewPagingInfo()
            {
                PageIndex = page.Value,
                PageSize = PageSize
            };
            query.Condition = condition;
            PagingResult<IList<Models.EDNF_CMS_Content>> result = Business.Bus_CMS_Content.GetListByPager(query);




            ViewBag.PageSize = PageSize;
            ViewBag.PageIndex = page.Value;
            ViewBag.TotalCount = result.TotalCount;
            ViewBag.News = result.Result ?? new List<Models.EDNF_CMS_Content>();
            return View();
        }

        public ActionResult List(string id, int? page = 1)
        {
            int PageSize = 10;
            dynamic condition = new { cid = id };
            ViewQueryCondition<dynamic> query = new ViewQueryCondition<dynamic>();
            query.PagingInfo = new ViewPagingInfo()
            {
                PageIndex = page.Value,
                PageSize = PageSize
            };
            query.Condition = condition;
            PagingResult<IList<Models.EDNF_CMS_Content>> result = Business.Bus_CMS_Content.GetListByPager(query);



            ViewBag.ClassName = Business.Bus_CMS_Content.GetClassName(id);
            ViewBag.PageSize = PageSize;
            ViewBag.PageIndex = page.Value;
            ViewBag.TotalCount = result.TotalCount;
            ViewBag.News = result.Result ?? new List<Models.EDNF_CMS_Content>();

            int categoryID = 0;
            if (!string.IsNullOrWhiteSpace(id))
            {
                int.TryParse(id, out categoryID);
            }
            ViewBag.CategoryID = categoryID;
            return View();
        }

        public ActionResult Details(int? id = 0)
        {
            Models.Entity_Content entity = new Models.Entity_Content();
            if (id.Value > 0)
            {
                entity = Business.Bus_CMS_Content.GetModel(id.Value) ?? new Models.Entity_Content();
            }
            ViewBag.CategoryID = entity.ClassID;
            ViewBag.Entity = entity;
            return View();
        }

    }
}
