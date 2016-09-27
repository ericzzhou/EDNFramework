using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Controls;
using DotNet.Framework.Admin.Core.Entity;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using System;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Core.Config;
using DotNet.Framework.Utils.Web;
using DotNet.Framework.Utils.Safety;
namespace DotNet.Framework.Admin.Pages.Account.User
{
    public partial class ModifyInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master.FindControl("SubNavbar") as Control_SubNavbar).CurrentNav = Core.Enums.Navigation.ACCOUNT;
            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "getmodel":
                    GetModel();
                    break;
                case "update":
                    UpdateModel();
                    break;
                default:
                    break;
            }
        }

        private void UpdateModel()
        {
            Entity_User entity =
                DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
                .Json2EntityFromAjaxRequest<Entity_User>(Request);
            if (entity.NickName.IsNull())
            {
                throw new Exception("昵称不能为空");
            }

            Entity_User model = Business_User.GetModel(BusEntity_LoginUser.Sys_LoginUser.UserID);
            model.NickName = entity.NickName;
            model.Sex = entity.Sex;
            model.Phone = entity.Phone;
            model.Email = entity.Email;
            if (!Business_User.Update(model))
                throw new Exception("个人资料修改失败.");
            else
            {
                //更新cookie
                CookieManager.ChangeCookieValue(SysConfig.Config_CookieName_AdminTrueName, DESEncrypt.Encrypt(entity.NickName));
                Response.End();
            }
        }

        private void GetModel()
        {
            var entity = Business_User.GetModel(BusEntity_LoginUser.Sys_LoginUser.UserID);
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<Entity_User>(entity);
            Response.Write(json);
            Response.End();

        }
    }
}