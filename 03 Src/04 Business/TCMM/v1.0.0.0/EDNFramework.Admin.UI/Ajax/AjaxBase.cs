using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNet.Framework.Admin.UI.Ajax
{
    public class AjaxBase : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        protected HttpRequest Request;
        public virtual void ProcessRequest(HttpContext context)
        {
            Request = context.Request;
        }
    }
}