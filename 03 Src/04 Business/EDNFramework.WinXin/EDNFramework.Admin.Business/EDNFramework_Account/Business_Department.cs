using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.Business.EDNFramework_Account
{
    public class Business_Department
    {
        public static IList<Entity_Department> GetListByPager(int pageindex, int pagesize, string orderField, string dir, out int totolCount)
        {
            totolCount = 0;
            string totleString = @"
    SELECT COUNT(ID) 
    FROM [EDNF_Account_Department] WITH(NOLOCK) 
";
            Command cmdCount = CommandManager.CreateCommand(totleString);
            totolCount = cmdCount.ExecuteSingle<int>();

            string sqlString = string.Format(@"
SELECT * FROM 
(
    SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) NUM
    ,dep.*
    FROM EDNF_Account_Department dep WITH(NOLOCK)
	)
	DATA
WHERE DATA.NUM BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
", orderField, dir);
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@sortBy", orderField);
            cmd.SetParamter("@PageIndex", pageindex);
            cmd.SetParamter("@PageSize", pagesize);
            return cmd.ExecuteEntities<Entity_Department>();

        }

        public static bool Delete(int Id)
        {
            string totleString = @"
   DELETE  
    FROM [EDNF_Account_Department]
    WHERE ID = @ID
";
            Command cmd = CommandManager.CreateCommand(totleString);
            cmd.SetParamter("@ID", Id);
            return cmd.ExecuteNonQuery() > 0;
        }
        public static int GetDepartmentCountByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("部门名称空错误");
            }
            string totleString = @"
SELECT COUNT(ID) FROM [EDNF_Account_Department]
where Name = @Name
";
            Command cmd = CommandManager.CreateCommand(totleString);
            cmd.SetParamter("@Name", name);
            return cmd.ExecuteSingle<int>();
        }

        public static int GetDepartmentCountByName(string name, int id)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("部门名称空错误");
            }
            string totleString = @"
SELECT COUNT(ID) FROM [EDNF_Account_Department]
where Name = @Name and id <> @id
";
            Command cmd = CommandManager.CreateCommand(totleString);
            cmd.SetParamter("@Name", name);
            cmd.SetParamter("@id", id);
            return cmd.ExecuteSingle<int>();
        }

        public static Entity_Department GetModel(int id)
        {
            if (id > 0)
            {
                string sqlStr = @"
SELECT * FROM [EDNF_Account_Department]
where ID = @ID
";
                Command cmd = CommandManager.CreateCommand(sqlStr);
                cmd.SetParamter("@ID", id);
                return cmd.ExecuteEntity<Entity_Department>();
            }
            return null;
        }
        public static int Add(Entity_Department entity)
        {
            string totleString = @"
INSERT INTO [EDNF_Account_Department]
           ([Code]
           ,[Name]
           ,[ShortName]
           ,[ParentID]
           ,[Type]
           ,[Manager]
           ,[Manager2]
           ,[Phone]
           ,[ExtNumber]
           ,[Fax]
           ,[Status]
           ,[Description])
     VALUES
           (@Code
           ,@Name
           ,@ShortName
           ,@ParentID
           ,@Type
           ,@Manager
           ,@Manager2
           ,@Phone
           ,@ExtNumber
           ,@Fax
           ,@Status
           ,@Description)
";
            Command cmd = CommandManager.CreateCommand(totleString);
            cmd.SetParamter("@Code", entity.Code);
            cmd.SetParamter("@Name", entity.Name);
            cmd.SetParamter("@ShortName", entity.ShortName);
            cmd.SetParamter("@ParentID", entity.ParentID);
            cmd.SetParamter("@Type", entity.@Type);
            cmd.SetParamter("@Manager", entity.Manager);
            cmd.SetParamter("@Manager2", entity.Manager2);
            cmd.SetParamter("@Phone", entity.Phone);
            cmd.SetParamter("@ExtNumber", entity.ExtNumber);
            cmd.SetParamter("@Fax", entity.Fax);
            cmd.SetParamter("@Status", entity.Status);
            cmd.SetParamter("@Description", entity.Description);
            return cmd.ExecuteNonQuery();

        }

        public static IList<Entity_Department> GetList()
        {
            string totleString = @"
SELECT * FROM [EDNF_Account_Department]
where Status='True'
";
            Command cmd = CommandManager.CreateCommand(totleString);

            return cmd.ExecuteEntities<Entity_Department>();
        }



        public static int Edit(Entity_Department entity)
        {
            if (entity == null || entity.ID <= 0)
            {
                throw new BusinessException("数据错误，编辑失败");
            }
            string sqlStr = @"
UPDATE [EDNF_Account_Department]
   SET [Name] = @Name
      ,[ShortName] = @ShortName
      ,[Phone] = @Phone
      ,[ExtNumber] = @ExtNumber
      ,[Fax] = @Fax
      ,[Status] = @Status
      ,[Description] = @Description
 WHERE ID = @ID
";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@Name", entity.Name);
            cmd.SetParamter("@ShortName", entity.ShortName);
            cmd.SetParamter("@Phone", entity.Phone);
            cmd.SetParamter("@ExtNumber", entity.ExtNumber);
            cmd.SetParamter("@Fax", entity.Fax);
            cmd.SetParamter("@Status", entity.Status);
            cmd.SetParamter("@Description", entity.Description);
            cmd.SetParamter("@ID", entity.ID);
            return cmd.ExecuteNonQuery();

        }

        public static PagingResult<IList<Entity_Department>> GetListByPager(ViewQueryCondition<object> query)
        {
            PagingResult<IList<Entity_Department>> result = new PagingResult<IList<Entity_Department>>();
            result.PagingInfo = query.PagingInfo;
            string totleString = @"
    SELECT COUNT(ID) 
    FROM [EDNF_Account_Department] WITH(NOLOCK) 
";
            Command cmdCount = CommandManager.CreateCommand(totleString);
            result.TotalCount = cmdCount.ExecuteSingle<int>();

            string sqlString = string.Format(@"
SELECT * FROM 
(
    SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) NUM
    ,dep.*
    FROM EDNF_Account_Department dep WITH(NOLOCK)
	)
	DATA
WHERE DATA.NUM BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize
", query.PagingInfo.OrderField, query.PagingInfo.SortDir);
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@PageIndex", query.PagingInfo.PageIndex);
            cmd.SetParamter("@PageSize", query.PagingInfo.PageSize);
            result.Result = cmd.ExecuteEntities<Entity_Department>();
            return result;
        }
    }
}
