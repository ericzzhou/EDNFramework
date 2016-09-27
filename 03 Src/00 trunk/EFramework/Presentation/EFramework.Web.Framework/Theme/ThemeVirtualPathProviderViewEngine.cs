using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace EFramework.Web.Framework.Theme
{
    
    /// <summary>
    /// 主题视图引擎的路径提供者 222
    /// </summary>
    public abstract class ThemeVirtualPathProviderViewEngine : VirtualPathProviderViewEngine
    {
        private string theme = string.Empty;
        /// <summary>
        /// 手机主题的修饰符
        /// </summary>
        private readonly string _mobileviewmodifier = "Mobile";

        protected ThemeVirtualPathProviderViewEngine()
        {
            //视图文件允许的扩展名
            FileExtensions = new[] { "cshtml" };
        }

        #region 工具方法

        /// <summary>
        /// 获取视图文件的路径
        /// </summary>
        protected string GetPath(ControllerContext controllerContext, string[] locations, string[] areaLocations, string locationsPropertyName, string name, string controllerName, string theme, string cacheKeyPrefix, bool useCache, bool mobile, out string[] searchedLocations)
        {
            //搜索位置数组
            searchedLocations = null;
            if (string.IsNullOrWhiteSpace(name))
            {
                return string.Empty;
            }
            //获取区域名称
            string areaName = GetAreaName(controllerContext.RouteData);

            //访问后台管理区域
            if (!string.IsNullOrWhiteSpace(areaName) && areaName.Equals("admin", StringComparison.InvariantCultureIgnoreCase))
            {
                //不能通过移动访问后台
                if (mobile)
                {
                    searchedLocations = new string[0];
                    return string.Empty;
                }
                //由于后台项目未在web项目中所有后台的区域不起作用，所以要手动添加后台的查找路径
                areaLocations = new string[2] { "~/Administration/Views/Shared/{0}.cshtml", "~/Administration/Views/{1}/{0}.cshtml" };
            }

            bool flag = !string.IsNullOrWhiteSpace(areaName);
            //得到视图位置列表
            List<ViewLocation> viewLocations = GetViewLocations(locations, flag ? areaLocations : null);
            //不存在要搜索的位置时
            if (viewLocations.Count == 0)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "属性不能为空", new object[] { locationsPropertyName }));
            }
            //判读视图名称是否以“~”或“/”开头
            bool flag2 = IsSpecificPath(name);
            //创建视图位置的缓存key
            string key = this.CreateCacheKey(cacheKeyPrefix, name, flag2 ? string.Empty : controllerName, areaName, theme);
            if (useCache)
            {
                //从缓存中得到视图位置
                var cached = this.ViewLocationCache.GetViewLocation(controllerContext.HttpContext, key);
                if (cached != null)
                {
                    return cached;
                }
            }
            //不是特殊路径时的操作
            if (!flag2)
            {
                return this.GetPathFromGeneralName(controllerContext, viewLocations, name, controllerName, areaName, theme, key, ref searchedLocations);
            }
            //特殊路径时的操作
            return this.GetPathFromSpecificName(controllerContext, name, key, ref searchedLocations);
        }

        /// <summary>
        /// 判读文件扩展名是否为“.cshtml”，“.vbhtml”
        /// </summary>
        protected bool FilePathIsSupported(string virtualPath)
        {
            return virtualPath.EndsWith(".cshtml", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 特使路径时构建视图路径
        /// </summary>
        protected string GetPathFromSpecificName(ControllerContext controllerContext, string name, string cacheKey, ref string[] searchedLocations)
        {
            //视图路径
            string virtualPath = name;
            //扩展名不为“.cshtml”或者文件不存在时
            if (!this.FilePathIsSupported(name) || !this.FileExists(controllerContext, name))
            {
                virtualPath = string.Empty;
                searchedLocations = new string[] { name };
            }
            //将路径添加到视图位置缓存
            this.ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, cacheKey, virtualPath);
            return virtualPath;
        }

        /// <summary>
        /// 不是特殊路径构建视图路径
        /// </summary>
        protected string GetPathFromGeneralName(ControllerContext controllerContext, List<ViewLocation> locations, string name, string controllerName, string areaName, string theme, string cacheKey, ref string[] searchedLocations)
        {
            //视图位置路径
            string virtualPath = string.Empty;
            searchedLocations = new string[locations.Count];
            //循环要查找的格式化位置列表
            for (int i = 0; i < locations.Count; i++)
            {
                //根据格式化字符串构建路径
                string str2 = locations[i].Format(name, controllerName, areaName, theme);
                //当视图文件存在时讲文件路径插入到缓存中
                if (this.FileExists(controllerContext, str2))
                {
                    searchedLocations = null;
                    virtualPath = str2;
                    this.ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, cacheKey, virtualPath);
                    return virtualPath;
                }
                //将路径添加到搜索位置列表中
                searchedLocations[i] = str2;
            }
            return virtualPath;
        }

        /// <summary>
        /// 创建视图位置的缓冲key
        /// </summary>
        protected string CreateCacheKey(string prefix, string name, string controllerName, string areaName, string theme)
        {
            return string.Format(":ViewCacheKey:{0}:{1}:{2}:{3}:{4}:{5}", new object[] { base.GetType().AssemblyQualifiedName, prefix, name, controllerName, areaName, theme });
        }

        /// <summary>
        /// 构建视图位置列表
        /// </summary>
        protected List<ViewLocation> GetViewLocations(string[] viewLocationFormats, string[] areaViewLocationFormats)
        {
            var list = new List<ViewLocation>();
            //区域不为空
            if (areaViewLocationFormats != null)
            {
                list.AddRange(areaViewLocationFormats.Select(str => new AreaAwareViewLocation(str)).Cast<ViewLocation>());
            }
            //视图不为空时
            if (viewLocationFormats != null)
            {
                list.AddRange(viewLocationFormats.Select(str2 => new ViewLocation(str2)));
            }
            return list;
        }

        /// <summary>
        /// 判读视图名称是否以“~”或“/”开头
        /// </summary>
        protected bool IsSpecificPath(string name)
        {
            char ch = name[0];
            if (ch != '~')
            {
                return (ch == '/');
            }
            return true;
        }

        /// <summary>
        /// 获取区域名称
        /// </summary>
        protected string GetAreaName(RouteData routeData)
        {
            object obj2;
            if (routeData.DataTokens.TryGetValue("area", out obj2))
            {
                return (obj2 as string);
            }
            return null;
        }

        /// <summary>
        /// 构建视图引擎结果
        /// </summary>
        protected ViewEngineResult FindThemeableView(ControllerContext controllerContext, string viewName, string masterName, bool useCache, bool mobile)
        {
            //视图文件搜索列表
            string[] strArray;
            //布局文件搜索列表
            string[] strArray2;

            if (string.IsNullOrWhiteSpace(viewName))
            {
                throw new ArgumentException("视图名不能为空", "viewName");
            }
            //获取主题名称
            //string theme = BSPConfig.ShopConfig.ThemeName;
            //获取控制器名称
            string requiredString = controllerContext.RouteData.GetRequiredString("controller");
            //获取视图文件路径
            string str2 = this.GetPath(controllerContext, this.ViewLocationFormats, this.AreaViewLocationFormats, "ViewLocationFormats", viewName, requiredString, theme, "View", useCache, mobile, out strArray);
            //获取布局文件的路径
            string str3 = this.GetPath(controllerContext, this.MasterLocationFormats, this.AreaMasterLocationFormats, "MasterLocationFormats", masterName, requiredString, theme, "Master", useCache, mobile, out strArray2);
            //视图文件和布局文件都存在时返回可以呈现的视图引擎
            if (!string.IsNullOrWhiteSpace(str2) && (!string.IsNullOrWhiteSpace(str3) || string.IsNullOrWhiteSpace(masterName)))
            {
                return new ViewEngineResult(this.CreateView(controllerContext, str2, str3), this);
            }
            //没有使用布局时将布局位置列表设为 new string[0]
            if (strArray2 == null)
            {
                strArray2 = new string[0];
            }
            //视图文件不存在或者布局文件不存在时返回没有找到的视图引擎
            return new ViewEngineResult(strArray.Union<string>(strArray2));

        }

        /// <summary>
        /// 构建分部视图引擎结果
        /// </summary>
        protected ViewEngineResult FindThemeablePartialView(ControllerContext controllerContext, string partialViewName, bool useCache, bool mobile)
        {
            string[] strArray;
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
            if (string.IsNullOrWhiteSpace(partialViewName))
            {
                throw new ArgumentException("分部视图名不能为空", "partialViewName");
            }
            //获取主题名称
            //string theme = BSPConfig.ShopConfig.ThemeName;
            //获取控制器名称
            string requiredString = controllerContext.RouteData.GetRequiredString("controller");
            //获取视图文件路径
            string str2 = this.GetPath(controllerContext, this.PartialViewLocationFormats, this.AreaPartialViewLocationFormats, "PartialViewLocationFormats", partialViewName, requiredString, theme, "Partial", useCache, mobile, out strArray);
            //视图文件不存在时返回没有找到的视图引擎
            if (string.IsNullOrWhiteSpace(str2))
            {
                return new ViewEngineResult(strArray);
            }
            //视图文件存在时返回可以呈现的视图引擎
            return new ViewEngineResult(this.CreatePartialView(controllerContext, str2), this);

        }

        #endregion

        #region 重写视图引擎方法

        /// <summary>
        /// 寻找视图的方法
        /// </summary>
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            //判读是否支持移动访问且访问是来自移动
            bool useMobileDevice = false; //(BSPConfig.ShopConfig.IsMobile == 1) && WebHelper.IsMobile();

            //如果支持移动访问且当前请求来自移动，则构建一个新的视图名称。例如：Index.Mobile
            string overrideViewName = useMobileDevice ?
                string.Format("{0}.{1}", viewName, _mobileviewmodifier)
                : viewName;
            //构建一个分部视图引擎结果
            ViewEngineResult result = FindThemeableView(controllerContext, overrideViewName, masterName, useCache, useMobileDevice);
            //当支持移动访问且原视图没有对应文件时采用overrideViewName名称解析
            if (useMobileDevice && (result == null || result.View == null))
                result = FindThemeableView(controllerContext, viewName, masterName, useCache, false);
            return result;

        }

        /// <summary>
        /// 寻找分部视图的方法
        /// </summary>
        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            //判读是否支持移动访问且访问是来自移动
            bool useMobileDevice = false;// (BSPConfig.ShopConfig.IsMobile == 1) && WebHelper.IsMobile();

            //如果支持移动访问且当前请求来自移动，则构建一个新的视图名称。例如：Index.Mobile
            string overrideViewName = useMobileDevice ?
                string.Format("{0}.{1}", partialViewName, _mobileviewmodifier)
                : partialViewName;
            //构建一个分部视图引擎结果
            ViewEngineResult result = FindThemeablePartialView(controllerContext, overrideViewName, useCache, useMobileDevice);

            //当支持移动访问且原视图没有对应文件时采用overrideViewName名称解析
            if (useMobileDevice && (result == null || result.View == null))
                result = FindThemeablePartialView(controllerContext, partialViewName, useCache, false);
            return result;
        }

        #endregion
    }

    /// <summary>
    /// 区域视图位置
    /// </summary>
    public class AreaAwareViewLocation : ViewLocation
    {
        public AreaAwareViewLocation(string virtualPathFormatString)
            : base(virtualPathFormatString)
        {
        }

        public override string Format(string viewName, string controllerName, string areaName, string theme)
        {
            return string.Format(_virtualPathFormatString, viewName, controllerName, areaName, theme);
        }
    }

    /// <summary>
    /// 视图位置
    /// </summary>
    public class ViewLocation
    {
        protected readonly string _virtualPathFormatString;

        public ViewLocation(string virtualPathFormatString)
        {
            _virtualPathFormatString = virtualPathFormatString;
        }

        public virtual string Format(string viewName, string controllerName, string areaName, string theme)
        {
            return string.Format(_virtualPathFormatString, viewName, controllerName, theme);
        }
    }

}
