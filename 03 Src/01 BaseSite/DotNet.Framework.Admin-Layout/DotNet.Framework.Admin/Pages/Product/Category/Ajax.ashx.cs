using DotNet.Framework.Admin.Business.EDNFramework_Product;
using DotNet.Framework.Admin.Entity.EDNFramework_Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNet.Framework.Admin.Pages.Product.Category
{
    /// <summary>
    /// Ajax 的摘要说明
    /// </summary>
    public class Ajax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string ajax = context.Request["ajax"];
            context.Response.ContentType = "text/plain";
            if (!string.IsNullOrEmpty(ajax))
            {
                switch (ajax.ToLower())
                {
                    case "getclass":
                        GetClass(context);
                        break;
                    default:
                        break;
                }
                //context.Response.End();
            }
        }

        private void GetClass(HttpContext context)
        {
            var Entities = Business_Product_Class.GetClass_DropDownList() ?? new List<Entity_Product_Class_Dropdownlist>();
            context.Response.ContentType = "text/json";
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<IList<Entity_Product_Class_Dropdownlist>>(Entities);
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