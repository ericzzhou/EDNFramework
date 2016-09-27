using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WindowsServiceController
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string userPass = txtPasswork.Text.Trim();

            if (userName == ConfigurationManager.AppSettings["userName"] &&
                userPass == ConfigurationManager.AppSettings["userPass"])
            {
                Session["userName"] = userName;
                Response.Redirect("~/Manage/Index.aspx");
            }
            else
            {
                litMessage.Text = "账号密码错误";
            }
        }
    }
}