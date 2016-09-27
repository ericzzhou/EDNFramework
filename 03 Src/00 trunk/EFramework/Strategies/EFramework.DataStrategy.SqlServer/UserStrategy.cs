using EFramework.Core.Data;
using EFramework.Core.WebRuntime.ViewObject;
using EFramework.Entities.Domain.Account;
using System.Collections.Generic;
using EFramewrok.Dapper;
using System.Data;
using System.Linq;
using EFramework.Entities.Domain.Account.ViewQueryCondition;
namespace EFramework.DataStrategy.SqlServer
{
    public partial class DataStrategy : IDataStrategy
    {
        public PagingResult<List<EDNF_Account_RoleEntity>> GetAccountRolesByPager(ViewQueryCondition<object> condition)
        {
            PagingResult<List<EDNF_Account_RoleEntity>> result = new PagingResult<List<EDNF_Account_RoleEntity>>();
            string sqlStr = @"
    SELECT @TotalCount=COUNT(RoleID) 
      FROM [EDNF_Account_Role] WITH(NOLOCK) 
      WHERE 1=1 #whereStr#

    SELECT * FROM 
    (
	    SELECT ROW_NUMBER() OVER (ORDER BY @OrderField DESC) R,* 
        FROM [EDNF_Account_Role] WITH(NOLOCK) 
        WHERE 1=1 #whereStr#
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

                sqlStr = sqlStr.Replace("#whereStr#", where);
                result.Result = conn.Query<EDNF_Account_RoleEntity>(sqlStr, param).ToList();

                result.PagingInfo = condition.PagingInfo;
                result.TotalCount = param.Get<int>("@TotalCount");
            }
            return result;
        }


        public EDNF_Account_RoleEntity GetRoleInfo(int id)
        {
            string sqlStr = "SELECT TOP 1 * FROM [EDNF_Account_Role] WHERE RoleID = @RoleID";
            using (IDbConnection conn = DbManager.Create())
            {
                return conn.Query<EDNF_Account_RoleEntity>(sqlStr, new { RoleID = id }).FirstOrDefault();
            }
        }


        public List<EDNF_Account_RoleEntity> GetAvailableRoles()
        {
            string sqlStr = "SELECT * FROM [EDNF_Account_Role] WITH(NOLOCK)";
            using (IDbConnection conn = DbManager.Create())
            {
                return conn.Query<EDNF_Account_RoleEntity>(sqlStr).ToList();
            }
        }


        public PagingResult<List<EF_Account_RoleUsersEntity>> GetRoleUsersByPager(ViewQueryCondition<RoleUsersSearchCondition> condition)
        {
            PagingResult<List<EF_Account_RoleUsersEntity>> result = new PagingResult<List<EF_Account_RoleUsersEntity>>();
            string sqlStr = @"
    SELECT @TotalCount=COUNT(1) 
      FROM [EDNF_Account_User] U WITH(NOLOCK) 
      WHERE 1=1 #whereStr#

    SELECT * FROM 
    (
	    SELECT ROW_NUMBER() OVER (ORDER BY @OrderField DESC) R,* 
        FROM [EDNF_Account_User] U WITH(NOLOCK) 
        WHERE 1=1 #whereStr#
    ) DATA
    WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize ";

            using (IDbConnection conn = DbManager.Create())
            {
                string where = string.Empty;
                if (condition != null && condition.Condition != null)
                {
                    if (condition.Condition.roleId > 0)
                    {
                        where += " AND U.UserID IN (SELECT UserID FROM EDNF_Account_UserRoles UR WITH(NOLOCK) WHERE UR.RoleID= @RoleID )";
                    }
                    if ( !string.IsNullOrWhiteSpace(condition.Condition.UserName))
                    {
                        where += " AND U.UserName like @UserName";
                    }
                }



                sqlStr = sqlStr.Replace("#whereStr#", where);

                DynamicParameters param = new DynamicParameters();
                param.Add("@TotalCount", null, DbType.Int32, ParameterDirection.Output);
                param.Add("@OrderField", condition.PagingInfo.OrderField);
                param.Add("@PageIndex", condition.PagingInfo.PageIndex);
                param.Add("@PageSize", condition.PagingInfo.PageSize);
                param.Add("@RoleID", condition.Condition.roleId);
                param.Add("@UserName", string.Format("%{0}%",condition.Condition.UserName));
                
                result.Result = conn.Query<EF_Account_RoleUsersEntity>(sqlStr, param).ToList();

                result.PagingInfo = condition.PagingInfo;
                result.TotalCount = param.Get<int>("@TotalCount");
            }
            return result;
        }


        public PagingResult<List<EF_Account_UserInfoEntity>> GetUsersByPager(ViewQueryCondition<UsersSearchCondition> condition)
        {
            PagingResult<List<EF_Account_UserInfoEntity>> result = new PagingResult<List<EF_Account_UserInfoEntity>>();
            string sqlStr = @"
    SELECT @TotalCount=COUNT(1) 
      FROM [EDNF_Account_User] U WITH(NOLOCK) 
      WHERE 1=1 #whereStr#

    SELECT * FROM 
    (
	    SELECT ROW_NUMBER() OVER (ORDER BY @OrderField DESC) R,* 
        FROM [EDNF_Account_User] U WITH(NOLOCK) 
        WHERE 1=1 #whereStr#
    ) DATA
    WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize ";

            using (IDbConnection conn = DbManager.Create())
            {
                string where = string.Empty;
                if (condition != null && condition.Condition != null)
                {
                    if (condition.Condition.roleId > 0)
                    {
                        where += " AND U.UserID IN (SELECT UserID FROM EDNF_Account_UserRoles UR WITH(NOLOCK) WHERE UR.RoleID= @RoleID )";
                    }
                    if (!string.IsNullOrWhiteSpace(condition.Condition.UserName))
                    {
                        where += " AND U.UserName like @UserName";
                    }
                }



                sqlStr = sqlStr.Replace("#whereStr#", where);

                DynamicParameters param = new DynamicParameters();
                param.Add("@TotalCount", null, DbType.Int32, ParameterDirection.Output);
                param.Add("@OrderField", condition.PagingInfo.OrderField);
                param.Add("@PageIndex", condition.PagingInfo.PageIndex);
                param.Add("@PageSize", condition.PagingInfo.PageSize);
                param.Add("@RoleID", condition.Condition.roleId);
                param.Add("@UserName", string.Format("%{0}%", condition.Condition.UserName));

                result.Result = conn.Query<EF_Account_UserInfoEntity>(sqlStr, param).ToList();

                result.PagingInfo = condition.PagingInfo;
                result.TotalCount = param.Get<int>("@TotalCount");
            }
            return result;
        }
    }
}
