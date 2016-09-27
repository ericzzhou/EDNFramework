using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Core.Exceptions;
using System;
using DotNet.Framework.Core.Extends;
using System.Collections.Generic;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Core.WebRuntime;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS.ViewQueryCondition;
namespace DotNet.Framework.Admin.UI.Pages.Articles.Item
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("article_item_index");
            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "getPagerData":
                    getPagerData();
                    break;
                case "delete":
                    Detail();
                    break;
            }

        }
        private void getPagerData()
        {
            ViewQueryCondition<Entity_Content_Condition> query =
    ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<Entity_Content_Condition>>(Request);

            PagingResult<IList<Entity_Content_GetTableData>> result = Business_Content.GetListByPager2(query);
            Response.Write(result.ToString());
            Response.End();


            //int pageindex = Request["pageindex"].ToInt();
            //int pagesize = Request["pagesize"].ToInt();
            //string orderField = Request["orderField"];
            //string dir = Request["sortDir"];

            //string classId = Request["ClassID"];
            //string title = Request["Title"];
            //int totolCount = 0;
            //IList<Entity_Content_GetTableData> pageResult = Business_Content.GetListByPager(pageindex, pagesize, orderField, dir,classId,title, out totolCount);

            //var json = ObjectJsonSerializer.Serialize<IList<Entity_Content_GetTableData>>(pageResult);
            //Response.Write("{\"totalRecords\": " + totolCount + ", \"curPage\": " + pageindex + ",\"data\":" + json + " }");
            //Response.End();
        }

        private void Detail()
        {
            int id = Request["ID"].ToInt();
            if (!Business_Content.Delete(id))
            {
                throw new BusinessException(string.Format("编号为[{0}]的文章删除失败，请重试。", id));
            }
            Response.Write("{}");
            Response.End();
        }
    }
}