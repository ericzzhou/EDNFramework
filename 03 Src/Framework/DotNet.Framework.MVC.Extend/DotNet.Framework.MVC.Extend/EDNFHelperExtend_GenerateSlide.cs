using DotNet.Framework.MVC.Extend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DotNet.Framework.MVC.Extend
{
    /// <summary>
    /// ASP.NET MVC helper 扩展
    /// </summary>
    public static class EDNFHelperExtend_GenerateSlide
    {
        
        /// <summary>
        /// 生成幻灯片,建议使用 EDNF_GenerateSlide ，此方法以后可能会剔除
        /// </summary>
        /// <param name="helper">htmlHelper</param>
        /// <param name="containerParentID">容器父级id，不带“#”</param>
        /// <param name="containerClass">slide 容器 css，不带“.”</param>
        /// <param name="itemClass">变换项 css，不带“.”</param>
        /// <param name="slideId">SlideID</param>
        /// <param name="defaultImgSrc">没有数据的情况下默认显示的图片地址</param>
        /// <returns></returns>
        [Obsolete("此方法过时，建议使用 Slide.EDNFHelper_GenerateSlide")]
        public static string GenerateSlide(this HtmlHelper helper, string containerParentID, string containerClass, string itemClass, int slideId, string defaultImgSrc)
        {

            return GenerateSlide(containerParentID, containerClass, itemClass, slideId, defaultImgSrc);
        }

        private static string GenerateSlide(string containerParentID, string containerClass, string itemClass, int slideId, string defaultImgSrc)
        {
            if (string.IsNullOrWhiteSpace(containerParentID)
                || string.IsNullOrWhiteSpace(containerClass)
                || string.IsNullOrWhiteSpace(itemClass)
                || slideId <= 0)
            {
                return string.Empty;
            }

            IList<Entity_Slide> slides = Business.Business_Slide.GetSlideByID(slideId) ?? new List<Entity_Slide>();

            if (slides.Count == 0)
            {
                return string.Format("<img src=\"{0}\"></img>", defaultImgSrc);
            }
            string html = string.Empty;
            var itemType = slides.Select(x => x.ItemType).FirstOrDefault() ?? "";

            if (itemType == Enums.Enum_Slide.ItemType.image.ToString())
            {
                html = GenerateImageSlide(containerParentID, containerClass, itemClass, slides);
            }
            if (itemType == Enums.Enum_Slide.ItemType.flash.ToString())
            {
                html = GenerateFlashSlide(containerParentID, containerClass, itemClass, slides.FirstOrDefault());
            }
            return html;
        }

        private static string GenerateFlashSlide(string containerParentID, string containerClass, string itemClass, Entity_Slide item)
        {
            StringBuilder sbr = new StringBuilder();
            sbr.AppendFormat("<object id=\"FlashID{0}\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" width=\"{1}\" height=\"{2}\">", item.ID, item.Width, item.Height);
            sbr.AppendFormat("<param name=\"movie\" value=\"{0}\" />", item.FilePath);
            sbr.AppendFormat("<param name=\"quality\" value=\"high\" />");
            sbr.AppendFormat("<param name=\"wmode\" value=\"transparent\" />");
            sbr.AppendFormat("<param name=\"swfversion\" value=\"8.0.35.0\" />");
            sbr.Append("<!-- 此 param 标签提示使用 Flash Player 6.0 r65 和更高版本的用户下载最新版本的 Flash Player。如果您不想让用户看到该提示，请将其删除。 -->");
            sbr.Append("<param name=\"expressinstall\" value=\"/bin/DotNet.Framework.MVC.Extend/expressInstall.swf\" />");
            sbr.Append("<!-- 下一个对象标签用于非 IE 浏览器。所以使用 IECC 将其从 IE 隐藏。 -->");
            sbr.Append("<!--[if !IE]>-->");
            sbr.AppendFormat("<object type=\"application/x-shockwave-flash\" data=\"{0}\" width=\"{1}\" height=\"{2}\">", item.FilePath, item.Width, item.Height);
            sbr.Append("<!--<![endif]-->                                                     ");
            sbr.Append("<param name=\"quality\" value=\"high\" />                                ");
            sbr.Append("<param name=\"wmode\" value=\"transparent\" />                           ");
            sbr.Append("<param name=\"swfversion\" value=\"8.0.35.0\" />                         ");
            sbr.Append("<param name=\"expressinstall\" value=\"/bin/DotNet.Framework.MVC.Extend/expressInstall.swf\" />   ");
            sbr.Append("<!-- 浏览器将以下替代内容显示给使用 Flash Player 6.0 和更低版本的用户。 --> ");
            sbr.Append("<div><h4>此页面上的内容需要较新版本的 Adobe Flash Player。</h4><p> ");
            sbr.Append("<a href=\"http://www.adobe.com/go/getflashplayer\"><img src=\"http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif\" alt=\"获取 Adobe Flash Player\" width=\"112\" height=\"33\" /></a></p> ");
            sbr.Append("</div>");
            sbr.Append("<!--[if !IE]>--> ");
            sbr.Append("</object> ");
            sbr.Append("<!--<![endif]--> ");
            sbr.Append("</object> ");
            return sbr.ToString();
        }

        private static string GenerateImageSlide(string containerParentID, string containerClass, string itemClass, IList<Entity_Slide> slides)
        {
            int delay = 3000;
            if (slides.Count > 0)
            {
                var first = slides.FirstOrDefault();
                if (first != null && first.delay > 0)
                {
                    delay = first.delay;
                }
            }
            StringBuilder sbr = new StringBuilder();
            sbr.AppendFormat("<div class=\"{0}\">", containerClass);
            for (int i = 0; i < slides.Count; i++)
            {
                Entity_Slide item = slides[i];
                string style = "style=\"display: none\"";
                if (i == 0)
                {
                    style = string.Empty;
                }
                sbr.AppendFormat("<div class=\"{0}\" {1}>", itemClass, style);
                sbr.AppendFormat("<a href=\"{0}\">", item.Href);
                sbr.AppendFormat("<img style=\"width: {0}px; height: {1}px;\"", item.Width, item.Height);
                sbr.AppendFormat("  src=\"{0}\"></a>", item.FilePath);
                sbr.Append("</div>");
            }
            sbr.Append("</div>");
            sbr.AppendFormat("<script type=\"text/javascript\">$(function(){{new FlashPic($('#{0}'), {1}, '.{2}', '.{3}').init();}});</script>", containerParentID, delay, containerClass, itemClass);
            sbr.Append("");
            return sbr.ToString();
        }



    }

}
