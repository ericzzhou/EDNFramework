using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalWell.Web.UI.Business
{
    public class Bus_Product_Class
    {
        internal static IList<Models.EDNF_Product_Class> GetAll()
        {
            string sql = @"SELECT * FROM EDNF_Product_Class WITH(NOLOCK)
ORDER BY Sequence asc,ParentId DESC";

            Command cmd = CommandManager.CreateCommand(sql);
            return cmd.ExecuteEntities<Models.EDNF_Product_Class>();

        }

        public static IList<Models.EDNF_Product_Class> GetAll(int parentId)
        {
            string sql = @"
SELECT * FROM EDNF_Product_Class WITH(NOLOCK)
WHERE ParentId = @ParentId
ORDER BY Sequence DESC";

            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ParentId", parentId);
            return cmd.ExecuteEntities<Models.EDNF_Product_Class>();
        }

        internal static IList<Models.EDNF_Product_Class> GetSelfAndSon(string idIn)
        {
            string sql = string.Format(@"SELECT * FROM EDNF_Product_Class WITH(NOLOCK)
WHERE  ClassID IN ({0}) OR ParentId IN ({0}) 
ORDER BY ParentId DESC", idIn);

            Command cmd = CommandManager.CreateCommand(sql);
            return cmd.ExecuteEntities<Models.EDNF_Product_Class>();

        }

        internal static string GetCategoryName(int id)
        {
            string sql = "SELECT top 1 ClassName FROM EDNF_Product_Class WITH(NOLOCK) WHERE  ClassID = @ClassID";

            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ClassID", id);
            return cmd.ExecuteSingle<string>();
        }
    }
}