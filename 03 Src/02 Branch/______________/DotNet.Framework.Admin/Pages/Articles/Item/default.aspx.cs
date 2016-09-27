using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Controls;
using DotNet.Framework.Core.Exceptions;
using System;
using DotNet.Framework.Core.Extends;
using System.Collections.Generic;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Utils.Serialization;
namespace DotNet.Framework.Admin.Pages.Articles.Item
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master.FindControl("SubNavbar") as Control_SubNavbar).CurrentNav = Core.Enums.Navigation.ARTICLE;
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
            int pageindex = Request["pageindex"].ToInt();
            int pagesize = Request["pagesize"].ToInt();
            string orderField = Request["orderField"];
            string dir = Request["sortDir"];

            int totolCount = 0;
            IList<Entity_Content_GetTableData> pageResult = Business_Content.GetListByPager(pageindex, pagesize, orderField, dir, out totolCount);

            var json = ObjectJsonSerializer.Serialize<IList<Entity_Content_GetTableData>>(pageResult);
            Response.Write("{\"totalRecords\": " + totolCount + ", \"curPage\": " + pageindex + ",\"data\":" + json + " }");
            Response.End();
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