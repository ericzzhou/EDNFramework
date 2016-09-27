using EFramework.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFramework.Web.Areas.Admin.Controllers
{
    public class PictureController : BaseAdminController
    {
        //
        // GET: /Admin/Picture/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category()
        {
            return View();
        }

        public ActionResult Setting()
        {
            return View();
        }

        public ActionResult Tag()
        {
            return View();
        }

        public ActionResult Recycle()
        {
            return View();
        }

    }
}
