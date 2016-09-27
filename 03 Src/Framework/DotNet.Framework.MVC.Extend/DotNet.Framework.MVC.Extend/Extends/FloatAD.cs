using DotNet.Framework.MVC.Extend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DotNet.Framework.MVC.Extend.Extends
{
    public static class FloatAD
    {
        public static string EDNFHelper_FloatAD_Left(this HtmlHelper helper)
        {
            Entity_FloatAD model = Business.Business_FloatAD.GetModel();
            if (model == null || !model.Left_Enable)
            {
                return string.Empty;
            }
            StringBuilder sbr = new StringBuilder();
            sbr.Append("<style type=\"text/css\">");
            sbr.Append(".floatad_left {");
            sbr.AppendFormat("width:{0}px;", model.Left_Width);
            sbr.AppendFormat("height:{0}px;", model.Left_Height);
            sbr.AppendFormat("left:{0}px;", model.Left_left);
            sbr.AppendFormat("top:{0}px;", model.Left_top);
            sbr.Append("position:fixed;z-index:200px;filter:alpha(opacity=60); border:0px #000 solid;padding:10px;font-size:14px;line-height:170%;}");
            sbr.Append("</style>");

            sbr.AppendFormat("<div class=\"floatad_left\">{0}</div>", model.Left_Body);
            return sbr.ToString();
        }

        public static string EDNFHelper_FloatAD_Right(this HtmlHelper helper)
        {
            Entity_FloatAD model = Business.Business_FloatAD.GetModel();
            if (model == null || !model.Right_Enable)
            {
                return string.Empty;
            }

            StringBuilder sbr = new StringBuilder();
            sbr.Append("<style type=\"text/css\">");
            sbr.Append(".floatad_right {");
            sbr.AppendFormat("width:{0}px;", model.Right_Width);
            sbr.AppendFormat("height:{0}px;", model.Right_Height);
            sbr.AppendFormat("right:{0}px;", model.Right_right);
            sbr.AppendFormat("top:{0}px;", model.Right_top);
            sbr.Append("position:fixed;z-index:200px;filter:alpha(opacity=60); border:0px #000 solid;padding:10px;font-size:14px;line-height:170%;}");
            sbr.Append("</style>");

            sbr.AppendFormat("<div class=\"floatad_right\">{0}</div>", model.Right_Body);
            return sbr.ToString();
        }
    }
}
