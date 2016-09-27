using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Business.Hospital;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.Hospital;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNet.Framework.Core.Extends;
using System.Data;
namespace DotNet.Framework.Admin.Pages.Norm.Item
{
    /// <summary>
    /// ajax1 的摘要说明
    /// </summary>
    public class ajax1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var ajax = context.Request.QueryString["ajax"];
            switch (ajax)
            {
                case "getnorms":
                    GetNorms(context);
                    break;
                case "getdata":
                    GetData(context);
                    break;
                case "getpagerdata":
                    GetPagerData(context);
                    break;
                case "getsearchview":
                    GetSearchTable(context);
                    break;
            }
        }

        private void GetSearchTable(HttpContext context)
        {
            int categoryId = context.Request["categoryId"].ToInt();
            int normId = context.Request["normId"].ToInt();
            string departmentId = context.Request["departmentId"];

            DateTime? startTime = context.Request["startTime"].ToDateTime2();
            DateTime? endTime = context.Request["endTime"].ToDateTime2();

            //IList<Entity_Hospital_NormValue_Search> entities
            //    = Business_Hospital_NormValue.GetList(
            //    categoryId, normId, departmentId, startTime, endTime)??new List<Entity_Hospital_NormValue_Search>();
            //var json = ObjectJsonSerializer
            //    .Serialize<IList<Entity_Hospital_NormValue_Search>>(entities);

            DataSet entities
                = Business_Hospital_NormValue.GetDataSetList(
                categoryId, normId, departmentId, startTime, endTime);
            var json = ObjectJsonSerializer
                .Serialize_NewTon<DataTable>(entities.Tables[0]);

            context.Response.Write(json);
            context.Response.End();
        }

        private void GetPagerData(HttpContext context)
        {
            int pageindex = context.Request["pageindex"].ToInt();
            int pagesize = context.Request["pagesize"].ToInt();
            string orderField = context.Request["orderField"];
            string dir = context.Request["sortDir"];

            int categoryId = context.Request["categoryId"].ToInt();
            int normId = context.Request["normId"].ToInt();
            int departmentId = context.Request["departmentId"].ToInt();

            DateTime? startTime = context.Request["startTime"].ToDateTime2();
            DateTime? endTime = context.Request["endTime"].ToDateTime2();

            int totolCount = 0;
            IList<Entity_Hospital_NormValue_Search> pageResult
                = Business_Hospital_NormValue.GetListByPager(
                pageindex, pagesize, orderField, dir,
                categoryId, normId, departmentId, startTime, endTime,
                out totolCount);

            var json = ObjectJsonSerializer.Serialize<IList<Entity_Hospital_NormValue_Search>>(pageResult);
            context.Response.Write("{\"totalRecords\": "
                + totolCount + ", \"curPage\": " + pageindex + ",\"data\":" + json + " }");
            context.Response.End();

        }

        private void GetData(HttpContext context)
        {
            int categoryId = context.Request["categoryId"].ToInt();
            int normId = context.Request["normId"].ToInt();
            int departmentId = context.Request["departmentId"].ToInt();

            DateTime? startTime = context.Request["startTime"].ToDateTime2();
            DateTime? endTime = context.Request["endTime"].ToDateTime2();

            IList<Entity_Hospital_NormItem> ItemList =
                Business_Hospital_NormItem.GetNormItems(categoryId, normId, departmentId, startTime, endTime);

            //获取部门列表
            IList<Entity_Department> Department = Business_Department.GetList(departmentId);

            dynamic res = new
            {
                Department = Department ?? new List<Entity_Department>(),
                Norm = ItemList ?? new List<Entity_Hospital_NormItem>()
            };
            string jsonResult = ObjectJsonSerializer.Serialize<dynamic>(res);
            context.Response.Write(jsonResult);
            //context.Response.End();

        }

        private void GetNorms(HttpContext context)
        {
            int categoryId = context.Request["categoryId"].ToInt();
            //获取指标目录列表
            IList<Entity_Hospital_NormItem> norms =
                Business_Hospital_NormItem.GetListByCategoryID(categoryId)
                ?? new List<Entity_Hospital_NormItem>();
            var json = ObjectJsonSerializer.Serialize<IList<Entity_Hospital_NormItem>>(norms);
            context.Response.Write(json);
            //context.Response.End();

        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}