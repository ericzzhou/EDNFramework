using System;
using DotNet.Framework.Core.Extends;
using System.Collections.Generic;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.Pages.Account.Department
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("Account_Department_Index");
            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "getpagerdata":
                    GetPagerData();
                    break;
                case "deletemodel":
                    DeleteModel();
                    break;
                //default:
                //    break;
            }

        }

        private void DeleteModel()
        {
            int Id = Request["id"].ToInt();
            if (Id > 0)
            {
                if (!Business_Department.Delete(Id))
                {
                    throw new BusinessException("删除部门失败");
                }
            }

            Response.Write("{}");
            Response.End();

        }

        private void GetPagerData()
        {
            int pageindex = Request["pageindex"].ToInt();
            int pagesize = Request["pagesize"].ToInt();

            string orderField = Request["orderField"];
            string dir = Request["sortDir"];


            int totolCount = 0;

            IList<Entity_Department> Entities = Business_Department.GetListByPager(pageindex, pagesize, orderField, dir, out totolCount);
            var json = ObjectJsonSerializer.Serialize<IList<Entity_Department>>(Entities);
            Response.Write("{\"totalRecords\": " + totolCount + ", \"curPage\": " + pageindex + ",\"data\":" + json + " }");
            Response.End();

        }
    }
}