using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.EDNFramework_Account.ViewQueryCondition;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Utils.Serialization;
using System.Collections.Generic;
using System.Web;
using DotNet.Framework.Core.Extends;
namespace DotNet.Framework.Admin.UI.Ajax.Account
{
    /// <summary>
    /// PermissionActions 的摘要说明
    /// </summary>
    public class PermissionActions : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string ajax = context.Request.QueryString["ajax"];
            switch (ajax.ToLower())
            {
                case "getpagerdata":
                    GetPagerData(context);
                    break;
                case "getlist":
                    GetList(context);
                    break;
                case "add":
                    Add(context);
                    break;
                case "edit":
                    Edit(context);
                    break;
                case "delete":
                    Delete(context);
                    break;
                default:
                    break;
            }
        }

        private void Edit(HttpContext context)
        {
            Entity_PermissionAction entity = ObjectJsonSerializer.Json2EntityFromAjaxRequest<Entity_PermissionAction>(context.Request);
            if (string.IsNullOrWhiteSpace(entity.PermissionCode))
            {
                throw new BusinessException("模块信息读取错误。");
            }
            if (string.IsNullOrWhiteSpace(entity.ActionCode))
            {
                throw new BusinessException("按钮权限不能为空。");
            }
            if (string.IsNullOrWhiteSpace(entity.Description))
            {
                throw new BusinessException("按钮名称不能为空。");
            }
            if (!Business.EDNFramework_Account.Business_PermissionAction.Edit(entity))
            {
                throw new BusinessException("权限按钮编辑失败。");
            }
        }

        private void Delete(HttpContext context)
        {
            int ActionID = context.Request["ActionID"].ToInt();
            if (!Business.EDNFramework_Account.Business_PermissionAction.Delete(ActionID))
            {
                throw new BusinessException("删除失败。");
            }
        }

        private void Add(HttpContext context)
        {
            Entity_PermissionAction entity = ObjectJsonSerializer.Json2EntityFromAjaxRequest<Entity_PermissionAction>(context.Request);
            if (string.IsNullOrWhiteSpace(entity.PermissionCode))
            {
                throw new BusinessException("模块信息读取错误。");
            }
            if (string.IsNullOrWhiteSpace(entity.ActionCode))
            {
                throw new BusinessException("按钮权限不能为空。");
            }
            if (string.IsNullOrWhiteSpace(entity.Description))
            {
                throw new BusinessException("按钮名称不能为空。");
            }
            if (Business.EDNFramework_Account.Business_PermissionAction.Add(entity) <= 0)
            {
                throw new BusinessException("权限按钮添加失败。");
            }
        }

        private void GetList(HttpContext context)
        {
            ViewQueryCondition<Entity_PermissionAction_Condition>
            query =
               ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<Entity_PermissionAction_Condition>>(context.Request);

            IList<Entity_PermissionAction> result = Business_PermissionAction.GetList(query) ?? new List<Entity_PermissionAction>();
            string json = ObjectJsonSerializer.Serialize<IList<Entity_PermissionAction>>(result);
            context.Response.Write(json);
        }

        private void GetPagerData(HttpContext context)
        {
            ViewQueryCondition<Entity_PermissionAction_Condition>
            query =
               ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<Entity_PermissionAction_Condition>>(context.Request);

            PagingResult<IList<Entity_PermissionAction>> result = Business_PermissionAction.GetListByPager(query);
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