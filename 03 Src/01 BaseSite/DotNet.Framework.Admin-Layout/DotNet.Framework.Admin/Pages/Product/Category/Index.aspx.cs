using DotNet.Framework.Admin.Core.Business;
using System;
using DotNet.Framework.Core.Extends;
using System.Collections.Generic;
using DotNet.Framework.Admin.Entity.EDNFramework_Product;
using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.Admin.Business.EDNFramework_Product;
using DotNet.Framework.Core.Exceptions;
namespace DotNet.Framework.Admin.Pages.Product.Category
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
                    getPagerData();
                    break;
                //case "addCategory":
                //    addCategory();
                //    break;
                case "deleteclass":
                    DeleteClass();
                    break;
                default:
                    break;
            }
        }

        private void DeleteClass()
        {
            int classID = Request["ClassID"].ToInt();

            if (!Business_Product_Class.Delete(classID))
            {
                throw new BusinessException("删除失败。");
            }
            else
            {
                Response.Write("{}");
            }

            Response.End();
        }

        private void getPagerData()
        {
            int pageindex = Request["pageindex"].ToInt();
            int pagesize = Request["pagesize"].ToInt();
            string orderField = Request["orderField"];
            string dir = Request["sortDir"];

            int totolCount = 0;
            IList<Entity_Product_Class_PagerGrid> pageResult = Business_Product_Class.GetListByPager(pageindex, pagesize, orderField, dir, out totolCount);

            var json = ObjectJsonSerializer.Serialize<IList<Entity_Product_Class_PagerGrid>>(pageResult);
            Response.Write("{\"totalRecords\": " + totolCount + ", \"curPage\": " + pageindex + ",\"data\":" + json + " }");
            Response.End();
        }
    }
}