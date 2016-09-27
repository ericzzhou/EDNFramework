using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.Business.EDNFramework_Account
{
    public class Business_RolePermissionsAction
    {
        public static IList<Entity_RolePermissionsAction> GetList(ViewQueryCondition<Entity_RolePermissionsAction> query)
        {
            PagingResult<IList<Entity_RolePermissionsAction>> result = new PagingResult<IList<Entity_RolePermissionsAction>>();
            string sqlStr = @"
SELECT  *
FROM EDNF_Account_RolePermissionsAction WITH (NOLOCK )
    WHERE 1=1 
#strWhere#
";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            string where = "";
            if (query.Condition.ARPID != null && query.Condition.ARPID != Guid.Empty)
            {
                where += " AND ARPID = @ARPID ";
            }
            if (!string.IsNullOrWhiteSpace(query.Condition.ActionCode))
            {
                where += " AND ActionCode = @ActionCode ";
            }
            if (query.Condition.ARPAID != null && query.Condition.ARPAID != Guid.Empty)
            {
                where += " AND ARPAID = @ARPAID ";
            }

            cmd.SetReplaceParamter("#strWhere#", where);

            cmd.SetParamter("@ARPID", query.Condition.ARPID);
            cmd.SetParamter("@ActionCode", query.Condition.ActionCode);
            cmd.SetParamter("@ARPAID", query.Condition.ARPAID);
            return cmd.ExecuteEntities<Entity_RolePermissionsAction>();
        }

        public static bool Refresh(IList<Entity_RolePermissionsAction> entities)
        {
            StringBuilder sbrSql = new StringBuilder();
            //去重后取出本次涉及的ARPID
            List<Guid> deletes = entities.Select(x => x.ARPID).Distinct().ToList();
            //删除涉及到的ARPID下的所有按钮权限
            if (deletes != null && deletes.Count > 0)
            {
                foreach (var item in deletes)
                {
                    sbrSql.AppendFormat("DELETE FROM [EDNF_Account_RolePermissionsAction] WHERE RoleID='{0}' ", entities.Select(x => x.RoleID).First());
                }
            }
            //构造需要重新赋予的权限按钮
            foreach (var item in entities)
            {
                if (item.ARPID != null && item.ARPID != Guid.Empty)
                {
                    sbrSql.AppendFormat(@"
INSERT INTO [EDNF_Account_RolePermissionsAction]
           ([ARPAID]
           ,[ARPID]
           ,[ActionCode]
           ,[RoleID])
     VALUES
           (NEWID()
           ,'{0}'
           ,'{1}'
           ,{2})"
                        , item.ARPID, item.ActionCode, item.RoleID);
                }


            }
            if (sbrSql == null || sbrSql.Length <= 0)
            {
                return false;
            }
            Command cmd = CommandManager.CreateCommand(sbrSql.ToString());
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
