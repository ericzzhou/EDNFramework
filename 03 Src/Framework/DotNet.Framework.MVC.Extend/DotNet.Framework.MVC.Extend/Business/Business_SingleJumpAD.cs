using DotNet.Framework.DataAccess;
using DotNet.Framework.MVC.Extend.Entity;

namespace DotNet.Framework.MVC.Extend.Business
{
    public class Business_SingleJumpAD
    {
        internal static Entity_SingleJumpAD GetModel()
        {
            string sql = "SELECT TOP 1 * FROM EDNF_SYS_SingleJumpAD WITH(NOLOCK)";
            Command cmd = CommandManager.CreateCommand(sql);
            return cmd.ExecuteEntity<Entity_SingleJumpAD>();
        }
    }
}
