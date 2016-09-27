using DotNet.Framework.Admin.Core.Config;
using DotNet.Framework.Utils.Web;
using System;

namespace DotNet.Framework.UI.Admin
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            
            CookieManager.SetCookie(SysConfig.Config_CookieName_AdminId, "", DateTime.Now.AddDays(-1000));
            CookieManager.SetCookie(SysConfig.Config_CookieName_AdminUserName, "", DateTime.Now.AddDays(-1000));
            CookieManager.SetCookie(SysConfig.Config_CookieName_AdminTrueName, "", DateTime.Now.AddDays(-1000));
            var c =CookieManager.GetCookieValue(SysConfig.Config_CookieName_AdminId);
            Response.Redirect("Login.aspx",true);
        }
    }
}