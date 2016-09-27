using DotNet.Framework.Admin.Entity.Hospital;
using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.Business.Hospital
{
    public class Business_Hospital_NormItem
    {
        public static IList<Entity_Hospital_NormItem> GetListByPager(int categoryid, int pageindex, int pagesize, string orderField, string dir, out int totolCount)
        {
            totolCount = 0;
            string totleString = @"
    SELECT COUNT(ID) 
    FROM [Hospital_NormItem] WITH(NOLOCK) 
  where ItemCategory = @ItemCategory
";
            Command cmdCount = CommandManager.CreateCommand(totleString);
            cmdCount.SetParamter("@ItemCategory", categoryid);
            totolCount = cmdCount.ExecuteSingle<int>();

            string sqlString = string.Format(@"
SELECT * FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) R,ni.*,nc.CategoryName  as ItemCategoryName
      FROM Hospital_NormItem ni WITH(NOLOCK) 
	left join Hospital_NormCategory nc
		on nc.ID = ni.ItemCategory
    where ni.ItemCategory = @ItemCategory
) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
", orderField, dir);
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@sortBy", orderField);
            cmd.SetParamter("@PageIndex", pageindex);
            cmd.SetParamter("@PageSize", pagesize);
            cmd.SetParamter("@ItemCategory", categoryid);
            return cmd.ExecuteEntities<Entity_Hospital_NormItem>();
        }

        public static bool Add(Entity_Hospital_NormItem entity)
        {
            string sqlString = @"
INSERT INTO [Hospital_NormItem]
           ([ItemCode]
           ,[ItremName]
           ,[ItemCategory]
           ,[ItemCreateTime]
           ,[ItemStopTime]
           ,[ItemStatus])
     VALUES
           (@ItemCode
           ,@ItremName
           ,@ItemCategory
           ,GETDATE()
           ,@ItemStopTime
           ,@ItemStatus)
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ItemCode", entity.ItemCode);
            cmd.SetParamter("@ItremName", entity.ItremName);
            cmd.SetParamter("@ItemCategory", entity.ItemCategory);
            cmd.SetParamter("@ItemStopTime", entity.ItemStopTime);
            cmd.SetParamter("@ItemStatus", entity.ItemStatus);
            return cmd.ExecuteNonQuery() > 0;

        }

        public static bool Delete(int id)
        {
            string sqlString = @"
DELETE FROM [Hospital_NormItem]
      WHERE ID = @ID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ID", id);
            //TODO 这里还要删除指标关系数据 
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool Stop(int id, string status)
        {
            string sqlString = @"
UPDATE [Hospital_NormItem]
   SET [ItemStatus] = @ItemStatus";
            if (status == "Y")
            {
                sqlString += " ,[ItemStopTime] = GETDATE()";
            }
            else
            {
                sqlString += ",[ItemStopTime] = NULL";
            }
            sqlString += " WHERE ID = @ID ";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ID", id);
            cmd.SetParamter("@ItemStatus", status);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool Edit(Entity_Hospital_NormItem entity)
        {
            string sqlString = @"
UPDATE [Hospital_NormItem]
   SET [ItemCode]       = @ItemCode
      ,[ItremName]      = @ItremName
      ,[ItemCategory]   = @ItemCategory
      ,[ItemStopTime]   = @ItemStopTime
      ,[ItemStatus]     = @ItemStatus
 WHERE ID = @ID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ItemCode", entity.ItemCode);
            cmd.SetParamter("@ItremName", entity.ItremName);
            cmd.SetParamter("@ItemCategory", entity.ItemCategory);
            cmd.SetParamter("@ItemStopTime", entity.ItemStopTime);
            cmd.SetParamter("@ItemStatus", entity.ItemStatus);
            cmd.SetParamter("@ID", entity.ID);
            return cmd.ExecuteNonQuery() > 0;

        }

        public static Entity_Hospital_NormItem GetModel(int id)
        {
            string sqlString = @"
SELECT top 1 ni.*,nc.CategoryName as ItemCategoryName
  FROM [EDNFramework].[dbo].[Hospital_NormItem] ni
  left join Hospital_NormCategory nc 
  on nc.ID = ni.ItemCategory
  where ni.id= @ID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ID", id);
            return cmd.ExecuteEntity<Entity_Hospital_NormItem>();
        }

        public static IList<Entity_Hospital_NormItem> GetList()
        {
            string sqlString = @"
SELECT ID,ItemCode,ItremName,ItemCategory 
FROM [Hospital_NormItem]
WHERE ItemStatus='N'
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            return cmd.ExecuteEntities<Entity_Hospital_NormItem>();

        }

        public static IList<Entity_Hospital_NormItem> GetListByCategoryID(int categoryId)
        {
            string sqlString = @"
SELECT ID,ItemCode,ItremName,ItemCategory 
FROM [Hospital_NormItem]
WHERE ItemStatus='N' AND ItemCategory=@ItemCategory

";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ItemCategory", categoryId);
            return cmd.ExecuteEntities<Entity_Hospital_NormItem>();

        }

        public static IList<Entity_Hospital_NormItem> GetNormItems(int categoryId, int normId, int departmentId, DateTime? startTime, DateTime? endTime)
        {
            throw new NotImplementedException();
        }
    }
}
