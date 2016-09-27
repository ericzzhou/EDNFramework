
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.DataAccess;
using System.Collections.Generic;
namespace DotNet.Framework.Admin.Business.EDNFramework_Account
{
    public class Bussines_Permission
    {
        public static IList<Entity_PermissionTree> GetPermissionTreeData()
        {
            string sqlString = @"
SELECT 
	[ID],
	[ParentID],
	[PermissionName],
	[RequestUrl],
    [ico]
 FROM [EDNF_Account_Permission] WITH(NOLOCK)
 ORDER BY ParentID ASC,Sequence DESC
 


";
            Command cmd = CommandManager.CreateCommand(sqlString);

            return cmd.ExecuteEntities<Entity_PermissionTree>();

        }

        public static Entity_Permission GetModel(int id)
        {
            string sqlString = @"
SELECT *
 FROM [EDNF_Account_Permission] WITH(NOLOCK)
 WHERE ID = @ID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ID", id);
            return cmd.ExecuteEntity<Entity_Permission>();
        }

        public static Entity_Permission_Full GetFullModel(int id)
        {
            string sqlString = @"
SELECT 
(CASE WHEN (Parent.PermissionName IS NULL OR Parent.PermissionName ='') THEN 'Root'  ELSE Parent.PermissionName END )ParentName,
per.*
 FROM [EDNF_Account_Permission] per WITH(NOLOCK)
 LEFT JOIN [EDNF_Account_Permission] Parent WITH(NOLOCK)
	ON per.ParentID = Parent.ID
 WHERE per.id=@ID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ID", id);
            return cmd.ExecuteEntity<Entity_Permission_Full>();

        }

        public static bool Delete(int id)
        {
            if (GetSonNode(id) > 0)
                throw new BusinessException("当前节点存在子节点，不能删除");

            string sqlString = @"
DELETE FROM 
    [EDNF_Account_Permission]
    WHERE ID = @ID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ID", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static int GetSonNode(int id)
        {
            string sqlString = @"
SELECT COUNT(id)
 FROM [EDNF_Account_Permission] WITH(NOLOCK)
 WHERE ParentID = @ID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ID", id);
            return (int)cmd.ExecuteSingle();
        }

        public static int GetCodeCount(string code)
        {
            string sqlString = @"
SELECT COUNT(id)
 FROM [EDNF_Account_Permission] WITH(NOLOCK)
 WHERE PermissionCode = @PermissionCode
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@PermissionCode", code);
            return (int)cmd.ExecuteSingle();
        }
        public static int GetCodeCount(string code, int id)
        {
            string sqlString = @"
SELECT COUNT(id)
 FROM [EDNF_Account_Permission] WITH(NOLOCK)
 WHERE PermissionCode = @PermissionCode
AND ID != @ID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@PermissionCode", code);
            cmd.SetParamter("@ID", id);
            return (int)cmd.ExecuteSingle();
        }
        public static int Add(Entity_Permission entity)
        {
            if (GetCodeCount(entity.PermissionCode) > 0)
            {
                throw new BusinessException("已经存在相同权限Code,不能重复添加");
            }
            string sqlString = @"
INSERT INTO [EDNF_Account_Permission]
           ([ParentID]
           ,[CategoryID]
           ,[PermissionCode]
           ,[PermissionName]
           ,[Description]
           ,[Sequence]
           ,[HasSon]
           ,[ico]
           ,[RequestUrl])
     VALUES
           (@ParentID
           ,@CategoryID
           ,@PermissionCode
           ,@PermissionName
           ,@Description
           ,@Sequence
           ,@HasSon
           ,@ico
           ,@RequestUrl)
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ParentID", entity.ParentID);
            cmd.SetParamter("@CategoryID", entity.CategoryID);
            cmd.SetParamter("@PermissionCode", entity.PermissionCode);
            cmd.SetParamter("@PermissionName", entity.PermissionName);
            cmd.SetParamter("@Description", entity.Description);
            cmd.SetParamter("@Sequence", entity.Sequence);
            cmd.SetParamter("@RequestUrl", entity.RequestUrl);
            cmd.SetParamter("@HasSon", entity.HasSon);
            cmd.SetParamter("@ico", entity.Ico);

            return cmd.ExecuteNonQuery();
        }

        public static bool Update(Entity_Permission entity)
        {
            if (GetCodeCount(entity.PermissionCode, entity.ID) > 0)
            {
                throw new BusinessException("已经存在相同权限Code,不能重复添加");
            }

            string sqlString = @"
UPDATE [EDNF_Account_Permission]
   SET [ParentID] = @ParentID
      ,[CategoryID] = @CategoryID
      ,[PermissionCode] = @PermissionCode
      ,[PermissionName] = @PermissionName
      ,[Description] = @Description
      ,[Sequence] = @Sequence
      ,[RequestUrl] = @RequestUrl
      ,[HasSon] = @HasSon
      ,[ico] = @ico
 WHERE ID = @ID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ParentID", entity.ParentID);
            cmd.SetParamter("@CategoryID", entity.CategoryID);
            cmd.SetParamter("@PermissionCode", entity.PermissionCode);
            cmd.SetParamter("@PermissionName", entity.PermissionName);
            cmd.SetParamter("@Description", entity.Description);
            cmd.SetParamter("@Sequence", entity.Sequence);
            cmd.SetParamter("@RequestUrl", entity.RequestUrl);
            cmd.SetParamter("@ID", entity.ID);
            cmd.SetParamter("@HasSon", entity.HasSon);
            cmd.SetParamter("@ico", entity.Ico);
            return cmd.ExecuteNonQuery() > 0;

        }



        public static Entity_Permission GetModelByCode(string PermissionCode)
        {
            string sqlString = @"
SELECT TOP 1 *
 FROM [EDNF_Account_Permission] WITH(NOLOCK)
 WHERE PermissionCode = @PermissionCode
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@PermissionCode", PermissionCode);
            return cmd.ExecuteEntity<Entity_Permission>();
        }
    }
}
