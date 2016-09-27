using EFramework.Web.Framework.Controllers;
using EFramework.Web.Framework.WorkContext;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace EFramework.Web.Framework.ViewPages
{
    /// <summary>
    /// 前台视图页面基类型
    /// </summary>
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        public WebWorkContext WorkContext;

        public override void InitHelpers()
        {
            base.InitHelpers();
            WorkContext = ((BaseWebController)(this.ViewContext.Controller)).WorkContext;
        }

        ///// <summary>
        ///// 获得验证错误列表
        ///// </summary>
        ///// <returns></returns>
        //public MvcHtmlString GetVerifyErrorList()
        //{
        //    ModelStateDictionary modelState = ((Controller)(this.ViewContext.Controller)).ModelState;
        //    if (modelState == null || modelState.Count == 0)
        //        return new MvcHtmlString("null");

        //    StringBuilder errorList = new StringBuilder("[");
        //    foreach (KeyValuePair<string, ModelState> item in modelState)
        //    {
        //        errorList.AppendFormat("{0}'key':'{1}','msg':'{2}'{3},", "{", item.Key, item.Value.Errors[0].ErrorMessage, "}");
        //    }
        //    errorList.Remove(errorList.Length - 1, 1);
        //    errorList.Append("]");

        //    return new MvcHtmlString(errorList.ToString());
        //}
    }

    /// <summary>
    /// 前台视图页面基类型
    /// </summary>
    public abstract class WebViewPage : WebViewPage<dynamic>
    {
    }
}
