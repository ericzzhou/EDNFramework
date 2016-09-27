using DotNet.Framework.Admin.Business.EDNFramework_SYS;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.DataAccess;
using System.Collections.Generic;
using DotNet.Framework.Core.Extends;
using System.Linq;
using DotNet.Framework.Core.Exceptions;
namespace DotNet.Framework.Admin.Business.EDNFramework_Account
{
    public class Business_User
    {
        public static IList<Entity_UserTableData> GetTablesData()
        {
            string sqlString = @"
SELECT 
	U.UserID
	,U.UserName
	,U.NickName
	,U.Sex
	,U.Phone
	,U.Email
	,U.Activity
FROM EDNF_Account_User U WITH(NOLOCK)
ORDER BY U.UserID DESC
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            return cmd.ExecuteEntities<Entity_UserTableData>();
        }
        public static IList<Entity_UserTableData> GetTablesData(int roleId)
        {
            string sqlString = @"
SELECT 
	U.UserID
	,U.UserName
	,U.NickName
	,U.Sex
	,U.Phone
	,U.Email
	,U.Activity
FROM EDNF_Account_User U WITH(NOLOCK)
WHERE U.UserID IN (SELECT UserID FROM EDNF_Account_UserRoles WITH(NOLOCK)
WHERE RoleID = @RoleID)
ORDER BY U.UserID DESC


";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@RoleID", roleId);
            return cmd.ExecuteEntities<Entity_UserTableData>();
        }

