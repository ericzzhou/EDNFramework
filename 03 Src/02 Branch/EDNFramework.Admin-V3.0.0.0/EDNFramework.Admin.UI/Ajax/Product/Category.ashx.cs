using DotNet.Framework.Admin.Business.EDNFramework_Product;
using DotNet.Framework.Admin.Entity.EDNFramework_Product;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.UI.Ajax.Product
{
    /// <summary>
    /// Category 的摘要说明
    /// </summary>
    public class Category : IHttpHandler
    {
        public string PermissionCode = "product_category_index";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            string ajax = context.Request.QueryString["ajax"];
            switch (ajax.ToLower())
            {
                case "getpagerdata":
                    GetPagerData(context);
                    break;
                case "deleteclass":
                    DeleteClass(context);
                    break;

                case "getclass":
                    GetClass(context);
                    break;

                case "adddata":
                    Add(context);
                    break;
                case "editdata":
                    Edit(context);
                    break;
            }
        }

        private void Edit(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_modify");
            Entity_Product_Class_Edit entity =
                DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
                .Json2EntityFromAjaxRequest<Entity_Product_Class_Edit>(context.Request);
            if (string.IsNullOrWhiteSpace(entity.ClassName))
            {
                throw new BusinessException("类别名称不能为空");
            }

            int userId = DotNet.Framework.Admin.Core.Entity.BusEntity_LoginUser.Sys_LoginUser.UserID;
            if (Business_Product_Class.Edit(entity, userId) <= 0)
            {
                throw new BusinessException("修改失败，请重试");
            }
        }

        private void Add(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_add");
            Entity_Product_Class_Add entity =
              DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
              .Json2EntityFromAjaxRequest<Entity_Product_Class_Add>(context.Request);
            if (string.IsNullOrWhiteSpace(entity.ClassName))
            {
                throw new BusinessException("类别名称不能为空");
            }

            int userId = DotNet.Framework.Admin.Core.Entity.BusEntity_LoginUser.Sys_LoginUser.UserID;
            if (Business_Product_Class.Add(entity, userId) <= 0)
            {
                throw new BusinessException("添加失败，请重试");
            }
        }

        private void GetClass(HttpContext context)
        {
            var Entities = Business_Product_Class.GetClass_DropDownList() ?? new List<Entity_Product_Class_Dropdownlist>();
            var json = ObjectJsonSerializer.Serialize<IList<Entity_Product_Class_Dropdownlist>>(Entities);
            context.Response.Write(json);
        }

        private void DeleteClass(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_delete");
            int classID = context.Request["ClassID"].ToInt();

            if (!Business_Product_Class.Delete(classID))
            {
                throw new BusinessException("删除失败。");
            }
        }

        private void GetPagerData(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_search");
            ViewQueryCondition<object> query =
 ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<object>>(context.Request);

            PagingResult<IList<Entity_Product_Class_PagerGrid>> result = Business_Product_Class.GetListByPager(query);
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