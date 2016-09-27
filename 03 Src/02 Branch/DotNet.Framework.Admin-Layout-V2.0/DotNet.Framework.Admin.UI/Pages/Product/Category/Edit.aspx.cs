using DotNet.Framework.Admin.Core.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Entity.EDNFramework_Product;
using DotNet.Framework.Admin.Business.EDNFramework_Product;
using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.Core.Exceptions;

namespace DotNet.Framework.Admin.UI.Pages.Product.Category
{
    public partial class Edit : System.Web.UI.Page
    {
        public string json_Detail = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
           
            var ajax = Request["ajax"];
            if (ajax != null && !string.IsNullOrWhiteSpace(ajax))
            {
                switch (ajax)
                {
                    case "editdata":
                        EditData();
                        break;
                    default:
                        break;
                }

            }
            else
            {
                CheckPermission.CheckRight("product_category_index");
                GetModel();
            }
            
        }

        private void EditData()
        {
            Entity_Product_Class_Edit entity =
               DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
               .Json2EntityFromAjaxRequest<Entity_Product_Class_Edit>(Request);
            if (string.IsNullOrWhiteSpace(entity.ClassName))
            {
                throw new BusinessException("类别名称不能为空");
            }

            int userId = DotNet.Framework.Admin.Core.Entity.BusEntity_LoginUser.Sys_LoginUser.UserID;
            if (Business_Product_Class.Edit(entity, userId) <= 0)
            {
                throw new BusinessException("修改失败，请重试");
            }
            Response.End();
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