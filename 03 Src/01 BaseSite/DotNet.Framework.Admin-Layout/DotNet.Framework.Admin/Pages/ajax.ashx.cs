using DotNet.Framework.Admin.Core.Config;
using DotNet.Framework.Utils.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace DotNet.Framework.Admin.Pages
{
    /// <summary>
    /// ajax 的摘要说明
    /// </summary>
    public class ajax : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var q = context.Request.QueryString["ajax"];
            if (q != null)
            {
                switch (q.ToString().ToLower())
                {
                    case "chacklogin":
                        CheckLogin(context);
                        break;
                    default:
                        break;
                }
            }
        }

        private void CheckLogin(HttpContext context)
        {
            string jsonString = "status:\"{0}\",admin_id:\"{1}\",admin_username:\"{2}\",admin_truename:\"{3}\"";
            string admin_id = CookieManager.GetCookieValue(SysConfig.Config_CookieName_AdminId);
            string admin_username = CookieManager.GetCookieValue(SysConfig.Config_CookieName_AdminUserName);
            string admin_truename = CookieManager.GetCookieValue(SysConfig.Config_CookieName_AdminTrueName);
            string result = "{" + string.Format(jsonString, "false", admin_id, admin_username, admin_truename) + "}";

            if (!string.IsNullOrWhiteSpace(admin_id) && !string.IsNullOrWhiteSpace(admin_username) && !string.IsNullOrWhiteSpace(admin_truename))
            {
                result = "{" + string.Format(jsonString, "true", admin_id, admin_username, admin_truename) + "}";
            }

            context.Response.Write(result);
            context.Response.End();

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