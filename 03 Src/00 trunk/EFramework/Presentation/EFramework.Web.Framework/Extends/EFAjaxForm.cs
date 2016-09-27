using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;

namespace EFramework.Web.Framework.Extends
{
    public static class EFAjaxForm
    {
        /// <summary>
        /// 扩展的 Ajax.BeginForm 方法
        /// </summary>
        /// <param name="ajaxHelper"></param>
        /// <param name="actionName"></param>
        /// <param name="ajaxOptions"></param>
        /// <param name="controllerName"></param>
        /// <param name="routeValues"></param>
        /// <returns></returns>
        public static MvcForm EFBeginForm(this AjaxHelper ajaxHelper, string actionName, string controllerName = null, AjaxOptions ajaxOptions = null, object routeValues = null)
        {
            object htmlAttributes = new { @class = "form-horizontal", role = "form", id = "myform" };

            AjaxOptions aoptions = new AjaxOptions()
            {
                OnSuccess = "OnSuccess",
                HttpMethod = "POST"
            };

            if (ajaxOptions != null)
            {
                aoptions.Confirm = ajaxOptions.Confirm;
                aoptions.InsertionMode = ajaxOptions.InsertionMode;
                aoptions.LoadingElementDuration = ajaxOptions.LoadingElementDuration;
                aoptions.OnFailure = ajaxOptions.OnFailure;
                aoptions.LoadingElementId = ajaxOptions.LoadingElementId;
                aoptions.OnBegin = ajaxOptions.OnBegin;
                aoptions.OnComplete = ajaxOptions.OnBegin;
                aoptions.Url = ajaxOptions.Url;
                aoptions.UpdateTargetId = ajaxOptions.UpdateTargetId;
            }

            return AjaxExtensions.BeginForm(
                ajaxHelper,
                actionName,
                controllerName,
                aoptions,
                htmlAttributes);
        }
    }
}
