
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
        /// (-2)系统配置类型，拒绝修改类型
        /// </summary>
        public static int Config_DenyModifyType { get { return -2; } }

        /// <summary>
        /// (-1)系统配置类型，拒绝删除类型
        /// </summary>
        public static int Config_DenyDeleteType { get { return -1; } }

        public static string Config_CookieName_AdminId { get { return "admin_id"; } }
        public static string Config_CookieName_AdminUserName { get { return "admin_username"; } }
        public static string Config_CookieName_AdminTrueName { get { return "admin_truename"; } }




    }
}
