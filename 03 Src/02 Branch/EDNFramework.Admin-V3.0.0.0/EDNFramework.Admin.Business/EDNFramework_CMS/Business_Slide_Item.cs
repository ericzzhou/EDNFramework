using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Admin.Entity.EDNFramework_CMS.ViewQueryCondition;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.Business.EDNFramework_CMS
{
    public class Business_Slide_Item
    {
        public static PagingResult<IList<Entity_Slide_Item>> GetListByPager(ViewQueryCondition<Entity_Slide_Item_Condition> query)
        {
            PagingResult<IList<Entity_Slide_Item>> result = new PagingResult<IList<Entity_Slide_Item>>();
            string sqlStr = @"
SELECT @TotalCount= COUNT(SI.ID) 
FROM EDNF_CMS_Slide_Item SI WITH(NOLOCK)
LEFT JOIN EDNF_CMS_Slide S WITH(NOLOCK)
		ON S.ID = SI.SlideID
WHERE 1=1
#strWhere#
SELECT * FROM 
(
SELECT 
ROW_NUMBER() OVER (ORDER BY #OrderField# #SortDir#) R,
	SI.*,
	S.Name as groupName
	FROM EDNF_CMS_Slide_Item SI WITH(NOLOCK)
	LEFT JOIN EDNF_CMS_Slide S WITH(NOLOCK)
		ON S.ID = SI.SlideID
WHERE 1=1
#strWhere#
) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize

";
            if (query == null)
            {
                query = new ViewQueryCondition<Entity_Slide_Item_Condition>();
            }
            if (query.Condition == null)
            {
                query.Condition = new Entity_Slide_Item_Condition();
            }
            string where = "";
            if (query.Condition.GroupID > 0)
            {
                where = " AND SI.SlideID = @SlideID";
            }
            Command cmd = CommandManager.CreateCommand(sqlStr);

            cmd.SetReplaceParamter("#OrderField#", query.PagingInfo.OrderField);
            cmd.SetReplaceParamter("#SortDir#", query.PagingInfo.SortDir);
            cmd.SetOutParameter("@TotalCount", System.Data.DbType.Int32, null);
            cmd.SetParamter("@PageIndex", query.PagingInfo.PageIndex);
            cmd.SetParamter("@PageSize", query.PagingInfo.PageSize);
            cmd.SetReplaceParamter("#strWhere#", where);
            cmd.SetParamter("@SlideID", query.Condition.GroupID);

            result.Result = cmd.ExecuteEntities<Entity_Slide_Item>();
            result.PagingInfo = query.PagingInfo;
            int totalCount = cmd.GetOutParameter<Int32>("@TotalCount");
            result.TotalCount = totalCount;
            return result;
        }

        public static int Add(Entity_Slide_Item entity)
        {
            string sql = @"
INSERT INTO [EDNF_CMS_Slide_Item]
           ([SlideID]
           ,[Name]
           ,[Description]
           ,[Href]
           ,[FilePath]
           ,[Enable]
           ,[sequence])
     VALUES
           (@SlideID
           ,@Name
           ,@Description
           ,@Href
           ,@FilePath
           ,@Enable
           ,@sequence)
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@SlideID",entity.SlideID);
            cmd.SetParamter("@Name",entity.Name);
            cmd.SetParamter("@Description",entity.Description);
            cmd.SetParamter("@Href",entity.Href);
            cmd.SetParamter("@FilePath",entity.FilePath);
            cmd.SetParamter("@Enable", entity.Enable);
            cmd.SetParamter("@sequence", entity.sequence);
            return cmd.ExecuteNonQuery();
        }

        public static Entity_Slide_Item GetModel(int id)
        {
            string sql = "SELECT TOP 1 * FROM EDNF_CMS_Slide_Item WITH(NOLOCK) WHERE ID = @ID";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ID", id);
            return cmd.ExecuteEntity<Entity_Slide_Item>();
        }

        public static bool Update(Entity_Slide_Item entity)
        {
            string sql = @"
UPDATE TOP (1) [EDNF_CMS_Slide_Item]
   SET [SlideID] = @SlideID
      ,[Name] = @Name
      ,[Description] = @Description
      ,[Href] = @Href
      ,[FilePath] = @FilePath
      ,[Enable] = @Enable
      ,[sequence] = @sequence
 WHERE ID = @ID
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@SlideID", entity.SlideID);
            cmd.SetParamter("@Name", entity.Name);
            cmd.SetParamter("@Description", entity.Description);
            cmd.SetParamter("@Href", entity.Href);
            cmd.SetParamter("@FilePath", entity.FilePath);
            cmd.SetParamter("@Enable", entity.Enable);
            cmd.SetParamter("@sequence", entity.sequence);
            cmd.SetParamter("@ID", entity.ID);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool Delete(int id)
        {
            string sql = @"DELETE TOP (1) FROM [EDNF_CMS_Slide_Item] WHERE ID = @ID";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ID", id);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
