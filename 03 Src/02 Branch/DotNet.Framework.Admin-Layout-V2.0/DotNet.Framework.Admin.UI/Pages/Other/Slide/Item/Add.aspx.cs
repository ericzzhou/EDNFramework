using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet.Framework.Admin.UI.Pages.Other.Slide.Item
{
    public partial class Add : System.Web.UI.Page
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
                case "adddata":
                    AddData();
                    break;
            }
        }

        private void AddData()
        {
            Entity_Slide_Item entity = ObjectJsonSerializer.Json2EntityFromAjaxRequest<Entity_Slide_Item>(Request);
            if (entity == null)
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
            
            if (Business.EDNFramework_CMS.Business_Slide_Item.Add(entity) <= 0)
            {
                throw new BusinessException("添加失败.");
            }
            Response.End();
            
        }

        private void GetGroups()
        {
            IList<Entity_Slide> entities = Business_Slide.GetALL() ?? new List<Entity_Slide>();
            json_group = ObjectJsonSerializer.Serialize<IList<Entity_Slide>>(entities);
        }
    }
}