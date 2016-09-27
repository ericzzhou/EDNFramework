using DotNet.Framework.Admin.Core.Business;
using System;
namespace DotNet.Framework.Admin.UI.Pages.Product.Item
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("product_category_index");
        }
    }
}