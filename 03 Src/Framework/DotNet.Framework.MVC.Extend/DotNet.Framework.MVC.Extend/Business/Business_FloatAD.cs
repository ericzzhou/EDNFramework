using DotNet.Framework.DataAccess;
using DotNet.Framework.MVC.Extend.Entity;

namespace DotNet.Framework.MVC.Extend.Business
{
    public class Business_FloatAD
    {
        public static bool Exists()
        {
            string sql = "SELECT COUNT(ID) FROM EDNF_SYS_FloatAD WITH(NOLOCK)";
            Command cmd = CommandManager.CreateCommand(sql);
            return cmd.ExecuteSingle<int>() > 0;
        }

        public static Entity_FloatAD GetModel()
        {
            string sql = "SELECT TOP 1 * FROM EDNF_SYS_FloatAD WITH(NOLOCK)";
            Command cmd = CommandManager.CreateCommand(sql);
            return cmd.ExecuteEntity<Entity_FloatAD>();
        }
    }
}
