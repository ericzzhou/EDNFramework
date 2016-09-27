using DotNet.Framework.DataAccess;
using System;
using System.Web;
namespace DotNet.Framework.Admin.Core.Business
{
    public class CheckPermission
    {
        static string noPermissionPage = Config.ConfigHelper.ResourcePath + "/Pages/NoPermission.aspx";
        public static bool HasRight(string permissionCode)
        {
            if (string.IsNullOrWhiteSpace(permissionCode))
            {
                return false;
            }
            string sql = @"
SELECT COUNT(EARP.ARPID) FROM EDNF_Account_RolePermissions EARP WITH(NOLOCK)
INNER JOIN EDNF_Account_UserRoles UR WITH(NOLOCK)
	ON UR.RoleID = EARP.RoleID
WHERE UR.UserID=@UserID AND EARP.PermissionCode=@PermissionCode
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@UserID",Entity.BusEntity_LoginUser.Sys_LoginUser.UserID);
            cmd.SetParamter("@PermissionCode",permissionCode);
            return (int)cmd.ExecuteSingle() > 0;
        }
        public static bool HasRight(string permissionCode, string actionCode)
        {
            if (string.IsNullOrWhiteSpace(permissionCode) || string.IsNullOrWhiteSpace(actionCode))
            {
                return false;
            }
            string sql = @"
SELECT 
	COUNT(EARPA.ARPAID) 
	FROM EDNF_Account_RolePermissionsAction EARPA  WITH(NOLOCK)
	INNER JOIN EDNF_Account_RolePermissions EARP WITH(NOLOCK)
		ON EARPA.ARPID = EARP.ARPID
	INNER JOIN EDNF_Account_UserRoles UR WITH(NOLOCK)
		ON UR.RoleID = EARP.RoleID
	WHERE 
		UR.UserID=@UserID 
		AND EARP.PermissionCode=@PermissionCode 
		AND EARPA.ActionCode=@ActionCode
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@UserID", Entity.BusEntity_LoginUser.Sys_LoginUser.UserID);
            cmd.SetParamter("@PermissionCode", permissionCode);
            cmd.SetParamter("@ActionCode", actionCode);
            return (int)cmd.ExecuteSingle() > 0;

        }

        /// <summary>
        /// 页面级权限验证，无权限跳转至提示页面
        /// </summary>
        /// <param name="permissionCode"></param>
        public static void CheckRight(string permissionCode)
        {
            if (DotNet.Framework.Auth.AuthUserInfo.GetAuthUserInfo().UserID == 1)
            {
                return;
            }
            if (!HasRight(permissionCode))
            {
                HttpContext.Current.Response.Redirect(noPermissionPage);
                HttpContext.Current.Response.End();
            }
        }

        /// <summary>
        /// 操作级权限验证，无权限抛出“无权限”异常
        /// </summary>
        /// <param name="permissionCode"></param>
        /// <param name="actionCode"></param>
        public static void CheckRight(string permissionCode, string actionCode)
        {
            if (DotNet.Framework.Auth.AuthUserInfo.GetAuthUserInfo().UserID == 1)
            {
                return;
            }
            if (!HasRight(permissionCode, actionCode))
            {
                throw new Exception("您没有权限进行此操作！");
            }
        }
    }
}
