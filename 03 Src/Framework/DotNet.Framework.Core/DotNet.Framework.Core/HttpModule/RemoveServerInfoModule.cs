using System;
using System.Web;

namespace DotNet.Framework.Core.HttpModules
{
    /// <summary>
    /// 移除页面相应 ServiceHander 信息 Module（本地浏览不移除）
    /// Web.config modules节点下添加
    /// <add name="RemoveServerInfoModule" type="DotNet.Framework.Core.HttpModules.RemoveServerInfoModule,DotNet.Framework.Core"/>
    /// </summary>
    public class RemoveServerInfoModule : IHttpModule
    {
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
        
        /// <summary>
        /// HttpModules 入口
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += context_PreSendRequestHeaders;
        }

        void context_PreSendRequestHeaders(object sender, EventArgs e)
        {
            //HttpContext.Current.Response.Headers.Remove("Server");
            //HttpContext.Current.Response.Headers.Remove("X-AspNetMvc-Version");

            try
            {
                HttpApplication app = sender as HttpApplication;

                if (null != app && null != app.Request && !app.Request.IsLocal && null != app.Context && null != app.Context.Response)
                {
                    var headers = app.Context.Response.Headers;

                    if (null != headers)
                    {
                        headers.Remove("Server");
                    }
                }
            }
            catch
            {
                //异常记录
                throw;
            }
        }
    }
}
