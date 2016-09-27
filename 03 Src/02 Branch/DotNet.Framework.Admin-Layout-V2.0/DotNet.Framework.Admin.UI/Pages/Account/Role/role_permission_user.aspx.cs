using System;
using System.Collections.Generic;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.Admin.Core.Entity;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Admin.Entity.EDNFramework_Account.ViewQueryCondition;

namespace DotNet.Framework.Admin.UI.Pages.Account.Role
{
    public partial class role_permission_user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("Account_RolePermission_Index");
            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "getlistbyroleid":
                    GetListByRoleID();
                    break;
                case "removeuser":
                    RemoveUser();
                    break;
            }

        }

        private void RemoveUser()
        {
            int roleid = Request["roleid"].ToInt();
            int uid = Request["uid"].ToInt();

            if (BusEntity_LoginUser.Sys_LoginUser.UserID == uid)
            {
                throw new BusinessException("不能删除自己");
            }

            if (Business_User.RemoveUserFromRole(uid, roleid))
            {
                Response.Write("{}");
            }
            Response.End();
        }

        private void GetListByRoleID()
        {

            ViewQueryCondition<Entity_Role_Users_Condition> query =
ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<Entity_Role_Users_Condition>>(Request);

            PagingResult<IList<Entity_UserTableData>> result = Business_User.GetListByPager(query);
            Response.Write(result.ToString());
            Response.End();


            //int roleId = Request["roleid"].ToInt();
            //int pageindex = Request["pageindex"].ToInt();
            //int pagesize = Request["pagesize"].ToInt();

            //string orderField = Request["orderField"];
            //string dir = Request["sortDir"];


            //int totolCount = 0;

            //IList<Entity_UserTableData> Entities = Business_User.GetListByRoleID(roleId, pageindex, pagesize, orderField, dir, out totolCount);
            //var json = ObjectJsonSerializer.Serialize<IList<Entity_UserTableData>>(Entities);
            //Response.Write("{\"totalRecords\": " + totolCount + ", \"curPage\": " + pageindex + ",\"data\":" + json + " }");
            //Response.End();

        }
    }
}