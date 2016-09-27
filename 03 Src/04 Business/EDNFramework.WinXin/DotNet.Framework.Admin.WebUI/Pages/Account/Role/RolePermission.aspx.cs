using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using System.Text;
namespace DotNet.Framework.Admin.WebUI.Pages.Account.Role
{
    public partial class RolePermission : System.Web.UI.Page
    {
        public string HtmlPermission { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            GetRole_permission();
        }

        private void GetRole_permission()
        {
            string reqRole = Request["role"];
            if (string.IsNullOrWhiteSpace(reqRole) || !reqRole.IsInt() || reqRole.ToInt() <= 0)
            {
                HtmlPermission = FormatNoData();
                return;
            }

            HtmlPermission = FormatHtml(reqRole.ToInt());

        }

        private string FormatHtml(int roleID)
        {
            IList<Entity_Role_Permission_Table> data = Business_Role.GetRole_permission(roleID) ?? new List<Entity_Role_Permission_Table>();

            if (data == null || data.Count <= 0)
            {
                return FormatNoData();
            }
            StringBuilder sbrHtml = new StringBuilder();
            CreateHtml(data, 0, sbrHtml);
            return sbrHtml.ToString();
        }

        private void CreateHtml(IList<Entity_Role_Permission_Table> data, int parentID, StringBuilder sbrHtml)
        {
            //顶级
            var datas = data.Where(x => x.ParentID == parentID).ToList();
            if (datas != null && datas.Count > 0)
            {
                foreach (Entity_Role_Permission_Table item in datas)
                {
                    sbrHtml.Append("<tr>");


                    #region 权限名
                    sbrHtml.Append("<td>");
                    sbrHtml.AppendFormat("<label class=\"checkbox inline\">{0}", CreateSpacing(parentID,item.HasSon));
                    sbrHtml.AppendFormat("<input name=\"ckPermission\" data-parent=\"" + item.ParentID + "\" data-this=\"" + item.ID + "\" type=\"checkbox\"  value=\"{0}\" {1}/>"
                        , item.PermissionCode
                        , item.Checked.ToLower() == "true" ? " checked=\"checked\" " : "");
                    sbrHtml.AppendFormat(item.PermissionName);
                    sbrHtml.Append("</label>");
                    sbrHtml.Append("</td>");
                    #endregion

                    #region 权限码
                    //sbrHtml.AppendFormat("<td>{0}</td>", item.PermissionCode);
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

        private string FormatNoData()
        {
            return "没有数据";
        }

        private string CreateSpacing(int ParentID,bool hasSone)
        {
            string s = "";

            if (ParentID == 0)
            {
                s = "<label class=\"col-md-1 control-label\"></label>";
            }
            else if (ParentID == 0 && !hasSone)
            {
                s = "<label class=\"col-md-3 control-label\"></label>";
            }
            else if (ParentID != 0 && !hasSone)
            {
                s = "<label class=\"col-md-3 control-label\"></label>";
            }
            else if (ParentID != 0 && hasSone)
            {
                s = "<label class=\"col-md-2 control-label\"></label>";
            }
            else
            {
                s = "<label class=\"col-md-3 control-label\"></label>";
            }
            //for (int i = 0; i < (ParentID + 1) * 4; i++)
            //{
            //    s += "&nbsp;";
            //}
            return s;
        }
    }
}