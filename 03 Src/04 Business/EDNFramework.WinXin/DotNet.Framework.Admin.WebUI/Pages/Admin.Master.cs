using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet.Framework.Admin.WebUI.Pages
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        public static string ResourcePath
        {
            get
            {
                return DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ednf_treemenu.Menu = Request["menuid"];
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("/pages/account/login.aspx?ReturnUrl=" + this.Request.RawUrl, true);
            }
        }
    }
}