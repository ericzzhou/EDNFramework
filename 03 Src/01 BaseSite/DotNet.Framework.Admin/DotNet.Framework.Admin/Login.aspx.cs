using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using System;

using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Utils.Web;
using DotNet.Framework.Utils.Safety;
using DotNet.Framework.Admin.Core.Config;
namespace DotNet.Framework.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            litDisplay.Text = "none";
        }

        protected void btnSingIn_Click(object sender, EventArgs e)
        {
            var userName = username.Value;
            var pass = password.Value;
            var autoSing = autoLogin.Checked;

            if (userName.IsNull())
            {
                litMessage.Text = "请输入登录账户";
                litDisplay.Text = "";
                return;
            }

            if (Business_User.GetUserNameCount(userName) == 0)
            {
                litMessage.Text = string.Format("登录账户 [{0}] 不存在", userName);
                litDisplay.Text = "";
                return;
            }

            if (pass.IsNull())
            {
                litMessage.Text = "请输入登录密码";
                litDisplay.Text = "";
                return;
            }

            Entity_User model = Business_User.GetModel(userName.Trim());
            if (model == null)
            {
                litMessage.Text = string.Format("登录账户 [{0}] 不存在", userName);
                litDisplay.Text = "";
                return;
            }
            else
            {
                string uPass = model.Password;
                if (uPass != DotNet.Framework.Utils.Safety.DESEncrypt.EncryptPassword(pass))
                {
                    litMessage.Text = string.Format("登录账户 [{0}] 密码输入错误，请重试。", userName);
                    litDisplay.Text = "";
                    return;
                }

                string cookie_admin_id = DESEncrypt.Encrypt(model.UserID.ToString());
                string cookie_admin_username = DESEncrypt.Encrypt(model.UserName);
                string cookie_admin_truename = DESEncrypt.Encrypt(model.TrueName);
                //TODO 设置cookie
                if (autoSing)
                {
                    CookieManager.SetCookie(SysConfig.Config_CookieName_AdminId, cookie_admin_id);
                    CookieManager.SetCookie(SysConfig.Config_CookieName_AdminUserName, cookie_admin_username);
                    CookieManager.SetCookie(SysConfig.Config_CookieName_AdminTrueName, cookie_admin_truename);
                }
                else
                {
                    CookieManager.SetCookie(SysConfig.Config_CookieName_AdminId, cookie_admin_id, DateTime.Now.AddDays(7));
                    CookieManager.SetCookie(SysConfig.Config_CookieName_AdminUserName, cookie_admin_username, DateTime.Now.AddDays(7));
                    CookieManager.SetCookie(SysConfig.Config_CookieName_AdminTrueName, cookie_admin_truename, DateTime.Now.AddDays(7));
                }
                Response.Redirect("Index.aspx");
            }


        }
    }
}