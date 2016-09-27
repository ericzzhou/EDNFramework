using DotNet.Framework.Core.Entity.Runtime;
using System;
using System.Collections.Specialized;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace DotNet.Framework.Core.WebRuntime
{
    public sealed class DotNetFrameworkContext : ILogicalThreadAffinative
    {
        private NameValueCollection m_qsCollection;
        private Uri m_currentUri;
        private string m_returnUrl;
        private Browser m_browserInfo;
        private HttpContext m_httpContext;

        public DotNetFrameworkContext()
        {
            m_httpContext = HttpContext.Current;
            m_qsCollection = new NameValueCollection(m_httpContext.Request.QueryString);
            m_currentUri = m_httpContext.Request.Url;
            m_browserInfo = new Browser(m_httpContext);
        }

        /// <summary>
        /// 是否异步请求，如果 AjaxRequestType 不为空，就是 异步请求
        /// </summary>
        public static bool IsAjaxRequest { get { return AjaxRequestType != String.Empty; } }

        /// <summary>
        /// Ajax 请求类型
        /// </summary>
        public static string AjaxRequestType
        {
            get
            {
                string ajaxType = string.Empty;
                HttpContext httpContext = HttpContext.Current;
                if (httpContext.Request.Headers["X-MicrosoftAjax"] == "Delta=true" ||
                     httpContext.Request["__ASYNCPOST"] == "true")
                {
                    ajaxType = "aspnetAjax";                        // Asp.Net WebForm Ajax
                }
                else if (httpContext.Request["__MVCASYNCPOST"] == "true")
                {
                    ajaxType = "mvcAjax";                           // Asp.Net MVC Ajax
                }
                else if (httpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    ajaxType = "jqueryAjax";                        // jQuery Ajax 
                }
                else if (httpContext.Request.Headers["X-AjaxPro-Method"] != null)
                {
                    ajaxType = "ajaxPro";                           //Ajax Pro 
                }

                return ajaxType;
            }
        }

        public static string AcceptType
        {
            get
            {
                string[] acceptTypes = HttpContext.Current.Request.AcceptTypes;
                string acceptType = HttpConst.AcceptTypes.Html;

                if (acceptTypes != null)
                {
                    foreach (string s in acceptTypes)
                    {
                        if (s.Contains("/xml"))
                        {
                            acceptType = HttpConst.AcceptTypes.Xml;
                            break;
                        }
                        else if (s.Contains("/json"))
                        {
                            acceptType = HttpConst.AcceptTypes.Json;
                            break;
                        }
                        else if (s.Contains("/html"))
                        {
                            acceptType = HttpConst.AcceptTypes.Html;
                            break;
                        }
                        else if (s.Contains("/plain"))
                        {
                            acceptType = HttpConst.AcceptTypes.Text;
                            break;
                        }
                    }
                }

                return acceptType;
            }
        }
    }
}
