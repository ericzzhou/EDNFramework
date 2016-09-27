
using DotNet.Framework.Admin.Core.Config;
using DotNet.Framework.Utils.Web;
namespace DotNet.Framework.Admin.Core.BasePage
{
    public class Base_MasterPage : System.Web.UI.MasterPage
    {
        public static string ResourcePath
        {
            get
            {
                return Config.ConfigHelper.ResourcePath;
            }
        }

        public static string Css = string.Empty;
        public static string Script = string.Empty;

        protected override void OnInit(System.EventArgs e)
        {
            string admin_id = CookieManager.GetCookieValue(SysConfig.Config_CookieName_AdminId);
            string admin_username = CookieManager.GetCookieValue(SysConfig.Config_CookieName_AdminUserName);
            string admin_truename = CookieManager.GetCookieValue(SysConfig.Config_CookieName_AdminTrueName);
            if (string.IsNullOrWhiteSpace(admin_id) || string.IsNullOrWhiteSpace(admin_username) || string.IsNullOrWhiteSpace(admin_truename))
            {
                Response.Redirect(ResourcePath + "/Login.aspx");
            }

        }

        protected override void OnLoad(System.EventArgs e)
        {
            Css = string.Empty;
            Css += "<link href=\"{#ResourcePath#}/Resource/Style/bootstrap.min.css\" rel=\"stylesheet\"  type=\"text/css\" />";

            Css += "<link href=\"{#ResourcePath#}/Resource/Libs/jquery-ui/bundle/themes/base/jquery.ui.all.css\" rel=\"stylesheet\"  type=\"text/css\" />";

            //Css += "<link href=\"{#ResourcePath#}/Resource/Style/bootstrap-responsive.min.css\" rel=\"stylesheet\" />";
            Css += "<link href=\"{#ResourcePath#}/Resource/Style/font-awesome.css\" rel=\"stylesheet\" />";
            Css += "<link href=\"{#ResourcePath#}/Resource/Style/base-admin.css\" rel=\"stylesheet\" />";
            //Css += "<link href=\"{#ResourcePath#}/Resource/Style/base-admin-responsive.css\" rel=\"stylesheet\" />";
            //Css += "<link href=\"{#ResourcePath#}/Resource/Style/pages/dashboard.css\" rel=\"stylesheet\" />";
            //Css += "<link href=\"{#ResourcePath#}/Resource/Libs/showLoading/css/showLoading.css\" rel=\"stylesheet\" />";

            Css += "<link href=\"{#ResourcePath#}/Resource/Libs/pqgrid/pqgrid.min.css\" rel=\"stylesheet\" />";
            Css += "<link href=\"{#ResourcePath#}/Resource/Libs/terebentina-sco.js/css/scojs.css\" rel=\"stylesheet\" />";
            //Css += "<link href=\"{#ResourcePath#}/Resource/Libs/iCheck/skins/all.css\" rel=\"stylesheet\" />";


            Css = Css.Replace("{#ResourcePath#}", ResourcePath);
            Css = Server.HtmlDecode(Css);

            string url = Request.RawUrl.ToString();
            Script = string.Format("<script src=\"{0}/Resource{1}\"></script>", ResourcePath, url.Replace(".aspx", ".js"));

        }
    }
}
