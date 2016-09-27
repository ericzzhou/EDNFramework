using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
using System.Web;
namespace DotNet.Framework.Auth
{
    public class AuthUserInfo
    {
        public IList<int> RoleID { get; set; }
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string TrueName { get; set; }

        public static AuthUserInfo GetAuthUserInfo()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return new AuthUserInfo();
            }

            System.Web.Security.FormsIdentity fi = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
            System.Web.Security.FormsAuthenticationTicket ticket = fi.Ticket;

            return ObjectJsonSerializer.Deserialize<AuthUserInfo>(ticket.UserData);
        }

        public static string FormatAuthUserInfoToJson(AuthUserInfo entity)
        {
            if (entity == null)
            {
                throw new Exception("Auth信息不存在，设置用户信息失败.");
            }
            return ObjectJsonSerializer.Serialize<Auth.AuthUserInfo>(entity);
        }
    }
}
