using DotNet.Framework.Admin.Entity.EDNFramework_Account;
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
            cmd.SetParamter("@Code",entity.Code);
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
        public static IList<Entity_DepartmentForTree> GetListForTree()
        {
            string totleString = @"
SELECT ID,Name,ParentID FROM [EDNF_Account_Department]
where Status='True'
";
            Command cmd = CommandManager.CreateCommand(totleString);

            return cmd.ExecuteEntities<Entity_DepartmentForTree>();

        }

        public static IList<Entity_Department> GetList(int departmentId)
        {
            if (departmentId == 0)
            {
                return GetList();
            }

            string totleString = @"
SELECT * FROM [EDNF_Account_Department]
where Status='True' AND ID= @ID

";
            Command cmd = CommandManager.CreateCommand(totleString);
            cmd.SetParamter("@ID", departmentId);
            return cmd.ExecuteEntities<Entity_Department>();
        }
    }
}
