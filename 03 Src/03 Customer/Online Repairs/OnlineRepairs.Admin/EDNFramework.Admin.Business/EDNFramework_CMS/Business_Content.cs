using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS.ViewQueryCondition;
namespace DotNet.Framework.Admin.Business.EDNFramework_CMS
{
    public class Business_Content
    {
        public static int Add(Entity.EDNFramework_CMS.Entity_Content entity)
        {
            string sqlString = @"
INSERT INTO [EDNF_CMS_Content]
           ([Title]
           ,[SubTitle]
           ,[Summary]
           ,[Description]
           ,[ImageUrl]
           ,[ThumbImageUrl]
           ,[NormalImageUrl]
           ,[CreatedDate]
           ,[CreatedUserID]
           ,[LastEditUserID]
           ,[LastEditDate]
           ,[LinkUrl]
           ,[PvCount]
           ,[State]
           ,[ClassID]
           ,[Keywords]
           ,[Sequence]
           ,[IsRecomend]
           ,[IsHot]
           ,[IsColor]
           ,[IsTop]
           ,[Attachment]
           ,[Remary]
           ,[TotalComment]
           ,[TotalSupport]
           ,[TotalFav]
           ,[TotalShare]
           ,[BeFrom]
           ,[FileName]
           ,[Meta_Title]
           ,[Meta_Description]
           ,[Meta_Keywords]
           ,[SeoUrl]
           ,[SeoImageAlt]
           ,[SeoImageTitle]
           ,[StaticUrl])
     VALUES
           (@Title
           ,@SubTitle
           ,@Summary
           ,@Description
           ,@ImageUrl
           ,@ThumbImageUrl
           ,@NormalImageUrl
           ,@CreatedDate
           ,@CreatedUserID
           ,@LastEditUserID
           ,@LastEditDate
           ,@LinkUrl
           ,@PvCount
           ,@State
           ,@ClassID
           ,@Keywords
           ,@Sequence
           ,@IsRecomend
           ,@IsHot
           ,@IsColor
           ,@IsTop
           ,@Attachment
           ,@Remary
           ,@TotalComment
           ,@TotalSupport
           ,@TotalFav
           ,@TotalShare
           ,@BeFrom
           ,@FileName
           ,@Meta_Title
           ,@Meta_Description
           ,@Meta_Keywords
           ,@SeoUrl
           ,@SeoImageAlt
           ,@SeoImageTitle
           ,@StaticUrl)
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@Title", entity.Title);
            cmd.SetParamter("@SubTitle", entity.SubTitle);
            cmd.SetParamter("@Summary", entity.Summary);
            cmd.SetParamter("@Description", entity.Description);
            cmd.SetParamter("@ImageUrl", entity.ImageUrl);
            cmd.SetParamter("@ThumbImageUrl", entity.ThumbImageUrl);
            cmd.SetParamter("@NormalImageUrl", entity.NormalImageUrl);
            cmd.SetParamter("@CreatedDate", entity.CreatedDate);
            cmd.SetParamter("@CreatedUserID", entity.CreatedUserID);
            cmd.SetParamter("@LastEditUserID", entity.LastEditUserID);
            cmd.SetParamter("@LastEditDate", entity.LastEditDate);
            cmd.SetParamter("@LinkUrl", entity.LinkUrl);
            cmd.SetParamter("@PvCount", entity.PvCount);
            cmd.SetParamter("@State", entity.State);
            cmd.SetParamter("@ClassID", entity.ClassID);
            cmd.SetParamter("@Keywords", entity.Keywords);
            cmd.SetParamter("@Sequence", entity.Sequence);
            cmd.SetParamter("@IsRecomend", entity.IsRecomend);
            cmd.SetParamter("@IsHot", entity.IsHot);
            cmd.SetParamter("@IsColor", entity.IsColor);
            cmd.SetParamter("@IsTop", entity.IsTop);
            cmd.SetParamter("@Attachment", entity.Attachment);
            cmd.SetParamter("@Remary", entity.Remary);
            cmd.SetParamter("@TotalComment", entity.TotalComment);
            cmd.SetParamter("@TotalSupport", entity.TotalSupport);
            cmd.SetParamter("@TotalFav", entity.TotalFav);
            cmd.SetParamter("@TotalShare", entity.TotalShare);
            cmd.SetParamter("@BeFrom", entity.BeFrom);
            cmd.SetParamter("@FileName", entity.FileName);
            cmd.SetParamter("@Meta_Title", entity.Meta_Title);
            cmd.SetParamter("@Meta_Description", entity.Meta_Description);
            cmd.SetParamter("@Meta_Keywords", entity.Meta_Keywords);
            cmd.SetParamter("@SeoUrl", entity.SeoUrl);
            cmd.SetParamter("@SeoImageAlt", entity.SeoImageAlt);
            cmd.SetParamter("@SeoImageTitle", entity.SeoImageTitle);
            cmd.SetParamter("@StaticUrl", entity.StaticUrl);

            return (int)cmd.ExecuteNonQuery();
        }

