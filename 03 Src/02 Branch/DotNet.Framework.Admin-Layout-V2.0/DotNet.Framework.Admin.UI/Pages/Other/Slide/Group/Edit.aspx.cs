using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.Core.Exceptions;
namespace DotNet.Framework.Admin.UI.Pages.Other.Slide.Group
{
    public partial class Edit : System.Web.UI.Page
    {
        public string jsonData = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
            var ajax = Request["ajax"];
            if (!string.IsNullOrWhiteSpace(ajax))
            {
                switch (ajax)
                {
                    case "updatedata":
                        Update();
                        break;
                }
            }
            else
            {
                CheckPermission.CheckRight("other_sild_default");
                GetModel();
            }
        }

        private void GetModel()
        {
            int id = Request["id"].ToInt();
            Entity_Slide entity = Business_Slide.GetModel(id) ?? new Entity_Slide();
            jsonData = ObjectJsonSerializer.Serialize<Entity_Slide>(entity);
        }

        private void Update()
        {
            Entity_Slide entity = ObjectJsonSerializer.Json2EntityFromAjaxRequest<Entity_Slide>(Request);
            if (entity == null || entity.ID <=0)
            {
                throw new BusinessException("数据获取错误，请刷新重试.");
            }
            Business_Slide.Update(entity);
            //Response.Write("{}");
            Response.End();
        }
    }
}