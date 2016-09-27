using OnlineRepairs.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using OnlineRepairs.Web.Models;
using DotNet.Framework.Auth;
using System.Web.Security;
using DotNet.Framework.Utils.Safety;
using DotNet.Framework.Admin.Business.EDNFramework_SYS;
using DotNet.Framework.Admin.Core.Config;

namespace OnlineRepairs.Web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View("login");
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Register(string UserName, string Password, string Password2, string NickName, string Phone)
        {
            var ret = new JsonReturnValue { status = 0, message = "注册失败" };
            if (string.IsNullOrWhiteSpace(UserName))
            {
                ret.message = "请输入登录账号";
                return Json(ret);
            }
            if (string.IsNullOrWhiteSpace(Password))
            {
                ret.message = "请输入密码";
                return Json(ret);
            }
            if (string.IsNullOrWhiteSpace(Password2))
            {
                ret.message = "请输入重复密码";
                return Json(ret);
            }
            if (Password != Password2)
            {
                ret.message = "两次密码输入不一致";
                return Json(ret);
            }
            if (string.IsNullOrWhiteSpace(Phone))
            {
                ret.message = "请输入联系电话";
                return Json(ret);
            }
            Entity_User entity = new Entity_User();
            entity.Activity = true;

            entity.NickName = NickName;
            entity.Password = DESEncrypt.EncryptPassword(Password);
            entity.Phone = Phone;

            entity.UserName = UserName;
            entity.UserType = "UU";

            int defaultRole = Convert.ToInt32(Business_ConfigContent.GetValueByKey(SysConfig.Default_UserRoleID));
            if (Business_User.Add(entity, defaultRole) > 0)
            {
                try
                {
                    //"【鑫奕科技】亲爱的{@用户名}！恭喜您成为【鑫奕科技】会员，请牢记您的账号和密码，用户名：{@用户名} 密码：{@密码}";
                    string sms = Business_ConfigContent.GetValueByKey("sms_register").Replace("{@用户名}", UserName).Replace("{@密码}", Password);
                    OnlineRepairs.Library.ORBusiness.SendSMS(Phone, sms);
                }
                catch (Exception ex)
                {
                    
                }
                ret.status = 1;
            }
            return Json(ret);
        }

        [HttpPost]
        public JsonResult Login(string UserName, string Password)
        {

            var ret = new JsonReturnValue { status = 0, message = "登录失败" };
            if (UserName.IsNull())
            {
                ret.message = "用户名不能为空";
                return Json(ret);
            }
            if (Password.IsNull())
            {
                ret.message = "请输入登录密码";
                return Json(ret);
            }

            Entity_User model = Business_User.GetModel(UserName.Trim());
            if (model == null)
            {
                ret.message = string.Format("登录账户 [{0}] 不存在", UserName);
                return Json(ret);
            }

            string uPass = model.Password;
            if (uPass != DotNet.Framework.Utils.Safety.DESEncrypt.EncryptPassword(Password))
            {
                ret.message = string.Format("登录账户 [{0}] 密码输入错误，请重试。", UserName);
                return Json(ret);
            }

            if (!model.Activity)
            {
                ret.message = string.Format("账户 [{0}] 未激活，请联系管理员激活。", UserName);
                return Json(ret);
            }

            IList<int> userRoles = Business_User.GetUserRoles(model.UserID);
            AuthUserInfo info = new AuthUserInfo()
            {
                TrueName = model.TrueName ?? "未命名",
                UserID = model.UserID,
                UserName = model.UserName,
                RoleID = userRoles
            };

            string authUserData = AuthUserInfo.FormatAuthUserInfoToJson(info);


            DateTime expiration = DateTime.Now.AddDays(1);

            string formName = model.UserID.ToString();
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1
                , formName
                , DateTime.Now
                , expiration
                , false
                , authUserData
                );
            HttpContext.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket)));
            //Response.Redirect("index.aspx");
            //Response.Redirect(FormsAuthentication.GetRedirectUrl(formName, false));
            FormsAuthentication.GetRedirectUrl(formName, false);
            var t = HttpContext.User.Identity.IsAuthenticated;
            if (info.RoleID.Contains(3))
            {
                ret.status = 3;
            }
            else
            {
                ret.status = 1;
            }
            return Json(ret);
        }

    }
}
