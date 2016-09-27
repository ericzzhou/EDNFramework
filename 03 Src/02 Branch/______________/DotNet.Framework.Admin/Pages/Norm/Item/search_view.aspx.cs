using DotNet.Framework.Admin.Business.Hospital;
using DotNet.Framework.Admin.Entity.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Framework.Core.Extends;
using System.Data;
using DotNet.Framework.Utils.Serialization;
using System.Text;
namespace DotNet.Framework.Admin.Pages.Norm.Item
{
    public partial class search_view : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.hidDepartment.Value = Request["categoryId"];
            var ajax = Request["ajax"];

            switch (ajax)
            {
                case "getsearchview":
                    GetSearchTable();
                    break;
                case "formatsearchviewdate":
                    GetSearchTableDate();
                    break;
                case "formatsearchtablehtml":
                    FormatSearchTableHtml();
                    break;
            }
        }

        private void FormatSearchTableHtml()
        {
            int categoryId = Request["categoryId"].ToInt();
            int normId = Request["normId"].ToInt();
            string normName = Request["normName"];
            string departmentId = Request["departmentId"];

            DateTime? startTime = Request["startTime"].ToDateTime2();
            DateTime? endTime = Request["endTime"].ToDateTime2();

            DataSet ds
                = Business_Hospital_NormValue.GetDataSetList(
                categoryId, normId, departmentId, startTime, endTime);

            StringBuilder sbrHtml = new StringBuilder();
           

            if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)
            {
                List<Entity_Hospital_SearchTime> times = Business_Hospital_NormValue.GetSearcjDateList(startTime, endTime) ?? new List<Entity_Hospital_SearchTime>();

                sbrHtml.AppendFormat("<tr><th colspan=\"{0}\" id=\"th_title\">{1}</th></tr>", times.Count + 2, normName);

                /*title*/
                sbrHtml.Append("<tr>");
                sbrHtml.Append("<td><b>科室</b></td>");
                sbrHtml.Append("<td><b>合计</b></td>");
                foreach (var item in times)
                {
                    var title = item.Year + "/" + item.Month;
                    sbrHtml.AppendFormat("<td><b>{0}</b></td>", title);
                }
                sbrHtml.Append("</tr>");

                /*body*/
                var DataTable = ds.Tables[0];
                for (int i = 0; i < DataTable.Rows.Count; i++)
                {
                    sbrHtml.Append("<tr>");
                    DataRow row = DataTable.Rows[i];
                    sbrHtml.AppendFormat("<td>{0}</td>", row["科室"]);
                    sbrHtml.AppendFormat("<td>{0}</td>", row["合计"]);
                    foreach (var item in times)
                    {
                        var title = item.Year + "年" + item.Month + "月";
                        sbrHtml.AppendFormat("<td>{0}</td>", row[title]);
                    }
                    sbrHtml.Append("</tr>");
                }
            }
            else
            {
                sbrHtml.Append("<tr><td colspan=\"14\">未检索到数据</th></tr>");
            }
            Response.Write(sbrHtml.ToString());
            Response.End();
        }

        private void GetSearchTableDate()
        {
            DateTime? startTime = Request["startTime"].ToDateTime2();
            DateTime? endTime = Request["endTime"].ToDateTime2();

            List<Entity_Hospital_SearchTime> times = Business_Hospital_NormValue.GetSearcjDateList(startTime, endTime);

            List<string> timeList = new List<string>();
            foreach (var time in times)
            {
                timeList.Add(time.Year + "年" + time.Month + "月");
            }

            //var json = ObjectJsonSerializer
            //    .Serialize<List<string>>(timeList);
            var json = ObjectJsonSerializer
               .Serialize<List<Entity_Hospital_SearchTime>>(times);

            Response.Write(json);
            Response.End();

        }

        private void GetSearchTable()
        {
            int categoryId = Request["categoryId"].ToInt();
            int normId = Request["normId"].ToInt();
            string departmentId = Request["departmentId"];

            DateTime? startTime = Request["startTime"].ToDateTime2();
            DateTime? endTime = Request["endTime"].ToDateTime2();

            DataSet entities
                = Business_Hospital_NormValue.GetDataSetList(
                categoryId, normId, departmentId, startTime, endTime);
            var json = ObjectJsonSerializer
                .Serialize_NewTon<DataTable>(entities.Tables[0]);

            Response.Write(json);
            Response.End();


        }

    }
}