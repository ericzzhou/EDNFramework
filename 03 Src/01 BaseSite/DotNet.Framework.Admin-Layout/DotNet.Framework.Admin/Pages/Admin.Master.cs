using DotNet.Framework.Admin.Core.BasePage;
using DotNet.Framework.Admin.Core.Enums;
using System;
using System.Web;

namespace DotNet.Framework.Admin.Pages
{
    public partial class Admin : Base_MasterPage
    {
        public Navigation MasterCurrentNav { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            Context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        }
    }
}