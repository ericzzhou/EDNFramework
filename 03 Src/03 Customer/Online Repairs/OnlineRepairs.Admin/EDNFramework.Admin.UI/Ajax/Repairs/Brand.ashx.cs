using DotNet.Framework.Admin.Business.EDNFramework_Repairs;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Entity.EDNFramework_Repairs;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNet.Framework.Core.Extends;
namespace DotNet.Framework.Admin.UI.Ajax.Repairs
{
    /// <summary>
    /// Brand 的摘要说明
    /// </summary>
    public class Brand : IHttpHandler
    {
        string permissionCode = "repairs_brand_index";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string ajax = context.Request.QueryString["ajax"];
            switch (ajax.ToLower())
            {
                case "getpagerdata":
                    GetPagerData(context);
                    break;
                case "delete":
                    Delete(context);
                    break;
                case "add":
                    Add(context);
                    break;
                case "getmodel":
                    GetModel(context);
                    break;
                case "update":
                    Update(context);
                    break;
                //case "getpermissionnames":
                //    GetPermissionNames(context);
                //    break;
                default:
                    break;
            }
        }

        private void Update(HttpContext context)
        {
            CheckPermission.CheckRight(permissionCode, "btn_update");
            Entity_Brand entity =
               ObjectJsonSerializer.Json2EntityFromAjaxRequest<Entity_Brand>(context.Request);
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new BusinessException("品牌名称不能为空");
            }

            if (Business_Repairs.Update(entity) <= 0)
            {
                throw new BusinessException("修改失败，请重试");
            }
        }

        private void GetModel(HttpContext context)
        {
            CheckPermission.CheckRight(permissionCode);
            int id = context.Request["ID"].ToInt();
            if (id <=0)
            {
                throw new BusinessException("编号获取失败");
            }
            Entity_Brand entity = Business_Repairs.GetModel(id);

            var json = ObjectJsonSerializer.Serialize<Entity_Brand>(entity);
            context.Response.Write(json);
        }

        private void Add(HttpContext context)
        {
            CheckPermission.CheckRight(permissionCode, "btn_add");
            Entity_Brand entity =
               ObjectJsonSerializer.Json2EntityFromAjaxRequest<Entity_Brand>(context.Request);
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new BusinessException("品牌名称不能为空");
            }

            if (Business_Repairs.Add(entity) <= 0)
            {
                throw new BusinessException("添加失败，请重试");
            }
        }

        private void Delete(HttpContext context)
        {
            CheckPermission.CheckRight(permissionCode, "btn_delete");
            int id = context.Request["ID"].ToInt();

            if (Business_Repairs.Delete(id) <= 0)
            {
                throw new BusinessException("删除失败");
            }
        }

        private void GetPagerData(HttpContext context)
        {
            ViewQueryCondition<object>
  query =
     ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<object>>(context.Request);

            PagingResult<IList<Entity_Brand>> result = Business_Repairs.GetListByPager(query);
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