        public static IList<Entity_Content_GetTableData> GetTablesData()
        {
            string sqlString = @"
SELECT 
	CON.ContentID
	,CON.Title
	,(CASE WHEN CON.State = 1 THEN '发布' ELSE '' END ) State
	,(CASE WHEN CON.IsHot = 1 THEN '热点' ELSE '' END ) IsHot
	,(CASE WHEN CON.IsRecomend = 1 THEN '推荐'  ELSE '' END ) IsRecomend
	,(CASE WHEN CON.IsTop = 1 THEN '置顶' ELSE '' END ) IsTop
	,CC.ClassName
FROM EDNF_CMS_Content CON WITH(NOLOCK)
	INNER JOIN EDNF_CMS_ContentClass CC WITH(NOLOCK)
	ON CC.ClassID = CON.ClassID
ORDER BY CON.ContentID DESC
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            return cmd.ExecuteEntities<Entity_Content_GetTableData>();
        }

        public static bool Delete(int id)
        {
            string sqlString = @"
DELETE FROM [EDNF_CMS_Content]
      WHERE ContentID = @ContentID 
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ContentID", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static Entity_Content GetModel(int ContentID)
        {
            string sqlString = @"
SELECT TOP 1 * FROM [EDNF_CMS_Content]
      WHERE ContentID = @ContentID 
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ContentID", ContentID);
            return cmd.ExecuteEntity<Entity_Content>();
        }

        public static IList<Entity_Content_GetTableData> GetListByPager(int pageindex, int pagesize, string orderField, string dir, string classId, string title, out int totolCount)
        {
            totolCount = 0;
            string totleString = @"

SELECT COUNT(CONTENTID) 
FROM EDNF_CMS_Content CON WITH(NOLOCK)
WHERE 1=1 
";
            if (!classId.IsNull() && classId.IsInt() && classId.ToInt() > 0)
            {
                totleString += " AND CON.ClassID=@ClassID";
            }
            if (!title.IsNull())
            {
                totleString += string.Format(" AND CON.Title LIKE '%{0}%'", title.Trim());
            }



            string sqlString = string.Format(@"
SELECT * FROM 
(
SELECT 
ROW_NUMBER() OVER (ORDER BY {0} {1}) R,
	CON.ContentID
	,CON.Title
	,CON.State
	,CON.IsHot IsHot
	,CON.IsRecomend  IsRecomend
	,CON.IsTop  IsTop
	,CC.ClassName
    ,CON.Summary
FROM EDNF_CMS_Content CON WITH(NOLOCK)
	INNER JOIN EDNF_CMS_ContentClass CC WITH(NOLOCK)
	ON CC.ClassID = CON.ClassID
WHERE 1=1 
", orderField, dir);
            if (!classId.IsNull() && classId.IsInt() && classId.ToInt() > 0)
            {
                sqlString += " AND CC.ClassID = @ClassID ";
            }
            if (!title.IsNull())
            {
                sqlString += string.Format(" AND CON.Title LIKE '%{0}%'", title.Trim());
            }

            sqlString += @"
) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
";

            Command cmdCount = CommandManager.CreateCommand(totleString);
            if (!classId.IsNull() && classId.IsInt() && classId.ToInt() > 0)
            {
                cmdCount.SetParamter("@ClassID", classId);
            }

            totolCount = cmdCount.ExecuteSingle<int>();


            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@PageIndex", pageindex);
            cmd.SetParamter("@PageSize", pagesize);
            if (!classId.IsNull() && classId.IsInt() && classId.ToInt() > 0)
            {
                cmd.SetParamter("@ClassID", classId);
            }

            return cmd.ExecuteEntities<Entity_Content_GetTableData>();

        }

        public static int Update(Entity_Content entity)
        {
            string sqlString = @"
UPDATE TOP (1) [EDNF_CMS_Content]
    SET
        [Title]             =  @Title
        ,[Summary]          =  @Summary
        ,[Description]      =  @Description
        ,[LastEditUserID]   =  @LastEditUserID
        ,[LastEditDate]     =  @LastEditDate
        ,[State]            =  @State
        ,[ClassID]          =  @ClassID
        ,[IsRecomend]       =  @IsRecomend
        ,[IsHot]            =  @IsHot
        ,[IsTop]            =  @IsTop
        ,[Meta_Title]       =  @Meta_Title
        ,[Meta_Description] =  @Meta_Description
        ,[Meta_Keywords]    =  @Meta_Keywords
        ,[SeoUrl]           =  @SeoUrl
        ,[Sequence]         =  @Sequence
    WHERE ContentID = @ContentID
";
            Command cmd = CommandManager.CreateCommand(sqlString);

            cmd.SetParamter("@Title", entity.Title);
            cmd.SetParamter("@Summary", entity.Summary);
            cmd.SetParamter("@Description", entity.Description);
            cmd.SetParamter("@LastEditUserID", entity.LastEditUserID);
            cmd.SetParamter("@LastEditDate", entity.LastEditDate);
            cmd.SetParamter("@State", entity.State);
            cmd.SetParamter("@ClassID", entity.ClassID);
            cmd.SetParamter("@IsRecomend", entity.IsRecomend);
            cmd.SetParamter("@IsHot", entity.IsHot);
            cmd.SetParamter("@IsTop", entity.IsTop);
            cmd.SetParamter("@Meta_Title", entity.Meta_Title);
            cmd.SetParamter("@Meta_Description", entity.Meta_Description);
            cmd.SetParamter("@Meta_Keywords", entity.Meta_Keywords);
            cmd.SetParamter("@SeoUrl", entity.SeoUrl);
            cmd.SetParamter("@ContentID", entity.ContentID);
            cmd.SetParamter("@Sequence", entity.Sequence);

            return (int)cmd.ExecuteNonQuery();
        }

        public static PagingResult<IList<Entity_Content_GetTableData>> GetListByPager2(ViewQueryCondition<Entity_Content_Condition> query)
        {
            PagingResult<IList<Entity_Content_GetTableData>> result = new PagingResult<IList<Entity_Content_GetTableData>>();
            string sqlStr = @"
SELECT @TotalCount= COUNT(CONTENTID) 
FROM EDNF_CMS_Content CON WITH(NOLOCK)
	INNER JOIN EDNF_CMS_ContentClass CC WITH(NOLOCK)
	ON CC.ClassID = CON.ClassID
WHERE 1=1 
#strWhere#




SELECT * FROM 
(
SELECT 
ROW_NUMBER() OVER (ORDER BY #OrderField# #SortDir#) R,
	CON.ContentID
	,CON.Title
	,CON.State
	,CON.IsHot IsHot
	,CON.IsRecomend  IsRecomend
	,CON.IsTop  IsTop
	,CC.ClassName
    ,CON.Summary
    ,CON.Sequence
FROM EDNF_CMS_Content CON WITH(NOLOCK)
	INNER JOIN EDNF_CMS_ContentClass CC WITH(NOLOCK)
	ON CC.ClassID = CON.ClassID
WHERE 1=1 

#strWhere#

) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize

";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            string where = "";
            if (query.Condition.ClassID.HasValue && query.Condition.ClassID.Value > 0)
            {
                where += " AND CC.ClassID = @ClassID ";
            }
            if (!query.Condition.Title.IsNull())
            {
                where += string.Format(" AND CON.Title LIKE '%{0}%'", query.Condition.Title.Trim());
            }
            cmd.SetReplaceParamter("#strWhere#", where);
            cmd.SetReplaceParamter("#OrderField#", query.PagingInfo.OrderField);
            cmd.SetReplaceParamter("#SortDir#", query.PagingInfo.SortDir);
            cmd.SetOutParameter("@TotalCount", System.Data.DbType.Int32, null);
            cmd.SetParamter("@PageIndex", query.PagingInfo.PageIndex);
            cmd.SetParamter("@PageSize", query.PagingInfo.PageSize);
            cmd.SetParamter("@ClassID", query.Condition.ClassID);
            result.Result = cmd.ExecuteEntities<Entity_Content_GetTableData>();
            result.PagingInfo = query.PagingInfo;
            int totalCount = cmd.GetOutParameter<Int32>("@TotalCount");
            result.TotalCount = totalCount;
            return result;
        }
        public static PagingResult<IList<Entity_Content_GetTableData>> GetListByPager(ViewQueryCondition<Entity_Content_Condition> query)
        {
            PagingResult<IList<Entity_Content_GetTableData>> result = new PagingResult<IList<Entity_Content_GetTableData>>();

            string totleString = @"
SELECT COUNT(CONTENTID) 
FROM EDNF_CMS_Content CON WITH(NOLOCK)
WHERE 1=1 
";

            string sqlString = string.Format(@"
SELECT * FROM 
(
SELECT 
ROW_NUMBER() OVER (ORDER BY {0} {1}) R,
	CON.ContentID
	,CON.Title
	,CON.State
	,CON.IsHot IsHot
	,CON.IsRecomend  IsRecomend
	,CON.IsTop  IsTop
	,CC.ClassName
    ,CON.Summary
FROM EDNF_CMS_Content CON WITH(NOLOCK)
	INNER JOIN EDNF_CMS_ContentClass CC WITH(NOLOCK)
	ON CC.ClassID = CON.ClassID
WHERE 1=1 
", query.PagingInfo.OrderField, query.PagingInfo.SortDir);

            if (query.Condition.ClassID.HasValue && query.Condition.ClassID.Value > 0)
            {
                totleString += " AND CON.ClassID=@ClassID";
                sqlString += " AND CC.ClassID = @ClassID ";
            }
            if (!query.Condition.Title.IsNull())
            {
                totleString += string.Format(" AND CON.Title LIKE '%{0}%'", query.Condition.Title.Trim());
                sqlString += string.Format(" AND CON.Title LIKE '%{0}%'", query.Condition.Title.Trim());
            }



            sqlString += @"
) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
";

            Command cmdCount = CommandManager.CreateCommand(totleString);
            Command cmd = CommandManager.CreateCommand(sqlString);
            if (query.Condition.ClassID.HasValue && query.Condition.ClassID.Value > 0)
            {
                cmdCount.SetParamter("@ClassID", query.Condition.ClassID.Value);
                cmd.SetParamter("@ClassID", query.Condition.ClassID.Value);
            }
            result.TotalCount = cmdCount.ExecuteSingle<int>();

            cmd.SetParamter("@PageIndex", query.PagingInfo.PageIndex);
            cmd.SetParamter("@PageSize", query.PagingInfo.PageSize);
            result.Result = cmd.ExecuteEntities<Entity_Content_GetTableData>();
            result.PagingInfo = query.PagingInfo;

            return result;
        }
    }
}
