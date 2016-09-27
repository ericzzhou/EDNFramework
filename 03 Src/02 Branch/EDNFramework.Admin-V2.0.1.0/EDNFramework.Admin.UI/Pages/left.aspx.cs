using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DotNet.Framework.Admin.UI.Pages
{
    public partial class left : System.Web.UI.Page
    {
        public string HtmlPermission = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            GetRolePermission();
        }

        private void GetRolePermission()
        {
            StringBuilder sbrHtml = new StringBuilder();
            //int userId = DotNet.Framework.Admin.Core.Entity.BusEntity_LoginUser.Sys_LoginUser.UserID;
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return;
            }
            int userId = Auth.AuthUserInfo.GetAuthUserInfo().UserID;
            if (userId > 0)
            {
                IList<Entity_Role_LeftPermissionTree> data = Business_Role.GetRolePermissionByUserLogined(userId) ?? new List<Entity_Role_LeftPermissionTree>();
                CreateRightTree(data, 0, sbrHtml);
                if (sbrHtml != null && sbrHtml.Length > 0)
                {
                    HtmlPermission = sbrHtml.ToString();
                }
            }

            if (string.IsNullOrWhiteSpace(HtmlPermission))
            {
                HtmlPermission = "没有任何权限";
            }
            //else
            //{
            //    Response.Write("没有任何权限");
            //    Response.End();
            //}
        }

        private void CreateRightTree(IList<Entity_Role_LeftPermissionTree> data, int ParentID, StringBuilder sbrHtml)
        {
            //顶级
            var datas = data.Where(x => x.ParentID == ParentID).ToList();
            if (datas != null && datas.Count > 0)
            {
                foreach (Entity_Role_LeftPermissionTree item in datas)
                {
                    if (item.ParentID == 0)
                    {
                        sbrHtml.AppendFormat("<h3>{0}</h3>", item.PermissionName);
                        sbrHtml.Append("<div>");
                    }

                    if (item.ParentID != 0)
                    {

                        sbrHtml.AppendFormat("<div style=\"cursor: pointer\" data-href=\"{0}{1}\">{2}</div>"
                            , DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath
                            , item.RequestUrl
                            , item.PermissionName);

                    }

                    CreateRightTree(data, item.ID, sbrHtml);
                    if (item.ParentID == 0)
                    {
                        sbrHtml.Append("</div>");
                    }




                }
            }
        }
    }
}