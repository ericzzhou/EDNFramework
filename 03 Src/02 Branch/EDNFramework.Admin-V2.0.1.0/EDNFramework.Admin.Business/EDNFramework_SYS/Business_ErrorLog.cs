using DotNet.Framework.Admin.Entity.EDNFramework_SYS;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.DataAccess;
using System.Collections.Generic;

namespace DotNet.Framework.Admin.Business.EDNFramework_SYS
{
    public class Business_ErrorLog
    {
        public static IList<Entity_ErrorLog> GetAll()
        {
            string sqlString = @"
SELECT [ID]
      ,[OPTime]
      ,[Url]
      ,[Loginfo]
      ,[ErrorType]
      ,[Domain]
  FROM [EDNF_SYS_ErrorLog] WITH(NOLOCK)
  ORDER BY [ID] DESC
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            return cmd.ExecuteEntities<Entity_ErrorLog>();
        }

        public static Entity_ErrorLog GetModel(int id)
        {
            string sqlString = @"
SELECT TOP 1 [ID]
      ,[OPTime]
      ,[Url]
      ,[Loginfo]
      ,[ErrorType]
      ,[Domain]
      ,[StackTrace]
  FROM [EDNF_SYS_ErrorLog] WITH(NOLOCK)
  WHERE ID = @ID
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ID", id);
            return cmd.ExecuteEntity<Entity_ErrorLog>();
        }

        public static IList<Entity_ErrorLog> GetListByPager(int pageindex, int pagesize, string sortBy, string dir, out int totolCount)
        {
            totolCount = 0;
            string totleString = @"
    SELECT COUNT(ID) 
    FROM [EDNF_SYS_ErrorLog] WITH(NOLOCK) 
";
            Command cmdCount = CommandManager.CreateCommand(totleString);
            totolCount = cmdCount.ExecuteSingle<int>();

            string sqlString = string.Format(@"
SELECT * FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) R,* 
    FROM [EDNF_SYS_ErrorLog] WITH(NOLOCK)
) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
", sortBy, dir);
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@sortBy", sortBy);
            cmd.SetParamter("@PageIndex", pageindex);
            cmd.SetParamter("@PageSize", pagesize);
            return cmd.ExecuteEntities<Entity_ErrorLog>();
        }

        public static PagingResult<IList<Entity_ErrorLog>> GetListByPager(ViewQueryCondition<object> query)
        {
            PagingResult<IList<Entity_ErrorLog>> result = new PagingResult<IList<Entity_ErrorLog>>();
            result.PagingInfo = query.PagingInfo;
            string totleString = @"
    SELECT COUNT(ID) 
    FROM [EDNF_SYS_ErrorLog] WITH(NOLOCK) 
";
            Command cmdCount = CommandManager.CreateCommand(totleString);
            result.TotalCount = cmdCount.ExecuteSingle<int>();

            string sqlString = string.Format(@"
SELECT * FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) R,* 
    FROM [EDNF_SYS_ErrorLog] WITH(NOLOCK)
) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
", query.PagingInfo.OrderField, query.PagingInfo.SortDir);
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@PageIndex", query.PagingInfo.PageIndex);
            cmd.SetParamter("@PageSize", query.PagingInfo.PageSize);
            result.Result = cmd.ExecuteEntities<Entity_ErrorLog>();

            return result;
        }
    }
}
