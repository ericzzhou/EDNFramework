using DotNet.Framework.Admin.Business.Hospital;
using DotNet.Framework.Admin.Entity.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Utils.Serialization;
namespace DotNet.Framework.Admin.Pages.Norm.Category
{
    public partial class ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "gettreedata":
                    GetTreeData();
                    break;
                case "delete":
                    DeleteCategory();
                    break;
                case "add":
                    AddCategory();
                    break;
                case "edit":
                    EditCategory();
                    break;
                case "getmodel":
                    GetCategoryModel();
                    break;

            }
        }

        private void GetCategoryModel()
        {
            int id = Request["id"].ToInt();
            var model = Business_Hospital_NormCategory.GetModel(id);
            var json = ObjectJsonSerializer.Serialize<Entity_Hospital_NormCategory>(model);
            Response.Write(json);
            Response.End();

        }

        private void EditCategory()
        {
            Entity_Hospital_NormCategory entity = ObjectJsonSerializer.Json2EntityFromAjaxRequest<Entity_Hospital_NormCategory>(Request);
            if (entity.ID <= 0)
            {
                throw new BusinessException("分类编号异常，请刷新页面重试");
            }
            if (string.IsNullOrWhiteSpace(entity.CategoryName))
            {
                throw new BusinessException("分类名称不能为空");
            }
            if (string.IsNullOrWhiteSpace(entity.CategoryCode))
            {
                throw new BusinessException("分类简码不能为空");
            }

            if (!Business_Hospital_NormCategory.Update(entity))
            {
                throw new BusinessException("新增指标分类失败，请重试。");
            }
            else
            {
                Response.Write("{}");
            }
            Response.End();
        }

        private void AddCategory()
        {
            Entity_Hospital_NormCategory entity = ObjectJsonSerializer.Json2EntityFromAjaxRequest<Entity_Hospital_NormCategory>(Request);
            if (string.IsNullOrWhiteSpace(entity.CategoryName))
            {
                throw new BusinessException("分类名称不能为空");
            }
            if (string.IsNullOrWhiteSpace(entity.CategoryCode))
            {
                throw new BusinessException("分类简码不能为空");
            }

            if (!Business_Hospital_NormCategory.Add(entity))
            {
                throw new BusinessException("新增指标分类失败，请重试。");
            }
            else
            {
                Response.Write("{}");
            }
            Response.End();
        }

        private void DeleteCategory()
        {
            var id = Request["id"].ToInt();
            if (!Business_Hospital_NormCategory.Delete(id))
            {
                throw new BusinessException("删除指标分类失败");
            }
            else
            {
                Response.Write("{}");
            }
            Response.End();
        }

        private void GetTreeData()
        {
            var entity = Business_Hospital_NormCategory.GetNormCategoryTreeData() ?? new List<Entity_Hospital_NormCategoryTree>();

            entity.Insert(0, new Entity_Hospital_NormCategoryTree()
            {
                id = 0,
                pid = -1,
                name = "指标分类",
                open = true
            });
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<IList<Entity_Hospital_NormCategoryTree>>(entity);
            Response.Write(json);
            Response.End();
        }
    }
}