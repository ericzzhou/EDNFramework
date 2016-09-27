using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using System;
using System.Collections.Generic;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.Pages.Account.Role
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("Account_RolePermission_Index");
            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "getlist":
                    GetList();
                    break;
                case "adddata":
                    InsertData();
                    break;
                case "editdata":
                    UpdateData();
                    break;
                case "deletemodel":
                    DeleteModel();
                    break;
            }
        }
        private void DeleteModel()
        {
            string roleIdStr = Request["RoleID"];
            if (!roleIdStr.IsInt())
            {
                throw new BusinessException("角色编号错误");
            }
            if (!Business_Role.Delete(roleIdStr.ToInt()))
            {
                throw new BusinessException("删除失败");
            }


            Response.Write("{}");
            Response.End();
        }

        private void UpdateData()
        {
            int RoleID = Request["RoleID"].ToInt();
            string RoleName = Request["RoleName"];
            string Description = Request["Description"];
            if (string.IsNullOrWhiteSpace(RoleName))
            {
                throw new BusinessException("RoleName 不能为空");
            }

            Entity_Role entity = new Entity_Role();
            entity.RoleName = RoleName;
            entity.Description = Description;
            entity.RoleID = RoleID;
            if (!Business_Role.Update(entity))
            {
                throw new BusinessException("编辑失败");
            }
            Response.End();
        }
        private void InsertData()
        {
            string RoleID = Request["RoleID"];
            string RoleName = Request["RoleName"];
            string Description = Request["Description"];
            if (string.IsNullOrWhiteSpace(RoleID))
            {
                if (string.IsNullOrWhiteSpace(RoleName))
                {
                    throw new BusinessException("RoleName 不能为空");
                }

                Entity_Role entity = new Entity_Role();
                entity.RoleName = RoleName;
                entity.Description = Description;

                if (Business_Role.AddModel(entity) <= 0)
                {
                    throw new BusinessException("添加失败");
                }
            }
            else
            {
                throw new BusinessException("操作错误");
            }

            Response.End();
        }
        private void GetList()
        {
            int pageindex = Request["pageindex"].ToInt();
            int pagesize = Request["pagesize"].ToInt();

            string orderField = Request["orderField"];
            string dir = Request["sortDir"];


            int totolCount = 0;

            IList<Entity_RoleList> Entities = Business_Role.GetListByPager(pageindex, pagesize, orderField, dir, out totolCount);
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<IList<Entity_RoleList>>(Entities);
            Response.Write("{\"totalRecords\": " + totolCount + ", \"curPage\": " + pageindex + ",\"data\":" + json + " }");
            Response.End();
        }

    }
}