using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
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
    public partial class Edit : System.Web.UI.Page
    {
        public string json_group = "{}";
        public string json_Entity = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
            var ajax = Request.QueryString["ajax"];
            if (string.IsNullOrWhiteSpace(ajax))
            {
                CheckPermission.CheckRight("other_sild_item_default");
                GetGroups();
                GetModel();
            }
            switch (ajax)
            {
                case "update":
                    Update();
                    break;
            }
        }

        private void Update()
        {
            Entity_Slide_Item entity = ObjectJsonSerializer.Json2EntityFromAjaxRequest<Entity_Slide_Item>(Request);
            if (entity == null || entity.ID <= 0)
            {
                throw new BusinessException("数据获取错误，请重试.");
            }
            if (entity.SlideID <= 0)
            {
                throw new BusinessException("请选择幻灯片组.");
            }
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new BusinessException("请输入文件名.");
            }
            if (string.IsNullOrWhiteSpace(entity.Href))
            {
                entity.Href = "#";
            }
            if (string.IsNullOrWhiteSpace(entity.FilePath))
            {
                throw new BusinessException("请上传文件.");
            }

            if (!Business.EDNFramework_CMS.Business_Slide_Item.Update(entity))
            {
                throw new BusinessException("修改失败.");
            }
            Response.End();
        }

        private void GetModel()
        {
            int id = Request["id"].ToInt();
            Entity_Slide_Item entity = Business_Slide_Item.GetModel(id) ?? new Entity_Slide_Item();
            json_Entity = ObjectJsonSerializer.Serialize<Entity_Slide_Item>(entity);
        }

        private void GetGroups()
        {
            IList<Entity_Slide> entities = Business_Slide.GetALL() ?? new List<Entity_Slide>();
            json_group = ObjectJsonSerializer.Serialize<IList<Entity_Slide>>(entities);

        }
    }
}