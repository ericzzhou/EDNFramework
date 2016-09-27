using DotNet.Framework.Admin.Controls;
using System;
using System.Collections.Generic;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Core.Exceptions;

namespace DotNet.Framework.Admin.Pages.Account.User
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master.FindControl("SubNavbar") as Control_SubNavbar).CurrentNav = Core.Enums.Navigation.ACCOUNT;
            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "getlist":
                    GetList();
                    break;
                case "deletemodel":
                    DeleteModel();
                    break;
                case "getdepartment":
                    GetDepartment();
                    break;
                default:
                    break;
            }

        }


        private void GetDepartment()
        {
            var Entities = Business_Department.GetList();
            var json = ObjectJsonSerializer.Serialize<IList<Entity_Department>>(Entities);
            Response.Write(json);
            Response.End();
        }


        private void DeleteModel()
        {
            int userId = Request["id"].ToInt();
            if (userId == DotNet.Framework.Admin.Core.Entity.BusEntity_LoginUser.Sys_LoginUser.UserID)
            {
                throw new BusinessException(string.Format("用户 {0} 不允许删除自己", DotNet.Framework.Admin.Core.Entity.BusEntity_LoginUser.Sys_LoginUser.UserName));
            }
            if (!Business_User.Delete(userId))
            {
                throw new BusinessException("删除失败");
            }


            Response.Write("{}");
            Response.End();

        }

        private void GetList()
        {
            int pageindex = Request["pageindex"].ToInt();
            int pagesize = Request["pagesize"].ToInt();

            string orderField = Request["orderField"];
            string dir = Request["sortDir"];


            int totolCount = 0;

            IList<Entity_UserTableData> Entities = Business_User.GetListByPager(pageindex, pagesize, orderField, dir, out totolCount);
            var json = ObjectJsonSerializer.Serialize<IList<Entity_UserTableData>>(Entities);
            Response.Write("{\"totalRecords\": " + totolCount + ", \"curPage\": " + pageindex + ",\"data\":" + json + " }");
            Response.End();

        }
    }
}