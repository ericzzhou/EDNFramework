using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS.ViewQueryCondition;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Core.Exceptions;
namespace DotNet.Framework.Admin.UI.Pages.Other.Slide.Item
{
    public partial class Default : System.Web.UI.Page
    {
        public string json_group = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
            var ajax = Request.QueryString["ajax"];
            if (string.IsNullOrWhiteSpace(ajax))
            {
                CheckPermission.CheckRight("other_sild_item_default");
                GetGroups();
            }
            switch (ajax)
            {
                case "getPagerData":
                    GetPagerData();
                    break;
                case "delete":
                    Delete();
                    break;
            }
        }

        private void Delete()
        {
            int id = Request["id"].ToInt();
            if (!Business_Slide_Item.Delete(id))
            {
                throw new BusinessException("删除失败");
            }
            Response.End();
        }

        private void GetGroups()
        {
            IList<Entity_Slide> entities = Business_Slide.GetALL() ?? new List<Entity_Slide>();
            json_group = ObjectJsonSerializer.Serialize<IList<Entity_Slide>>(entities);
        }

        private void GetPagerData()
        {
            ViewQueryCondition<Entity_Slide_Item_Condition>
             query =
                ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<Entity_Slide_Item_Condition>>(Request);

            PagingResult<IList<Entity_Slide_Item>> result = Business_Slide_Item.GetListByPager(query);
            Response.Write(result.ToString());
            Response.End();
        }
    }
}