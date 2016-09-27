using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Auth;
using System.Web.Security;
using DotNet.Framework.Core.Exceptions;
namespace DotNet.Framework.Admin.WebUI.Ajax.Account
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string ajax = context.Request.QueryString["ajax"];
            switch (ajax.ToLower())
            {
                case "login":
                    Login(context);
                    break;
            }
        }

        private void Login(HttpContext context)
        {
            string message = "";
            string code = "n";

            var username = context.Request["username"];
            var password = context.Request["password"];
            bool keeplogin = context.Request["keeplogin"].ToBoolean();

            try
            {
                if (username.IsNull())
                {
                    message = "请输入登录账户";
                    throw new BusinessException("请输入登录账户");
                    return;
                }

                if (Business_User.GetUserNameCount(username) == 0)
                {
                    message = string.Format("登录账户 [{0}] 不存在", username);
                    throw new BusinessException(string.Format("登录账户 [{0}] 不存在", username));
                    return;
                }

                if (password.IsNull())
                {
                    message = "请输入登录密码";
                    throw new BusinessException("请输入登录密码");
                    return;
                }

                Entity_User model = Business_User.GetModel(username.Trim());
                if (model == null)
                {
                    message = string.Format("登录账户 [{0}] 不存在", username);
                    throw new BusinessException(string.Format("登录账户 [{0}] 不存在", username));
                    return;
                }
                else
                {
                    string uPass = model.Password;
                    if (uPass != DotNet.Framework.Utils.Safety.DESEncrypt.EncryptPassword(password))
                    {

                        message = string.Format("登录账户 [{0}] 密码输入错误，请重试。", username);
                        throw new BusinessException(string.Format("登录账户 [{0}] 密码输入错误，请重试。", username));
                        return;
                    }

                    if (!model.Activity)
                    {
                        message = string.Format("账户 [{0}] 未激活，请联系管理员激活。", username);
                        throw new BusinessException(string.Format("账户 [{0}] 未激活，请联系管理员激活。", username));
                        return;
                    }

                    Auth.AuthUserInfo info = new Auth.AuthUserInfo()
                    {
                        TrueName = model.TrueName ?? "未命名",
                        UserID = model.UserID,
                        UserName = model.UserName
                    };

                    string authUserData = AuthUserInfo.FormatAuthUserInfoToJson(info);


                    DateTime expiration = DateTime.Now;
                    //TODO 设置cookie
                    if (keeplogin)
                    {
                        expiration = expiration.AddDays(7);
                    }
                    else
                    {
                        expiration = expiration.AddDays(1);
                    }
                    string formName = model.UserID.ToString();
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1
                        , formName
                        , DateTime.Now
                        , expiration
                        , false
                        , authUserData
                        );
                    context.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket)));
                    //Response.Redirect("index.aspx");
                    //Response.Redirect(FormsAuthentication.GetRedirectUrl(formName, false));
                    message = string.Format("用户[{0}]登录成功", username);
                    code = "y";
                   

                }
            }

            catch (Exception ex)
            {
                message = "系统错误";
                code = "n";
            }

            dynamic json = new { message = message, code = code };
            string jsonString = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<dynamic>(json);
            context.Response.Write(jsonString);
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