using DotNet.Framework.Admin.Entity.Hospital;
using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;

namespace DotNet.Framework.Admin.Business.Hospital
{
    public class Business_Hospital_NormCategory
    {
        public static IList<Entity_Hospital_NormCategoryTree> GetNormCategoryTreeData()
        {
            string sqlString = @"
SELECT 
	ID
    ,CategoryName
    ,CategoryCode
    ,(
        CASE 
            when ParentID IS NULL then 0 
           else ParentID end )ParentID
	,Deleted
 FROM [Hospital_NormCategory] WITH(NOLOCK) 
    WHERE Deleted != 'Y' OR Deleted IS NULL
";
            Command cmd = CommandManager.CreateCommand(sqlString);

            return cmd.ExecuteEntities<Entity_Hospital_NormCategoryTree>();

        }

        public static bool Delete(int id)
        {
            string sqlString = @"
UPDATE TOP (1) [Hospital_NormCategory]
           SET [Deleted] = 'Y'
           WHERE ID = @ID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ID", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool Add(Entity_Hospital_NormCategory entity)
        {
            string sqlString = @"
INSERT INTO [Hospital_NormCategory]
           ([CategoryName]
           ,[CategoryCode]
           ,[ParentID]
           ,[Deleted])
     VALUES
           (@CategoryName
           ,@CategoryCode
           ,@ParentID
           ,'N')
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@CategoryName", entity.CategoryName);
            cmd.SetParamter("@CategoryCode", entity.CategoryCode);
            cmd.SetParamter("@ParentID", entity.ParentID);
            return cmd.ExecuteNonQuery() > 0;


        }

        public static Entity_Hospital_NormCategory GetModel(int id)
        {
            string sqlString = @"
SELECT top 1 
	c.ID,c.CategoryName,c.CategoryCode,
	(CASE when c.ParentID IS NULL then 0 else c.ParentID end )ParentID
	,c.Deleted,
(CASE WHEN p.CategoryName IS NULL THEN '指标分类' ELSE p.CategoryName END )ParentName
 FROM [Hospital_NormCategory] c WITH(NOLOCK) 
 left join [Hospital_NormCategory] p on p.ID = c.ParentID
           WHERE c.ID = @ID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ID", id);
            return cmd.ExecuteEntity<Entity_Hospital_NormCategory>();
        }

        public static bool Update(Entity_Hospital_NormCategory entity)
        {
            string sqlString = @"
UPDATE top 1 [Hospital_NormCategory]
   SET [CategoryName] = @CategoryName
      ,[CategoryCode] = @CategoryCode
      ,[ParentID] = @ParentID
 WHERE  WHERE ID = @ID
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@CategoryName", entity.CategoryName);
            cmd.SetParamter("@CategoryCode", entity.CategoryCode);
            cmd.SetParamter("@ParentID", entity.ParentID);
            cmd.SetParamter("@ID", entity.ID);
            return cmd.ExecuteNonQuery() > 0;

        }
    }
}
