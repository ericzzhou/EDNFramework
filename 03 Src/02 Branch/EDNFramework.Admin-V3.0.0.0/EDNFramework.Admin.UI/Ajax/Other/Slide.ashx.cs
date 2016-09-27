using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS.ViewQueryCondition;
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
    /// Slide 的摘要说明
    /// </summary>
    public class Slide : IHttpHandler
    {
        public string PermissionCode_Sild = "other_sild_default";
        public string PermissionCode_Item = "other_sild_item_default";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            string ajax = context.Request.QueryString["ajax"];
            switch (ajax.ToLower())
            {
                case "getgrouppagerdata":
                    GetGroupPagerData(context);
                    break;
                case "addgroup":
                    AddSlideGroup(context);
                    break;
                case "updategroup":
                    UpdateSlideGroup(context);
                    break;

                case "getitempagerdata":
                    GetItemPagerData(context);
                    break;
                case "deleteitem":
                    DeleteItem(context);
                    break;
                case "updateitem":
                    UpdateItem(context);
                    break;

                case "additem":
                    AddItem(context);
                    break;
            }
        }

        private void AddItem(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_Item, "btn_add");
            Entity_Slide_Item entity = ObjectJsonSerializer.Json2EntityFromAjaxRequest<Entity_Slide_Item>(context.Request);
            if (entity == null)
            {
                throw new BusinessException("数据获取错误，请重试.");
            }
            if (entity.SlideID <= 0)
            {
                throw new BusinessException("请选择幻灯片组.");
            }
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new BusinessException("请输入文件名.");
            }
            if (string.IsNullOrWhiteSpace(entity.Href))
            {
                entity.Href = "#";
            }
            if (string.IsNullOrWhiteSpace(entity.FilePath))
            {
                throw new BusinessException("请上传文件.");
            }

            if (Business.EDNFramework_CMS.Business_Slide_Item.Add(entity) <= 0)
            {
                throw new BusinessException("添加失败.");
            }
        }

        private void UpdateItem(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_Item, "btn_modify");
            Entity_Slide_Item entity = ObjectJsonSerializer.Json2EntityFromAjaxRequest<Entity_Slide_Item>(context.Request);
            if (entity == null || entity.ID <= 0)
            {
                throw new BusinessException("数据获取错误，请重试.");
            }
            if (entity.SlideID <= 0)
            {
                throw new BusinessException("请选择幻灯片组.");
            }
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new BusinessException("请输入文件名.");
            }
            if (string.IsNullOrWhiteSpace(entity.Href))
            {
                entity.Href = "#";
            }
            if (string.IsNullOrWhiteSpace(entity.FilePath))
            {
                throw new BusinessException("请上传文件.");
            }

            if (!Business.EDNFramework_CMS.Business_Slide_Item.Update(entity))
            {
                throw new BusinessException("修改失败.");
            }
        }

        private void DeleteItem(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_Item, "btn_delete");
            int id = context.Request["id"].ToInt();
            if (!Business_Slide_Item.Delete(id))
            {
                throw new BusinessException("删除失败");
            }
        }

        private void GetItemPagerData(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_Item, "btn_search");
            ViewQueryCondition<Entity_Slide_Item_Condition>
            query =
               ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<Entity_Slide_Item_Condition>>(context.Request);

            PagingResult<IList<Entity_Slide_Item>> result = Business_Slide_Item.GetListByPager(query);
            context.Response.Write(result.ToString());
        }

        private void UpdateSlideGroup(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_Sild, "btn_modify");
            Entity_Slide entity = ObjectJsonSerializer.Json2EntityFromAjaxRequest<Entity_Slide>(context.Request);
            if (entity == null || entity.ID <= 0)
            {
                throw new BusinessException("数据获取错误，请刷新重试.");
            }
            Business_Slide.Update(entity);
        }

        private void AddSlideGroup(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_Sild, "btn_add");
            Entity_Slide entity =
                DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
                .Json2EntityFromAjaxRequest<Entity_Slide>(context.Request);
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new BusinessException("组名称不能为空");
            }

            if (Business_Slide.Add(entity) <= 0)
            {
                throw new BusinessException("添加失败，请重试");
            }
        }

        private void GetGroupPagerData(HttpContext context)
        {
            ViewQueryCondition<object>
              query =
                 ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<object>>(context.Request);

            PagingResult<IList<Entity_Slide>> result = Business_Slide.GetListByPager(query);
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