using DotNet.Framework.Admin.Entity.EDNFramework_SYS;
using DotNet.Framework.DataAccess;

namespace DotNet.Framework.Admin.Business.EDNFramework_SYS
{
    public class Business_SingleJumpAD
    {
        public static Entity_SingleJumpAD GetNormal()
        {
            string sqlString = @"
SELECT TOP 1 *
  FROM [EDNF_SYS_SingleJumpAD] WITH(NOLOCK)
";

            Command cmd = CommandManager.CreateCommand(sqlString);
            return cmd.ExecuteEntity<Entity_SingleJumpAD>();
        }

        public static int Save(Entity_SingleJumpAD entity)
        {
            string sqlString = @"
IF EXISTS (SELECT * FROM [EDNF_SYS_SingleJumpAD] WITH(NOLOCK))
BEGIN

	UPDATE TOP (1) [EDNF_SYS_SingleJumpAD]
   SET [Name] = @Name
      ,[Width] = @Width
      ,[Height] = @Height
      ,[Enable] = @Enable
      ,[ContentType] = @ContentType
      ,[Content] = @Content

END
ELSE
BEGIN
INSERT INTO [EDNF_SYS_SingleJumpAD]
           ([Name]
           ,[Width]
           ,[Height]
           ,[Enable]
           ,[ContentType]
           ,[Content])
     VALUES
           (@Name
           ,@Width
           ,@Height
           ,@Enable
           ,@ContentType
           ,@Content)
END
";
            Command cmd = CommandManager.CreateCommand(sqlString);
            cmd.SetParamter("@Name", entity.Name);
            cmd.SetParamter("@Width", entity.Width);
            cmd.SetParamter("@Height", entity.Height);
            cmd.SetParamter("@Enable", entity.Enable);
            cmd.SetParamter("@ContentType", entity.ContentType);
            cmd.SetParamter("@Content", entity.Content);
            
            return cmd.ExecuteNonQuery();
        }
    }
}
