using DotNet.Framework.Admin.Controls;
using DotNet.Framework.Admin.Core.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet.Framework.Admin.UI.Pages.ControlPanel.SYSMailConfig
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("controlpanel_SYSMailConfig_default");
        }
    }
}