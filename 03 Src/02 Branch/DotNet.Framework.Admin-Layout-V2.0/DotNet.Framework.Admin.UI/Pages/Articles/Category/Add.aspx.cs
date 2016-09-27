using System;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Admin.Core.Entity;

using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.UI.Pages.Articles.Category
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("article_category_add");

            var ajax = Request["ajax"];
            if (!string.IsNullOrWhiteSpace(ajax) && ajax == "AddData")
            {
                AddData();
            }


        }

        private void Bind()
        {
            //EDNF_CMS_ClassType
            //ParentClass
            throw new NotImplementedException();
        }

        private void AddData()
        {
            Entity_ContentClass_Model entity = 
                DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
                .Json2EntityFromAjaxRequest<Entity_ContentClass_Model>(Request);
            if (string.IsNullOrWhiteSpace(entity.ClassName))
            {
                throw new BusinessException("类别名称不能为空");
            }

            //int ClassTypeID = Request["ClassTypeID"].ToInt();
            //int Sequence = Request["Sequence"].ToInt();
            //bool State = Request["State"].ToBoolean();
            //bool AllowAddContent = Request["AllowAddContent"].ToBoolean();

            //string ClassName = Request["ClassName"];
            //string Description = Request["Description"];
            //string Meta_Title = Request["Meta_Title"];
            //string SeoUrl = Request["SeoUrl"];
            //string Meta_Keywords = Request["Meta_Keywords"];
            //string Meta_Description = Request["Meta_Description"];

            //if (string.IsNullOrWhiteSpace(ClassName))
            //{
            //    throw new BusinessException("类别名称不能为空");
            //}

            //Entity_ContentClass_Model entity = new Entity_ContentClass_Model();

            //entity.AllowAddContent = AllowAddContent;
            //entity.ClassName = ClassName;
            //entity.ClassTypeID = ClassTypeID;
            //entity.Description = Description;
            //entity.Meta_Description = Meta_Description;
            //entity.Meta_Keywords = Meta_Keywords;
            //entity.Meta_Title = Meta_Title;
            //entity.SeoUrl = SeoUrl;
            //entity.Sequence = Sequence;
            //entity.State = State;
            entity.CreatedUserID = BusEntity_LoginUser.Sys_LoginUser.UserID;


            if (Business_ContentClass.Add(entity) <= 0)
            {
                throw new BusinessException("添加失败，请重试");
            }
            Response.End();
        }
    }
}