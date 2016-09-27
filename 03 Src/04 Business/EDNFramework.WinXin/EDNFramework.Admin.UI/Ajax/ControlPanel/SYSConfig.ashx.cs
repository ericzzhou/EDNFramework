using DotNet.Framework.Admin.Business.EDNFramework_SYS;
using DotNet.Framework.Admin.Entity.EDNFramework_SYS;
using DotNet.Framework.Admin.Entity.EDNFramework_SYS.ViewQueryCondition;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Utils.Serialization;
using System.Collections.Generic;
using System.Web;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.UI.Ajax.ControlPanel
{
    /// <summary>
    /// SYSConfig 的摘要说明
    /// </summary>
    public class SYSConfig : IHttpHandler
    {
        public string PermissionCode = "controlpanel_sysConfig_default";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            string ajax = context.Request.QueryString["ajax"];
            switch (ajax.ToLower())
            {
                case "getpagerdata":
                    GetPagerData(context);
                    break;
                case "getmodel":
                    GetModel(context);
                    break;
                case "editdata":
                    Update(context);
                    break;
                case "adddata":
                    Add(context);
                    break;
                case "deletemodel":
                    Delete(context);
                    break;
            }
        }

        private void Delete(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_delete");
            int ID = context.Request["ID"].ToInt();

            if (!Business_ConfigContent.Delete(ID))
            {
                throw new BusinessException("删除失败");
            }
        }

        private void Add(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_add");
            string Keyname = context.Request["Keyname"];
            string Value = context.Request["Value"];
            string Description = context.Request["Description"];

            if (string.IsNullOrWhiteSpace(Keyname))
            {
                throw new BusinessException("Keyname 不能为空");
            }

            Entity_ConfigContent entity = new Entity_ConfigContent();
            entity.Value = Value;
            entity.Description = Description;
            entity.Keyname = Keyname;
            // 0:默认用户自己添加，可任意维护
            //-2:系统保留，不可见，不可维护
            //-1:系统保留，可见，可改，不可删
            entity.KeyType = 0;

            if (Business_ConfigContent.AddModel(entity) <= 0)
            {
                throw new BusinessException("添加失败");
            }
        }

        private void Update(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode, "btn_modify");
            int id = context.Request["id"].ToInt();
            string Value = context.Request["Value"];
            string Description = context.Request["Description"];
            string Keyname = context.Request["Keyname"];

            if (string.IsNullOrWhiteSpace(Keyname))
            {
                throw new BusinessException("Keyname 不能为空");
            }
            Entity_ConfigContent entity = new Entity_ConfigContent();
            entity.ID = id;
            entity.Value = Value;
            entity.Description = Description;
            entity.Keyname = Keyname;

            if (!Business_ConfigContent.UpdateModel(entity))
            {
                throw new BusinessException("更新失败");
            }
        }

        private void GetModel(HttpContext context)
        {
            int id = context.Request["id"].ToInt();
            var entity = Business_ConfigContent.GetModel(id);
            var json = ObjectJsonSerializer.Serialize<Entity_ConfigContent>(entity);
            context.Response.Write(json);
        }

        private void GetPagerData(HttpContext context)
        {
            ViewQueryCondition<Entity_ErrorLog_Condition>
              query =
                 ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<Entity_ErrorLog_Condition>>(context.Request);

            PagingResult<IList<Entity_ConfigContent>> result = Business_ConfigContent.GetListByPager(query);
            context.Response.Write(result.ToString());
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