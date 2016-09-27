using System;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.UI.Pages.ControlPanel.SYSConfig
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("controlpanel_sysConfig_default");
        }
    }
}