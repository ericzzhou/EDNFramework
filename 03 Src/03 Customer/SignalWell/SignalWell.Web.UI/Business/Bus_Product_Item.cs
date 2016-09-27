using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalWell.Web.UI.Business
{
    public class Bus_Product_Item
    {
        internal static IList<Models.Entity_Product_Item_Pager> GetPagerData(int cid, int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = 0;
            string totleString = @"
	SELECT COUNT(I.ID)	
FROM EDNF_Product_Item I WITH(NOLOCK) WHERE  I.Deleted<>1";
            if (cid > 0)
            {
                totleString += " AND I.ClassID=@ClassID";
            }

            Command cmdCount = CommandManager.CreateCommand(totleString);
            cmdCount.SetParamter("@ClassID", cid);
            totalCount = cmdCount.ExecuteSingle<int>();

            string sqlString = @"
SELECT * FROM 
(
SELECT 
ROW_NUMBER() OVER (ORDER BY I.ID DESC) R,
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
	,I.ImageUrl
    ,I.Deleted
    ,I.Summary
    ,IC.ClassName
FROM EDNF_Product_Item I WITH(NOLOCK)
LEFT JOIN EDNF_Product_Class IC WITH(NOLOCK) ON IC.ClassID = I.ClassID
WHERE I.Deleted<>1";
            if (cid > 0)
            {
                sqlString += " AND I.ClassID=@ClassID";
            }
            sqlString += @"
) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@PageIndex", pageIndex);
            cmd.SetParamter("@PageSize", pageSize);
            cmd.SetParamter("@ClassID", cid);
            return cmd.ExecuteEntities<Models.Entity_Product_Item_Pager>();
        }



        internal static Models.Entity_Product_Item GetModel(int id)
        {
            string sqlString = @"
SELECT TOP 1 * 
FROM EDNF_Product_Item I WITH(NOLOCK)
WHERE I.Deleted<>1 AND ID=@ID";

            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ID", id);
            return cmd.ExecuteEntity<Models.Entity_Product_Item>();
        }

        internal static IList<Models.Entity_Product_Item_Pager> GetPagerData(string ids, int pageIndex, int PageSize, out int totalCount)
        {
            totalCount = 0;
            string totleString = @"
SELECT COUNT(I.ID) 
FROM EDNF_Product_Item I WITH(NOLOCK)
WHERE 
	i.Deleted <> 1
	AND I.ClassID IN 
		(
		SELECT DISTINCT ClassID FROM  EDNF_Product_Class IC WITH(NOLOCK) ";

            if (!string.IsNullOrWhiteSpace(ids))
            {
                totleString += string.Format(" WHERE IC.ParentId IN ({0}) or  IC.ClassID IN ({0})", ids);
            }
            totleString += ")";

            Command cmdCount = CommandManager.CreateCommand(totleString);
            totalCount = cmdCount.ExecuteSingle<int>();

            string sqlString = @"
SELECT * FROM 
(
SELECT 
ROW_NUMBER() OVER (ORDER BY I.ID DESC) R,
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
	,I.ImageUrl
    ,I.Deleted
    ,I.Summary
    
FROM EDNF_Product_Item I WITH(NOLOCK)
WHERE I.Deleted<>1 AND I.ClassID IN 
		(
            SELECT DISTINCT ClassID FROM  EDNF_Product_Class IC WITH(NOLOCK) ";
            if (!string.IsNullOrWhiteSpace(ids))
            {
                sqlString += string.Format(" WHERE IC.ParentId IN ({0}) or  IC.ClassID IN ({0})", ids);
            }
            sqlString += @"
         )
) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@PageIndex", pageIndex);
            cmd.SetParamter("@PageSize", PageSize);
            return cmd.ExecuteEntities<Models.Entity_Product_Item_Pager>();
        }

        internal static IList<Models.Entity_Product_Item> GetAll(int classID)
        {
            string sqlString = @"
SELECT * 
FROM EDNF_Product_Item I WITH(NOLOCK)
WHERE I.Deleted<>1 AND I.ClassID = @ClassID";

            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ClassID", classID);
            return cmd.ExecuteEntities<Models.Entity_Product_Item>();
        }

        internal static IList<Models.Entity_Product> GetAllList(int classID)
        {
            string sqlString = @"
SELECT  I.ID ,
        I.ClassID ,
        I.ImageUrl ,
        I.PName ,
        I.Summary ,
        I.Description
FROM    EDNF_Product_Item I WITH ( NOLOCK )
WHERE   I.Deleted <> 1
        AND I.ClassID IN ( SELECT   ClassID
                           FROM     dbo.EDNF_Product_Class
                           WHERE    ClassID = @ClassID
                                    OR ParentId = @ClassID )";

            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ClassID", classID);
            return cmd.ExecuteEntities<Models.Entity_Product>();
        }
    }
}