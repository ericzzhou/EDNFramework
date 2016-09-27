using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNet.Framework.Admin.UI.Ajax.Log
{
    /// <summary>
    /// UserLog 的摘要说明
    /// </summary>
    public class UserLog : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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