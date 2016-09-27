using System;

namespace EFramework.Entities.Domain.Account.ViewQueryCondition
{
    [Serializable]
    public class UsersSearchCondition
    {
        public int roleId { get; set; }
        public string UserName { get; set; }
    }
}
