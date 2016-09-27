using EFramework.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFramework.Web.Controllers
{
    public class HomeController : BaseWebController
    {
        public ActionResult Index()
        {
            var cache =  EFramework.Core.Cache.Factory.Get("ttt");
            ViewBag.Message = cache ?? "没有获取到缓存信息";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            EFramework.Core.Cache.Factory.Insert("ttt", "abc");
            return View();
        }
    }
}
