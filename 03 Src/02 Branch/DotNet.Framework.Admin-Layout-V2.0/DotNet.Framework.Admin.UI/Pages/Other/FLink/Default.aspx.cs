using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Core.Exceptions;
namespace DotNet.Framework.Admin.UI.Pages.Other.FLink
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ajax = Request.QueryString["ajax"];
            if (string.IsNullOrWhiteSpace(ajax))
            {
                CheckPermission.CheckRight("other_flink_default");
            }
            switch (ajax)
            {
                case "getPagerData":
                    GetPagerData();
                    break;
                //case "getmodel":
                //    GetModel();
                //    break;
                //case "editdata":
                //    UpdateData();
                //    break;
                //case "adddata":
                //    InsertData();
                //    break;
                case "deletemodel":
                    Delete();
                    break;
                //default:
                //    break;
            }
        }

        private void Delete()
        {
            int id = Request["id"].ToInt();

            if (Business_FLinks.Delete(id) <= 0)
            {
                throw new BusinessException("删除失败");
            }


            Response.Write("{}");
            Response.End();
        }

        private void GetPagerData()
        {
            ViewQueryCondition<object>
             query =
                ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<object>>(Request);

            PagingResult<IList<Entity_FLinks>> result = Business_FLinks.GetListByPager(query);
            Response.Write(result.ToString());
            Response.End();
        }
    }
}