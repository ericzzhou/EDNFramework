using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.DataAccess;
using System.Collections.Generic;

namespace DotNet.Framework.Admin.Business.EDNFramework_Account
{
    public class Business_PermissionCategories
    {
        public static IList<Entity_PermissionCategories> GetAll()
        {
            string sqlString = @"
SELECT [CategoryID],[Description] 
    FROM EDNF_Account_PermissionCategories WITH (NOLOCK)
";
            Command cmd = CommandManager.CreateCommand(sqlString);

            return cmd.ExecuteEntities<Entity_PermissionCategories>();
        }
    }
}
