using System;
using System.Web.Mvc;

namespace DotNet.Framework.MVC.Extend.Extends
{
    public static class DB
    {
        /// <summary>
        /// 获取指定TableName指定ColumnName
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper"></param>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static T EDNFHelper_GetDBValue<T>(this HtmlHelper helper, string tableName, string columnName, string strWhere)
        {
            object obj = Business.Business_DB.GetDBValue(tableName, columnName, strWhere);
            return (T)Convert.ChangeType(obj, typeof(T));
        }
    }
}
