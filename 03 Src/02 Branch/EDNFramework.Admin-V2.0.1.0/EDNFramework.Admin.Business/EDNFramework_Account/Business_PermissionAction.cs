using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.EDNFramework_Account.ViewQueryCondition;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.Business.EDNFramework_Account
{
    public class Business_PermissionAction
    {
        public static PagingResult<IList<Entity_PermissionAction>> GetListByPager(ViewQueryCondition<Entity_PermissionAction_Condition> query)
        {
            PagingResult<IList<Entity_PermissionAction>> result = new PagingResult<IList<Entity_PermissionAction>>();
            string sqlStr = @"
SELECT @TotalCount= COUNT([ActionID]) 
    FROM [EDNF_Account_PermissionActions] WITH(NOLOCK) 
    WHERE 1=1 
#strWhere#




SELECT * FROM 
(
SELECT 
    ROW_NUMBER() OVER (ORDER BY #OrderField# #SortDir#) R,
	*
    FROM EDNF_Account_PermissionActions WITH(NOLOCK)
    WHERE 1=1 

#strWhere#

) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize

";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            string where = "";
            if (!string.IsNullOrWhiteSpace(query.Condition.PermissionCode))
            {
                where += " AND PermissionCode = @PermissionCode ";
            }

            cmd.SetReplaceParamter("#strWhere#", where);
            cmd.SetReplaceParamter("#OrderField#", query.PagingInfo.OrderField);
            cmd.SetReplaceParamter("#SortDir#", query.PagingInfo.SortDir);
            cmd.SetOutParameter("@TotalCount", System.Data.DbType.Int32, null);
            cmd.SetParamter("@PageIndex", query.PagingInfo.PageIndex);
            cmd.SetParamter("@PageSize", query.PagingInfo.PageSize);
            cmd.SetParamter("@PermissionCode", query.Condition.PermissionCode);
            result.Result = cmd.ExecuteEntities<Entity_PermissionAction>() ?? new List<Entity_PermissionAction>();
            result.PagingInfo = query.PagingInfo;
            int totalCount = cmd.GetOutParameter<Int32>("@TotalCount");
            result.TotalCount = totalCount;
            return result;
        }

        public static IList<Entity_PermissionAction> GetList(ViewQueryCondition<Entity_PermissionAction_Condition> query)
        {
            string sqlStr = @"
SELECT *
    FROM [EDNF_Account_PermissionActions] WITH(NOLOCK) 
    WHERE 1=1
    #strWhere#
";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            string where = "";
            if (!string.IsNullOrWhiteSpace(query.Condition.PermissionCode))
            {
                where += " AND PermissionCode = @PermissionCode ";
            }

            cmd.SetReplaceParamter("#strWhere#", where);
            cmd.SetParamter("@PermissionCode", query.Condition.PermissionCode);
            return cmd.ExecuteEntities<Entity_PermissionAction>();
        }

        public static int Add(Entity_PermissionAction entity)
        {
            CheckAction(entity.ActionCode,entity.PermissionCode);
            string sql = @"
INSERT INTO [EDNF_Account_PermissionActions]
           ([ActionCode]
           ,[Description]
           ,[PermissionCode])
     VALUES
           (@ActionCode
           ,@Description
           ,@PermissionCode)
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@PermissionCode", entity.PermissionCode);
            cmd.SetParamter("@ActionCode", entity.ActionCode);
            cmd.SetParamter("@Description", entity.Description);
            return cmd.ExecuteNonQuery();
        }

        private static void CheckAction(string ActionCode, string PermissionCode)
        {
            Command cmd = CommandManager.CreateCommand(@"
SELECT COUNT(ActionID) FROM [EDNF_Account_PermissionActions]
   WHERE [ActionCode] = @ActionCode
      AND [PermissionCode] = @PermissionCode
");
            cmd.SetParamter("@ActionCode", ActionCode);
            cmd.SetParamter("@PermissionCode", PermissionCode);
            int count = cmd.ExecuteSingle<int>();
            if (count > 0)
            {
                throw new BusinessException(string.Format("权限“{0}”中已经存在按钮“{1}”", PermissionCode, ActionCode));
            }
            
        }

        public static bool Delete(int ActionID)
        {
            string sql = @"
DELETE FROM [EDNF_Account_RolePermissionsAction]
      WHERE ActionCode IN (SELECT ActionCode FROM EDNF_Account_PermissionActions WHERE ActionID=@ActionID)

DELETE FROM [EDNF_Account_PermissionActions]
      WHERE ActionID=@ActionID
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ActionID", ActionID);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static Entity_PermissionAction_Edit GetModelByID(int ActionID)
        {
            string sql = @"
SELECT TOP 1 
        PA.*
        ,P.PermissionName
    FROM EDNF_Account_PermissionActions PA WITH(NOLOCK)
    INNER JOIN EDNF_Account_Permission P WITH(NOLOCK)
        ON PA.PermissionCode = P.PermissionCode
    WHERE PA.ActionID=@ActionID
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ActionID", ActionID);
            return cmd.ExecuteEntity<Entity_PermissionAction_Edit>();
        }

        public static bool Edit(Entity_PermissionAction entity)
        {
            string sql = @"
UPDATE TOP (1) [EDNF_Account_PermissionActions]
   SET [ActionCode] = @ActionCode
      ,[Description] = @Description
 WHERE ActionID=@ActionID
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ActionID", entity.ActionID);
            cmd.SetParamter("@ActionCode", entity.ActionCode);
            cmd.SetParamter("@Description", entity.Description);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
