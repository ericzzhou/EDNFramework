using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS.ViewQueryCondition;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
using System.Web;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Core.Entity;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.UI.Ajax.Articles
{
    /// <summary>
    /// Item 的摘要说明
    /// </summary>
    public class Item : IHttpHandler
    {
        public string PermissionCode_ArticleItemIndex = "article_item_index";
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
                case "add":
                    Add(context);
                    break;
                case "getmodel":
                    GetModel(context);
                    break;
                case "update":
                    Update(context);
                    break;
            }
        }

        private void Update(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_ArticleItemIndex, "btn_modify");
            Entity_Content entity =
                 DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
                 .Json2EntityFromAjaxRequest<Entity_Content>(context.Request);

            if (entity.ClassID == 0)
            {
                throw new BusinessException("请选择文章类别");
            }

            if (string.IsNullOrWhiteSpace(entity.Title))
            {
                throw new BusinessException("文章Title不能为空");
            }
            if (entity.Summary.Length > 500)
            {
                throw new BusinessException("概要长度超长");
            }
            if (string.IsNullOrWhiteSpace(entity.Description))
            {
                throw new BusinessException("文章正文不能为空");
            }
            entity.LastEditDate = DateTime.Now;
            //entity.Description = Server.HtmlEncode(entity.Description);
            entity.LastEditUserID = BusEntity_LoginUser.Sys_LoginUser.UserID;

            if (Business_Content.Update(entity) <= 0)
            {
                throw new BusinessException("编辑失败，请重试");
            }
        }

        private void GetModel(HttpContext context)
        {
            int ContentID = context.Request["id"].ToInt();
            if (ContentID > 0)
            {
                Entity_Content entity = Business_Content.GetModel(ContentID);

                var json = ObjectJsonSerializer.Serialize<Entity_Content>(entity);
                context.Response.Write(json);

            }
        }

        private void Add(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_ArticleItemIndex, "btn_add");
            Entity_Content entity =
                DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
                .Json2EntityFromAjaxRequest<Entity_Content>(context.Request);

            if (entity.ClassID == 0)
            {
                throw new BusinessException("请选择文章类别");
            }

            if (string.IsNullOrWhiteSpace(entity.Title))
            {
                throw new BusinessException("文章Title不能为空");
            }
            if (entity.Summary.Length > 500)
            {
                throw new BusinessException("概要长度超长");
            }
            if (string.IsNullOrWhiteSpace(entity.Description))
            {
                throw new BusinessException("文章正文不能为空");
            }
            entity.CreatedDate = DateTime.Now;
            //entity.Description = Server.HtmlEncode(entity.Description);
            entity.CreatedUserID = BusEntity_LoginUser.Sys_LoginUser.UserID;

            if (Business_Content.Add(entity) <= 0)
            {
                throw new BusinessException("添加失败，请重试");
            }
        }

        private void Delete(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_ArticleItemIndex, "btn_delete");
            int id = context.Request["ID"].ToInt();
            if (!Business_Content.Delete(id))
            {
                throw new BusinessException(string.Format("编号为[{0}]的文章删除失败，请重试。", id));
            }
        }

        private void GetPagerData(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_ArticleItemIndex, "btn_search");
            ViewQueryCondition<Entity_Content_Condition> query =
     ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<Entity_Content_Condition>>(context.Request);

            PagingResult<IList<Entity_Content_GetTableData>> result = Business_Content.GetListByPager2(query);
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