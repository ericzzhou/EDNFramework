using DotNet.Framework.Admin.Business.EDNFramework_Product;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Entity.EDNFramework_Product;
using DotNet.Framework.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet.Framework.Admin.Pages.Product.Category
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ajax = Request["ajax"];
            if (!string.IsNullOrWhiteSpace(ajax))
            {
                switch (ajax)
                {
                    case "adddata":
                        AddData();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                CheckPermission.CheckRight("product_category_index");
            }

        }

       

        private void AddData()
        {
            Entity_Product_Class_Add entity =
               DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
               .Json2EntityFromAjaxRequest<Entity_Product_Class_Add>(Request);
            if (string.IsNullOrWhiteSpace(entity.ClassName))
            {
                throw new BusinessException("类别名称不能为空");
            }

            int userId = DotNet.Framework.Admin.Core.Entity.BusEntity_LoginUser.Sys_LoginUser.UserID;
            if (Business_Product_Class.Add(entity, userId) <= 0)
            {
                throw new BusinessException("添加失败，请重试");
            }
            Response.End();
        }
    }
}