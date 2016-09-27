using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet.Framework.Admin.UI.Controls
{
    public partial class Control_Info : System.Web.UI.UserControl
    {
        /// <summary>
        /// 需要加粗显示的文字
        /// </summary>
        public string Text_Strong { get; set; }
        /// <summary>
        /// 默认显示的文字
        /// </summary>
        public string Text_Normal { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}