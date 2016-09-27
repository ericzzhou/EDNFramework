using System.Collections.Generic;
using System.Web;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.Admin.Entity.EDNFramework_Account.ViewQueryCondition;
using DotNet.Framework.Admin.Core.Entity;
using System.Linq;
using System.Text;
using System;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.UI.Ajax.Account
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
            context.Response.ContentType = "application/json; charset=utf-8";
            string ajax = context.Request.QueryString["ajax"];
            switch (ajax.ToLower())
            {
                case "getlist":
                    GetList(context);
                    break;
                case "adddata":
                    Add(context);
                    break;
                case "editdata":
                    Edit(context);
                    break;
                case "deletemodel":
                    Delete(context);
                    break;
                case "getlistbyroleid":
                    GetListByRoleID(context);
                    break;
                case "impower":
                    Impower(context);
                    break;
                case "removeuserfromrole":
                    RemoveUserFromRole(context);
                    break;
                case "addmember":
                    AddMember(context);
                    break;
                case "loadactions":
                    LoadActions(context);
                    break;
                case "saveactions":
                    SaveActions(context);
                    break;
                default:
                    break;
            }
        }

        private void SaveActions(HttpContext context)
        {
#if !DEBUG
            CheckPermission.CheckRight(PermissionCode_RolePermission, "btn_action_save");
#endif
            IList<Entity_RolePermissionsAction> entities = ObjectJsonSerializer.Json2EntityFromAjaxRequest<IList<Entity_RolePermissionsAction>>(context.Request);
            if (entities == null || entities.Count == 0)
            {
                throw new BusinessException("没有选择任何内容");
            }
            if (!Business.EDNFramework_Account.Business_RolePermissionsAction.Refresh(entities))
            {
                throw new BusinessException("权限按钮保存失败。");
            }
        }

        private void LoadActions(HttpContext context)
        {
#if !DEBUG
            CheckPermission.CheckRight(PermissionCode_RolePermission, "btn_action_load");
#endif

            string html = BuildRoleActions(context.Request["roleid"].ToInt());
            dynamic result = new { body = html };
            context.Response.Write(ObjectJsonSerializer.Serialize<dynamic>(result));
        }

        private string BuildRoleActions(int roleID)
        {
            string html = "";
            IList<Entity_RolePermissionAction_Table> data = Business_Role.GetRole_permissionActions(roleID) ?? new List<Entity_RolePermissionAction_Table>();
            foreach (var item in data)
            {
                item.Actions = Business_PermissionAction.GetList(new ViewQueryCondition<Entity_PermissionAction_Condition>()
                {
                    Condition = new Entity_PermissionAction_Condition()
                    {
                        PermissionCode = item.PermissionCode
                    }
                }) ?? new List<Entity_PermissionAction>();
                item.RightActions = Business_RolePermissionsAction.GetList(new ViewQueryCondition<Entity_RolePermissionsAction>()
                {
                    Condition = new Entity_RolePermissionsAction()
                    {
                        ARPID = item.ARPID ?? Guid.Empty
                    }
                }) ?? new List<Entity_RolePermissionsAction>();


            }
            StringBuilder sbrHtml = new StringBuilder();
            CreateHtml(data, 0, sbrHtml, roleID);
            if (sbrHtml != null && sbrHtml.Length > 0)
            {
                html = sbrHtml.ToString();
            }
            return html;
        }


        private void AddMember(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_RolePermission, "btn_user_add");
            int Roleid = context.Request["rid"].ToInt();
            string users = context.Request["users"];
            if (Roleid <= 0 || users.IsNull())
            {
                throw new BusinessException("数据异常，请刷新重试。");
            }
            int[] userArr = users.ToIntArr(',');
            if (userArr == null || userArr.Count() <= 0)
            {
                throw new BusinessException("用户信息错误");
            }
            Business_Role.AddMembers(Roleid, userArr);
        }

        private void RemoveUserFromRole(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_RolePermission, "btn_user_remove");
            int roleid = context.Request["roleid"].ToInt();
            int uid = context.Request["uid"].ToInt();

            if (BusEntity_LoginUser.Sys_LoginUser.UserID == uid)
            {
                throw new BusinessException("不能删除自己");
            }

            Business_User.RemoveUserFromRole(uid, roleid);
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

        private void GetListByRoleID(HttpContext context)
        {
            ViewQueryCondition<Entity_Role_Users_Condition> query =
ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<Entity_Role_Users_Condition>>(context.Request);

            PagingResult<IList<Entity_UserTableData>> result = Business_User.GetListByPager(query);
            context.Response.Write(result.ToString());
        }

        private void Delete(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_Role, "btn_delete");
            string roleIdStr = context.Request["RoleID"];
            if (!roleIdStr.IsInt())
            {
                throw new BusinessException("角色编号错误");
            }
            if (!Business_Role.Delete(roleIdStr.ToInt()))
            {
                throw new BusinessException("删除失败");
            }
        }

        private void Edit(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_Role, "btn_modify");
            int RoleID = context.Request["RoleID"].ToInt();
            string RoleName = context.Request["RoleName"];
            string Description = context.Request["Description"];
            if (string.IsNullOrWhiteSpace(RoleName))
            {
                throw new BusinessException("RoleName 不能为空");
            }

            Entity_Role entity = new Entity_Role();
            entity.RoleName = RoleName;
            entity.Description = Description;
            entity.RoleID = RoleID;
            if (!Business_Role.Update(entity))
            {
                throw new BusinessException("编辑失败");
            }
        }

        private void Add(HttpContext context)
        {
            CheckPermission.CheckRight(PermissionCode_Role, "btn_add");
            string RoleID = context.Request["RoleID"];
            string RoleName = context.Request["RoleName"];
            string Description = context.Request["Description"];
            if (string.IsNullOrWhiteSpace(RoleID))
            {
                if (string.IsNullOrWhiteSpace(RoleName))
                {
                    throw new BusinessException("RoleName 不能为空");
                }

                Entity_Role entity = new Entity_Role();
                entity.RoleName = RoleName;
                entity.Description = Description;

                if (Business_Role.AddModel(entity) <= 0)
                {
                    throw new BusinessException("添加失败");
                }
            }
            else
            {
                throw new BusinessException("操作错误");
            }
        }

        private void GetList(HttpContext context)
        {
            ViewQueryCondition<object> query =
ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<object>>(context.Request);

            PagingResult<IList<Entity_RoleList>> result = Business_Role.GetListByPager(query);
            context.Response.Write(result.ToString());
        }



        private void CreateHtml(IList<Entity_RolePermissionAction_Table> data, int ParentID, StringBuilder sbrHtml, int roleID)
        {
            //顶级
            var datas = data.Where(x => x.ParentID == ParentID).ToList();
            if (datas != null && datas.Count > 0)
            {
                foreach (Entity_RolePermissionAction_Table item in datas)
                {
                    sbrHtml.Append("<tr>");


                    #region 权限名
                    sbrHtml.Append("<td>");
                    sbrHtml.AppendFormat("{0}{1}", CreateSpacing(ParentID), item.PermissionName);
                    sbrHtml.Append("</td>");
                    #endregion

                    #region 权限按钮
                    sbrHtml.Append("<td>");
                    sbrHtml.Append(BuilderRightPermissionAction(roleID, item.ARPID, item.Actions, item.RightActions, item.Checked));
                    sbrHtml.Append("</td>");
                    #endregion

                    sbrHtml.Append("</tr>");

                    CreateHtml(data, item.ID, sbrHtml, roleID);
                }
            }
        }

        private string BuilderRightPermissionAction(int roleId, Guid? ARPID, IList<Entity_PermissionAction> all, IList<Entity_RolePermissionsAction> right, bool Checked)
        {
            StringBuilder sbr = new StringBuilder();
            foreach (var item in all)
            {
                if (Checked)
                {
                    bool contains = right.FirstOrDefault(x => x.ActionCode == item.ActionCode) != null;
                    sbr.AppendFormat("<a href=\"javascript:;\" data-permission=\"{0}\" data-action=\"{1}\" data-role=\"{2}\" class=\"btn {3}\">{4}</a>&nbsp;"
                        , ARPID, item.ActionCode, roleId,
                       ARPID.HasValue && ARPID.Value != Guid.Empty && contains ? "icon-ok" : "", item.Description
                        );
                }
            }

            return sbr.ToString();
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




        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


    }
}