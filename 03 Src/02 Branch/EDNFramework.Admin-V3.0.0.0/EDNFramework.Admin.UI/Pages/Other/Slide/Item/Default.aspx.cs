using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
namespace DotNet.Framework.Admin.UI.Pages.Other.Slide.Item
{
    public partial class Default : System.Web.UI.Page
    {
        public string json_group = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("other_sild_item_default");
            GetGroups();
        }

        private void GetGroups()
        {
            IList<Entity_Slide> entities = Business_Slide.GetALL() ?? new List<Entity_Slide>();
            json_group = ObjectJsonSerializer.Serialize<IList<Entity_Slide>>(entities);
        }


    }
}