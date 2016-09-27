using System.Web;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Core.Entity.Exceptions;
namespace DotNet.Framework.Core.HttpModules
{
    /// <summary>
    /// 全局Model
    /// </summary>
    public class DotNetGlobalModule : IHttpModule
    {
        public void Dispose() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.Error += context_Error;
        }

        void context_BeginRequest(object sender, System.EventArgs e)
        {
            //string contentType = DotNetFrameworkContext.AcceptType.ToLower();
            //if (contentType == HttpConst.AcceptTypes.Html)
            //{
            //    HttpContext context = HttpContext.Current;

            //    StringBuilder sbrCopy = new StringBuilder();
            //    sbrCopy.AppendLine("<!--");
            //    sbrCopy.Append("DotNet.Framework");
            //    sbrCopy.AppendFormat("By @Eric {0} ", DateTime.Now.Year);
            //    sbrCopy.AppendLine("mailto:zhouzhaokun@gmail.com");
            //    sbrCopy.Append("-->");
            //    sbrCopy.AppendLine();
            //    context.Response.Write(sbrCopy.ToString());
            //}
        }

        void context_Error(object sender, System.EventArgs e)
        {
            ExceptionProcessor.ProcessError(ServerLastError.GetLastError());
        }
    }
}
