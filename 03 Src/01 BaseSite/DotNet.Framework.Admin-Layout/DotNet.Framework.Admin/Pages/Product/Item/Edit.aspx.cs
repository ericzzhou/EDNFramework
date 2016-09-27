using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Entity.EDNFramework_Product;
using DotNet.Framework.Utils.Serialization;
using System;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Business.EDNFramework_Product;
using DotNet.Framework.Core.Exceptions;
namespace DotNet.Framework.Admin.Pages.Product.Item
{
    public partial class Edit : System.Web.UI.Page
    {
        public string model_json = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
            var ajax = Request["ajax"];
            if (ajax == null || ajax == "")
            {
                CheckPermission.CheckRight("product_item_index");
                GetModel();
            }
            else
            {
                switch (ajax)
                {
                    case "edit":
                        EditData();
                        break;
                    default:
                        break;
                }
            }
        }

        private void EditData()
        {
            Entity_Product_Item_Edit entity =
                DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
                .Json2EntityFromAjaxRequest<Entity_Product_Item_Edit>(Request);
            if (string.IsNullOrWhiteSpace(entity.PName))
            {
                throw new BusinessException("产品名称不能为空");
            }
            if (entity.ClassID <= 0)
            {
                throw new BusinessException("请选择产品类型");
            }

            int userId = DotNet.Framework.Admin.Core.Entity.BusEntity_LoginUser.Sys_LoginUser.UserID;
            if (Business_Product_Item.Edit(entity, userId) <= 0)
            {
                throw new BusinessException("保存失败，请重试");
            }
            Response.End();
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