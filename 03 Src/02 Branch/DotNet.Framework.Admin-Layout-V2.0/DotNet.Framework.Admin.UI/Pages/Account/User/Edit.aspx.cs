using System;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.UI.Pages.Account.User
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("Account_User_Index");
            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "getmodel":
                    GetModel();
                    break;
                case "updatemodel":
                    UpdateModel();
                    break;
                default:
                    break;
            }
        }

        private void UpdateModel()
        {
            int UserID = Request["UserID"].ToInt();
            Entity_User entity = new Entity_User();
            entity.UserID = UserID;
            entity.Activity = Request["Activity"].ToBoolean();
            entity.Email = Request["Email"];
            entity.NickName = Request["NickName"];

            entity.Phone = Request["Phone"];
            entity.Sex = Request["Sex"];
            entity.TrueName = Request["TrueName"];
            entity.UserName = Request["UserName"];
            entity.UserType = Request["UserType"];
            entity.DepartmentID = Request["DepartmentID"];
            string pass = Request["Password"];
            if (!pass.IsNull())
                entity.Password = DotNet.Framework.Utils.Safety.DESEncrypt.EncryptPassword(pass);

            if (!Business_User.Update(entity))
            {
                throw new BusinessException("更新失败");
            }

            Response.Write("{}");
            Response.End();
        }

        private void GetModel()
        {
            int UserId = Request["id"].ToInt();


            var entity = Business_User.GetModel(UserId);
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<Entity_User>(entity);
            Response.Write(json);
            Response.End();

        }
    }
}