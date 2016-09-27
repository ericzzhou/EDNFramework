using DotNet.Framework.Admin.Business.EDNFramework_SYS;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.DataAccess;
using System.Collections.Generic;
using DotNet.Framework.Core.Extends;
using System.Linq;
using System.Text;
namespace DotNet.Framework.Admin.Business.EDNFramework_Account
{
    public class Business_Role
    {

        public static IList<Entity_RoleList> GetAll()
        {
            string sqlString = @"
SELECT 
	R.RoleID,
    R.RoleName,
    R.Description,
	(   SELECT COUNT(UR.UserID) 
	        FROM EDNF_Account_UserRoles UR WITH(NOLOCK)
	        WHERE UR.RoleID = R.RoleID
	) as UserCount
	FROM EDNF_Account_Role R WITH(NOLOCK)
";
            Command cmd = CommandManager.CreateCommand(sqlString);

            return cmd.ExecuteEntities<Entity_RoleList>();
        }

        public static int AddModel(Entity_Role entity)
        {
            if (GetCodeCount(entity.RoleName) > 0)
            {
                throw new BusinessException("已经存在相同角色,不能重复添加");
            }
            string sqlString = @"
INSERT INTO [EDNF_Account_Role]
           ([RoleName]
           ,[Description])
     VALUES
           (@RoleName
           ,@Description)
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@RoleName", entity.RoleName);
            cmd.SetParamter("@Description", entity.Description);
            return cmd.ExecuteNonQuery();
        }

        public static Entity_Role GetModel(int id)
        {
            string sqlString = @"
SELECT 
	R.RoleID,
    R.RoleName,
    R.Description
	FROM EDNF_Account_Role R WITH(NOLOCK)
    WHERE R.RoleID=@RoleID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@RoleID", id);
            return cmd.ExecuteEntity<Entity_Role>();
        }

        public static bool Update(Entity_Role entity)
        {
            if (GetCodeCount(entity.RoleName, entity.RoleID) > 0)
            {
                throw new BusinessException("已经存在相同角色,不能重复添加");
            }

            string sqlString = @"
UPDATE [EDNF_Account_Role]
   SET [RoleName] = @RoleName
      ,[Description] = @Description
 WHERE RoleID = @RoleID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@RoleName", entity.RoleName);
            cmd.SetParamter("@Description", entity.Description);
            cmd.SetParamter("@RoleID", entity.RoleID);

            return cmd.ExecuteNonQuery() > 0;
        }

        private static int GetCodeCount(string RoleName, int RoleID)
        {
            string sqlString = @"
SELECT COUNT(RoleName)
 FROM [EDNF_Account_Role] WITH(NOLOCK)
 WHERE RoleName = @RoleName
        AND RoleID != @RoleID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@RoleName", RoleName);
            cmd.SetParamter("@RoleID", RoleID);
            return (int)cmd.ExecuteSingle();
        }

        private static int GetCodeCount(string RoleName)
        {
            string sqlString = @"
SELECT COUNT(RoleName)
 FROM [EDNF_Account_Role] WITH(NOLOCK)
 WHERE RoleName = @RoleName
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@RoleName", RoleName);
            return (int)cmd.ExecuteSingle();
        }

        private static int GetUserCount(int roleId)
        {
            string sqlString = @"
 SELECT COUNT(UR.UserID) 
	        FROM EDNF_Account_UserRoles UR WITH(NOLOCK)
	        WHERE UR.RoleID = @RoleID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@RoleID", roleId);
            return (int)cmd.ExecuteSingle();
        }
        public static bool Delete(int RoleID)
        {
            var sys_roles = Business_ConfigContent.GetValueByKey(Admin.Core.Config.SysConfig.Reserved_RoleIDs);
            if (!string.IsNullOrWhiteSpace(sys_roles))
            {
                int[] sysArr = sys_roles.ToIntArr(',');

                if (sysArr.Contains(RoleID))
                {
                    throw new BusinessException("系统预留角色，不允许删除");
                }
            }
            var userCount = GetUserCount(RoleID);
            if (userCount > 0)
            {
                throw new BusinessException(string.Format("当前角色下用户数为{0}，不允许直接删除，请先将用户信息移至其他角色。", userCount));
            }

            //TODO:判断是否有权限删除当前角色

            string sqlString = @"
DELETE FROM [EDNF_Account_Role]
      WHERE  RoleID = @RoleID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@RoleID", RoleID);

            return cmd.ExecuteNonQuery() > 0;


        }


