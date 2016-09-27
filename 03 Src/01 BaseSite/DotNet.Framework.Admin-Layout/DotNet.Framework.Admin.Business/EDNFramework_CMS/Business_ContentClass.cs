using DotNet.Framework.Admin.Entity.EDNFramework_CMS;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;

namespace DotNet.Framework.Admin.Business.EDNFramework_CMS
{
    public class Business_ContentClass
    {
        public static int Add(Entity_ContentClass_Model entity)
        {
            if (GetCountByName(entity.ClassName) > 0)
            {
                throw new BusinessException(string.Format("已存在类别名称‘{0}’", entity.ClassName));
            }
            string sqlString = @"
INSERT INTO [EDNF_CMS_ContentClass]
           ([ClassName]
           ,[Sequence]
           ,[State]
           ,[AllowAddContent]
           ,[Description]
           ,[ClassTypeID]
           ,[CreatedUserID]
           ,[Meta_Title]
           ,[Meta_Description]
           ,[Meta_Keywords]
           ,[SeoUrl]
           ,[ClassModel])
     VALUES
            (@ClassName
           ,@Sequence
           ,@State
           ,@AllowAddContent
           ,@Description
           ,@ClassTypeID
           ,@CreatedUserID
           ,@Meta_Title
           ,@Meta_Description
           ,@Meta_Keywords
           ,@SeoUrl
           ,0)
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ClassName", entity.ClassName);
            cmd.SetParamter("@Sequence", entity.Sequence);
            cmd.SetParamter("@State", entity.State);
            cmd.SetParamter("@AllowAddContent", entity.AllowAddContent);
            cmd.SetParamter("@Description", entity.Description);
            cmd.SetParamter("@ClassTypeID", entity.ClassTypeID);
            cmd.SetParamter("@CreatedUserID", entity.CreatedUserID);
            cmd.SetParamter("@Meta_Title", entity.Meta_Title);
            cmd.SetParamter("@Meta_Description", entity.Meta_Description);
            cmd.SetParamter("@Meta_Keywords", entity.Meta_Keywords);
            cmd.SetParamter("@SeoUrl", entity.SeoUrl);

            return (int)cmd.ExecuteNonQuery();
        }

        public static int GetCountByName(int ClassID, string className)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new BusinessException("类别名称不能为空");
            }

            string sqlString = @"
SELECT COUNT(ClassID) 
    FROM EDNF_CMS_ContentClass WITH(NOLOCK) 
    WHERE ClassName = @ClassName
         And ClassID != @ClassID
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ClassID", ClassID);
            cmd.SetParamter("@ClassName", className);

            return (int)cmd.ExecuteSingle();
        }
        public static int GetCountByName(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new BusinessException("类别名称不能为空");
            }

            string sqlString = @"
