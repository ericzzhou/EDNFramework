using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Entity.EDNFramework_Product;
using System;
using System.Collections.Generic;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.Admin.Business.EDNFramework_Product;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Admin.Entity.EDNFramework_Product.ViewQueryCondition;
namespace DotNet.Framework.Admin.UI.Pages.Product.Item
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ajax = Request.QueryString["ajax"];
            if (string.IsNullOrWhiteSpace(ajax))
            {
                CheckPermission.CheckRight("product_category_index");
            }

            switch (ajax)
            {
                case "getPagerData":
                    GetPagerData();
                    break;
                //case "addCategory":
                //    addCategory();
                //    break;
                case "delete":
                    Delete();
                    break;
                case "recycle":
                    Recycle();
                    break;
                default:
                    break;
            }

        }

        private void Recycle()
        {
            int id = Request["ClassID"].ToInt();

            if (!Business_Product_Item.Recycle(id))
            {
                throw new BusinessException("回收失败。");
            }
            else
            {
                Response.Write("{}");
            }

            Response.End();
        }

        private void Delete()
        {
            int id = Request["ClassID"].ToInt();

            if (!Business_Product_Item.Delete(id))
            {
                throw new BusinessException("删除失败。");
            }
            else
            {
                Response.Write("{}");
            }

            Response.End();
        }

        private void GetPagerData()
        {

            ViewQueryCondition<Entity_Product_Condition> query =
ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<Entity_Product_Condition>>(Request);

            PagingResult<IList<Entity_Product_ItemGrid>> result = Business_Product_Item.GetListByPager(query);
            Response.Write(result.ToString());
            Response.End();


            //int pageindex = Request["pageindex"].ToInt();
            //int pagesize = Request["pagesize"].ToInt();
            //string orderField = Request["orderField"];
            //string dir = Request["sortDir"];

            //int totolCount = 0;
            //IList<Entity_Product_ItemGrid> pageResult =
            //    Business_Product_Item.GetListByPager(pageindex, pagesize, orderField, dir, out totolCount) ?? new List<Entity_Product_ItemGrid>();

            //var json = ObjectJsonSerializer.Serialize<IList<Entity_Product_ItemGrid>>(pageResult);
            //Response.Write("{\"totalRecords\": " + totolCount + ", \"curPage\": " + pageindex + ",\"data\":" + json + " }");
            //Response.End();

        }
    }
}