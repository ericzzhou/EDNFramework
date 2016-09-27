using EFramework.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFramework.Web.Areas.Admin.Controllers
{
    public class CustomerController : BaseAdminController
    {
        //
        // GET: /Admin/Customer/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Gustbook()
        {
            return View();
        }

        public ActionResult Comment()
        {
            return View();
        }
    }
}
