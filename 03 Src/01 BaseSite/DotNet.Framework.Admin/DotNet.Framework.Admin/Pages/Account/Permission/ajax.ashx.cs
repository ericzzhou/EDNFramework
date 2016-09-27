using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNet.Framework.Admin.Pages.Account.Permission
{
    /// <summary>
    /// ajax 的摘要说明
    /// </summary>
    public class ajax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string ajax = context.Request["ajax"];
            context.Response.ContentType = "text/plain";
            if (!string.IsNullOrEmpty(ajax))
            {
                if (ajax.ToLower() == "getcategories")
                {
                    GetPermissionCategories(context);
                }

                if (ajax.ToLower() == "getpermissionnames")
                {
                    GetPermissionNames(context);
                }
                //context.Response.End();
            }
        }

        private void GetPermissionNames(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private void GetPermissionCategories(HttpContext context)
        {
            IList<Entity_PermissionCategories> Entities = Busincess_PermissionCategories.GetAll();
            context.Response.ContentType = "text/json";
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<IList<Entity_PermissionCategories>>(Entities);
            context.Response.Write(json);

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