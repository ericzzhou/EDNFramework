using DotNet.Framework.Admin.Business.EDNFramework_Account;
using System;
using System.Collections.Generic;
using System.Linq;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.Pages.Account.Role
{
    public partial class AddMember : System.Web.UI.Page
    {
        public string RoleNameString = string.Empty;
        public string users = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("Account_RolePermission_Index");
            int Roleid = Request["rid"].ToInt();
            var ajax = Request.QueryString["ajax"];
            if (!string.IsNullOrWhiteSpace(ajax))
            {
                switch (ajax)
                {
                    case "addmember":
                        Add(Roleid, Request["users"]);
                        break;
                }
            }
            else
            {
                GetRoleInfo(Roleid);
                GetUsers(Roleid);

            }


        }

        private void Add(int Roleid, string users)
        {
            if (Roleid > 0 && !users.IsNull())
            {
                int[] userArr = users.ToIntArr(',');
                if (userArr != null && userArr.Count() > 0)
                {
                    Business_Role.AddMembers(Roleid, userArr);
                    Response.Write("{}");
                }
            }
            else
            {
                throw new BusinessException("数据异常，请刷新重试。");
            }
            Response.End();

        }

        private void GetUsers(int Roleid)
        {
            IList<Entity_RoleMembers> list = Business_User.GetNoMembers(Roleid) ?? new List<Entity_RoleMembers>();
            users = ObjectJsonSerializer.Serialize<IList<Entity_RoleMembers>>(list);
        }

        private void GetRoleInfo(int Roleid)
        {
            Entity_Role model = Business_Role.GetModel(Roleid);
            if (model != null)
            {
                RoleNameString = model.RoleName;
            }
        }
    }
}
