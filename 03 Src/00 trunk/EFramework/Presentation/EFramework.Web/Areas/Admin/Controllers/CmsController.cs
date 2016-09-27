using EFramework.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFramework.Web.Areas.Admin.Controllers
{
    public class CmsController : BaseAdminController
    {
        //
        // GET: /Admin/Cms/

        public ActionResult Index()
        {
            return View("Article");
        }

        /// <summary>
        /// 文章管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Article()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Category()
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
