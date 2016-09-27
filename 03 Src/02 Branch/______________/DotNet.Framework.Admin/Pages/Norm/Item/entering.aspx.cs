using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Business.Hospital;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.Hospital;
using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
using DotNet.Framework.Core.Extends;
namespace DotNet.Framework.Admin.Pages.Norm.Item
{
    public partial class entering : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "getdata":
                    GetData();
                    break;

            }
        }

        private void GetData()
        {
            int categoryId = Request["categoryId"].ToInt();
            //获取指标目录列表
            IList<Entity_Hospital_NormItem> ItemList = Business_Hospital_NormItem.GetListByCategoryID(categoryId);
            //var json_item = ObjectJsonSerializer.Serialize<IList<Entity_Hospital_NormItem>>(ItemList);

            //获取部门列表
            IList<Entity_Department> Department = Business_Department.GetList();
            //var json_Department = ObjectJsonSerializer.Serialize<IList<Entity_Department>>(Department);

            dynamic res = new
            {
                Department = Department ?? new List<Entity_Department>(),
                Norm = ItemList ?? new List<Entity_Hospital_NormItem>()
            };
            //string jsonResult = string.Format("Norm:{0},Department:{1}", json_item, json_Department);
            string jsonResult = ObjectJsonSerializer.Serialize<dynamic>(res);
            Response.Write(jsonResult);
            Response.End();

        }
    }
}