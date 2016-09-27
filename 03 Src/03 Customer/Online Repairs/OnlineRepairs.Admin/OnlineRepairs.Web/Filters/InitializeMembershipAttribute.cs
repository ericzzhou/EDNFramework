using DotNet.Framework.Admin.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineRepairs.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class InitializeMembershipAttribute : AuthorizeAttribute
    {
        public int Role { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
            {
                httpContext.Response.Redirect("/account/login?ReturnUrl=" + httpContext.Request.RawUrl);
                httpContext.Response.End();
                return false;
            }
            else
            {
                if (Role > 0 && !BusEntity_LoginUser.Sys_LoginUser.UserRole.Contains(Role))
                {
                    httpContext.Response.Redirect("/account/login?ReturnUrl=" + httpContext.Request.RawUrl);
                    httpContext.Response.End();
                    return false;
                }
                else
                    return true;
            }
        }
    }
}