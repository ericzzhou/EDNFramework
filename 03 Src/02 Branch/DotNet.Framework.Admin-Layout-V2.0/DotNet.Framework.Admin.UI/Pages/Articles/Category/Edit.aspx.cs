using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Core.Entity;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Core.Extends;
using System;
namespace DotNet.Framework.Admin.UI.Pages.Articles.Category
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("article_category_index");
            var ajax = Request["ajax"];
            if (!string.IsNullOrWhiteSpace(ajax))
            {
                if (ajax.ToLower() == "getclassinfo")
                    GetClassData();
                if (ajax.ToLower() == "updatedata")
                    UpdateData();
            }
        }

        private void UpdateData()
        {
            int ClassID = Request["ClassID"].ToInt();
            int ClassTypeID = Request["ClassTypeID"].ToInt();
            int Sequence = Request["Sequence"].ToInt();
            bool State = Request["State"].ToBoolean();
            bool AllowAddContent = Request["AllowAddContent"].ToBoolean();
            string ClassName = Request["ClassName"];
            string Description = Request["Description"];
            string Meta_Title = Request["Meta_Title"];
            string SeoUrl = Request["SeoUrl"];
            string Meta_Keywords = Request["Meta_Keywords"];
            string Meta_Description = Request["Meta_Description"];

            if (string.IsNullOrWhiteSpace(ClassName))
            {
                throw new BusinessException("类别名称不能为空");
            }

            Entity_ContentClass_Model entity = new Entity_ContentClass_Model();
            entity.ClassID = ClassID;
            entity.AllowAddContent = AllowAddContent;
            entity.ClassName = ClassName;
            entity.ClassTypeID = ClassTypeID;
            entity.Description = Description;
            entity.Meta_Description = Meta_Description;
            entity.Meta_Keywords = Meta_Keywords;
            entity.Meta_Title = Meta_Title;
            entity.SeoUrl = SeoUrl;
            entity.Sequence = Sequence;
            entity.State = State;
            entity.CreatedUserID = BusEntity_LoginUser.Sys_LoginUser.UserID;

            if (Business_ContentClass.Update(entity) <= 0)
            {
                throw new BusinessException("更新失败，请重试");
            }
            Response.End();
        }

        private void GetClassData()
        {
            int ClassID = Request["ClassID"].ToInt();
            if (ClassID > 0)
            {
                Entity_ContentClass_Model entity = Business_ContentClass.GetModel(ClassID);
                var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<Entity_ContentClass_Model>(entity);
                Response.Write(json);
                Response.End();
            }

        }
    }
}