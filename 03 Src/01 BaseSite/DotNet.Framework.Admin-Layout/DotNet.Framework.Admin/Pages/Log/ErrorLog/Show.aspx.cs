using System;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Entity.EDNFramework_SYS;
using DotNet.Framework.Admin.Business.EDNFramework_SYS;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.Pages.Log.ErrorLog
{
    public partial class Show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("log_sys_index");

            var ajax = Request["ajax"];
            if (!string.IsNullOrWhiteSpace(ajax))
            {
                if (ajax.ToLower() == "show")
                    ShowData();
            }
        }

        private void ShowData()
        {
            int id = Request["id"].ToInt();
            if (id > 0)
            {
                Entity_ErrorLog entity = Business_ErrorLog.GetModel(id);
                var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<Entity_ErrorLog>(entity);
                Response.Write(json);
                Response.End();
            }
        }
    }
}