using EFramework.Core.WebRuntime.ViewObject;
using EFramework.Entities.Domain.Account;
using EFramework.Entities.Domain.Account.ViewQueryCondition;
using System.Collections.Generic;

namespace EFramework.Core.Data
{
    public partial interface IDataStrategy
    {
       List<EDNF_Account_RoleEntity> GetAvailableRoles();
       PagingResult<List<EDNF_Account_RoleEntity>> GetAccountRolesByPager(ViewQueryCondition<object> condition);
       PagingResult<List<EF_Account_RoleUsersEntity>> GetRoleUsersByPager(ViewQueryCondition<RoleUsersSearchCondition> condition);

       EDNF_Account_RoleEntity GetRoleInfo(int id);
       PagingResult<List<EF_Account_UserInfoEntity>> GetUsersByPager(ViewQueryCondition<UsersSearchCondition> condition);

    }
}
