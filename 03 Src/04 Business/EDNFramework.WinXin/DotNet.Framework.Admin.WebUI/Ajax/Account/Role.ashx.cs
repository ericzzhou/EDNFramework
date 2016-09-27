using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Utils.Serialization;
using System.Collections.Generic;
using System.Web;
using DotNet.Framework.Core.Extends;
namespace DotNet.Framework.Admin.WebUI.Ajax.Account
{
    /// <summary>
    /// Role 的摘要说明
    /// </summary>
    public class Role : IHttpHandler
    {
        public string PermissionCode_Role = "Account_Role_Index";
        public string PermissionCode_RolePermission = "Account_RolePermission_Index";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string ajax = context.Request["ajax"];
            if (string.IsNullOrWhiteSpace(ajax))
            {
                return;
            }
            switch (ajax.ToLower())
            {
                case "loadrole":
                    GetAllRole(context);
                    break;
                case "impower":
                    Impower(context);
                    break;
                default:
                    break;
            }
        }

        private void Impower(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_RolePermission, "btn_promission_gave");
            var roleId = context.Request["roleid"].ToInt();
            var pcodes = context.Request["pcodes"];
            List<string> codes = new List<string>();
            dynamic codesdynamic = ObjectJsonSerializer.Deserialize_NewTon<dynamic>(pcodes);
            foreach (var item in codesdynamic)
            {
                codes.Add(item.Value.Value);
            }
            if (codes == null || codes.Count <= 0)
            {
                throw new BusinessException("请选择要授权的权限点");
            }
            bool result = Business_Role.SavePermission(roleId, codes);
            if (result)
            {
                context.Response.Write("{}");
            }
        }

        private void GetAllRole(HttpContext context)
        {
            var Entities = Business_Role.GetAll();
            var json = ObjectJsonSerializer.Serialize<IList<Entity_RoleList>>(Entities);
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