using DotNet.Framework.Admin.Business.EDNFramework_CMS;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using System.Collections.Generic;
using System.Web;

namespace DotNet.Framework.Admin.Pages.Articles.Category
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
                    case "getclasstype":
                        GetClassTypes(context);
                        break;
                    case "getclasslist":
                        GetClassList(context);
                        break;
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
            var Entities = Business_ContentClass.GetEntity_ContentClass_DropDownList();
            context.Response.ContentType = "text/json";
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<IList<Entity_ContentClass_DropDownList>>(Entities);
            context.Response.Write(json);

        }

        private void GetClassList(HttpContext context)
        {
            //Entity_ContentClass_GetList
            var Entities = Business_ContentClass.GetAll();
            context.Response.ContentType = "text/json";
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<IList<Entity_ContentClass_GetList>>(Entities);
            context.Response.Write("{\"aaData\":" + json + "}");
            
        }

        private void GetClassTypes(HttpContext context)
        {
            var Entities = Business_ClassType.GetAll();
            context.Response.ContentType = "text/json";
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<IList<Entity_ClassType>>(Entities);
            context.Response.Write(json);

        }




        public bool IsReusable
        {
            get { return true; }
        }
    }
}