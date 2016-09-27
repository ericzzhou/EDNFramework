using DotNet.Framework.Admin.Core.Config;
using DotNet.Framework.Utils.Web;
using System;

namespace DotNet.Framework.Admin.UI
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";

            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("index.aspx"); 
        }
    }
}