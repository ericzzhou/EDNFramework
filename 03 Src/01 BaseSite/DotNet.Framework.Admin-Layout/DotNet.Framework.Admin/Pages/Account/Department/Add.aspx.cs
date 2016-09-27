using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Controls;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Utils.Serialization;
using System;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.Pages.Account.Department
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("Account_Department_Index");
            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "adddata":
                    AddData();
                    break;
                //default:
                //    break;
            }
        }

        private void AddData()
        {
            Entity_Department entity =
                ObjectJsonSerializer
                .Json2EntityFromAjaxRequest<Entity_Department>(Request);

            if (entity.Name.IsNull())
            {
                throw new BusinessException("请输入部门名称");
            }
            if (Business_Department.GetDepartmentCountByName(entity.Name) > 0)
            {
                throw new BusinessException(string.Format("请部门名称[{0}]已存在，不能重复输入", entity.Name));
            }
            if (Business_Department.Add(entity) <= 0)
            {
                throw new BusinessException("添加部门失败，请重试");
            }
            Response.Write("{}");
            Response.End();
        }
    }
}