using EFramework.Core.Data;
using EFramework.Core.WebRuntime.ViewObject;
using EFramework.Entities.Domain.Account;
using EFramework.Entities.Domain.Account.ViewQueryCondition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFramework.Services
{
    public class AccountService
    {
        public static List<EDNF_Account_RoleEntity> GetAvailableRoles()
        {
            return Factory.Instance.GetAvailableRoles() ?? new List<EDNF_Account_RoleEntity>();
        }
        public static PagingResult<List<EDNF_Account_RoleEntity>> GetAccountRolesByPager(ViewQueryCondition<object> condition)
        {
            return Factory.Instance.GetAccountRolesByPager(condition);
        }
        public static EDNF_Account_RoleEntity GetRoleInfo(int id)
        {
            return Factory.Instance.GetRoleInfo(id) ?? new EDNF_Account_RoleEntity();
        }

        public static PagingResult<List<EF_Account_RoleUsersEntity>> GetRoleUsersByPager(ViewQueryCondition<RoleUsersSearchCondition> condition)
        {
            return Factory.Instance.GetRoleUsersByPager(condition) ?? new PagingResult<List<EF_Account_RoleUsersEntity>>()
            {
                Result = new List<EF_Account_RoleUsersEntity>(),
                PagingInfo = condition.PagingInfo
            };
        }

        public static PagingResult<List<EF_Account_UserInfoEntity>> GetUsersByPager(ViewQueryCondition<UsersSearchCondition> condition)
        {
            return Factory.Instance.GetUsersByPager(condition) ?? new PagingResult<List<EF_Account_UserInfoEntity>>()
            {
                Result = new List<EF_Account_UserInfoEntity>(),
                PagingInfo = condition.PagingInfo
            };
        }
    }
}