        public static IList<Entity_RoleList> GetListByPager(int pageindex, int pagesize, string orderField, string dir, out int totolCount)
        {
            totolCount = 0;
            string totleString = @"
    SELECT COUNT(RoleID) 
    FROM [EDNF_Account_Role] WITH(NOLOCK) 
";
            Command cmdCount = CommandManager.CreateCommand(totleString);
            totolCount = cmdCount.ExecuteSingle<int>();

            string sqlString = string.Format(@"
SELECT * FROM 
(
    SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) NUM,
	R.RoleID,
    R.RoleName,
    R.Description,
	(   SELECT COUNT(UR.UserID) 
	        FROM EDNF_Account_UserRoles UR WITH(NOLOCK)
	        WHERE UR.RoleID = R.RoleID
	) as UserCount
	FROM EDNF_Account_Role R WITH(NOLOCK)
	)
	DATA
WHERE DATA.NUM BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
", orderField, dir);
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@sortBy", orderField);
            cmd.SetParamter("@PageIndex", pageindex);
            cmd.SetParamter("@PageSize", pagesize);
            return cmd.ExecuteEntities<Entity_RoleList>();

        }

        public static void AddMembers(int roleId, string[] uidArr)
        {
            StringBuilder sbrSql = new StringBuilder();
            if (uidArr.Length <= 0)
            {
                throw new BusinessException("未提交要加入当前角色的成员.");
            }
            foreach (var uid in uidArr)
            {
                sbrSql.AppendFormat("INSERT INTO [EDNF_Account_UserRoles] ([UserID] ,[RoleID]) VALUES ({0},{1})", uid, roleId);
            }
            if (sbrSql.Length <= 0)
            {
                throw new BusinessException("保存角色成员错误，请重试.");
            }
            Command cmd = CommandManager.CreateCommand(sbrSql.ToString());
            cmd.ExecuteNonQuery();

        }

        public static void AddMembers(int roleId, int[] uidArr)
        {
            StringBuilder sbrSql = new StringBuilder();
            if (uidArr.Length <= 0)
            {
                throw new BusinessException("未提交要加入当前角色的成员.");
            }
            foreach (var uid in uidArr)
            {
                sbrSql.AppendLine(string.Format(@"
IF NOT EXISTS(SELECT * FROM EDNF_Account_UserRoles WHERE UserID = {0} AND RoleID = {1})
BEGIN
	INSERT INTO [EDNF_Account_UserRoles] ([UserID] ,[RoleID]) VALUES ({0},{1})
END

", uid, roleId));
            }
            if (sbrSql.Length <= 0)
            {
                throw new BusinessException("保存角色成员错误，请重试.");
            }
            Command cmd = CommandManager.CreateCommand(sbrSql.ToString());
            cmd.ExecuteNonQuery();

        }

        public static IList<Entity_Role_Permission_Table> GetRole_permission(int roleId)
        {
            string sqlStr = @"
SELECT 
	(CASE 
		WHEN EXISTS(SELECT TOP 1 ARPID FROM EDNF_Account_RolePermissions EARP WHERE EARP.PermissionCode=EAP.PermissionCode AND EARP.RoleID = @ROLEID) THEN 'True'
		ELSE 'False'
		END
	) AS Checked
	,EAPC.Description AS CategoryName
	,EAP.*
FROM EDNF_Account_Permission EAP WITH(NOLOCK)
LEFT JOIN EDNF_Account_PermissionCategories EAPC WITH(NOLOCK)
	ON EAPC.CategoryID = EAP.CategoryID
	ORDER BY EAP.Sequence ASC 
";

            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@ROLEID", roleId);
            return cmd.ExecuteEntities<Entity_Role_Permission_Table>();
        }

        public static bool SavePermission(int roleid, List<string> codes)
        {
            StringBuilder sbrSql = new StringBuilder();
            sbrSql.Append(@"DELETE FROM [EDNF_Account_RolePermissions]
                         WHERE RoleID = @RoleID  ");
            sbrSql.AppendLine();
            foreach (string item in codes)
            {
                sbrSql.AppendFormat(@"
    INSERT INTO [EDNF_Account_RolePermissions]
           ([ARPID]
           ,[RoleID]
           ,[PermissionCode])
     VALUES
           (NEWID()
           ,@RoleID
           ,'{0}')
", item);
                sbrSql.AppendLine();
            }

            Command cmd = CommandManager.CreateCommand(sbrSql.ToString());
            cmd.SetParamter("@RoleID", roleid);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static IList<Entity_Role_LeftPermissionTree> GetRolePermissionByUserLogined(int userId)
        {
            string sqlStr = @"
SELECT 
distinct
	EAP.ID
	,EAP.PermissionCode
	,EAP.PermissionName
	,EAP.RequestUrl
	,EAP.ParentID
FROM 
EDNF_Account_RolePermissions EARP WITH(NOLOCK)
INNER JOIN EDNF_Account_Permission EAP WITH(NOLOCK)
	ON EAP.PermissionCode = EARP.PermissionCode
INNER JOIN EDNF_Account_UserRoles UR WITH(NOLOCK)
	ON UR.RoleID = EARP.RoleID

WHERE UR.UserID=@UserID


";

            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@UserID", userId);
            return cmd.ExecuteEntities<Entity_Role_LeftPermissionTree>();
        }
    }
}
