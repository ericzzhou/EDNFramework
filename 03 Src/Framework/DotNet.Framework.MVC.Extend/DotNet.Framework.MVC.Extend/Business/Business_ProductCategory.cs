using DotNet.Framework.DataAccess;
using DotNet.Framework.MVC.Extend.Entity;
using System.Collections.Generic;
using System.Linq;

namespace DotNet.Framework.MVC.Extend.Business
{
    public class Business_ProductCategory
    {
        internal static Entity.Entity_ProductCategory GetModel(int ID)
        {
            Command cmd = CommandManager.CreateCommand("SELECT TOP 1 * FROM EDNF_Product_Class WITH(NOLOCK) WHERE ClassID = @ID");
            cmd.SetParamter("@ID", ID);
            return cmd.ExecuteEntity<Entity_ProductCategory>();
        }

        internal static Entity.Entity_ProductCategory GetModel(int ID, string where)
        {
            Command cmd = CommandManager.CreateCommand("SELECT TOP 1 * FROM EDNF_Product_Class WITH(NOLOCK) WHERE ClassID = @ID #strWhere#");
            cmd.SetParamter("@ID", ID);
            where = where.ToUpper();
            if (where.Contains("WHERE"))
            {
                where = where.Replace("WHERE", "");
                where = " AND " + where;
            }
            cmd.SetReplaceParamter("#strWhere#", where);
            return cmd.ExecuteEntity<Entity_ProductCategory>();
        }

        internal static Entity.Entity_ProductCategory GetModel(int ID, string[] columns)
        {
            if (columns.Count() == 0)
            {
                return null;
            }
            Command cmd = CommandManager.CreateCommand("SELECT TOP 1 #columns# FROM EDNF_Product_Class WITH(NOLOCK) WHERE ClassID = @ID");
            cmd.SetParamter("@ID", ID);
            cmd.SetReplaceParamter("#columns#", string.Join(",", columns));
            return cmd.ExecuteEntity<Entity_ProductCategory>();
        }

        internal static Entity.Entity_ProductCategory GetModel(int ID, string where, string[] columns)
        {
            if (columns.Count() == 0)
            {
                return null;
            }
            Command cmd = CommandManager.CreateCommand("SELECT TOP 1 #columns# FROM EDNF_Product_Class WITH(NOLOCK) WHERE ClassID = @ID #strWhere#");
            cmd.SetParamter("@ID", ID);
            where = where.ToUpper();
            if (where.Contains("WHERE"))
            {
                where = where.Replace("WHERE", "");
                where = " AND " + where;
            }
            cmd.SetReplaceParamter("#strWhere#", where);
            cmd.SetReplaceParamter("#columns#", string.Join(",", columns));
            return cmd.ExecuteEntity<Entity_ProductCategory>();
        }

        internal static IList<Entity.Entity_ProductCategory> GetProductCategories(int top, string where)
        {
            string sqlString = @"
SELECT #strTop# * FROM [EDNF_Product_Class] WITH(NOLOCK) #strWhere#
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetReplaceParamter("#strWhere#", where);
            if (top == 0)
            {
                cmd.SetReplaceParamter("#strTop#", "");
            }
            else
            {
                cmd.SetReplaceParamter("#strTop#", "top (@top)");
                cmd.SetParamter("@top", top);
            }
            return cmd.ExecuteEntities<Entity_ProductCategory>();
        }

        internal static IList<Entity.Entity_ProductCategory> GetProductCategories(int top, string where, string[] columns)
        {
            if (columns.Count() == 0)
            {
                return null;
            }
            string columnName = string.Join(",", columns);
            string sqlString = @"
SELECT #strTop# #columns# FROM [EDNF_Product_Class] WITH(NOLOCK) #strWhere#
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetReplaceParamter("#strWhere#", where);
            cmd.SetReplaceParamter("#columns#", columnName);
            if (top == 0)
            {
                cmd.SetReplaceParamter("#strTop#", "");
            }
            else
            {
                cmd.SetReplaceParamter("#strTop#", "top (@top)");
                cmd.SetParamter("@top", top);
            }
            return cmd.ExecuteEntities<Entity_ProductCategory>();
        }
    }
}
