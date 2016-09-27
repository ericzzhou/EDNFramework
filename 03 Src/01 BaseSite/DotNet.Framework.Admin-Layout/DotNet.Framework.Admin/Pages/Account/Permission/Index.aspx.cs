using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using System;
using System.Collections.Generic;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.Pages.Account.Permission
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("Account_Permission_Index");

            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "gettreedata":
                    GetTreeData();
                    break;
                case "getmodel":
                    GetModel();
                    break;

                case "deletedata":
                    DeleteModel();
                    break;
                case "savedata":
                    SaveData();
                    break;
                default:
                    break;
            }
        }

        private void SaveData()
        {
            string idStr = Request["id"];
            Entity_Permission entity = new Entity_Permission();
            entity.CategoryID = Request["CategoryID"].ToInt();
            entity.Description = Request["Description"];
            entity.ParentID = Request["ParentID"].ToInt();
            entity.PermissionCode = Request["PermissionCode"];
            entity.PermissionName = Request["PermissionName"];
            entity.RequestUrl = Request["RequestUrl"];
            entity.Sequence = Request["Sequence"].ToInt();

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

                if (Bussiness_Permission.Add(entity) <= 0)
                {
                    throw new BusinessException("添加失败");
                }
            }
            else
            {
                //modify
                entity.ID = idStr.ToInt();
                if (!Bussiness_Permission.Update(entity))
                {
                    throw new BusinessException("修改失败");
                }
            }
            Response.Write("{}");
            Response.End();
        }

        private void DeleteModel()
        {
            int id = Request["id"].ToInt();
            if (!Bussiness_Permission.Delete(id))
            {
                throw new BusinessException("删除失败，请重试");
            }
            Response.Write("{}");
            Response.End();
        }

        private void GetModel()
        {
            var id = Request["id"].ToInt();
            var entity = Bussiness_Permission.GetFullModel(id);
            string json = "{}";
            if (entity != null)
                json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<Entity_Permission_Full>(entity);


            Response.Write(json);
            Response.End();

        }

        private void GetTreeData()
        {
            var entity = Bussiness_Permission.GetPermissionTreeData();
            entity.Insert(0, new Entity_PermissionTree()
            {
                id = 0,
                pid = -1,
                name = "Root",
                open = true
            });
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<IList<Entity_PermissionTree>>(entity);
            Response.Write(json);
            Response.End();
        }
    }
}