using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DotNet.Framework.DataAccess
{
    public class CommandTools : IBuildSqlString
    {
        /// <summary>
        /// 根据实体对象生成UPdate sql 语句，需在属性上添加数据库映射 Attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="updateCount"></param>
        /// <param name="tableName"></param>
        /// <param name="updateWhere"></param>
        /// <returns></returns>
        public string BuildeUpdateString<T>(int? updateCount, string tableName, string updateWhere)
        {
            if (!updateCount.HasValue)
            {
                updateCount = 1;
            }
            StringBuilder sbrSql = new StringBuilder();
            sbrSql.AppendFormat("UPDATE TOP ({0}) {1}", updateCount.Value, tableName);
            sbrSql.AppendLine();
            sbrSql.Append(" SET ");
            sbrSql.AppendLine();
            Type type = typeof(T);
            PropertyInfo[] Properties = type.GetProperties();
            if (Properties != null && Properties.Count() > 0)
            {
                int i = 0;
                foreach (var Prop in Properties)
                {
                    if (Prop == null)
                    {
                        continue;
                    }

                    Attribute.DataMappingAttribute attr =
                        (Attribute.DataMappingAttribute)System.Attribute.GetCustomAttribute(Prop, typeof(Attribute.DataMappingAttribute));

                    if (attr == null)
                        continue;

                    //获取当前公开属性 Attribute 标记的 Name
                    string attName = attr.ColumnName;

                    if (i > 0)
                    {
                        sbrSql.Append(",");
                    }

                    sbrSql.AppendFormat(" {0}=@{1} ", attName, attName);
                    sbrSql.AppendLine();
                    i++;
                }
            }

            if (!string.IsNullOrWhiteSpace(updateWhere))
            {
                sbrSql.Append(" " + updateWhere);
            }
            return sbrSql.ToString();
        }


        [Obsolete("次方法有Bug,若属性类型的默认值为业务数据时，次方法不能用")]
        public string BuildeUpdateString<T>(T dataSource, int? updateCount, string tableName, string updateWhere)
        {
            if (!updateCount.HasValue)
            {
                updateCount = 1;
            }
            StringBuilder sbrSql = new StringBuilder();
            sbrSql.AppendFormat("UPDATE TOP ({0}) {1}", updateCount.Value, tableName);
            sbrSql.AppendLine();
            sbrSql.Append(" SET ");
            sbrSql.AppendLine();
            Type type = typeof(T);
            PropertyInfo[] Properties = type.GetProperties();
            if (Properties != null && Properties.Count() > 0)
            {
                int i = 0;
                foreach (var Prop in Properties)
                {
                    string propName = Prop.Name;
                    if (Prop == null)
                    {
                        continue;
                    }

                    Attribute.DataMappingAttribute attr =
                        (Attribute.DataMappingAttribute)System.Attribute.GetCustomAttribute(Prop, typeof(Attribute.DataMappingAttribute));

                    if (attr == null)
                        continue;

                    //获取当前公开属性 Attribute 标记的 Name
                    string attName = attr.ColumnName;

                    System.Reflection.PropertyInfo propertyInfo = type.GetProperty(propName);
                    //获取当前公开属性的值，如果值为空，跳过本属性
                    var value = propertyInfo.GetValue(dataSource, null);
                    Type propType = Prop.PropertyType;
                    
                    if (value == null || value.Equals(null) || value.Equals(DBNull.Value) || value.Equals(string.Empty))
                    {
                        continue;
                    }

                    if (i > 0)
                    {
                        sbrSql.Append(",");
                    }

                    sbrSql.AppendFormat(" {0}=@{1} ", attName, attName);
                    sbrSql.AppendLine();
                    i++;
                }
            }

            if (!string.IsNullOrWhiteSpace(updateWhere))
            {
                sbrSql.Append(" " + updateWhere);
            }
            return sbrSql.ToString();
        }
    }
}
