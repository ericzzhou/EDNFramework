using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet.Framework.Admin.UI.Controls
{
    public partial class Control_BreadCrumb : System.Web.UI.UserControl
    {
        /// <summary>
        /// 面包屑显示内容
        /// </summary>
        public string BreadCrumbContent { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}