using DotNet.Framework.Admin.Entity.EDNFramework_SYS;
using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.Business.EDNFramework_SYS
{
    public class Business_FloatAD
    {
        public static Entity_FloatAD GetNormal()
        {
            string sqlString = @"
SELECT TOP 1 *
  FROM [EDNF_SYS_FloatAD] WITH(NOLOCK)
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            return cmd.ExecuteEntity<Entity_FloatAD>();
        }

        public static int Save(Entity_FloatAD entity)
        {
            string sqlString = @"
IF EXISTS (SELECT * FROM [EDNF_SYS_FloatAD] WITH(NOLOCK))
BEGIN
	UPDATE TOP (1) [EDNF_SYS_FloatAD]
   SET [Name] = @Name
      ,[Left_Width] = @Left_Width
      ,[Left_Height] = @Left_Height
      ,[Left_left] = @Left_left
      ,[Left_top] = @Left_top
      ,[Left_Body] = @Left_Body
      ,[Left_Enable] = @Left_Enable
      ,[Right_Width] = @Right_Width
      ,[Right_Height] = @Right_Height
      ,[Right_right] = @Right_right
      ,[Right_top] = @Right_top
      ,[Right_Body] = @Right_Body
      ,[Right_Enable] = @Right_Enable
END
ELSE
BEGIN
INSERT INTO [EDNF_SYS_FloatAD]
           ([Name]
           ,[Left_Width]
           ,[Left_Height]
           ,[Left_left]
           ,[Left_top]
           ,[Left_Body]
           ,[Left_Enable]
           ,[Right_Width]
           ,[Right_Height]
           ,[Right_right]
           ,[Right_top]
           ,[Right_Body]
           ,[Right_Enable])
     VALUES
           (@Name
           ,@Left_Width
           ,@Left_Height
           ,@Left_left
           ,@Left_top
           ,@Left_Body
           ,@Left_Enable
           ,@Right_Width
           ,@Right_Height
           ,@Right_right
           ,@Right_top
           ,@Right_Body
           ,@Right_Enable)
END
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@Name", entity.Name);
            cmd.SetParamter("@Left_Width",entity.Left_Width);
            cmd.SetParamter("@Left_Height",entity.Left_Height);
            cmd.SetParamter("@Left_left",entity.Left_left);
            cmd.SetParamter("@Left_top",entity.Left_top);
            cmd.SetParamter("@Left_Body",entity.Left_Body);
            cmd.SetParamter("@Left_Enable",entity.Left_Enable);
            cmd.SetParamter("@Right_Width",entity.Right_Width);
            cmd.SetParamter("@Right_Height",entity.Right_Height);
            cmd.SetParamter("@Right_right",entity.Right_right);
            cmd.SetParamter("@Right_top",entity.Right_top);
            cmd.SetParamter("@Right_Body",entity.Right_Body);
            cmd.SetParamter("@Right_Enable",entity.Right_Enable);
            return cmd.ExecuteNonQuery();
        }
    }
}
