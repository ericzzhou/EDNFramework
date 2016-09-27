using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.Entity.EDNFramework_Account
{
    public class Entity_SingIn
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool AutoLogin { get; set; }
    }
}
