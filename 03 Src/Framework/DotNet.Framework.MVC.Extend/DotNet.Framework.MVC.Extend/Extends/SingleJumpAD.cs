using DotNet.Framework.MVC.Extend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DotNet.Framework.MVC.Extend.Extends
{
    public static class SingleJumpAD
    {
        public static string EDNFHelper_SingleJumpAD_Show(this HtmlHelper helper, string adId)
        {
            Entity_SingleJumpAD model = Business.Business_SingleJumpAD.GetModel();
            if (model == null || !model.Enable)
            {
                return string.Empty;
            }
            StringBuilder sbr = new StringBuilder();
            sbr.AppendFormat("<div id=\"{0}\" style=\"position:absolute;height:{1}px; width:{2}px; ", adId, model.Height, model.Width);
            sbr.Append("  background:url(/Content/images/ri.png) center center no-repeat;filter:alpha(opacity=70);-moz-opacity:0.7;opacity:0.7; \">");
            sbr.AppendFormat("<div>{0}</div>", model.Content);
            sbr.Append("<div onclick=\"hidead();\" style=\"FONT-SIZE: 9pt; CURSOR: hand;color:#333333;vertical-align:bottom;\" align=right>关闭窗口×</div></div>");

            return sbr.ToString();
        }
    }
}
