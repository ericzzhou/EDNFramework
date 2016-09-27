using System;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.UI.Pages.Log.ErrorLog
{
    public partial class Show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("log_sys_index");
        }
    }
}