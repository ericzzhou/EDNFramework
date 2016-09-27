using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using System;
using System.Collections.Generic;
using System.Web;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.UI.Ajax.Account
{
    /// <summary>
    /// Permission 的摘要说明
    /// </summary>
    public class Permission : IHttpHandler
    {
        public string PermissionCode = "Account_Permission_Index";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string ajax = context.Request.QueryString["ajax"];
            switch (ajax.ToLower())
            {
                case "gettreedata":
                    GetTreeData(context);
                    break;
                case "getmodel":
                    GetModel(context);
                    break;
                case "deletedata":
                    Delete(context);
                    break;
                case "savedata":
                    Save(context);
                    break;
                case "getcategories":
                    GetPermissionCategories(context);
                    break;
                case "getpermissionnames":
                    GetPermissionNames(context);
                    break;
                default:
                    break;
            }
        }

        private void GetPermissionNames(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private void GetPermissionCategories(HttpContext context)
        {
            IList<Entity_PermissionCategories> Entities = Business_PermissionCategories.GetAll();
            context.Response.ContentType = "text/json";
            var json = ObjectJsonSerializer.Serialize<IList<Entity_PermissionCategories>>(Entities);
            context.Response.Write(json);
        }

        private void Save(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_add");
            string idStr = context.Request["id"];
            Entity_Permission entity = new Entity_Permission();
            entity.CategoryID = context.Request["CategoryID"].ToInt();
            entity.Description = context.Request["Description"];
            entity.ParentID = context.Request["ParentID"].ToInt();
            entity.PermissionCode = context.Request["PermissionCode"];
            entity.PermissionName = context.Request["PermissionName"];
            entity.RequestUrl = context.Request["RequestUrl"];
            entity.Sequence = context.Request["Sequence"].ToInt();

            if (string.IsNullOrWhiteSpace(entity.PermissionCode))
            {
                throw new BusinessException("权限Code不能为空");
            }
            if (string.IsNullOrWhiteSpace(entity.PermissionName))
            {
                throw new BusinessException("权限名不能为空");
            }

            if (string.IsNullOrWhiteSpace(idStr))
            {
                //add
                entity.CreateDate = DateTime.Now;

                if (Bussines_Permission.Add(entity) <= 0)
                {
                    throw new BusinessException("添加失败");
                }
            }
            else
            {
                //modify
                entity.ID = idStr.ToInt();
                if (!Bussines_Permission.Update(entity))
                {
                    throw new BusinessException("修改失败");
                }
            }
            context.Response.Write("{}");
        }

        private void Delete(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_delete");
            int id = context.Request["id"].ToInt();
            if (!Bussines_Permission.Delete(id))
            {
                throw new BusinessException("删除失败，请重试");
            }
            context.Response.Write("{}");
        }

        private void GetModel(HttpContext context)
        {
            var id = context.Request["id"].ToInt();
            var entity = Bussines_Permission.GetFullModel(id);
            string json = "{}";
            if (entity != null)
                json = ObjectJsonSerializer.Serialize<Entity_Permission_Full>(entity);


            context.Response.Write(json);
        }

        private void GetTreeData(HttpContext context)
        {
            var entity = Bussines_Permission.GetPermissionTreeData();
            entity.Insert(0, new Entity_PermissionTree()
            {
                id = 0,
                pid = -1,
                name = "Root",
                open = true
            });
            var json = ObjectJsonSerializer.Serialize<IList<Entity_PermissionTree>>(entity);
            context.Response.Write(json);
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