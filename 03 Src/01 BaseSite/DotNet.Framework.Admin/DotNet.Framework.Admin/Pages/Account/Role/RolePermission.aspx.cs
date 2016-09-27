using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Controls;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using System;
using System.Collections.Generic;
using DotNet.Framework.Core.Extends;
namespace DotNet.Framework.Admin.Pages.Account.Role
{
    public partial class RolePermission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master.FindControl("SubNavbar") as Control_SubNavbar).CurrentNav = Core.Enums.Navigation.ACCOUNT;
            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "getuser":
                    GetUsers();
                    break;
                case "getnotmembers":
                    GetNoMembers(); 
                    break;
                case "savemembers":
                    SaveMembers();
                    break;
            }
            GetRoleList();
        }

        private void SaveMembers()
        {
            int roleId = Request["roleid"].ToInt();
            string users = Request["uids"];
            string[] uidArr = users.Split(',');
            Business_Role.AddMembers(roleId, uidArr);
            Response.Write("{}");
            Response.End();
        }

        private void GetNoMembers()
        {
            int roleId = Request["roleid"].ToInt();
            var Entities = Business_User.GetNoMembers(roleId);
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<IList<Entity_RoleMembers>>(Entities);
            Response.Write(json);
            Response.End();
        }

        private void GetUsers()
        {
            int roleId = Request["roleid"].ToInt();
            var Entities = Business_User.GetTablesData(roleId);
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<IList<Entity_UserTableData>>(Entities);
            Response.Write(json);
            Response.End();

        }

        private void GetRoleList()
        {
            var Entities = Business_Role.GetAll();
            this.rep_roles.DataSource = Entities;
            this.rep_roles.DataBind();
        }
    }
}