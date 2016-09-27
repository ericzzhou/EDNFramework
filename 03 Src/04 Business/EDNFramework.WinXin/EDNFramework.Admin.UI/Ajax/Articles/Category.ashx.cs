using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Core.Entity;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.UI.Ajax.Articles
{
    /// <summary>
    /// Category 的摘要说明
    /// </summary>
    public class Category : IHttpHandler
    {
        public string PermissionCode_ArticleCategoryIndex = "article_category_index";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            string ajax = context.Request.QueryString["ajax"];
            switch (ajax.ToLower())
            {
                case "getpagerdata":
                    GetPagerData(context);
                    break;
                case "addcategory":
                    AddCategory(context);
                    break;
                case "deletecategory":
                    DeleteCategory(context);
                    break;
                case "getclasstype":
                    GetClassType(context);
                    break;
                case "getclasslist":
                    GetClassList(context);
                    break;
                case "getclass":
                    GetClass(context);
                    break;
                case "getclassinfo":
                    GetClassInfo(context);
                    break;
                case "updatedata":
                    UpdateData(context);
                    break;

            }
        }

        private void UpdateData(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_ArticleCategoryIndex, "btn_modify");
            int ClassID = context.Request["ClassID"].ToInt();
            int ClassTypeID = context.Request["ClassTypeID"].ToInt();
            int Sequence = context.Request["Sequence"].ToInt();
            bool State = context.Request["State"].ToBoolean();
            bool AllowAddContent = context.Request["AllowAddContent"].ToBoolean();
            string ClassName = context.Request["ClassName"];
            string Description = context.Request["Description"];
            string Meta_Title = context.Request["Meta_Title"];
            string SeoUrl = context.Request["SeoUrl"];
            string Meta_Keywords = context.Request["Meta_Keywords"];
            string Meta_Description = context.Request["Meta_Description"];

            if (string.IsNullOrWhiteSpace(ClassName))
            {
                throw new BusinessException("类别名称不能为空");
            }

            Entity_ContentClass_Model entity = new Entity_ContentClass_Model();
            entity.ClassID = ClassID;
            entity.AllowAddContent = AllowAddContent;
            entity.ClassName = ClassName;
            entity.ClassTypeID = ClassTypeID;
            entity.Description = Description;
            entity.Meta_Description = Meta_Description;
            entity.Meta_Keywords = Meta_Keywords;
            entity.Meta_Title = Meta_Title;
            entity.SeoUrl = SeoUrl;
            entity.Sequence = Sequence;
            entity.State = State;
            entity.CreatedUserID = BusEntity_LoginUser.Sys_LoginUser.UserID;

            if (Business_ContentClass.Update(entity) <= 0)
            {
                throw new BusinessException("更新失败，请重试");
            }
        }

        private void GetClassInfo(HttpContext context)
        {
            int ClassID = context.Request["ClassID"].ToInt();
            if (ClassID > 0)
            {
                Entity_ContentClass_Model entity = Business_ContentClass.GetModel(ClassID);
                var json = ObjectJsonSerializer.Serialize<Entity_ContentClass_Model>(entity);
                context.Response.Write(json);
            }
        }

        private void GetClass(HttpContext context)
        {
            var Entities = Business_ContentClass.GetEntity_ContentClass_DropDownList();
            var json = ObjectJsonSerializer.Serialize<IList<Entity_ContentClass_DropDownList>>(Entities);
            context.Response.Write(json);
        }

        private void GetClassList(HttpContext context)
        {
            var Entities = Business_ContentClass.GetAll();
            var json = ObjectJsonSerializer.Serialize<IList<Entity_ContentClass_GetList>>(Entities);
            context.Response.Write("{\"aaData\":" + json + "}");
        }

        private void GetClassType(HttpContext context)
        {
            var Entities = Business_ClassType.GetAll();
            var json = ObjectJsonSerializer.Serialize<IList<Entity_ClassType>>(Entities);
            context.Response.Write(json);
        }

        private void DeleteCategory(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_ArticleCategoryIndex, "btn_delete");
            int id = context.Request["ID"].ToInt();

            if (Business_ContentClass.Delete(id) <= 0)
            {
                throw new BusinessException("删除失败");
            }
        }

        private void AddCategory(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_ArticleCategoryIndex, "btn_add");
            Entity_ContentClass_Model entity =
               ObjectJsonSerializer.Json2EntityFromAjaxRequest<Entity_ContentClass_Model>(context.Request);
            if (string.IsNullOrWhiteSpace(entity.ClassName))
            {
                throw new BusinessException("类别名称不能为空");
            }
            entity.CreatedUserID = BusEntity_LoginUser.Sys_LoginUser.UserID;

            if (Business_ContentClass.Add(entity) <= 0)
            {
                throw new BusinessException("添加失败，请重试");
            }
        }

        private void GetPagerData(HttpContext context)
        {
            ViewQueryCondition<object>
             query =
                ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<object>>(context.Request);

            PagingResult<IList<Entity_ContentClass_GetList>> result = Business_ContentClass.GetListByPager(query);
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