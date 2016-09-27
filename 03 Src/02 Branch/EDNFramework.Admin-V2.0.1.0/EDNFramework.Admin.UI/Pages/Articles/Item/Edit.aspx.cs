using System;
using DotNet.Framework.Admin.Core.Business;


namespace DotNet.Framework.Admin.UI.Pages.Articles.Item
{
    public partial class Edit : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("article_item_add");
        }
    }
}