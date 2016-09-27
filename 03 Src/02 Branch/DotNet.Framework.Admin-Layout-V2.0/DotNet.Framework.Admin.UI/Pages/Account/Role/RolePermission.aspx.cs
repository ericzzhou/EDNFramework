using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using System;
using System.Collections.Generic;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Core.Business;
using System.Text;
using System.Linq;
using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Admin.Entity.EDNFramework_Account.ViewQueryCondition;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Admin.Core.Entity;
namespace DotNet.Framework.Admin.UI.Pages.Account.Role
{
    public partial class RolePermission : System.Web.UI.Page
    {
        public string html_permission = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("Account_RolePermission_Index");
            var ajax = Request.QueryString["ajax"];
            var roleId = Request["roleid"];
            if (!string.IsNullOrWhiteSpace(ajax))
            {
                switch (ajax)
                {
                    case "getuser":
                        GetUsers();
                        break;
                    case "getnotmembers":
                        GetNoMembers();
                        break;
                    case "savemembers":
                        SaveMembers();
                        break;
                    case "impower":
                        Impower();
                        break;
                    case "getlistbyroleid":
                        GetListByRoleID();
                        break;
                    case "RemoveUserFromRole":
                        RemoveUserFromRole();
                        break;

                }
            }
            else
            {

                GetRoleList();
                if (roleId.IsInt() && roleId.ToInt() > 0)
                {
                    GetRole_permission(roleId.ToInt());
                }
            }

        }

        private void RemoveUserFromRole()
        {
            int roleid = Request["roleid"].ToInt();
            int uid = Request["uid"].ToInt();

            if (BusEntity_LoginUser.Sys_LoginUser.UserID == uid)
            {
                throw new BusinessException("不能删除自己");
            }

            if (Business_User.RemoveUserFromRole(uid, roleid))
            {
                Response.Write("{}");
            }
            Response.End();
        }
        private void GetListByRoleID()
        {

            ViewQueryCondition<Entity_Role_Users_Condition> query =
ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<Entity_Role_Users_Condition>>(Request);

            PagingResult<IList<Entity_UserTableData>> result = Business_User.GetListByPager(query);
            Response.Write(result.ToString());
            Response.End();
        }
        private void Impower()
        {
            var roleId = Request["roleid"].ToInt();
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
            bool result = Business_Role.SavePermission(roleId, codes);
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

        private void SaveMembers()
        {
            int roleId = Request["roleid"].ToInt();
            string users = Request["uids"];
            string[] uidArr = users.Split(',');
            Business_Role.AddMembers(roleId, uidArr);
            Response.Write("{}");
            Response.End();
        }

        private void GetNoMembers()
        {
            int roleId = Request["roleid"].ToInt();
            var Entities = Business_User.GetNoMembers(roleId);
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<IList<Entity_RoleMembers>>(Entities);
            Response.Write(json);
            Response.End();
        }

        private void GetUsers()
        {
            int roleId = Request["roleid"].ToInt();
            var Entities = Business_User.GetTablesData(roleId);
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<IList<Entity_UserTableData>>(Entities);
            Response.Write(json);
            Response.End();

        }

        private void GetRoleList()
        {
            var Entities = Business_Role.GetAll();
            this.rep_roles.DataSource = Entities;
            this.rep_roles.DataBind();
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
                s = "&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            else
            {
                s = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            //for (int i = 0; i < (ParentID + 1) * 4; i++)
            //{
            //    s += "&nbsp;";
            //}
            return s;
        }

    }
}