using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFramework.Entities.Domain.Account
{
    [Serializable]
    public class EDNF_Account_RoleEntity
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
