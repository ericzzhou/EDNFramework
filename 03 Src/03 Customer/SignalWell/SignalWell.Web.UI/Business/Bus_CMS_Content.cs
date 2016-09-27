using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.DataAccess;
using SignalWell.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalWell.Web.UI.Business
{
    public class Bus_CMS_Content
    {
        public static Entity_Content GetModel(int id)
        {
            string sql = "SELECT TOP 1 * FROM EDNF_CMS_Content WHERE ContentID=@ContentID";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ContentID", id);
            return cmd.ExecuteEntity<Entity_Content>();
        }

        public static IList<Entity_About_LeftContent> GetListByClassID(int cid)
        {
            string sql = "SELECT  c.Sequence,c.* FROM EDNF_CMS_Content c WHERE State=1 AND ClassID = @ClassID ORDER BY c.Sequence ASC,c.ContentID desc";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ClassID", cid);
            return cmd.ExecuteEntities<Entity_About_LeftContent>();
        }

        public static PagingResult<IList<Models.EDNF_CMS_Content>> GetListByPager(ViewQueryCondition<dynamic> query)
        {
            PagingResult<IList<Models.EDNF_CMS_Content>> result = new PagingResult<IList<Models.EDNF_CMS_Content>>();
            string sqlStr = @"
SELECT @TotalCount= COUNT(ContentID) 
FROM EDNF_CMS_Content WITH(NOLOCK)
WHERE [State]=1 AND ClassID IN (#cid#)

SELECT * FROM 
(
SELECT 
ROW_NUMBER() OVER (ORDER BY ContentID DESC) R,
	C.ContentID
    ,C.ClassID
    ,C.Title
    ,C.CreatedDate
    ,C.IsTop
    ,C.Sequence
FROM EDNF_CMS_Content C WITH(NOLOCK)
WHERE [State]=1  AND ClassID IN (#cid#)

) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
ORDER BY DATA.IsTop DESC ,DATA.Sequence ASC,DATA.ContentID DESC
";
            Command cmd = CommandManager.CreateCommand(sqlStr);


            cmd.SetOutParameter("@TotalCount", System.Data.DbType.Int32, null);
            cmd.SetParamter("@PageIndex", query.PagingInfo.PageIndex);
            cmd.SetParamter("@PageSize", query.PagingInfo.PageSize);
            string cid = query.Condition.cid;
            cmd.SetReplaceParamter("#cid#", cid);

            result.Result = cmd.ExecuteEntities<Models.EDNF_CMS_Content>();
            result.PagingInfo = query.PagingInfo;
            int totalCount = cmd.GetOutParameter<Int32>("@TotalCount");
            result.TotalCount = totalCount;
            return result;
        }

        public static string GetClassName(string cid)
        {
            string sql = "SELECT TOP 1 ClassName FROM EDNF_CMS_ContentClass WITH(NOLOCK) WHERE ClassID = @ClassID";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ClassID", cid);
            return cmd.ExecuteSingle<string>();
        }
    }
}