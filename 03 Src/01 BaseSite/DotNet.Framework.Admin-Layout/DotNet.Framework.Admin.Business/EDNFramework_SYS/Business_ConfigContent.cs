using DotNet.Framework.Admin.Entity.EDNFramework_SYS;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;

namespace DotNet.Framework.Admin.Business.EDNFramework_SYS
{
    public class Business_ConfigContent
    {

        /// <summary>
        /// 根据系统配置Key读取配置Value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValueByKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new BusinessException("Key值不能为空");
            }
            string sqlString = @"
SELECT 
    TOP 1 [Value] 
    FROM [EDNF_SYS_ConfigContent] WITH(NOLOCK)
    WHERE Keyname = @Keyname
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@Keyname", key.Trim());

            return cmd.ExecuteSingle().ToString();

        }

        public static IList<Entity_ConfigContent> GetAll()
        {
            string sqlString = @"
SELECT [ID]
      ,[Keyname]
      ,[Value]
      ,[KeyType]
      ,[Description]
  FROM [EDNF_SYS_ConfigContent]
  WHERE KeyType != -2
  ORDER BY ID DESC
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            return cmd.ExecuteEntities<Entity_ConfigContent>();
        }

        public static Entity_ConfigContent GetModel(int id)
        {
            if (id <= 0)
                throw new BusinessException("编号错误");

            string sqlString = @"
SELECT TOP 1 [ID]
      ,[Keyname]
      ,[Value]
      ,[KeyType]
      ,[Description]
  FROM [EDNF_SYS_ConfigContent] WITH(NOLOCK)
  WHERE ID = @ID
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ID", id);
            return cmd.ExecuteEntity<Entity_ConfigContent>();
        }

        public static int GetKeyType(int id)
        {
            if (id <= 0)
                throw new BusinessException("编号错误");

            string sqlString = @"
SELECT TOP 1 [KeyType]
  FROM [EDNF_SYS_ConfigContent] WITH(NOLOCK)
  WHERE ID = @ID
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ID", id);
            return (int)cmd.ExecuteSingle();

        }

        public static int GetKeyNameCount(string keyName)
        {
            if (string.IsNullOrWhiteSpace(keyName))
                throw new BusinessException("key 不能为空");

            string sqlString = @"
SELECT COUNT(ID) 
    FROM [EDNF_SYS_ConfigContent]
    WHERE Keyname = @Keyname
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@Keyname", keyName);
            return (int)cmd.ExecuteSingle();
        }
        public static int GetKeyNameCount(string keyName, int id)
        {
            if (id <= 0)
                throw new BusinessException("编号不能为空");
            if (string.IsNullOrWhiteSpace(keyName))
                throw new BusinessException("key 不能为空");

            string sqlString = @"
SELECT COUNT(ID) 
    FROM [EDNF_SYS_ConfigContent]
    WHERE Keyname = @Keyname
        AND ID != @ID
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@Keyname", keyName);
            cmd.SetParamter("@ID", id);
            return (int)cmd.ExecuteSingle();
        }
        /// <summary>
        /// 检测 是否系统保留配置
        /// </summary>
        /// <param name="id"></param>
        public static void AllowModify(int id)
        {
            var type = GetKeyType(id);
            //if (type == -2)
            if (type == Admin.Core.Config.SysConfig.Config_DenyModifyType)
                throw new BusinessException("系统保留配置，不可维护");
        }

        public static void AllowDelete(int id)
        {
            var type = GetKeyType(id);
            //if (type == -1)
            if (type == Admin.Core.Config.SysConfig.Config_DenyDeleteType)
                throw new BusinessException("系统保留配置，不可删除");
        }
        public static bool UpdateModel(Entity_ConfigContent entity)
        {
            if (entity.ID <= 0) throw new BusinessException("编号错误");

            AllowModify(entity.ID);

            if (GetKeyNameCount(entity.Keyname, entity.ID) > 0)
            {
                throw new BusinessException(string.Format("‘{0}’已经存在", entity.Keyname));
            }

            string sqlString = @"
UPDATE [EDNF_SYS_ConfigContent]
    SET
       [Value] = @Value
      ,[Description] = @Description
  WHERE ID = @ID
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@Value", entity.Value);
            cmd.SetParamter("@Description", entity.Description);
            cmd.SetParamter("@ID", entity.ID);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool Delete(int ID)
        {
            if (ID <= 0) throw new BusinessException("编号错误");

            AllowDelete(ID);

            string sqlString = @"
    DELETE FROM [EDNF_SYS_ConfigContent]
      WHERE ID = @ID
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ID", ID);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static int AddModel(Entity_ConfigContent entity)
        {
            if (GetKeyNameCount(entity.Keyname) > 0)
            {
                throw new BusinessException(string.Format("‘{0}’已经存在", entity.Keyname));
            }
            string sqlString = @"
INSERT INTO [EDNF_SYS_ConfigContent]
           ([Keyname]
           ,[Value]
           ,[KeyType]
           ,[Description])
     VALUES
           (@Keyname
           ,@Value
           ,@KeyType
           ,@Description)
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@Keyname", entity.Keyname);
            cmd.SetParamter("@Value", entity.Value);
            cmd.SetParamter("@KeyType", entity.KeyType);
            cmd.SetParamter("@Description", entity.Description);
            return cmd.ExecuteNonQuery();
        }



        public static IList<Entity_ConfigContent> GetListByPager(int pageindex, int pagesize, string sortBy, string dir, out int totolCount)
        {
            totolCount = 0;
            string totleString = @"
    SELECT COUNT(ID) 
      FROM [EDNF_SYS_ConfigContent] WITH(NOLOCK) 
      WHERE KeyType != -2
";
            Command cmdCount = CommandManager.CreateCommand(totleString);
            totolCount = cmdCount.ExecuteSingle<int>();

            string sqlString = string.Format(@"
SELECT * FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) R,* 
    FROM [EDNF_SYS_ConfigContent] WITH(NOLOCK) 
    WHERE KeyType != -2
) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
", sortBy, dir);
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@sortBy", sortBy);
            cmd.SetParamter("@PageIndex", pageindex);
            cmd.SetParamter("@PageSize", pagesize);
            return cmd.ExecuteEntities<Entity_ConfigContent>();
        }
    }
}
