using DotNet.Framework.Admin.Entity.EDNFramework_Product;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;

namespace DotNet.Framework.Admin.Business.EDNFramework_Product
{
    public class Business_Product_Class
    {
        public static IList<Entity_Product_Class_PagerGrid> GetListByPager(int pageindex, int pagesize, string orderField, string dir, out int totolCount)
        {
            totolCount = 0;
            string totleString = @"
    SELECT COUNT(ClassID) 
    FROM EDNF_Product_Class cc WITH(NOLOCK) 
";
            Command cmdCount = CommandManager.CreateCommand(totleString);
            totolCount = cmdCount.ExecuteSingle<int>();

            string sqlString = string.Format(@"
SELECT * FROM 
(
SELECT
ROW_NUMBER() OVER (ORDER BY {0} {1}) R,
    cc.ClassID
	,cc.ClassName
	,cc.Sequence
	,cc.Activity
	,cc.AllowAddContent
	,cc.ImageUrl
	,cc.Description
	,cc.Keywords
    ,cp.ClassName as ParentName
        FROM EDNF_Product_Class cc WITH(NOLOCK)
            LEFT JOIN  EDNF_Product_Class cp WITH(NOLOCK)
                on cp.ClassID = cc.ParentId
) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
", orderField, dir);
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@PageIndex", pageindex);
            cmd.SetParamter("@PageSize", pagesize);
            return cmd.ExecuteEntities<Entity_Product_Class_PagerGrid>();
        }

        public static bool ExistsName(string name)
        {
            string sql = @"
SELECT COUNT(CLASSID) FROM [EDNF_Product_Class] WITH(NOLOCK)
WHERE [ClassName] = @ClassName
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ClassName", name);
            return cmd.ExecuteSingle<int>() > 0;
        }

        public static bool ExistsName(string name, int id)
        {
            string sql = @"
SELECT COUNT(CLASSID) FROM [EDNF_Product_Class] WITH(NOLOCK)
WHERE [ClassName] = @ClassName AND ClassID <> @ClassID
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ClassName", name);
            cmd.SetParamter("@ClassID", id);
            return cmd.ExecuteSingle<int>() > 0;
        }

        public static int Add(Entity_Product_Class_Add entity, int userId)
        {
            if (ExistsName(entity.ClassName))
            {
                throw new BusinessException(string.Format("类别“{0}”已经存在。", entity.ClassName));
            }

            string sql = @"
INSERT INTO [EDNF_Product_Class]
           ([ClassName]
           ,[Sequence]
           ,[Activity]
           ,[AllowAddContent]
           ,[Description]
           ,[CreatedDate]
           ,[CreatedUserID]
           ,[ParentId] )
     VALUES
           (@ClassName
           ,@Sequence
           ,@Activity
           ,@AllowAddContent
           ,@Description
           ,GETDATE()
           ,@CreatedUserID
           ,@ParentId)
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ClassName", entity.ClassName);
            cmd.SetParamter("@Sequence", entity.Sequence);
            cmd.SetParamter("@Activity", entity.Activity);
            cmd.SetParamter("@AllowAddContent", entity.AllowAddContent);
            cmd.SetParamter("@Description", entity.Description);
            cmd.SetParamter("@CreatedUserID", userId);
            cmd.SetParamter("@ParentId", entity.ParentId);

            return cmd.ExecuteNonQuery();
        }

        public static int Edit(Entity_Product_Class_Edit entity, int userId)
        {
            if (ExistsName(entity.ClassName, entity.ClassID))
            {
                throw new BusinessException(string.Format("类别“{0}”已经存在。", entity.ClassName));
            }

            string sql = @"
UPDATE TOP (1) [EDNF_Product_Class]
        SET [ClassName]         = @ClassName
           ,[Sequence]          = @Sequence
           ,[Activity]          = @Activity
           ,[AllowAddContent]   = @AllowAddContent
           ,[Description]       = @Description
           ,[LastEditDate]      = GETDATE()
           ,[LastEditUserID]    = @LastEditUserID
           ,[ParentId]          = @ParentId
WHERE  ClassID = @ClassID
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ClassName", entity.ClassName);
            cmd.SetParamter("@Sequence", entity.Sequence);
            cmd.SetParamter("@Activity", entity.Activity);
            cmd.SetParamter("@AllowAddContent", entity.AllowAddContent);
            cmd.SetParamter("@Description", entity.Description);
            cmd.SetParamter("@LastEditUserID", userId);
            cmd.SetParamter("@ClassID", entity.ClassID);
            cmd.SetParamter("@ParentId", entity.ParentId);

            return cmd.ExecuteNonQuery();
        }

        public static Entity_Product_Class_Edit GetModel(int classID)
        {
            string sql = @"
            SELECT TOP 1 * FROM [EDNF_Product_Class] WITH(NOLOCK)
                WHERE [ClassID] = @ClassID
            ";

            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ClassID", classID);
            return cmd.ExecuteEntity<Entity_Product_Class_Edit>();
        }

        public static bool Delete(int classID)
        {
            int itemSonCount = ItemSonCount(classID);
            if (itemSonCount > 0)
            {
                throw new BusinessException(string.Format("该分类下子分类数量为“{0}”，不能删除.", itemSonCount));
            }

            int itemCount = ItemCount(classID);

            if (itemCount > 0)
            {
                throw new BusinessException(string.Format("该分类下商品数量为“{0}”，不能删除.", itemCount));
            }
            string sql = @"
DELETE FROM [EDNF_Product_Class]
WHERE ClassID = @ClassID
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ClassID", classID);
            return cmd.ExecuteNonQuery() > 0;
        }

        private static int ItemSonCount(int classID)
        {
            string sql = @"
SELECT COUNT(ClassID) FROM [EDNF_Product_Class] WITH(NOLOCK)
WHERE ParentId = @ClassID
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ClassID", classID);
            return cmd.ExecuteSingle<int>();
        }

        public static int ItemCount(int classID)
        {
            string sql = @"
SELECT COUNT(ID) FROM [EDNF_Product_Item] WITH(NOLOCK)
WHERE ClassID = @ClassID
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@ClassID", classID);
            return cmd.ExecuteSingle<int>();
        }

        public static IList<Entity_Product_Class_Dropdownlist> GetClass_DropDownList()
        {
            string sql = @"
SELECT [ClassID]
      ,[ClassName]
  FROM  [EDNF_Product_Class]
  WHERE Activity=1 AND AllowAddContent=1
";
            Command cmd = CommandManager.CreateCommand(sql);
            return cmd.ExecuteEntities<Entity_Product_Class_Dropdownlist>();
        }
    }
}
