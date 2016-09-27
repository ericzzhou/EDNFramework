using DotNet.Framework.Admin.Core.Config;
using DotNet.Framework.Utils.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet.Framework.Admin
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string admin_id = CookieManager.GetCookieValue(SysConfig.Config_CookieName_AdminId);
            string admin_username = CookieManager.GetCookieValue(SysConfig.Config_CookieName_AdminUserName);

            if (string.IsNullOrWhiteSpace(admin_id) || string.IsNullOrWhiteSpace(admin_username))
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("/pages/Index.aspx");
            }
        }
    }
}