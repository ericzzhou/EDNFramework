using EFramework.Core.Data;
using EFramework.Entities.Domain.ControlPanel;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EFramewrok.Dapper;
using EFramework.Core.WebRuntime.ViewObject;
using EFramework.Entities.Domain.ControlPanel.ViewQueryCondition;
using EFramework.Core;
namespace EFramework.DataStrategy.SqlServer
{
    public partial class DataStrategy : IDataStrategy
    {
        public IList<SYS_ConfigContentEntity> GetSysConfigs()
        {
            using (IDbConnection connection = DbManager.Create())
            {
                string sql = "SELECT * FROM [EDNF_SYS_ConfigContent] WITH(NOLOCK)";
                return connection.Query<SYS_ConfigContentEntity>(sql).ToList();
            }
        }


        public PagingResult<List<SYS_ConfigContentEntity>> GetConfigsByPager(ViewQueryCondition<ConfigSearchCondition> condition)
        {
            PagingResult<List<SYS_ConfigContentEntity>> result = new PagingResult<List<SYS_ConfigContentEntity>>();
            string sqlStr = @"
    SELECT @TotalCount=COUNT(ID) 
      FROM [EDNF_SYS_ConfigContent] WITH(NOLOCK) 
      WHERE KeyType != -2 #whereStr#

    SELECT * FROM 
    (
	    SELECT ROW_NUMBER() OVER (ORDER BY @OrderField DESC) R,* 
        FROM [EDNF_SYS_ConfigContent] WITH(NOLOCK) 
        WHERE KeyType != -2 #whereStr#
    ) DATA
    WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize ";



            using (IDbConnection conn = DbManager.Create())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@TotalCount", null, DbType.Int32, ParameterDirection.Output);
                param.Add("@OrderField", condition.PagingInfo.OrderField);
                param.Add("@PageIndex", condition.PagingInfo.PageIndex);
                param.Add("@PageSize", condition.PagingInfo.PageSize);
                string where = string.Empty;
                if (!string.IsNullOrWhiteSpace(condition.Condition.Key))
                {
                    where += string.Format(" AND Keyname LIKE '%{0}%'", condition.Condition.Key);
                }

                if (!string.IsNullOrWhiteSpace(condition.Condition.Value))
                {
                    where += string.Format(" AND Value LIKE '%{0}%'", condition.Condition.Value);
                }
                sqlStr = sqlStr.Replace("#whereStr#", where);
                result.Result = conn.Query<SYS_ConfigContentEntity>(sqlStr, param).ToList();

                result.PagingInfo = condition.PagingInfo;
                result.TotalCount = param.Get<int>("@TotalCount");
            }
            return result;
        }


        public SYS_ConfigContentEntity GetConfigModel(int id)
        {
            using (IDbConnection connection = DbManager.Create())
            {
                string sql = "SELECT TOP 1 * FROM [EDNF_SYS_ConfigContent] WITH(NOLOCK) WHERE ID = @ID";
                return connection.Query<SYS_ConfigContentEntity>(sql, new { ID = id }).FirstOrDefault();
            }
        }


        public bool ModifyConfig(SYS_ConfigContentEntity entity)
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

            using (IDbConnection connection = DbManager.Create())
            {
                return connection.Execute(sqlString, entity) > 0;
            }
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

            using (IDbConnection connection = DbManager.Create())
            {
                return connection.ExecuteScalar<int>(sqlString, new { ID = id, Keyname = keyName });
            }
        }

        /// <summary>
        /// 检测 是否系统保留配置
        /// </summary>
        /// <param name="id"></param>
        public static void AllowModify(int id)
        {
            var type = GetKeyType(id);
            //if (type == -2)
            if (type == -2)
                throw new BusinessException("系统保留配置，不可维护");
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

            using (IDbConnection connection = DbManager.Create())
            {
                return connection.ExecuteScalar<int>(sqlString, new { ID = id });
            }

        }


        public bool AddConfig(SYS_ConfigContentEntity entity)
        {
            if (GetKeyNameCount(entity.Keyname) > 0)
            {
                throw new BusinessException(string.Format("‘{0}’已经存在", entity.Keyname));
            }
            if (string.IsNullOrWhiteSpace(entity.Keyname))
            {
                throw new BusinessException("项目不能为空");
            }
            if (string.IsNullOrWhiteSpace(entity.Value))
            {
                throw new BusinessException("值不能为空");
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

            using (IDbConnection connection = DbManager.Create())
            {
                return connection.Execute(sqlString, entity) > 0;
            }
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

            using (IDbConnection connection = DbManager.Create())
            {
                return connection.ExecuteScalar<int>(sqlString, new { Keyname = keyName });
            }
        }
    }
}
