using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Controls;
using DotNet.Framework.Admin.Core.Entity;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet.Framework.Admin.Pages.Articles.Item
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master.FindControl("SubNavbar") as Control_SubNavbar).CurrentNav = Core.Enums.Navigation.ARTICLE;

            var ajax = Request["ajax"];
            if (!string.IsNullOrWhiteSpace(ajax) && ajax.ToLower() == "adddata")
            {
                AddData();
            }
        }

        private void AddData()
        {
            Entity_Content entity =
                DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
                .Json2EntityFromAjaxRequest<Entity_Content>(Request);

            if (entity.ClassID == 0)
            {
                throw new BusinessException("请选择文章类别");
            }

            if (string.IsNullOrWhiteSpace(entity.Title))
            {
                throw new BusinessException("文章Title不能为空");
            }

            if (string.IsNullOrWhiteSpace(entity.Description))
            {
                throw new BusinessException("文章正文不能为空");
            }
            entity.CreatedDate = DateTime.Now;
            //entity.Description = Server.HtmlEncode(entity.Description);
            entity.CreatedUserID = BusEntity_LoginUser.Sys_LoginUser.UserID;

            if (Business_Content.Add(entity) <= 0)
            {
                throw new BusinessException("添加失败，请重试");
            }
            Response.Write("{}");
            Response.End();
        }
    }
}