        public static bool Delete(int userId)
        {
            var sys_roles = Business_ConfigContent.GetValueByKey(Admin.Core.Config.SysConfig.Reserved_AdminID);
            if (!string.IsNullOrWhiteSpace(sys_roles))
            {
                int[] sysArr = sys_roles.ToIntArr(',');

                if (sysArr.Contains(userId))
                {
                    throw new BusinessException("系统预留账号，不允许删除");
                }
            }

            string sqlString = @"
DELETE FROM [EDNF_Account_UserRoles]
      WHERE UserID = @UserID

DELETE FROM [EDNF_Account_User]
      WHERE UserID = @UserID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@UserID", userId);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static int GetUserNameCount(string UserName)
        {
            if (UserName.IsNull())
            {
                throw new BusinessException("账号不能为空");
            }

            string sqlString = @"
    SELECT COUNT(UserName)
        FROM [EDNF_Account_User]
        WHERE UserName = @UserName
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@UserName", UserName);
            return (int)cmd.ExecuteSingle();
        }

        public static int GetUserNameCount(string UserName, int UserID)
        {
            if (UserID <= 0)
            {
                throw new BusinessException("编号不能为空");
            }

            if (UserName.IsNull())
            {
                throw new BusinessException("账号不能为空");
            }

            string sqlString = @"
    SELECT COUNT(UserName)
        FROM [EDNF_Account_User]
        WHERE UserName = @UserName
            AND UserID != @UserID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@UserName", UserName);
            cmd.SetParamter("@UserID", UserID);
            return (int)cmd.ExecuteSingle();
        }

        public static int Add(Entity_User entity, int roleid)
        {
            if (GetUserNameCount(entity.UserName) > 0)
            {
                throw new BusinessException(string.Format("账号{0}已经存在", entity.UserName));
            }

            string sqlString = @"
INSERT INTO [EDNF_Account_User]
           ([UserName]
           ,[Password]
           ,[NickName]
           ,[Sex]
           ,[Phone]
           ,[Email]
           ,[Activity]
           ,[UserType]
           ,[User_dateCreate]
           ,DepartmentID)
     VALUES
           (@UserName
           ,@Password
           ,@NickName
           ,@Sex
           ,@Phone
           ,@Email
           ,@Activity
           ,@UserType
           ,GETDATE()
           ,@DepartmentID)
INSERT INTO [EDNF_Account_UserRoles]
           ([UserID]
           ,[RoleID])
     VALUES
           (@@IDENTITY
           ,@RoleID)
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@UserName", entity.UserName);
            cmd.SetParamter("@Password", entity.Password);
            cmd.SetParamter("@NickName", entity.NickName);
            cmd.SetParamter("@Sex", entity.Sex);
            cmd.SetParamter("@Phone", entity.Phone);
            cmd.SetParamter("@Email", entity.Email);
            cmd.SetParamter("@Activity", entity.Activity);
            cmd.SetParamter("@UserType", entity.UserType);
            cmd.SetParamter("@DepartmentID", entity.DepartmentID);
            cmd.SetParamter("@RoleID", roleid);
            return cmd.ExecuteNonQuery();
        }

        public static Entity_User GetModel(int UserId)
        {
            if (UserId <= 0)
            {
                throw new BusinessException("编号错误");
            }

            string sqlString = @"
    SELECT TOP 1* 
    FROM EDNF_Account_User 
    WHERE UserID = @UserID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@UserID", UserId);
            return cmd.ExecuteEntity<Entity_User>();
        }

        public static bool Update(Entity_User entity)
        {
            if (GetUserNameCount(entity.UserName, entity.UserID) > 0)
            {
                throw new BusinessException(string.Format("账号{0}已经存在", entity.UserName));
            }

            string sqlString = @"
UPDATE [EDNF_Account_User]
   SET [UserName] = @UserName
      ,[Password] = @Password
      ,[NickName] = @NickName
      ,[Sex]      = @Sex
      ,[Phone]    = @Phone
      ,[Email]    = @Email
      ,[Activity] = @Activity
      ,[UserType] = @UserType
      ,[DepartmentID] = @DepartmentID
 WHERE UserID = @UserID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@UserID", entity.UserID);
            cmd.SetParamter("@UserName", entity.UserName);
            if (!entity.Password.IsNull())
            {
                cmd.SetParamter("@Password", entity.Password);
            }
            else
            {
                var model = GetModel(entity.UserID);
                cmd.SetParamter("@Password", model.Password);
            }
            cmd.SetParamter("@NickName", entity.NickName);
            cmd.SetParamter("@Sex", entity.Sex);
            cmd.SetParamter("@Phone", entity.Phone);
            cmd.SetParamter("@Email", entity.Email);
            cmd.SetParamter("@Activity", entity.Activity);
            cmd.SetParamter("@UserType", entity.UserType);
            cmd.SetParamter("@DepartmentID", entity.DepartmentID);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static Entity_User GetModel(string UserName)
        {
            if (UserName.IsNull())
            {
                return null;
            }

            string sqlString = @"
    SELECT TOP 1 * 
    FROM EDNF_Account_User 
    WHERE UserName = @UserName
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@UserName", UserName);
            return cmd.ExecuteEntity<Entity_User>();

        }



        public static IList<Entity_RoleMembers> GetNoMembers(int roleId)
        {
            string sqlString = @"
SELECT 
	U.UserID
	,U.UserName
	,U.NickName
	,U.Sex
	,U.Activity
FROM EDNF_Account_User U WITH(NOLOCK)
WHERE U.UserID NOT IN (SELECT UserID FROM EDNF_Account_UserRoles WITH(NOLOCK)
WHERE RoleID = @RoleID)
ORDER BY U.UserID DESC
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@RoleID", roleId);
            return cmd.ExecuteEntities<Entity_RoleMembers>();

        }

        public static IList<Entity_UserTableData> GetListByPager(int pageindex, int pagesize, string orderField, string dir, out int totolCount)
        {
            totolCount = 0;
            string totleString = @"
    SELECT COUNT(UserID) 
    FROM [EDNF_Account_User] WITH(NOLOCK) 
";
            Command cmdCount = CommandManager.CreateCommand(totleString);
            totolCount = cmdCount.ExecuteSingle<int>();

            string sqlString = string.Format(@"
SELECT * FROM 
(
    SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) NUM
    ,U.UserID
	,U.UserName
	,U.NickName
	,U.Sex
	,U.Phone
	,U.Email
	,U.Activity
    ,U.UserType
    ,U.DepartmentID
    ,UT.Description AS UserTypeName
    ,dep.Name DepartmentName
    FROM EDNF_Account_User U WITH(NOLOCK)
    LEFT JOIN EDNF_Account_UserType UT ON UT.UserType = U.UserType
    LEFT JOIN EDNF_Account_Department dep ON dep.ID = U.DepartmentID
	)
	DATA
WHERE DATA.NUM BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
", orderField, dir);
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@sortBy", orderField);
            cmd.SetParamter("@PageIndex", pageindex);
            cmd.SetParamter("@PageSize", pagesize);
            return cmd.ExecuteEntities<Entity_UserTableData>();
        }

        public static IList<Entity_UserTableData> GetListByRoleID(int roleId, int pageindex, int pagesize, string orderField, string dir, out int totolCount)
        {
            totolCount = 0;
            string totleString = @"
    SELECT COUNT(U.UserID) 
    FROM [EDNF_Account_User] U WITH(NOLOCK) 
        INNER JOIN EDNF_Account_UserRoles UR WITH(NOLOCK) 
        ON UR.UserID = U.UserID AND UR.RoleID = @RoleID
";
            Command cmdCount = CommandManager.CreateCommand(totleString);
            cmdCount.SetParamter("@RoleID", roleId);
            totolCount = cmdCount.ExecuteSingle<int>();

            string sqlString = string.Format(@"
SELECT * FROM 
(
    SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) NUM
    ,U.UserID
	,U.UserName
	,U.NickName
	,U.Sex
	,U.Phone
	,U.Email
	,U.Activity
    ,U.UserType
    ,U.DepartmentID
    ,UT.Description AS UserTypeName
    ,dep.Name DepartmentName
    FROM EDNF_Account_User U WITH(NOLOCK)
    INNER JOIN EDNF_Account_UserRoles UR WITH(NOLOCK) ON UR.UserID = U.UserID AND UR.RoleID = @RoleID
    LEFT JOIN EDNF_Account_UserType UT ON UT.UserType = U.UserType
    LEFT JOIN EDNF_Account_Department dep ON dep.ID = U.DepartmentID
	)
	DATA
WHERE DATA.NUM BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
", orderField, dir);
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@RoleID", roleId);
            cmd.SetParamter("@sortBy", orderField);
            cmd.SetParamter("@PageIndex", pageindex);
            cmd.SetParamter("@PageSize", pagesize);
            return cmd.ExecuteEntities<Entity_UserTableData>();
        }

        public static bool RemoveUserFromRole(int uid, int roleid)
        {
            string sqlStr = @"DELETE FROM [EDNF_Account_UserRoles]
      WHERE UserID=@UserID AND RoleID=@RoleID";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@UserID", uid);
            cmd.SetParamter("@RoleID", roleid);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
