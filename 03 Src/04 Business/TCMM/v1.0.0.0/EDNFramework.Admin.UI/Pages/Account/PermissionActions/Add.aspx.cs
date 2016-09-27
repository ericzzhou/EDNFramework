using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using System;

namespace DotNet.Framework.Admin.UI.Pages.Account.PermissionActions
{
    public partial class Add : System.Web.UI.Page
    {
        public string jsonStr = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
            string PermissionCode = Request["PermissionCode"];
            if (!string.IsNullOrWhiteSpace(PermissionCode))
            {
                Entity_Permission entity = Bussines_Permission.GetModelByCode(PermissionCode) ?? new Entity_Permission();
                jsonStr = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<Entity_Permission>(entity);
            }
        }
    }
}