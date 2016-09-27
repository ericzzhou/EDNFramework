using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Entity.EDNFramework_Product;
using DotNet.Framework.Utils.Serialization;
using System;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Business.EDNFramework_Product;
namespace DotNet.Framework.Admin.UI.Pages.Product.Item
{
    public partial class Edit : System.Web.UI.Page
    {
        public string model_json = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("product_item_index");
            GetModel();
        }

        private void GetModel()
        {
            int id = Request["id"].ToInt();
            if (id > 0)
            {
                Entity_Product_Item_Edit model = Business_Product_Item.GetModel(id) ?? new Entity_Product_Item_Edit();
                model_json = ObjectJsonSerializer
                 .Serialize<Entity_Product_Item_Edit>(model);
            }
        }
    }
}