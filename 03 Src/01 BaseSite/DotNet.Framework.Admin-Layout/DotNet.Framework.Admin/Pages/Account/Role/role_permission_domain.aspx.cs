using System;
using System.Collections.Generic;
using System.Linq;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using System.Text;
using DotNet.Framework.Utils.Serialization;
using System.Collections;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.Pages.Account.Role
{
    public partial class role_permission_domain : System.Web.UI.Page
    {
        public string html_permission = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("Account_RolePermission_Index");
            var roleId = Request["roleid"];
            var ajax = Request.QueryString["ajax"];
            if (!string.IsNullOrWhiteSpace(ajax))
            {
                switch (ajax)
                {
                    case "savepermission":
                        SavePermission(roleId.ToInt());
                        break;
                }
            }
            else
            {


                if (roleId.IsInt() && roleId.ToInt() > 0)
                {
                    GetRole_permission(roleId.ToInt());
                }
            }
        }

        private void SavePermission(int roleid)
        {
            var pcodes = Request["pcodes"];
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
            bool result = Business_Role.SavePermission(roleid, codes);
            if (result)
            {
                Response.Write("{}");
            }
            Response.End();
        }

        private void GetRole_permission(int roleId)
        {
            IList<Entity_Role_Permission_Table> data = Business_Role.GetRole_permission(roleId) ?? new List<Entity_Role_Permission_Table>();
            StringBuilder sbrHtml = new StringBuilder();
            CreateHtml(data, 0, sbrHtml);
            if (sbrHtml != null && sbrHtml.Length > 0)
            {
                html_permission = sbrHtml.ToString();
            }
        }

        private void CreateHtml(IList<Entity_Role_Permission_Table> data, int ParentID, StringBuilder sbrHtml)
        {
            //顶级
            var datas = data.Where(x => x.ParentID == ParentID).ToList();
            if (datas != null && datas.Count > 0)
            {
                foreach (Entity_Role_Permission_Table item in datas)
                {
                    sbrHtml.Append("<tr>");


                    #region 权限名
                    sbrHtml.Append("<td>");
                    sbrHtml.AppendFormat("{0}<label class=\"checkbox inline\">", CreateSpacing(ParentID));
                    sbrHtml.AppendFormat("<input name=\"ckPermission\" data-parent=\"" + item.ParentID + "\" data-this=\"" + item.ID + "\" type=\"checkbox\"  value=\"{0}\" {1}/>"
                        , item.PermissionCode
                        , item.Checked.ToLower() == "true" ? " checked=\"checked\" " : "");
                    sbrHtml.AppendFormat(item.PermissionName);
                    sbrHtml.Append("</label>");
                    sbrHtml.Append("</td>");
                    #endregion

                    #region 权限码
                    sbrHtml.AppendFormat("<td>{0}</td>", item.PermissionCode);
                    #endregion

                    #region 权限类别
                    sbrHtml.AppendFormat("<td>{0}</td>", item.CategoryName);
                    #endregion

                    #region 请求地址
                    sbrHtml.AppendFormat("<td>{0}</td>", item.RequestUrl);
                    #endregion

                    #region 描述
                    sbrHtml.AppendFormat("<td>{0}</td>", item.Description);
                    #endregion

                    sbrHtml.Append("</tr>");

                    CreateHtml(data, item.ID, sbrHtml);
                }
            }
        }

        private string CreateSpacing(int ParentID)
        {
            string s = "";

            if (ParentID == 0)
            {
                return "&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            else
            {
                return "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            //for (int i = 0; i < (ParentID + 1) * 4; i++)
            //{
            //    s += "&nbsp;";
            //}
            return s;
        }
    }
}