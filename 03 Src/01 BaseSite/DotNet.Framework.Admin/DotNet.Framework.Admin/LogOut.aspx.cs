using DotNet.Framework.Admin.Core.Config;
using DotNet.Framework.Utils.Web;
using System;

namespace DotNet.Framework.Admin
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CookieManager.ClearCookie(SysConfig.Config_CookieName_AdminId);
            CookieManager.ClearCookie(SysConfig.Config_CookieName_AdminUserName);
            CookieManager.ClearCookie(SysConfig.Config_CookieName_AdminTrueName);
            Response.Redirect("Login.aspx");
        }
    }
}