using DotNet.Framework.WinXin.Core.Entity;
using DotNet.Framework.WinXin.Core.Interactive;
using DotNet.Framework.WinXin.Core.Utils;
using DotNet.Framework.WinXin.Core.Process;
using System.Configuration;
using System.IO;
using System.Web;

namespace DotNet.Framework.Admin.WebUI.Apis
{
    /// <summary>
    /// WinXin 的摘要说明
    /// </summary>
    public class WinXin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (context.Request.HttpMethod.ToUpper() == "GET")
            {
                validate(context);
            }
            else if(context.Request.HttpMethod.ToUpper() == "POST")
            {
                StreamReader stream = new StreamReader(context.Request.InputStream);
                string xml = stream.ReadToEnd();

                

                string result = ProcessFactory.Reply(xml);
                context.Response.Write(result);
                context.Response.End();
            }
            else
            {
                context.Response.Write("HTTP 请求方式不允许");
            }
            context.Response.End();
        }

        private static void validate(HttpContext context)
        {

            ValidateEntity entity = new ValidateEntity()
            {
                Token = ConfigurationManager.AppSettings["WinXinToken"],
                Echostr = context.Request["echostr"],
                Timestamp = context.Request["timestamp"],
                Nonce = context.Request["nonce"],
                Signature = context.Request["signature"]
            };
            bool validate = Authentication.Validate(entity);
            if (validate)
            {
                context.Response.Write(entity.Echostr);
            }
            else
            {
                context.Response.Write("出错了");
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}