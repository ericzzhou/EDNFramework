using DotNet.Framework.Admin.Business.EDNFramework_Product;
using DotNet.Framework.Admin.Entity.EDNFramework_Product;
using DotNet.Framework.Admin.Entity.EDNFramework_Product.ViewQueryCondition;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Utils.Serialization;
using System.Collections.Generic;
using System.Web;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.UI.Ajax.Product
{
    /// <summary>
    /// Item 的摘要说明
    /// </summary>
    public class Item : IHttpHandler
    {
        public string PermissionCode = "product_item_index";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            string ajax = context.Request.QueryString["ajax"];
            switch (ajax.ToLower())
            {
                case "getpagerdata":
                    GetPagerData(context);
                    break;
                case "delete":
                    Delete(context);
                    break;

                case "recycle":
                    Recycle(context);
                    break;

                case "add":
                    Add(context);
                    break;
                case "edit":
                    Edit(context);
                    break;
            }
        }

        private void Edit(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_modify");
            Entity_Product_Item_Edit entity =
                DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
                .Json2EntityFromAjaxRequest<Entity_Product_Item_Edit>(context.Request);
            if (string.IsNullOrWhiteSpace(entity.PName))
            {
                throw new BusinessException("产品名称不能为空");
            }
            if (entity.ClassID <= 0)
            {
                throw new BusinessException("请选择产品类型");
            }
            if (entity.Summary.Length > 500)
            {
                throw new BusinessException("产品概要长度太长");
            }
            int userId = DotNet.Framework.Admin.Core.Entity.BusEntity_LoginUser.Sys_LoginUser.UserID;
            if (Business_Product_Item.Edit(entity, userId) <= 0)
            {
                throw new BusinessException("保存失败，请重试");
            }
        }

        private void Add(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_add");
            Entity_Product_Item_Add entity =
                DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
                .Json2EntityFromAjaxRequest<Entity_Product_Item_Add>(context.Request);
            if (string.IsNullOrWhiteSpace(entity.PName))
            {
                throw new BusinessException("产品名称不能为空");
            }
            if (entity.ClassID <= 0)
            {
                throw new BusinessException("请选择产品类型");
            }
            if (entity.Summary.Length > 500)
            {
                throw new BusinessException("产品概要长度太长");
            }
            int userId = DotNet.Framework.Admin.Core.Entity.BusEntity_LoginUser.Sys_LoginUser.UserID;
            if (Business_Product_Item.Add(entity, userId) <= 0)
            {
                throw new BusinessException("添加失败，请重试");
            }
        }

        private void Recycle(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_recycle");
            int id = context.Request["ClassID"].ToInt();

            if (!Business_Product_Item.Recycle(id))
            {
                throw new BusinessException("回收失败。");
            }
        }

        private void Delete(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_delete");
            int id = context.Request["ClassID"].ToInt();

            if (!Business_Product_Item.Delete(id))
            {
                throw new BusinessException("删除失败。");
            }
        }

        private void GetPagerData(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_search");
            ViewQueryCondition<Entity_Product_Condition> query =
ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<Entity_Product_Condition>>(context.Request);

            PagingResult<IList<Entity_Product_ItemGrid>> result = Business_Product_Item.GetListByPager(query);
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