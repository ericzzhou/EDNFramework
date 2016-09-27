using DotNet.Framework.Admin.Core.Business;
using System;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Entity.EDNFramework_Product;
using DotNet.Framework.Admin.Business.EDNFramework_Product;
using DotNet.Framework.Utils.Serialization;

namespace DotNet.Framework.Admin.UI.Pages.Product.Category
{
    public partial class Edit : System.Web.UI.Page
    {
        public string json_Detail = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("product_category_index");
            GetModel();
        }

        private void GetModel()
        {
            int id = Request["classid"].ToInt();
            if (id > 0)
            {
                Entity_Product_Class_Edit model = Business_Product_Class.GetModel(id) ?? new Entity_Product_Class_Edit();
                json_Detail = ObjectJsonSerializer
                 .Serialize<Entity_Product_Class_Edit>(model);
            }

        }
    }
}