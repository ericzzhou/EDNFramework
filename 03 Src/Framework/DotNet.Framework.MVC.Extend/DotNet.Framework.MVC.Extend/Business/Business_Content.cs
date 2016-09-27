using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.DataAccess;
using DotNet.Framework.MVC.Extend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNet.Framework.MVC.Extend.Business
{
    public class Business_Content
    {
        public static IList<Entity_Content> GetContents(int top, string where)
        {
            string sqlString = @"
SELECT #strTop# * FROM [EDNF_CMS_Content] WITH(NOLOCK) #strWhere#
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
            return cmd.ExecuteEntities<Entity_Content>();
        }

        public static IList<Entity_Content> GetContents(int top, string where, string[] columns)
        {
            if (columns.Count() == 0)
            {
                return null;
            }
            string columnName = string.Join(",", columns);
            string sqlString = @"
SELECT #strTop# #columns# FROM [EDNF_CMS_Content] WITH(NOLOCK) #strWhere#
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
            return cmd.ExecuteEntities<Entity_Content>();
        }

        public static Entity_Content GetModel(int ID)
        {
            Command cmd = CommandManager.CreateCommand("SELECT TOP 1 * FROM EDNF_CMS_Content WITH(NOLOCK) WHERE ContentID = @ID");
            cmd.SetParamter("@ID", ID);
            return cmd.ExecuteEntity<Entity_Content>();
        }

        public static Entity_Content GetModel(int ID, string where)
        {
            Command cmd = CommandManager.CreateCommand("SELECT TOP 1 * FROM EDNF_CMS_Content WITH(NOLOCK) WHERE ContentID = @ID #strWhere#");
            cmd.SetParamter("@ID", ID);
            where = where.ToUpper();
            if (where.Contains("WHERE"))
            {
                where = where.Replace("WHERE", "");
                where = " AND " + where;
            }
            cmd.SetReplaceParamter("#strWhere#", where);
            return cmd.ExecuteEntity<Entity_Content>();
        }

        public static Entity_Content GetModel(int ID, string[] columns)
        {
            if (columns.Count() == 0)
            {
                return null;
            }
            Command cmd = CommandManager.CreateCommand("SELECT TOP 1 #columns# FROM EDNF_CMS_Content WITH(NOLOCK) WHERE ContentID = @ID");
            cmd.SetParamter("@ID", ID);
            cmd.SetReplaceParamter("#columns#", string.Join(",", columns));
            return cmd.ExecuteEntity<Entity_Content>();
        }



        public static Entity_Content GetModel(int ID, string where, string[] columns)
        {
            if (columns.Count() == 0)
            {
                return null;
            }
            Command cmd = CommandManager.CreateCommand("SELECT TOP 1 #columns# FROM EDNF_CMS_Content WITH(NOLOCK) WHERE ContentID = @ID #strWhere#");
            cmd.SetParamter("@ID", ID);
            where = where.ToUpper();
            if (where.Contains("WHERE"))
            {
                where = where.Replace("WHERE", "");
                where = " AND " + where;
            }
            cmd.SetReplaceParamter("#strWhere#", where);
            cmd.SetReplaceParamter("#columns#", string.Join(",", columns));
            return cmd.ExecuteEntity<Entity_Content>();
        }

        public static PagingResult<IList<Entity_Content>> GetPagingResult(ViewQueryCondition<string> query)
        {
            PagingResult<IList<Entity_Content>> result = new PagingResult<IList<Entity_Content>>();
            if (query.PagingInfo == null)
            {
                query.PagingInfo = new ViewPagingInfo()
                {
                    PageIndex = 1,
                    PageSize = 10,
                    OrderField = "CON.ContentID",
                    SortDir = "DESC"
                };
            }

            string sqlString = @"
SELECT @totalCount= COUNT(CON.CONTENTID) 
FROM EDNF_CMS_Content CON WITH(NOLOCK)
WHERE 1=1 
#strWhere#

SELECT * FROM 
(
    SELECT 
    ROW_NUMBER() OVER (ORDER BY #OrderField# #SortDir#) R,
	    CON.*
	    ,CC.ClassName
    FROM EDNF_CMS_Content CON WITH(NOLOCK)
	    INNER JOIN EDNF_CMS_ContentClass CC WITH(NOLOCK)
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
            result.Result = cmd.ExecuteEntities<Entity_Content>();
            result.TotalCount = cmd.GetOutParameter<Int32>("@totalCount");
            result.PagingInfo = query.PagingInfo;

            return result;
        }
    }
}
