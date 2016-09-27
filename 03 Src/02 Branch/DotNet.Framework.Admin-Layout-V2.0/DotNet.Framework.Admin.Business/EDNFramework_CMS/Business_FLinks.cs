using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.Business.EDNFramework_CMS
{
    public class Business_FLinks
    {
        public static PagingResult<IList<Entity_FLinks>> GetListByPager(ViewQueryCondition<object> query)
        {
            PagingResult<IList<Entity_FLinks>> result = new PagingResult<IList<Entity_FLinks>>();
            string sqlStr = @"
SELECT @TotalCount= COUNT(ID) 
FROM EDNF_CMS_FLinks WITH(NOLOCK)
WHERE State = 1 AND IsDisplay = 1




SELECT * FROM 
(
SELECT 
ROW_NUMBER() OVER (ORDER BY #OrderField# #SortDir#) R,
	*
FROM EDNF_CMS_FLinks WITH(NOLOCK)
WHERE State = 1 AND IsDisplay = 1

) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize

";
            Command cmd = CommandManager.CreateCommand(sqlStr);

            cmd.SetReplaceParamter("#OrderField#", query.PagingInfo.OrderField);
            cmd.SetReplaceParamter("#SortDir#", query.PagingInfo.SortDir);
            cmd.SetOutParameter("@TotalCount", System.Data.DbType.Int32, null);
            cmd.SetParamter("@PageIndex", query.PagingInfo.PageIndex);
            cmd.SetParamter("@PageSize", query.PagingInfo.PageSize);


            result.Result = cmd.ExecuteEntities<Entity_FLinks>();
            result.PagingInfo = query.PagingInfo;
            int totalCount = cmd.GetOutParameter<Int32>("@TotalCount");
            result.TotalCount = totalCount;
            return result;
        }

        public static int Add(Entity_FLinks entity, int userId)
        {
            string sqlStr = @"
INSERT INTO [EDNF_CMS_FLinks]
           ([Name]
           ,[ImgUrl]
           ,[LinkUrl]
           ,[LinkDesc]
           ,[State]
           ,[OrderID]
           ,[ContactPerson]
           ,[Email]
           ,[TelPhone]
           ,[TypeID]
           ,[IsDisplay]
           ,[ImgWidth]
           ,[ImgHeight])
     VALUES
           (@Name
           ,@ImgUrl
           ,@LinkUrl
           ,@LinkDesc
           ,@State
           ,@OrderID
           ,@ContactPerson
           ,@Email
           ,@TelPhone
           ,@TypeID
           ,@IsDisplay
           ,@ImgWidth
           ,@ImgHeight)
";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@ContactPerson", entity.ContactPerson);
            cmd.SetParamter("@Email", entity.Email);
            cmd.SetParamter("@ImgHeight", entity.ImgHeight);
            cmd.SetParamter("@ImgUrl", entity.ImgUrl);
            cmd.SetParamter("@ImgWidth", entity.ImgWidth);
            cmd.SetParamter("@IsDisplay", entity.IsDisplay);
            cmd.SetParamter("@LinkDesc", entity.LinkDesc);
            cmd.SetParamter("@LinkUrl", entity.LinkUrl);
            cmd.SetParamter("@Name", entity.Name);
            cmd.SetParamter("@OrderID", entity.OrderID);
            cmd.SetParamter("@State", entity.State);
            cmd.SetParamter("@TelPhone", entity.TelPhone);
            cmd.SetParamter("@TypeID", entity.TypeID);
            return cmd.ExecuteNonQuery();
        }

        public static int Delete(int id)
        {
            string sqlStr = @"DELETE TOP (1) FROM [EDNF_CMS_FLinks] WHERE ID = @ID";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@ID", id);
            return cmd.ExecuteNonQuery();
        }

        public static int Update(Entity_FLinks entity, int userId)
        {
            string sqlStr = @"
UPDATE [EDNF_CMS_FLinks]
   SET [Name] = @Name
      ,[ImgUrl] = @ImgUrl
      ,[LinkUrl] = @LinkUrl
      ,[LinkDesc] = @LinkDesc
      ,[State] = @State
      ,[OrderID] = @OrderID
      ,[ContactPerson] = @ContactPerson
      ,[Email] = @Email
      ,[TelPhone] = @TelPhone
      ,[TypeID] = @TypeID
      ,[IsDisplay] = @IsDisplay
      ,[ImgWidth] = @ImgWidth
      ,[ImgHeight] = @ImgHeight
 WHERE ID = @ID
";

            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@ContactPerson", entity.ContactPerson);
            cmd.SetParamter("@Email", entity.Email);
            cmd.SetParamter("@ImgHeight", entity.ImgHeight);
            cmd.SetParamter("@ImgUrl", entity.ImgUrl);
            cmd.SetParamter("@ImgWidth", entity.ImgWidth);
            cmd.SetParamter("@IsDisplay", entity.IsDisplay);
            cmd.SetParamter("@LinkDesc", entity.LinkDesc);
            cmd.SetParamter("@LinkUrl", entity.LinkUrl);
            cmd.SetParamter("@Name", entity.Name);
            cmd.SetParamter("@OrderID", entity.OrderID);
            cmd.SetParamter("@State", entity.State);
            cmd.SetParamter("@TelPhone", entity.TelPhone);
            cmd.SetParamter("@TypeID", entity.TypeID);
            cmd.SetParamter("@ID", entity.ID);
            return cmd.ExecuteNonQuery();
        }

        public static Entity_FLinks GetModel(int id)
        {
            string sqlStr = @"SELECT TOP 1 * FROM [EDNF_CMS_FLinks] WITH(NOLOCK) WHERE ID = @ID";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@ID", id);
            return cmd.ExecuteEntity<Entity_FLinks>();
        }
    }
}
