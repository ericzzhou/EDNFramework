using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Core.Exceptions;
using System;

namespace DotNet.Framework.Admin.UI.Pages.Other.FLink
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ajax = Request["ajax"];
            if (!string.IsNullOrWhiteSpace(ajax))
            {
                switch (ajax)
                {
                    case "adddata":
                        AddData();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                CheckPermission.CheckRight("other_flink_default");
            }
        }

        private void AddData()
        {
            Entity_FLinks entity =
               DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
               .Json2EntityFromAjaxRequest<Entity_FLinks>(Request);
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new BusinessException("名称不能为空");
            }
            if (string.IsNullOrWhiteSpace(entity.LinkUrl))
            {
                throw new BusinessException("链接不能为空");
            }
            if (!entity.LinkUrl.StartsWith("http://"))
            {
                entity.LinkUrl = "http://" + entity.LinkUrl;
            }
            int userId = DotNet.Framework.Admin.Core.Entity.BusEntity_LoginUser.Sys_LoginUser.UserID;
            if (Business_FLinks.Add(entity, userId) <= 0)
            {
                throw new BusinessException("添加失败，请重试");
            }
            Response.End();
        }
    }
}