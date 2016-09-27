using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.MVC.Extend.Business
{
    public class Business_DB
    {
        public static object GetDBValue(string tableName, string columnName, string strWhere)
        {
            string sqlStr = "SELECT TOP 1 #columnName# FROM #tableName# WITH(NOLCOK) WHERE 1=1 #strWhere#";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetReplaceParamter("#columnName#", columnName);
            cmd.SetReplaceParamter("#tableName#", tableName);
            cmd.SetReplaceParamter("#strWhere#", strWhere);
            return cmd.ExecuteSingle();
        }
    }
}
