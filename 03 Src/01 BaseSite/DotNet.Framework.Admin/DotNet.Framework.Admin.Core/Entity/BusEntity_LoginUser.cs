
using DotNet.Framework.Admin.Core.Config;
using DotNet.Framework.Utils.Safety;
using DotNet.Framework.Utils.Web;
using System;

namespace DotNet.Framework.Admin.Core.Entity
{
    public class BusEntity_LoginUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string TrueName { get; set; }
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
                    return new BusEntity_LoginUser()
                    {
                        UserID = Convert.ToInt32(DESEncrypt.Decrypt(CookieManager.GetCookieValue(SysConfig.Config_CookieName_AdminId))),
                        UserName = DESEncrypt.Decrypt(CookieManager.GetCookieValue(SysConfig.Config_CookieName_AdminUserName)),
                        TrueName = DESEncrypt.Decrypt(CookieManager.GetCookieValue(SysConfig.Config_CookieName_AdminTrueName))
                    };
                }
            }
            set
            {
                Sys_LoginUser = value;
            }
        }

        
    }
}
