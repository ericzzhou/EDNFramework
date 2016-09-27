using DotNet.Framework.Admin.Core.Business;
using System;

namespace DotNet.Framework.Admin.UI.Pages.Other.Slide
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("other_sild_default");
        }
    }
}