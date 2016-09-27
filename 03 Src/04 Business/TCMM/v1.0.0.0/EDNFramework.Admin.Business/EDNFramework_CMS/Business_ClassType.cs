using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.DataAccess;
using System.Collections.Generic;

namespace DotNet.Framework.Admin.Business.EDNFramework_CMS
{
    public class Business_ClassType
    {
        public static IList<Entity_ClassType> GetAll()
        {
            string sqlString = @"SELECT ClassTypeID,ClassTypeName FROM EDNF_CMS_ClassType WITH(NOLOCK)";
            Command cmd = CommandManager.CreateCommand(sqlString);

            return cmd.ExecuteEntities<Entity_ClassType>();
        }
    }
}
