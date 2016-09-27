using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.Entity.EDNFramework_Account.ViewQueryCondition
{
    public class Entity_PermissionAction_Condition
    {
        public int? ActionID { get; set; }

        public string ActionCode { get; set; }

        public string Description { get; set; }

        public string PermissionCode { get; set; }
    }
}
