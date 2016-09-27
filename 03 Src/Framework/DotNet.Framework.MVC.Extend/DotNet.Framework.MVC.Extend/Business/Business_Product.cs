using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.DataAccess;
using DotNet.Framework.MVC.Extend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.MVC.Extend.Business
{
    public class Business_Product
    {
        internal static Entity.Entity_Product GetModel(int ID)
        {
            Command cmd = CommandManager.CreateCommand("SELECT TOP 1 * FROM EDNF_Product_Item WITH(NOLOCK) WHERE ID = @ID");
            cmd.SetParamter("@ID", ID);
            return cmd.ExecuteEntity<Entity_Product>();
        }

        internal static Entity.Entity_Product GetModel(int ID, string where)
        {
            Command cmd = CommandManager.CreateCommand("SELECT TOP 1 * FROM EDNF_Product_Item WITH(NOLOCK) WHERE ID = @ID #strWhere#");
            cmd.SetParamter("@ID", ID);
            where = where.ToUpper();
            if (where.Contains("WHERE"))
            {
                where = where.Replace("WHERE", "");
                where = " AND " + where;
            }
            cmd.SetReplaceParamter("#strWhere#", where);
            return cmd.ExecuteEntity<Entity_Product>();
        }

        internal static Entity.Entity_Product GetModel(int ID, string[] columns)
        {
            if (columns.Count() == 0)
            {
                return null;
            }
            Command cmd = CommandManager.CreateCommand("SELECT TOP 1 #columns# FROM EDNF_Product_Item WITH(NOLOCK) WHERE ID = @ID");
            cmd.SetParamter("@ID", ID);
            cmd.SetReplaceParamter("#columns#", string.Join(",", columns));
            return cmd.ExecuteEntity<Entity_Product>();
        }

        internal static Entity.Entity_Product GetModel(int ID, string where, string[] columns)
        {
            if (columns.Count() == 0)
            {
                return null;
            }
            Command cmd = CommandManager.CreateCommand("SELECT TOP 1 #columns# FROM EDNF_Product_Item WITH(NOLOCK) WHERE ID = @ID #strWhere#");
            cmd.SetParamter("@ID", ID);
            where = where.ToUpper();
            if (where.Contains("WHERE"))
            {
                where = where.Replace("WHERE", "");
                where = " AND " + where;
            }
            cmd.SetReplaceParamter("#strWhere#", where);
            cmd.SetReplaceParamter("#columns#", string.Join(",", columns));
            return cmd.ExecuteEntity<Entity_Product>();
        }

        internal static Core.Web.Data.ViewObject.PagingResult<IList<Entity.Entity_Product>> GetPagingResult(Core.Web.Data.ViewObject.ViewQueryCondition<string> query)
        {
            PagingResult<IList<Entity_Product>> result = new PagingResult<IList<Entity_Product>>();
            if (query.PagingInfo == null)
            {
                query.PagingInfo = new ViewPagingInfo()
                {
                    PageIndex = 1,
                    PageSize = 10,
                    OrderField = "CON.ID",
                    SortDir = "DESC"
                };
            }

            string sqlString = @"
SELECT @totalCount= COUNT(CON.ID) 
FROM EDNF_Product_Item CON WITH(NOLOCK)
WHERE 1=1 
#strWhere#

SELECT * FROM 
(
    SELECT 
    ROW_NUMBER() OVER (ORDER BY #OrderField# #SortDir#) R,
	    CON.*
	    ,CC.ClassName
    FROM EDNF_Product_Item CON WITH(NOLOCK)
	    INNER JOIN EDNF_Product_Class CC WITH(NOLOCK)
	    ON CC.ClassID = CON.ClassID
    WHERE 1=1 
    #strWhere#
) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize

";

            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@PageIndex", query.PagingInfo.PageIndex);
            cmd.SetParamter("@PageSize", query.PagingInfo.PageSize);
            cmd.SetReplaceParamter("#OrderField#", query.PagingInfo.OrderField);
            cmd.SetReplaceParamter("#SortDir#", query.PagingInfo.SortDir);
            cmd.SetReplaceParamter("#strWhere#", query.Condition);
            cmd.SetOutParameter("@totalCount", System.Data.DbType.Int32, null);
            result.Result = cmd.ExecuteEntities<Entity_Product>();
            result.TotalCount = cmd.GetOutParameter<Int32>("@totalCount");
            result.PagingInfo = query.PagingInfo;

            return result;
        }

        internal static IList<Entity.Entity_Product> GetProducts(int top, string where)
        {
            string sqlString = @"
SELECT #strTop# * FROM [EDNF_Product_Item] WITH(NOLOCK) #strWhere#
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
            return cmd.ExecuteEntities<Entity_Product>();
        }

        internal static IList<Entity.Entity_Product> GetProducts(int top, string where, string[] columns)
        {
            if (columns.Count() == 0)
            {
                return null;
            }
            string columnName = string.Join(",", columns);
            string sqlString = @"
SELECT #strTop# #columns# FROM [EDNF_Product_Item] WITH(NOLOCK) #strWhere#
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
            return cmd.ExecuteEntities<Entity_Product>();
        }
    }
}
