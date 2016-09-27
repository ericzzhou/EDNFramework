using EFramework.Web.Framework.Controllers;
using EFramework.Web.Framework.WorkContext;

namespace EFramework.Web.Framework.ViewPages
{
    /// <summary>
    /// 后台视图页面基类型
    /// </summary>
    public abstract class AdminViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        public AdminWorkContext WorkContext;

        public override void InitHelpers()
        {
            base.InitHelpers();
            Html.EnableClientValidation(true);//启用客户端验证
            Html.EnableUnobtrusiveJavaScript(true);//启用非侵入式脚本
            WorkContext = ((BaseAdminController)(this.ViewContext.Controller)).WorkContext;
        }
    }

    /// <summary>
    /// 后台视图页面基类型
    /// </summary>
    public abstract class AdminViewPage : AdminViewPage<dynamic>
    {
    }
}
