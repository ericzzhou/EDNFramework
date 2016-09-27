using DotNet.Framework.Admin.Core.Business;
using System;
namespace DotNet.Framework.Admin.UI.Pages.Articles.Category
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("article_category_index");
        }
    }
}