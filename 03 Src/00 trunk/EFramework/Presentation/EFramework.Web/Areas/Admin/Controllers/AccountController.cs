using EFramework.Core;
using EFramework.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFramework.Web.Areas.Admin.Controllers
{
    public class AccountController : BaseAdminController
    {
        //
        // GET: /Admin/Account/

        public ActionResult Index()
        {
            
            //todo 判断是否已经登录，如果已经登录 跳转到  /admin/home , 
            //todo 如果没有登录，返回login
            return View("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string username,string password)
        {
            throw new BusinessException("没有登录");
            return Json(new { status = 1 ,message="成功了"});
        }
    }
}
