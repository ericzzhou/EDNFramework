using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using System;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Core.Entity;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Utils.Safety;
namespace DotNet.Framework.Admin.Pages.Account.User
{
    public partial class ModifyPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "modifypass":
                    ChangePass();
                    break;
            }
        }

        private void ChangePass()
        {
            Entity_ChangePass entity =
                DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
                .Json2EntityFromAjaxRequest<Entity_ChangePass>(Request);
            if (entity == null)
            {
                throw new Exception("数据序列号失败，请刷新重试。");
            }

            if (entity.Password.IsNull())
            {
                throw new Exception("旧密码不能为空。");
            }
            if (entity.Password_new.IsNull())
            {
                throw new Exception("新密码不能为空。");
            }
            if (entity.Password_new2.IsNull())
            {
                throw new Exception("重复新密码不能为空。");
            }
            if (entity.Password_new != entity.Password_new2)
            {
                throw new Exception("两次新密码输入不一致。");
            }

            entity.UserID = BusEntity_LoginUser.Sys_LoginUser.UserID;
            Entity_User model = Business_User.GetModel(entity.UserID);

            if (model == null)
            {
                throw new Exception("密码修改失败，账户信息不存在");
            }

            if (model.Password != DESEncrypt.EncryptPassword(entity.Password))
            {
                throw new Exception("密码修改失败，旧密码错误.");
            }
            model.Password = DESEncrypt.EncryptPassword(entity.Password_new);

            //if (Business_User.Update(model))
            //{
            //    Response.Write("{}");
            //    Response.End();
            //}
            //else
            //{
            //    throw new Exception("密码修改失败.");
            //}

            if (!Business_User.Update(model))
                throw new Exception("密码修改失败.");
            else
            {
                Response.End();
            }
        }
    }
}