using EFramework.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFramework.Web.Areas.Admin.Controllers
{
    public class CalendarController : BaseAdminController
    {
        //
        // GET: /Admin/Calendar/

        public ActionResult Index()
        {
            return View();
        }

    }
}
