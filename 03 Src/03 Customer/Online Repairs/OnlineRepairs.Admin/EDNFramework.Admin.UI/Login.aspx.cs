using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using System;

using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using System.Web;
using System.Web.Security;
using DotNet.Framework.Auth;
namespace DotNet.Framework.Admin.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";

            litDisplay.Text = "none";

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("index.aspx");
            }
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

                if (!model.Activity)
                {
                    litMessage.Text = string.Format("账户 [{0}] 未激活，请联系管理员激活。", userName);
                    litDisplay.Text = "";
                    return;
                }

                Auth.AuthUserInfo info = new Auth.AuthUserInfo()
                {
                    TrueName = model.TrueName ?? "未命名",
                    UserID = model.UserID,
                    UserName = model.UserName,
                    RoleID = Business_User.GetUserRoles(model.UserID)
                };

                string authUserData = AuthUserInfo.FormatAuthUserInfoToJson(info);


                DateTime expiration = DateTime.Now;
                //TODO 设置cookie
                if (autoSing)
                {
                    expiration = expiration.AddDays(7);
                }
                else
                {
                    expiration = expiration.AddDays(1);
                }
                string formName = model.UserID.ToString();
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1
                    , formName
                    , DateTime.Now
                    , expiration
                    , false
                    , authUserData
                    );
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket)));
                //Response.Redirect("index.aspx");
                Response.Redirect(FormsAuthentication.GetRedirectUrl(formName, false));
            }


        }
    }
}