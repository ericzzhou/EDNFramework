using EFramework.Web.Framework.Controllers;
using EFramework.Web.Framework.WorkContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EFramework.Web.Framework.Filters
{
    /// <summary>
    /// 权限验证 attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ValidatePermissionAttribute : ActionFilterAttribute
    {
        public string PermissionCode { get; set; }
        public string ActionCode { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="PermissionCode"></param>
        /// <param name="ActionCode"></param>
        public ValidatePermissionAttribute(string PermissionCode, string ActionCode)
        {
            this.PermissionCode = PermissionCode;
            this.ActionCode = ActionCode;


        }

        public AdminWorkContext WorkContext;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            WorkContext = ((BaseAdminController)(filterContext.Controller)).WorkContext;

            int userId = WorkContext.Uid;
            List<int> urids = WorkContext.URIds;

            //filterContext.Result = new RedirectResult("/"); //页面跳转处理
            //filterContext.Result = new ViewResult() { ViewName = "_PromptPartial"  };//没有权限分布页
            //if (WorkContext.IsHttpAjax)
            //{
            //    filterContext.Result = new JsonResult { ContentEncoding = Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { status = -1, message = "没有权限执行此操作" } };
            //}

        }

        

    }
}
