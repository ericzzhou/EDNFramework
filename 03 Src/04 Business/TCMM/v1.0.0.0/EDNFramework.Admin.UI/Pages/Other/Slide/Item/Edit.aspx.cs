using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
using DotNet.Framework.Core.Extends;
namespace DotNet.Framework.Admin.UI.Pages.Other.Slide.Item
{
    public partial class Edit : System.Web.UI.Page
    {
        public string json_group = "{}";
        public string json_Entity = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("other_sild_item_default");
            GetGroups();
            GetModel();
        }

        private void GetModel()
        {
            int id = Request["id"].ToInt();
            Entity_Slide_Item entity = Business_Slide_Item.GetModel(id) ?? new Entity_Slide_Item();
            json_Entity = ObjectJsonSerializer.Serialize<Entity_Slide_Item>(entity);
        }

        private void GetGroups()
        {
            IList<Entity_Slide> entities = Business_Slide.GetALL() ?? new List<Entity_Slide>();
            json_group = ObjectJsonSerializer.Serialize<IList<Entity_Slide>>(entities);

        }
    }
}