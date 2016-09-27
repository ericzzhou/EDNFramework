using DotNet.Framework.Admin.Business.EDNFramework_SYS;
using DotNet.Framework.Admin.Entity.EDNFramework_SYS;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Utils.Serialization;
using System.Collections.Generic;
using System.Web;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Core.Business;

namespace DotNet.Framework.Admin.UI.Ajax.Log
{
    /// <summary>
    /// ErrorLog 的摘要说明
    /// </summary>
    public class ErrorLog : IHttpHandler
    {
        public string PermissionCode = "log_sys_index";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            string ajax = context.Request.QueryString["ajax"];
            switch (ajax.ToLower())
            {
                case "getlist":
                    GetList(context);
                    break;

                case "show":
                    ShowData(context);
                    break;
                default:
                    break;
            }
        }

        private void ShowData(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_viewdetail");
            int id = context.Request["id"].ToInt();
            if (id > 0)
            {
                Entity_ErrorLog entity = Business_ErrorLog.GetModel(id);
                var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<Entity_ErrorLog>(entity);
                context.Response.Write(json);
            }
        }

        private void GetList(HttpContext context)
        {
            ViewQueryCondition<object> query =
ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<object>>(context.Request);

            PagingResult<IList<Entity_ErrorLog>> result = Business_ErrorLog.GetListByPager(query);
            context.Response.Write(result.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}