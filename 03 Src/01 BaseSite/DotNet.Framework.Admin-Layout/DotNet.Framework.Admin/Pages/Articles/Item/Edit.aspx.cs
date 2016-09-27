using System;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Admin.Core.Entity;
using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.Admin.Core.Business;


namespace DotNet.Framework.Admin.Pages.Articles.Item
{
    public partial class Edit : System.Web.UI.Page
    {
        public string json_Model = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("article_item_add");
            
            var ajax = Request["ajax"];
            if (!string.IsNullOrWhiteSpace(ajax))
            {
                switch (ajax.ToLower())
                {
                    case "getdata":
                       
                        break;
                    case "update":
                        Update();
                        break;
                    default:
                        break;
                }
            }
            else
                GetModel();
            //getdata
        }

        private void Update()
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
            entity.LastEditDate= DateTime.Now;
            //entity.Description = Server.HtmlEncode(entity.Description);
            entity.LastEditUserID= BusEntity_LoginUser.Sys_LoginUser.UserID;

            if (Business_Content.Update(entity) <= 0)
            {
                throw new BusinessException("编辑失败，请重试");
            }
            Response.Write("{}");
            Response.End();
        }

        private void GetModel()
        {
            int ContentID = Request["id"].ToInt();
            if (ContentID > 0)
            {
                Entity_Content entity = Business_Content.GetModel(ContentID);

                var json = ObjectJsonSerializer.Serialize<Entity_Content>(entity);
                json_Model = json;
                //Response.Write(json);

            }
            //else
            //    Response.Write("{}");
            //Response.End();
        }
    }
}