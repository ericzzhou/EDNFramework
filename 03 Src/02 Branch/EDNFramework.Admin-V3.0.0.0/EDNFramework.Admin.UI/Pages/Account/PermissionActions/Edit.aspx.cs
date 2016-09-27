using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
namespace DotNet.Framework.Admin.UI.Pages.Account.PermissionActions
{
    public partial class Edit : System.Web.UI.Page
    {
        public string jsonStr = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
            int ActionID = Request["ActionID"].ToInt();
            if (ActionID > 0)
            {
                Entity_PermissionAction_Edit entity = Business_PermissionAction.GetModelByID(ActionID) ?? new Entity_PermissionAction_Edit();
                jsonStr = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<Entity_PermissionAction_Edit>(entity);
            }
        }
    }
}