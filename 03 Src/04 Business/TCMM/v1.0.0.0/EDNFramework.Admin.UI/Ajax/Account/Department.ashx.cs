using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Utils.Serialization;
using System.Collections.Generic;
using System.Web;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.UI.Ajax.Account
{
    /// <summary>
    /// Department 的摘要说明
    /// </summary>
    public class Department : IHttpHandler
    {
        public string PermissionCode = "Account_Department_Index";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            string ajax = context.Request.QueryString["ajax"];
            switch (ajax.ToLower())
            {
                case "adddata":
                    Add(context);
                    break;
                case "edit":
                    Edit(context);
                    break;
                case "delete":
                    Delete(context);
                    break;
                case "getpagerdata":
                    GetPagerData(context);
                    break;
                default:
                    break;
            }
        }

        private void GetPagerData(HttpContext context)
        {
            ViewQueryCondition<object> query =
 ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<object>>(context.Request);

            PagingResult<IList<Entity_Department>> result = Business_Department.GetListByPager(query);
            context.Response.Write(result.ToString());
        }

        private void Delete(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_delete");
            int Id = context.Request["id"].ToInt();
            if (Id > 0)
            {
                if (!Business_Department.Delete(Id))
                {
                    throw new BusinessException("删除部门失败");
                }
            }

            context.Response.Write("{}");
        }

        private void Edit(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_modify");
            Entity_Department entity =
                ObjectJsonSerializer
                .Json2EntityFromAjaxRequest<Entity_Department>(context.Request);

            if (entity.Name.IsNull())
            {
                throw new BusinessException("请输入部门名称");
            }
            if (Business_Department.GetDepartmentCountByName(entity.Name, entity.ID) > 0)
            {
                throw new BusinessException(string.Format("请部门名称[{0}]已存在，不能重复输入", entity.Name));
            }
            if (Business_Department.Edit(entity) <= 0)
            {
                throw new BusinessException("编辑部门信息失败，请重试");
            }
            context.Response.Write("{}");
        }

        private void Add(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_add");
            Entity_Department entity =
                ObjectJsonSerializer
                .Json2EntityFromAjaxRequest<Entity_Department>(context.Request);

            if (entity.Name.IsNull())
            {
                throw new BusinessException("请输入部门名称");
            }
            if (Business_Department.GetDepartmentCountByName(entity.Name) > 0)
            {
                throw new BusinessException(string.Format("请部门名称[{0}]已存在，不能重复输入", entity.Name));
            }
            if (Business_Department.Add(entity) <= 0)
            {
                throw new BusinessException("添加部门失败，请重试");
            }
            context.Response.Write("{}");
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