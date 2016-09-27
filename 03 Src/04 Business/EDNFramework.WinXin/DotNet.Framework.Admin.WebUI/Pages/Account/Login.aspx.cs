using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet.Framework.Admin.WebUI.Pages.Account
{
    public partial class Login : System.Web.UI.Page
    {
        public string ReturnUrl { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ReturnUrl = Request["ReturnUrl"];
        }
    }
}