
namespace DotNet.Framework.Admin.Core.Config
{
    public class SysConfig
    {

        /// <summary>
        /// 系统预留角色列表，以","分隔
        /// </summary>
        public static string Reserved_RoleIDs { get { return "Reserved_RoleIDs"; } }

        public static string Reserved_AdminID { get { return "Reserved_AdminID"; } }

        public static string Default_Password { get { return "Default_Password"; } }
        /// <summary>
        /// 默认用户注册 角色
        /// </summary>
        public static string Default_UserRoleID { get { return "Default_UserRoleID"; } }
        /// <summary>
        /// 管理平台 logo 地址
        /// </summary>
        public static string SYS_AdminLogoPath { get { return "SYS_AdminLogoPath"; } }
        /// <summary>
        /// 系统配置：系统名称
        /// </summary>
        public static string SYS_WebSiteName { get { return "SYS_WebSiteName"; } }
        /// <summary>
        /// 系统配置：版权所有
        /// </summary>
        public static string SYS_WebCopyRight { get { return "SYS_WebCopyRight"; } }
        /// <summary>
        /// (-2)系统配置类型，拒绝修改类型
        /// </summary>
        public static int Config_DenyModifyType { get { return -2; } }

        /// <summary>
        /// (-1)系统配置类型，拒绝删除类型
        /// </summary>
        public static int Config_DenyDeleteType { get { return -1; } }

        #region 会话
        public static string Config_CookieName_AdminId { get { return "admin_id"; } }
        public static string Config_CookieName_AdminUserName { get { return "admin_username"; } }
        public static string Config_CookieName_AdminTrueName { get { return "admin_truename"; } }
        #endregion

    }
}
