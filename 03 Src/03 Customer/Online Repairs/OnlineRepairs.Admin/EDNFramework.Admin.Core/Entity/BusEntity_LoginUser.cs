

using DotNet.Framework.Auth;
using System.Collections.Generic;
using System.Web;
namespace DotNet.Framework.Admin.Core.Entity
{
    public class BusEntity_LoginUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string TrueName { get; set; }
        public IList<int> UserRole { get; set; }

        /// <summary>
        /// 当前登录系统的用户
        /// </summary>
        public static BusEntity_LoginUser Sys_LoginUser
        {
            get
            {
                if (Config.ConfigHelper.MockUser)
                {
                    return new BusEntity_LoginUser()
                    {
                        UserID = 0,
                        UserName = "MockUser",
                        TrueName = "模拟用户"
                    };
                }
                else
                {
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        var auth = AuthUserInfo.GetAuthUserInfo();
                        return new BusEntity_LoginUser()
                        {
                            TrueName = auth.TrueName,
                            UserID = auth.UserID,
                            UserName = auth.UserName, UserRole = auth.RoleID
                        };
                    }
                    return null;
                }
            }
            set
            {
                Sys_LoginUser = value;
            }
        }


    }
}
