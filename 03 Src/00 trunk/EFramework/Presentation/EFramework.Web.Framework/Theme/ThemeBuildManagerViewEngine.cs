using System.Web.Compilation;
using System.Web.Mvc;

namespace EFramework.Web.Framework.Theme
{
    /// <summary>
    /// 主题视图引擎的路径提供者
    /// </summary>
    public abstract class ThemeBuildManagerViewEngine : ThemeVirtualPathProviderViewEngine
    {
        //判读视图文件是否存在
        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            return BuildManager.GetObjectFactory(virtualPath, false) != null;
        }
    }
}
