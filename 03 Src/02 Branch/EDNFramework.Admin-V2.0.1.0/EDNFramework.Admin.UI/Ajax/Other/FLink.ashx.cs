using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Utils.Serialization;
using System.Collections.Generic;
using System.Web;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.UI.Ajax.Other
{
    /// <summary>
    /// FLink 的摘要说明
    /// </summary>
    public class FLink : IHttpHandler
    {
        public string PermissionCode = "other_flink_default";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            string ajax = context.Request.QueryString["ajax"];
            switch (ajax.ToLower())
            {
                case "getpagerdata":
                    GetPagerData(context);
                    break;

                case "deletemodel":
                    Delete(context);
                    break;
                case "adddata":
                    AddData(context);
                    break;
                case "getmodel":
                    GetModel(context);
                    break;
                case "updatedata":
                    Update(context);
                    break;
            }
        }

        private void Update(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_modify");
            Entity_FLinks entity =
              ObjectJsonSerializer.Json2EntityFromAjaxRequest<Entity_FLinks>(context.Request);
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new BusinessException("名称不能为空");
            }
            if (string.IsNullOrWhiteSpace(entity.LinkUrl))
            {
                throw new BusinessException("链接不能为空");
            }
            if (!entity.LinkUrl.StartsWith("http://"))
            {
                entity.LinkUrl = "http://" + entity.LinkUrl;
            }
            int userId = DotNet.Framework.Admin.Core.Entity.BusEntity_LoginUser.Sys_LoginUser.UserID;
            if (Business_FLinks.Update(entity, userId) <= 0)
            {
                throw new BusinessException("修改失败，请重试");
            }
        }

        private void GetModel(HttpContext context)
        {
            int id = context.Request["id"].ToInt();

            Entity_FLinks entity = Business_FLinks.GetModel(id);
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<Entity_FLinks>(entity);
            context.Response.Write(json);
        }

        private void AddData(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_add");
            Entity_FLinks entity =
               DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
               .Json2EntityFromAjaxRequest<Entity_FLinks>(context.Request);
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new BusinessException("名称不能为空");
            }
            if (string.IsNullOrWhiteSpace(entity.LinkUrl))
            {
                throw new BusinessException("链接不能为空");
            }
            if (!entity.LinkUrl.StartsWith("http://"))
            {
                entity.LinkUrl = "http://" + entity.LinkUrl;
            }
            int userId = DotNet.Framework.Admin.Core.Entity.BusEntity_LoginUser.Sys_LoginUser.UserID;
            if (Business_FLinks.Add(entity, userId) <= 0)
            {
                throw new BusinessException("添加失败，请重试");
            }
        }

        private void Delete(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_delete");
            int id = context.Request["id"].ToInt();

            if (Business_FLinks.Delete(id) <= 0)
            {
                throw new BusinessException("删除失败");
            }
        }

        private void GetPagerData(HttpContext context)
        {
            ViewQueryCondition<object>
             query =
                ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<object>>(context.Request);

            PagingResult<IList<Entity_FLinks>> result = Business_FLinks.GetListByPager(query);
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