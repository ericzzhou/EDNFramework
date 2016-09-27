using EFramework.Core;
using EFramework.Core.WebRuntime.ViewObject;
using EFramework.Entities.Domain.Account;
using EFramework.Entities.Domain.Account.ViewQueryCondition;
using EFramework.Entities.Domain.ControlPanel;
using EFramework.Entities.Domain.ControlPanel.ViewQueryCondition;
using EFramework.Services;
using EFramework.Web.Framework.Controllers;
using EFramework.Web.Framework.Filters;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace EFramework.Web.Areas.Admin.Controllers
{
    
    public class ControlpanelController : BaseAdminController
    {
        //
        // GET: /Admin/Controlpanel/

        public ActionResult Index()
        {
            return View();
        }

        #region 系统安全
        public ActionResult SysConfig(string key, string value, int pageIndex = 1)
        {
            ViewBag.Key = key;
            ViewBag.Value = value;

            //throw new Exception("fsdfsd");
            ViewQueryCondition<ConfigSearchCondition> condition = new ViewQueryCondition<ConfigSearchCondition>();
            condition.Condition = new ConfigSearchCondition()
            {
                Key = key,
                Value = value
            };
            condition.PagingInfo = new ViewPagingInfo()
            {
                OrderField = "ID",
                PageSize = 10,
                PageIndex = pageIndex
            };
            PagingResult<List<SYS_ConfigContentEntity>> query = SystemService.GetConfigsByPager(condition);

            PagedList<SYS_ConfigContentEntity> result =
               new PagedList<SYS_ConfigContentEntity>(query.Result, query.PagingInfo.PageIndex, query.PagingInfo.PageSize, query.TotalCount);

            if (Request.IsAjaxRequest())
                return PartialView("_AjaxSysConfigPartial", result);
            else
                return View(result);
        }


        

       

       
        #endregion

        public ActionResult SysLogs()
        {
            return View();
        }

        public ActionResult OperationLogs()
        {
            return View();
        }

        public ActionResult UserLogs()
        {
            return View();
        }

        //[HttpPost]
        public JsonResult DeleteConfig(int id = 0)
        {
            throw new BusinessException("就是错误啦。");
            return Json(new { status = 1 }, JsonRequestBehavior.AllowGet);
            //return Content("test");
        }

        public ActionResult EditConfig(int id = 0)
        {
            ViewBag.ID = id;

            return View(SystemService.GetConfigModel(id));
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult EditConfig(SYS_ConfigContentEntity model)
        {
            SystemService.ModifyConfig(model);

            return Json(new { status = 1 });
        }

        public ActionResult AddConfig()
        {
            return View(new SYS_ConfigContentEntity());
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult AddConfig(SYS_ConfigContentEntity model)
        {
            SystemService.AddConfig(model);

            return Json(new { status = 1 });
        }

        
    }
}
