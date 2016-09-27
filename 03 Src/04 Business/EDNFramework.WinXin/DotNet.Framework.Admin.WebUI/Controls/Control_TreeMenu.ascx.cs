using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet.Framework.Admin.WebUI.Controls
{
    public partial class Control_TreeMenu : System.Web.UI.UserControl
    {
        public string Menu { get; set; }
        //public string Action { get; set; }
        public string HtmlSiteMapPath { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            GetRolePermission();
        }

        private void GetRolePermission()
        {
            StringBuilder sbrHtml = new StringBuilder();
            //if (!HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    return;
            //}
            int userId = Auth.AuthUserInfo.GetAuthUserInfo().UserID;
            //int userId = 1;
            if (userId > 0)
            {
                IList<Entity_Role_LeftPermissionTree> data = Business_Role.GetRolePermissionByUserLogined(userId) ?? new List<Entity_Role_LeftPermissionTree>();
                CreateRightTree(data, 0, sbrHtml);
                if (sbrHtml != null && sbrHtml.Length > 0)
                {
                    this.HtmlSiteMapPath = sbrHtml.ToString();
                }
            }

            if (string.IsNullOrWhiteSpace(this.HtmlSiteMapPath))
            {
                this.HtmlSiteMapPath = "没有任何权限";
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
                    if (item.HasSon)
                    {
                        sbrHtml.AppendFormat("<li id=\"menu_{0}\">", item.ID);
                        sbrHtml.AppendFormat("<a href=\"#\"><i class=\"{0}\"></i> <span class=\"menu-item-parent\">{1}</span></a>", item.Ico, item.PermissionName);
                        sbrHtml.Append("<ul>");
                    }
                    else
                    {

                        sbrHtml.AppendFormat("<li id=\"menu_{0}\">", item.ID);
                        if (item.ParentID == 0)
                        {
                            sbrHtml.AppendFormat("<a href=\"{0}?menuid={1}\"><i class=\"{2}\"></i> <span class=\"menu-item-parent\">{3}</span></a>", item.RequestUrl,item.ID, item.Ico, item.PermissionName);
                            //sbrHtml.AppendFormat("<a href=\"{0}\"><i class=\"fa fa-lg fa-fw fa-windows\"></i><span class=\"menu-item-parent\">{1}</span></a>", item.ID, item.PermissionName);
                        }
                        else
                        {
                            sbrHtml.AppendFormat("<a href=\"{0}?menuid={1}\">{2}</a>"
                                , item.RequestUrl
                                ,item.ID
                                , item.PermissionName);
                        }
                    }



                    CreateRightTree(data, item.ID, sbrHtml);
                    if (item.HasSon)
                    {
                        sbrHtml.Append("</ul>");
                        sbrHtml.Append("</li>");
                    }
                    else
                    {
                        sbrHtml.Append("</li>");
                    }
                    //else
                    //{
                    //    sbrHtml.Append("<ul>");
                    //    sbrHtml.Append("<li>");

                    //    sbrHtml.AppendFormat("<a href=\"{0}\">{1}</a>"
                    //        , item.RequestUrl
                    //        , item.PermissionName);



                    //    sbrHtml.Append("</li>");
                    //    sbrHtml.Append("</ul>");
                    //}




                    //if (ParentID == 0)
                    //{

                    //}
                    //else
                    //{
                    //    sbrHtml.AppendFormat("<a href=\"{0}\">{1}</a>"
                    //        , item.RequestUrl
                    //        , item.PermissionName);
                    //}



                    //CreateRightTree(data, item.ID, sbrHtml);





                    //if (item.ParentID != 0)
                    //{
                    //    sbrHtml.Append("</ul>");
                    //}
                    //sbrHtml.Append("</li>");
                }
            }
        }
    }
}