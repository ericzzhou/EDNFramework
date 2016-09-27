using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Controls;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Core.Web.Data.ViewObject;
namespace DotNet.Framework.Admin.UI.Pages.Articles.Category
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("article_category_index");

            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "getPagerData":
                    getPagerData();
                    break;
                case "addCategory":
                    addCategory();
                    break;
                case "deleteCategory":
                    DeleteCategory();
                    break;
                default:
                    break;
            }

        }
        private void getPagerData()
        {
            ViewQueryCondition<object>
             query =
                ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<object>>(Request);

            PagingResult<IList<Entity_ContentClass_GetList>> result = Business_ContentClass.GetListByPager(query);
            Response.Write(result.ToString());
            Response.End();

            //IList<Entity_ContentClass_GetList> pageResult = Business_ContentClass.GetListByPager(pageindex, pagesize, orderField, dir, out totolCount);

            //var json = ObjectJsonSerializer.Serialize<IList<Entity_ContentClass_GetList>>(pageResult);
            //Response.Write("{\"totalRecords\": " + totolCount + ", \"curPage\": " + pageindex + ",\"data\":" + json + " }");
            //Response.End();
        }
        private void DeleteCategory()
        {
            int id = Request["ID"].ToInt();

            if (Business_ContentClass.Delete(id) <= 0)
            {
                throw new BusinessException("删除失败");
            }


            Response.Write("{}");
            Response.End();
        }

        private void addCategory()
        {
            throw new NotImplementedException();
        }
    }
}