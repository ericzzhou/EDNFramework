using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using System;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Utils.Serialization;
namespace DotNet.Framework.Admin.UI.Pages.Other.Slide.Group
{
    public partial class Edit : System.Web.UI.Page
    {
        public string jsonData = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("other_sild_default");
            GetModel();
        }

        private void GetModel()
        {
            int id = Request["id"].ToInt();
            Entity_Slide entity = Business_Slide.GetModel(id) ?? new Entity_Slide();
            jsonData = ObjectJsonSerializer.Serialize<Entity_Slide>(entity);
        }
    }
}