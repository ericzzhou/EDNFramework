using DotNet.Framework.Admin.Core.Business;
using System;

namespace DotNet.Framework.Admin.UI.Pages.Articles.Item
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("article_item_add");
        }
    }
}