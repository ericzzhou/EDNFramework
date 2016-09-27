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
    public class Business_Slide
    {
        public static PagingResult<IList<Entity_Slide>> GetListByPager(ViewQueryCondition<object> query)
        {
            PagingResult<IList<Entity_Slide>> result = new PagingResult<IList<Entity_Slide>>();
            string sqlStr = @"
SELECT @TotalCount= COUNT(S.ID) 
FROM EDNF_CMS_Slide S WITH(NOLOCK)
WHERE 1=1

SELECT * FROM 
(
SELECT 
ROW_NUMBER() OVER (ORDER BY #OrderField# #SortDir#) R,
	S.*,
    (SELECT COUNT(ID) FROM EDNF_CMS_Slide_Item WITH(NOLOCK) WHERE SlideID = S.ID) as ItemCount,
    (SELECT COUNT(ID) FROM EDNF_CMS_Slide_Item WITH(NOLOCK) WHERE SlideID = S.ID AND [Enable] = 1) as EnableCount
FROM EDNF_CMS_Slide S WITH(NOLOCK)
WHERE 1=1

) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize

";
            Command cmd = CommandManager.CreateCommand(sqlStr);

            cmd.SetReplaceParamter("#OrderField#", query.PagingInfo.OrderField);
            cmd.SetReplaceParamter("#SortDir#", query.PagingInfo.SortDir);
            cmd.SetOutParameter("@TotalCount", System.Data.DbType.Int32, null);
            cmd.SetParamter("@PageIndex", query.PagingInfo.PageIndex);
            cmd.SetParamter("@PageSize", query.PagingInfo.PageSize);


            result.Result = cmd.ExecuteEntities<Entity_Slide>();
            result.PagingInfo = query.PagingInfo;
            int totalCount = cmd.GetOutParameter<Int32>("@TotalCount");
            result.TotalCount = totalCount;
            return result;
        }

        public static int Add(Entity_Slide entity)
        {
            string sql = @"
INSERT INTO [EDNF_CMS_Slide]
           ([Name]
           ,[Width]
           ,[Height]
           ,[ItemType]
           ,[delay])
     VALUES
           (@Name
           ,@Width
           ,@Height
           ,@ItemType
           ,@delay)
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@Name", entity.Name);
            cmd.SetParamter("@Height", entity.Height);
            cmd.SetParamter("@Width", entity.Width);
            cmd.SetParamter("@ItemType", entity.ItemType);
            cmd.SetParamter("@delay", entity.delay);
            return cmd.ExecuteNonQuery();
        }

        public static Entity_Slide GetModel(int id)
        {
            string sql = "SELECT TOP 1 * FROM [EDNF_CMS_Slide] WITH(NOLOCK) WHERE ID = @ID";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ID", id);
            return cmd.ExecuteEntity<Entity_Slide>();
        }

        public static bool Update(Entity_Slide entity)
        {
            string sql = @"
UPDATE TOP (1) [EDNF_CMS_Slide]
   SET [Name] = @Name
      ,[Width] = @Width
      ,[Height] = @Height
      ,[ItemType] = @ItemType
      ,[delay] = @delay
 WHERE ID = @ID
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@Name", entity.Name);
            cmd.SetParamter("@Height", entity.Height);
            cmd.SetParamter("@Width", entity.Width);
            cmd.SetParamter("@ID", entity.ID);
            cmd.SetParamter("@ItemType", entity.ItemType);
            cmd.SetParamter("@delay", entity.delay);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static IList<Entity_Slide> GetALL()
        {
            Command cmd = CommandManager.CreateCommand("SELECT * FROM [EDNF_CMS_Slide] WITH(NOLOCK)");
            return cmd.ExecuteEntities<Entity_Slide>();
        }
    }
}
