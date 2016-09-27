using DotNet.Framework.Admin.Core.Config;
using DotNet.Framework.Admin.Core.Enums;
using System;

namespace DotNet.Framework.Admin.UI.Controls
{
    public partial class Control_SubNavbar : System.Web.UI.UserControl
    {
        public Navigation CurrentNav { get; set; }
        public string ResourcePath = ConfigHelper.ResourcePath;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}