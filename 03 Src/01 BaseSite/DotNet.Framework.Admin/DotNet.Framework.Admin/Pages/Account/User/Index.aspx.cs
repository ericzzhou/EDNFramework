using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Controls;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Core.Exceptions;
using System;
using System.Collections.Generic;
using DotNet.Framework.Core.Extends;
namespace DotNet.Framework.Admin.Pages.Account.User
{
    public partial class Index : System.Web.UI.Page
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
                default:
                    break;
            }
        }

        private void DeleteModel()
        {
            int userId = Request["id"].ToInt();
            if (!Business_User.Delete(userId))
            {
                throw new BusinessException("删除失败");
            }


            Response.Write("{}");
            Response.End();
        }

        private void GetList()
        {
            var Entities = Business_User.GetTablesData();
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<IList<Entity_UserTableData>>(Entities);
            Response.Write("{\"aaData\":" + json + "}");
            Response.End();
        }
    }
}