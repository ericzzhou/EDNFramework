using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Core.Entity;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Business.EDNFramework_SYS;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.UI.Ajax.Account
{
    /// <summary>
    /// User 的摘要说明
    /// </summary>
    public class User : IHttpHandler
    {
        public string PermissionCode = "Account_User_Index";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            string ajax = context.Request.QueryString["ajax"];
            switch (ajax.ToLower())
            {
                case "getlist":
                    GetList(context);
                    break;
                case "deletemodel":
                    Delete(context);
                    break;
                case "getdepartment":
                    GetDepartment(context);
                    break;


                case "adddata":
                    AddUser(context);
                    break;
                case "updatemodel":
                    UpdateModel(context);
                    break;

                case "getmodel":
                    GetModel(context);
                    break;
            }
        }

        private void GetModel(HttpContext context)
        {
            int UserId = context.Request["id"].ToInt();

            var entity = Business_User.GetModel(UserId);
            var json = ObjectJsonSerializer.Serialize<Entity_User>(entity);
            context.Response.Write(json);
        }

        private void UpdateModel(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_modify");
            int UserID = context.Request["UserID"].ToInt();
            Entity_User entity = new Entity_User();
            entity.UserID = UserID;
            entity.Activity = context.Request["Activity"].ToBoolean();
            entity.Email = context.Request["Email"];
            entity.NickName = context.Request["NickName"];

            entity.Phone = context.Request["Phone"];
            entity.Sex = context.Request["Sex"];
            entity.TrueName = context.Request["TrueName"];
            entity.UserName = context.Request["UserName"];
            entity.UserType = context.Request["UserType"];
            entity.DepartmentID = context.Request["DepartmentID"];
            string pass = context.Request["Password"];
            if (!pass.IsNull())
                entity.Password = DotNet.Framework.Utils.Safety.DESEncrypt.EncryptPassword(pass);

            if (!Business_User.Update(entity))
            {
                throw new BusinessException("更新失败");
            }
        }

        private void AddUser(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_add");
            Entity_User entity = new Entity_User();
            entity.Activity = context.Request["Activity"].ToBoolean();
            entity.Email = context.Request["Email"];
            entity.NickName = context.Request["NickName"];
            entity.Password = Utils.Safety.DESEncrypt.EncryptPassword(Business_ConfigContent.GetValueByKey(Core.Config.SysConfig.Default_Password));
            entity.Phone = context.Request["Phone"];
            entity.Sex = context.Request["Sex"];
            entity.UserName = context.Request["UserName"];
            entity.UserType = context.Request["UserType"];

            if (string.IsNullOrWhiteSpace(entity.UserType))
            {
                throw new BusinessException("请选择账号类型");
            }

            if (string.IsNullOrWhiteSpace(entity.Sex))
            {
                throw new BusinessException("请选择性别");
            }

            int defaultRole = Convert.ToInt32(Business_ConfigContent.GetValueByKey(DotNet.Framework.Admin.Core.Config.SysConfig.Default_UserRoleID));
            if (Business_User.Add(entity, defaultRole) <= 0)
            {
                throw new BusinessException("添加失败");
            }
        }

        private void GetDepartment(HttpContext context)
        {
            var Entities = Business_Department.GetList();
            var json = ObjectJsonSerializer.Serialize<IList<Entity_Department>>(Entities);
            context.Response.Write(json);
        }

        private void Delete(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_delete");
            int userId = context.Request["id"].ToInt();
            if (userId == BusEntity_LoginUser.Sys_LoginUser.UserID)
            {
                throw new BusinessException(string.Format("用户 {0} 不允许删除自己", DotNet.Framework.Admin.Core.Entity.BusEntity_LoginUser.Sys_LoginUser.UserName));
            }
            if (!Business_User.Delete(userId))
            {
                throw new BusinessException("删除失败");
            }
        }

        private void GetList(HttpContext context)
        {
            ViewQueryCondition<object> query =
ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<object>>(context.Request);

            PagingResult<IList<Entity_UserTableData>> result = Business_User.GetListByPager(query);
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