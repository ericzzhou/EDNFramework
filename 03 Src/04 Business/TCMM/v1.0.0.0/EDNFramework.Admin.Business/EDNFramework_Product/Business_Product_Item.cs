using DotNet.Framework.Admin.Entity.EDNFramework_Product;
using DotNet.Framework.Admin.Entity.EDNFramework_Product.ViewQueryCondition;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;
using DotNet.Framework.Core.Extends;
namespace DotNet.Framework.Admin.Business.EDNFramework_Product
{
    public class Business_Product_Item
    {
        public static IList<Entity_Product_ItemGrid> GetListByPager(int pageindex, int pagesize, string orderField, string dir, out int totolCount)
        {
            totolCount = 0;
            string totleString = @"
	SELECT COUNT(I.ID)	
FROM EDNF_Product_Item I WITH(NOLOCK)
LEFT JOIN EDNF_Product_Class C WITH(NOLOCK)
	ON I.ClassID = C.ClassID
";
            Command cmdCount = CommandManager.CreateCommand(totleString);
            totolCount = cmdCount.ExecuteSingle<int>();

            string sqlString = string.Format(@"
SELECT * FROM 
(
SELECT 
ROW_NUMBER() OVER (ORDER BY {0} {1}) R,
	I.ID
	,I.PName
	,(CASE I.Price
		WHEN NULL THEN 0.00
		ELSE I.Price END) AS Price
	,(CASE I.DiscountPrice
		WHEN NULL THEN 0.00
		ELSE I.DiscountPrice END) AS DiscountPrice
	,I.CreatedDate
	,I.ClassID
	,I.IsTop
	,I.IsHot
	,I.IsRecomend
	,C.ClassName
	,I.ImageUrl
    ,I.Deleted
FROM EDNF_Product_Item I WITH(NOLOCK)
LEFT JOIN EDNF_Product_Class C WITH(NOLOCK)
	ON I.ClassID = C.ClassID

) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
", orderField, dir);
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@PageIndex", pageindex);
            cmd.SetParamter("@PageSize", pagesize);
            return cmd.ExecuteEntities<Entity_Product_ItemGrid>();
        }
        public static bool Recycle(int id)
        {
            return ChangeStatus("Deleted", false, id);
        }
        public static bool Delete(int id)
        {
            return ChangeStatus("Deleted", true, id);
        }

        public static bool ChangeStatus(string key, object val, int id)
        {
            string sql = string.Format(@"
UPDATE top (1) [EDNF_Product_Item]
   SET {0} = @val
 WHERE ID = @ID
", key);
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@val", val);
            cmd.SetParamter("@ID", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static int Add(Entity_Product_Item_Add entity, int userId)
        {
            string sql = @"
INSERT INTO [EDNF_Product_Item]
           ([PName]
           ,[Summary]
           ,[Description]
           ,[ImageUrl]
           ,[ThumbImageUrl]
           ,[NormalImageUrl]
           ,[Price]
           ,[DiscountPrice]
           ,[CreatedDate]
           ,[CreatedUserID] 
           ,[PvCount]
           ,[Deleted]
           ,[ClassID]
           ,[Sequence]
           ,[IsRecomend]
           ,[IsHot]
           ,[IsColor]
           ,[IsTop]
           ,[Meta_Title]
           ,[Meta_Description]
           ,[Meta_Keywords]
           ,[SeoUrl])
     VALUES
          ( @PName
           ,@Summary
           ,@Description
           ,@ImageUrl
           ,''
           ,''
           ,@Price
           ,@DiscountPrice
           ,GETDATE()
           ,@CreatedUserID
           ,0
           ,@Deleted
           ,@ClassID
           ,0
           ,@IsRecomend
           ,@IsHot
           ,0
           ,@IsTop
           ,@Meta_Title
           ,@Meta_Description
           ,@Meta_Keywords
           ,@SeoUrl);SELECT @@IDENTITY
";

            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@PName", entity.PName);
            cmd.SetParamter("@Summary", entity.Summary);
            cmd.SetParamter("@Description", entity.Description);
            cmd.SetParamter("@ImageUrl", entity.ImageUrl);
            cmd.SetParamter("@Price", entity.Price);
            cmd.SetParamter("@DiscountPrice", entity.DiscountPrice);
            cmd.SetParamter("@CreatedUserID", userId);
            cmd.SetParamter("@Deleted", entity.Deleted);
            cmd.SetParamter("@ClassID", entity.ClassID);
            cmd.SetParamter("@IsRecomend", entity.IsRecomend);
            cmd.SetParamter("@IsHot", entity.IsHot);
            cmd.SetParamter("@IsTop", entity.IsTop);
            cmd.SetParamter("@Meta_Title", entity.Meta_Title);
            cmd.SetParamter("@Meta_Description", entity.Meta_Description);
            cmd.SetParamter("@Meta_Keywords", entity.Meta_Keywords);
            cmd.SetParamter("@SeoUrl", entity.SeoUrl);
            return cmd.ExecuteSingle<int>();
        }



        public static Entity_Product_Item_Edit GetModel(int id)
        {
            string sql = @"
SELECT top 1 *
  FROM [EDNF_Product_Item]
  where ID=@id";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@id", id);
            return cmd.ExecuteEntity<Entity_Product_Item_Edit>();
        }

        public static int Edit(Entity_Product_Item_Edit entity, int userId)
        {
            string sql = @"
UPDATE TOP (1) [EDNF_Product_Item]
        SET [PName]                  =    @PName
           ,[Summary]                =    @Summary
           ,[Description]            =    @Description
           ,[ImageUrl]               =    @ImageUrl
           ,[ThumbImageUrl]          =    ''
           ,[NormalImageUrl]         =    ''
           ,[Price]                  =    @Price
           ,[DiscountPrice]          =    @DiscountPrice
           ,[LastEditDate]           =    GETDATE()
           ,[LastEditUserID]         =    @LastEditUserID
           ,[PvCount]                =    0
           ,[Deleted]                =    @Deleted
           ,[ClassID]                =    @ClassID
           ,[Sequence]               =    0
           ,[IsRecomend]             =    @IsRecomend
           ,[IsHot]                  =    @IsHot
           ,[IsColor]                =    0
           ,[IsTop]                  =    @IsTop
           ,[Meta_Title]             =    @Meta_Title
           ,[Meta_Description]       =    @Meta_Description
           ,[Meta_Keywords]          =    @Meta_Keywords
           ,[SeoUrl]                 =    @SeoUrl
    WHERE ID = @ID
";

            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@PName", entity.PName);
            cmd.SetParamter("@Summary", entity.Summary);
            cmd.SetParamter("@Description", entity.Description);
            cmd.SetParamter("@ImageUrl", entity.ImageUrl);
            cmd.SetParamter("@Price", entity.Price);
            cmd.SetParamter("@DiscountPrice", entity.DiscountPrice);
            cmd.SetParamter("@LastEditUserID", userId);
            cmd.SetParamter("@Deleted", entity.Deleted);
            cmd.SetParamter("@ClassID", entity.ClassID);
            cmd.SetParamter("@IsRecomend", entity.IsRecomend);
            cmd.SetParamter("@IsHot", entity.IsHot);
            cmd.SetParamter("@IsTop", entity.IsTop);
            cmd.SetParamter("@Meta_Title", entity.Meta_Title);
            cmd.SetParamter("@Meta_Description", entity.Meta_Description);
            cmd.SetParamter("@Meta_Keywords", entity.Meta_Keywords);
            cmd.SetParamter("@SeoUrl", entity.SeoUrl);
            cmd.SetParamter("@ID", entity.ID);
            return cmd.ExecuteNonQuery();
        }

        //        public static PagingResult<IList<Entity_Product_ItemGrid>> GetListByPager(ViewQueryCondition<Entity_Product_Condition> query)
        //        {
        //            PagingResult<IList<Entity_Product_ItemGrid>> result = new PagingResult<IList<Entity_Product_ItemGrid>>();
        //            result.PagingInfo = query.PagingInfo;
        //            string totleString = @"
        //	SELECT COUNT(I.ID)	
        //FROM EDNF_Product_Item I WITH(NOLOCK)
        //LEFT JOIN EDNF_Product_Class C WITH(NOLOCK)
        //	ON I.ClassID = C.ClassID
        //";
        //            Command cmdCount = CommandManager.CreateCommand(totleString);
        //            result.TotalCount = cmdCount.ExecuteSingle<int>();

        //            string sqlString = string.Format(@"
        //SELECT * FROM 
        //(
        //SELECT 
        //ROW_NUMBER() OVER (ORDER BY {0} {1}) R,
        //	I.ID
        //	,I.PName
        //	,(CASE I.Price
        //		WHEN NULL THEN 0.00
        //		ELSE I.Price END) AS Price
        //	,(CASE I.DiscountPrice
        //		WHEN NULL THEN 0.00
        //		ELSE I.DiscountPrice END) AS DiscountPrice
        //	,I.CreatedDate
        //	,I.ClassID
        //	,I.IsTop
        //	,I.IsHot
        //	,I.IsRecomend
        //	,C.ClassName
        //	,I.ImageUrl
        //    ,I.Deleted
        //FROM EDNF_Product_Item I WITH(NOLOCK)
        //LEFT JOIN EDNF_Product_Class C WITH(NOLOCK)
        //	ON I.ClassID = C.ClassID
        //
        //) DATA
        //WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
        //", query.PagingInfo.OrderField, query.PagingInfo.SortDir);
        //            Command cmd = CommandManager.CreateCommand(sqlString);
        //            cmd.SetParamter("@PageIndex", query.PagingInfo.PageIndex);
        //            cmd.SetParamter("@PageSize", query.PagingInfo.PageSize);
        //            result.Result = cmd.ExecuteEntities<Entity_Product_ItemGrid>();
        //            return result;
        //        }
        public static PagingResult<IList<Entity_Product_ItemGrid>> GetListByPager(ViewQueryCondition<Entity_Product_Condition> query)
        {
            PagingResult<IList<Entity_Product_ItemGrid>> result = new PagingResult<IList<Entity_Product_ItemGrid>>();

            string sqlString = @"
	SELECT @TotalCount = COUNT(I.ID)	
FROM EDNF_Product_Item I WITH(NOLOCK)
LEFT JOIN EDNF_Product_Class C WITH(NOLOCK)
	ON I.ClassID = C.ClassID
WHERE 1=1
	#StrWhere#
	
	
	SELECT * FROM 
(
SELECT 
ROW_NUMBER() OVER (ORDER BY #OrderField# #SortDir#) R,
	I.ID
	,I.PName
	,(CASE I.Price
		WHEN NULL THEN 0.00
		ELSE I.Price END) AS Price
	,(CASE I.DiscountPrice
		WHEN NULL THEN 0.00
		ELSE I.DiscountPrice END) AS DiscountPrice
	,I.CreatedDate
	,I.ClassID
	,I.IsTop
	,I.IsHot
	,I.IsRecomend
	,C.ClassName
	,I.ImageUrl
    ,I.Deleted
FROM EDNF_Product_Item I WITH(NOLOCK)
LEFT JOIN EDNF_Product_Class C WITH(NOLOCK)
	ON I.ClassID = C.ClassID
	WHERE 1=1
	#StrWhere#
) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize

";
            string where = string.Empty;
            if (query.Condition.ClassID.HasValue && query.Condition.ClassID.Value > 0)
            {
                where += " AND I.ClassID = @ClassID";
            }
            if (!query.Condition.Name.IsNull())
            {
                where += string.Format(" AND I.PName LIKE '%{0}%'", query.Condition.Name.Trim());
            }
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ClassID", query.Condition.ClassID);
            cmd.SetReplaceParamter("#StrWhere#", where);
            cmd.SetParamter("@PageIndex", query.PagingInfo.PageIndex);
            cmd.SetParamter("@PageSize", query.PagingInfo.PageSize);
            cmd.SetReplaceParamter("#OrderField#", query.PagingInfo.OrderField);
            cmd.SetReplaceParamter("#SortDir#", query.PagingInfo.SortDir);
            cmd.SetOutParameter("@TotalCount", System.Data.DbType.Int32, null);
            result.PagingInfo = query.PagingInfo;
            result.Result = cmd.ExecuteEntities<Entity_Product_ItemGrid>();
            result.TotalCount = cmd.GetOutParameter<Int32>("@TotalCount");
            return result;
        }
    }
}
