using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Core.Exceptions;
using System;

namespace DotNet.Framework.Admin.UI.Pages.Other.Slide.Group
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ajax = Request.QueryString["ajax"];
            if (string.IsNullOrWhiteSpace(ajax))
            {
                CheckPermission.CheckRight("other_sild_default");
            }
            switch (ajax)
            {
                case "adddata":
                    AddSlideGroup();
                    break;
            }
        }

        private void AddSlideGroup()
        {
            Entity_Slide entity =
               DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
               .Json2EntityFromAjaxRequest<Entity_Slide>(Request);
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new BusinessException("组名称不能为空");
            }
            
            if (Business_Slide.Add(entity) <= 0)
            {
                throw new BusinessException("添加失败，请重试");
            }
            Response.End();
        }
    }
}