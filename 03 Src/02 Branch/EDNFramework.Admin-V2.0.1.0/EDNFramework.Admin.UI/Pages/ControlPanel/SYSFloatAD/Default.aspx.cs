using DotNet.Framework.Admin.Entity.EDNFramework_SYS;
using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet.Framework.Admin.UI.Pages.ControlPanel.SYSFloatAD
{
    public partial class Default : System.Web.UI.Page
    {
        public string json = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
            GetNormalFloatAD();
        }

        private void GetNormalFloatAD()
        {
            Entity_FloatAD model = Business.EDNFramework_SYS.Business_FloatAD.GetNormal() ?? new Entity_FloatAD()
            {
                Left_Enable = true,
                Left_Height = 400,
                Left_left = 10,
                Left_top = 50,
                Left_Width = 150,
                Right_Enable = true,
                Right_Height = 400,
                Right_right = 10,
                Right_top = 50,
                Right_Width = 150
            };

            json = ObjectJsonSerializer.Serialize<Entity_FloatAD>(model);
        }
    }
}