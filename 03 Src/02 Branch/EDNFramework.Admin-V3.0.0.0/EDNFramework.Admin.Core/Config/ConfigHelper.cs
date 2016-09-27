
namespace DotNet.Framework.Admin.Core.Config
{
    public class ConfigHelper
    {
        public static string AjaxPath
        {
            get {
                return ResourcePath + "/ajax";
            }
        }
        /// <summary>
        /// 当前站点虚拟目录
        /// </summary>
        public static string AdminVirtualPath
        {
            get
            {
                return DotNet.Framework.Utils.Web.ConfigHelper.GetConfigString("AdminVirtualPath");
            }
        }

        public static bool MockUser
        {
            get
            {
                return DotNet.Framework.Utils.Web.ConfigHelper.GetConfigBool("MockUser");
            }
        }
        /// <summary>
        /// 当前站点 资源路径（css/javascript/images）
        /// ResourcePath/Resource/Images/xxx.jpg
        /// </summary>
        public static string ResourcePath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(AdminVirtualPath))
                {
                    return "";
                }
                else
                {
                    return "/" + AdminVirtualPath;
                }
            }
        }
    }
}
