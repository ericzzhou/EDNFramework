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

namespace DotNet.Framework.Admin.UI.Pages.Product.Item
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            var ajax = Request["ajax"];
            if (ajax == null || ajax == "")
            {
                CheckPermission.CheckRight("product_item_index");
            }
            else
            {
                switch (ajax)
                {
                    case "add":
                        AddData();
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddData()
        {
            Entity_Product_Item_Add entity =
               DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
               .Json2EntityFromAjaxRequest<Entity_Product_Item_Add>(Request);
            if (string.IsNullOrWhiteSpace(entity.PName))
            {
                throw new BusinessException("产品名称不能为空");
            }
            if (entity.ClassID <=0 )
            {
                throw new BusinessException("请选择产品类型");
            }
            if (entity.Summary.Length > 500)
            {
                throw new BusinessException("产品概要长度太长");
            }
            int userId = DotNet.Framework.Admin.Core.Entity.BusEntity_LoginUser.Sys_LoginUser.UserID;
            if (Business_Product_Item.Add(entity, userId) <= 0)
            {
                throw new BusinessException("添加失败，请重试");
            }
            Response.End();
        }
    }
}