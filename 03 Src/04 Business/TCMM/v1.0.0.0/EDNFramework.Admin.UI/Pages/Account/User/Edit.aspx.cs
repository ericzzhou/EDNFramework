using System;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.UI.Pages.Account.User
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("Account_User_Index");
        }

    }
}