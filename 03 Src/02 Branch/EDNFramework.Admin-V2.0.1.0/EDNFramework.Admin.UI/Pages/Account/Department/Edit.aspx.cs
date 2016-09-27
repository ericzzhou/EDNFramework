using System;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.UI.Pages.Account.Department
{
    public partial class Edit : System.Web.UI.Page
    {
        public string Json_Model = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("Account_Department_Index");

            var id = Request["id"];
            if (id.IsInt())
            {
                GetModel(id.ToInt());
            }
        }

        private void GetModel(int id)
        {
            Entity_Department dep = Business_Department.GetModel(id) ?? new Entity_Department();
            Json_Model = ObjectJsonSerializer.Serialize<Entity_Department>(dep);
        }
    }
}