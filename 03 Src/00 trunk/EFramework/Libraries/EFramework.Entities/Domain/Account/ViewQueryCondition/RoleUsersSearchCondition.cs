using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFramework.Entities.Domain.Account.ViewQueryCondition
{
    [Serializable]
    public class RoleUsersSearchCondition
    {
        public int roleId { get; set; }
        public string UserName { get; set; }
    }
}