SELECT COUNT(ClassID) 
    FROM EDNF_CMS_ContentClass WITH(NOLOCK) 
    WHERE ClassName = @ClassName";

            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ClassName", className);

            return (int)cmd.ExecuteSingle();
        }

        public static IList<Entity_ContentClass_GetList> GetAll()
        {
            string sqlString = @"
SELECT
    cc.ClassID,
    cc.ClassName,
    cc.Sequence,
    (CASE WHEN cc.[State] = 'true' THEN '显示' ELSE '隐藏' END) AS State,
    (CASE WHEN cc.[AllowAddContent] = 'true' THEN '允许' ELSE '不允许' END) AS AllowAddContent,
    cc.[Description],
    (CASE WHEN ct.ClassTypeName IS NULL THEN '根级别' ELSE ct.ClassTypeName END) AS ClassTypeName,
    cc.CreatedDate,
    cc.Meta_Title,
    cc.Meta_Description,
    cc.Meta_Keywords,
    cc.SeoUrl
        FROM EDNF_CMS_ContentClass cc WITH(NOLOCK)
        LEFT JOIN EDNF_CMS_ClassType ct WITH(NOLOCK) ON cc.ClassTypeID = ct.ClassTypeID
        
        ORDER BY cc.ClassID DESC
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            return cmd.ExecuteEntities<Entity_ContentClass_GetList>();
        }

        public static int Delete(int id)
        {
            string sqlString = @"
DELETE FROM [EDNF_CMS_ContentClass]
      WHERE ClassID = @ClassID
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ClassID", id);
            return cmd.ExecuteNonQuery();
        }

        public static Entity_ContentClass_Model GetModel(int ClassID)
        {
            string sqlString = @"
SELECT TOP 1
    --cc.ParentId,
    cc.ClassID,
    cc.ClassName,
    cc.Sequence,
    cc.[State],
    cc.AllowAddContent,
    cc.[Description],
    cc.[ClassTypeID],    
    cc.Meta_Title,
    cc.Meta_Description,
    cc.Meta_Keywords,
    cc.SeoUrl
        FROM EDNF_CMS_ContentClass cc WITH(NOLOCK)
        WHERE cc.ClassID = @ClassID
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ClassID", ClassID);
            return cmd.ExecuteEntity<Entity_ContentClass_Model>();
        }

        public static int Update(Entity_ContentClass_Model entity)
        {
            if (GetCountByName(entity.ClassID, entity.ClassName) > 0)
            {
                throw new BusinessException(string.Format("已存在类别名称‘{0}’", entity.ClassName));
            }

            string sqlString = @"
UPDATE [EDNF_CMS_ContentClass]
    SET [ClassName]         = @ClassName
       ,[Sequence]          = @Sequence
       ,[State]             = @State
       ,[AllowAddContent]   = @AllowAddContent
       ,[Description]       = @Description
       ,[ClassTypeID]       = @ClassTypeID
       ,[CreatedUserID]     = @CreatedUserID
       ,[Meta_Title]        = @Meta_Title
       ,[Meta_Description]  = @Meta_Description
       ,[Meta_Keywords]     = @Meta_Keywords
       ,[SeoUrl]            = @SeoUrl
    WHERE [ClassID]         = @ClassID

";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@ClassID", entity.ClassID);
            cmd.SetParamter("@ClassName", entity.ClassName);
            cmd.SetParamter("@Sequence", entity.Sequence);
            cmd.SetParamter("@State", entity.State);
            cmd.SetParamter("@AllowAddContent", entity.AllowAddContent);
            cmd.SetParamter("@Description", entity.Description);
            cmd.SetParamter("@ClassTypeID", entity.ClassTypeID);
            cmd.SetParamter("@CreatedUserID", entity.CreatedUserID);
            cmd.SetParamter("@Meta_Title", entity.Meta_Title);
            cmd.SetParamter("@Meta_Description", entity.Meta_Description);
            cmd.SetParamter("@Meta_Keywords", entity.Meta_Keywords);
            cmd.SetParamter("@SeoUrl", entity.SeoUrl);

            return (int)cmd.ExecuteNonQuery();
        }

        public static IList<Entity_ContentClass_DropDownList> GetEntity_ContentClass_DropDownList()
        {
            string sqlString = @"
SELECT
     cc.ClassID
    ,cc.ClassName  
    ,cc.AllowAddContent
 FROM EDNF_CMS_ContentClass cc WITH(NOLOCK)
 WHERE cc.[State] = 1
 ORDER BY cc.ClassID DESC
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            return cmd.ExecuteEntities<Entity_ContentClass_DropDownList>();
        }

        public static IList<Entity_ContentClass_GetList> GetListByPager(int pageindex, int pagesize, string orderField, string dir, out int totolCount)
        {
            totolCount = 0;
            string totleString = @"
    SELECT COUNT(classid) 
    FROM EDNF_CMS_ContentClass cc WITH(NOLOCK) 
";
            Command cmdCount = CommandManager.CreateCommand(totleString);
            totolCount = cmdCount.ExecuteSingle<int>();

            string sqlString = string.Format(@"
SELECT * FROM 
(
SELECT
ROW_NUMBER() OVER (ORDER BY {0} {1}) R,
    cc.ClassID,
    cc.ClassName,
    cc.Sequence,
    cc.[State] AS State,
    cc.[AllowAddContent]  AS AllowAddContent,
    cc.[Description],
    (CASE WHEN ct.ClassTypeName IS NULL THEN '根级别' ELSE ct.ClassTypeName END) AS ClassTypeName,
    cc.CreatedDate,
    cc.Meta_Title,
    cc.Meta_Description,
    cc.Meta_Keywords,
    cc.SeoUrl
        FROM EDNF_CMS_ContentClass cc WITH(NOLOCK)
        LEFT JOIN EDNF_CMS_ClassType ct WITH(NOLOCK) ON cc.ClassTypeID = ct.ClassTypeID
) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
", orderField, dir);
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@PageIndex", pageindex);
            cmd.SetParamter("@PageSize", pagesize);
            return cmd.ExecuteEntities<Entity_ContentClass_GetList>();


        }
    }
}
