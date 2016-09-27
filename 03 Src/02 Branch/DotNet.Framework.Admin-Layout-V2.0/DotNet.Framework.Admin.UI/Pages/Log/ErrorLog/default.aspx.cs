using DotNet.Framework.Admin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Business.EDNFramework_SYS;
using DotNet.Framework.Admin.Entity.EDNFramework_SYS;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Utils.Serialization;
namespace DotNet.Framework.Admin.UI.Pages.Log.ErrorLog
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("log_sys_index");
            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "getlist":
                    GetList();
                    break;
            }
        }

        private void GetList()
        {
            ViewQueryCondition<object> query =
ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<object>>(Request);

            PagingResult<IList<Entity_ErrorLog>> result = Business_ErrorLog.GetListByPager(query);
            Response.Write(result.ToString());
            Response.End();

            //int pageindex = Request["pageindex"].ToInt();
            //int pagesize = Request["pagesize"].ToInt();

            //string orderField = Request["orderField"];
            //string dir = Request["sortDir"];


            //int totolCount = 0;
            //IList<Entity_ErrorLog> pageResult = Business_ErrorLog.GetListByPager(pageindex, pagesize, orderField, dir, out totolCount);
            //var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<IList<Entity_ErrorLog>>(pageResult);

            //Response.Write("{\"totalRecords\": " + totolCount + ", \"curPage\": " + pageindex + ",\"data\":" + json + " }");
            //Response.End();
        }
    }
}