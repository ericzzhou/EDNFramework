using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace EFramework.Web.Framework.Theme
{
    /// <summary>
    /// 主题视图引擎
    /// </summary>
    public class ThemeRazorViewEngine : ThemeBuildManagerViewEngine
    {
        public ThemeRazorViewEngine()
        {
            AreaViewLocationFormats = new[]
                                          {
                                              //主题
                                              "~/Areas/{2}{3}/Views/{1}/{0}.cshtml", 
                                              "~/Areas/{2}{3}/Views/Shared/{0}.cshtml", 
                                          };

            AreaMasterLocationFormats = new[]
                                            {
                                                //主题
                                                "~/Areas/{2}{3}/Views/Shared/{0}.cshtml", 
                                            };

            AreaPartialViewLocationFormats = new[]
                                                 {
                                                     //主题
                                                    "~/Areas/{2}{3}/Views/{1}/{0}.cshtml", 
                                                    "~/Areas/{2}{3}/Views/Shared/{0}.cshtml", 
                                                 };

            ViewLocationFormats = new[]
                                      {
                                            //主题
                                            "~/{2}Views/{1}/{0}.cshtml", 
                                            "~/{2}Views/Shared/{0}.cshtml",
                                      };

            MasterLocationFormats = new[]
                                        {
                                            //主题
                                            "~/{2}Views/Shared/{0}.cshtml", 

                                        };

            PartialViewLocationFormats = new[]
                                             {
                                                 //主题
                                                "~/{2}Views/{1}/{0}.cshtml", 
                                                "~/{2}Views/Shared/{0}.cshtml", 

                                             };
        }

        /// <summary>
        /// 创建Razor分部视图
        /// </summary>
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            //将布局文件设为null
            string layoutPath = null;
            //布局时不考虑_ViewStart.cshtml文件
            var runViewStartPages = false;
            IEnumerable<string> fileExtensions = FileExtensions;
            return new RazorView(controllerContext, partialPath, layoutPath, runViewStartPages, fileExtensions);
            //return new RazorView(controllerContext, partialPath, layoutPath, runViewStartPages, fileExtensions, base.ViewPageActivator);
        }

        /// <summary>
        /// 创建Razor视图
        /// </summary>
        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            //布局文件路径
            string layoutPath = masterPath;
            //布局时考虑_ViewStart.cshtml文件
            var runViewStartPages = true;
            IEnumerable<string> fileExtensions = FileExtensions;
            return new RazorView(controllerContext, viewPath, layoutPath, runViewStartPages, fileExtensions);
        }
    }
}
