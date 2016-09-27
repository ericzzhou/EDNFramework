using DotNet.Framework.DataAccess.Attribute;
using DotNet.Framework.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DotNet.Framework.DataAccess
{
    internal class Utils
    {
        public Dictionary<DataMappingAttribute, PropertyInfo> Reflect(Type type)
        {
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Dictionary<DataMappingAttribute, PropertyInfo> mapping = new Dictionary<DataMappingAttribute, PropertyInfo>();
            foreach (PropertyInfo property in properties)
            {
                DataMappingAttribute attr = GetDataMapping(property);
                if (attr != null && !mapping.ContainsKey(attr))
                {
                    mapping[attr] = property;
                }
            }
            return mapping;
        }

        /// <summary>
        /// 应用参数到SqlCommand上
        /// </summary>
        /// <param name="cmd"></param>
        public void AppendParamters(SqlCommand cmd, IList<ParameterItem> parameters)
        {
            foreach (var item in parameters)
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = item.ParameterName;
                param.Value = item.ParameterValue;
                param.Direction = item.Direction;
                if (item.DbType.HasValue)
                {
                    param.DbType = item.DbType.Value;
                    if (item.Size.HasValue)
                    {
                        param.Size = item.Size.Value;
                    }
                    //outputParamterValue = cmd.Parameters[item.ParameterName].Value;
                }
                cmd.Parameters.Add(param);

            }
        }

        /// <summary>
        /// 执行sql语句，返回数据实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ExecuteEntity<T>(DataSet ds)
        {
            //DataSet ds = ExecuteDataSet();
            if (ds == null)
            {
                return default(T);
            }
            DataTable dt = new DataTable();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dt.Clear();
                dt = ds.Tables[0];
            }

            if (dt == null || dt.Columns.Count <= 0)
            {
                return default(T);
            }

            return BuilderEntity<T>(dt.Rows[0]);
        }

        /// <summary>
        /// 执行sql语句，返回数据实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IList<T> ExecuteEntities<T>(DataSet ds)
        {
            //DataSet ds = ExecuteDataSet();
            //List<T> tbs = FastReflection.ClassGetSet.GetList<T>(ds.Tables[0]);
            //return tbs;
            if (ds == null)
            {
                return null;
            }
            #region 处理数据
            DataTable dt = new DataTable();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dt.Clear();
                dt = ds.Tables[0];
            }

            if (dt == null || dt.Columns.Count <= 0)
            {
                return null;
            }
            #endregion

            IList<T> list = new List<T>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                T t = BuilderEntity<T>(dt.Rows[i]);
                list.Add(t);
            }

            if (list.Count > 0)
                return list;
            else
                return null;
        }

        #region 构建Entity
        #region 已废弃
        //private T BuilderEntity<T>(IDataReader reader)
        //{
        //    Type type = typeof(T);
        //    PropertyInfo[] Properties = GetProperties(type);
        //    object obj = Activator.CreateInstance(type, true);
        //    if (Properties != null && Properties.Count() > 0)
        //    {
        //        foreach (PropertyInfo property in Properties)
        //        {
        //            DataMappingAttribute attr = GetDataMapping(property);

        //            if (attr == null)
        //                continue;

        //            //获取当前公开属性 Attribute 标记的 Name
        //            string attName = attr.ColumnName;
        //            object drData = reader[attName];
        //            if (drData == null)
        //            {
        //                continue;
        //            }

        //            object value = drData;
        //            if (value.GetType() == typeof(DBNull))
        //                continue;
        //            else
        //            {
        //                //if (value.GetType() == typeof(string))
        //                //    value = DotNet.Framework.Utils.Web.XssHelper.HtmlEncode(value.ToString().Trim());
        //            }

        //            if (property.PropertyType.ToString().StartsWith("System.Nullable`1["))
        //            {
        //                Type convertType;
        //                NullableConverter nullableConverter = new NullableConverter(property.PropertyType);
        //                convertType = nullableConverter.UnderlyingType;
        //                property.SetValue(obj,
        //                 Convert.ChangeType(value, convertType)
        //                 , null);
        //            }
        //            else
        //            {
        //                property.SetValue(obj,
        //                    Convert.ChangeType(value, property.PropertyType)
        //                    , null);
        //            }
        //        }
        //    }

        //    return (T)(Convert.ChangeType(obj, type));
        //    //return (T)obj;
        //}

        //private T BuilderEntity<T>(DataRow dr)
        //{
        //    Type type = typeof(T);
        //    PropertyInfo[] Properties = GetProperties(type);
        //    object obj = Activator.CreateInstance(type, true);
        //    if (Properties != null && Properties.Count() > 0)
        //    {
        //        foreach (PropertyInfo property in Properties)
        //        {
        //            DataMappingAttribute attr = GetDataMapping(property);

        //            if (attr == null)
        //                continue;

        //            //获取当前公开属性 Attribute 标记的 Name
        //            string attName = attr.ColumnName;
        //            object drData = dr[attName];
        //            if (drData == null)
        //            {
        //                continue;
        //            }

        //            object value = drData;
        //            if (value.GetType() == typeof(DBNull))
        //                continue;
        //            else
        //            {
        //                //if (value.GetType() == typeof(string))
        //                //    value = DotNet.Framework.Utils.Web.XssHelper.HtmlEncode(value.ToString().Trim());
        //            }

        //            if (property.PropertyType.ToString().StartsWith("System.Nullable`1["))
        //            {
        //                Type convertType;
        //                NullableConverter nullableConverter = new NullableConverter(property.PropertyType);
        //                convertType = nullableConverter.UnderlyingType;
        //                property.SetValue(obj,
        //                 Convert.ChangeType(value, convertType)
        //                 , null);
        //            }
        //            else
        //            {
        //                property.SetValue(obj,
        //                    Convert.ChangeType(value, property.PropertyType)
        //                    , null);
        //            }
        //        }
        //    }
        //    return (T)(Convert.ChangeType(obj, type));
        //    //return (T)obj;
        //}
        #endregion
        private T BuilderEntity<T>(DataRow dr)
        {
            Type type = typeof(T);
            object obj = Activator.CreateInstance(type, true);
            Dictionary<DataMappingAttribute, PropertyInfo> mapping = Reflect(type);
            if (mapping == null)
            {
                return default(T);
            }
            foreach (KeyValuePair<DataMappingAttribute, PropertyInfo> map in mapping)
            {
                DataMappingAttribute attr = map.Key;
                PropertyInfo property = map.Value;

                string columnName = attr.ColumnName;
                if (!dr.Table.Columns.Contains(columnName))
                {
                    continue;
                }
                object drData = dr[columnName];
                if (drData == null || drData.GetType() == typeof(DBNull))
                {
                    continue;
                }

                if (property.PropertyType.ToString().StartsWith("System.Nullable`1["))
                {
                    Type convertType;
                    NullableConverter nullableConverter = new NullableConverter(property.PropertyType);
                    convertType = nullableConverter.UnderlyingType;
                    property.SetValue(obj,
                     Convert.ChangeType(drData, convertType)
                     , null);
                }
                else
                {
                    property.SetValue(obj,
                        Convert.ChangeType(drData, property.PropertyType)
                        , null);
                }
            }
            return (T)(Convert.ChangeType(obj, type));
            //return (T)obj;
        }
        public T BuilderEntity<T>(IDataReader reader)
        {
            Type type = typeof(T);
            object obj = Activator.CreateInstance(type, true);
            Dictionary<DataMappingAttribute, PropertyInfo> mapping = Reflect(type);
            if (mapping == null)
            {
                return default(T);
            }
            foreach (KeyValuePair<DataMappingAttribute, PropertyInfo> map in mapping)
            {
                DataMappingAttribute attr = map.Key;
                PropertyInfo property = map.Value;
                string columnName = attr.ColumnName;

                reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName= '" + columnName + "'";
                if (reader.GetSchemaTable().DefaultView.Count <= 0)
                {
                    continue;
                }

                object drData = reader[columnName];
                if (drData == null || drData.GetType() == typeof(DBNull))
                {
                    continue;
                }
                if (property.PropertyType.ToString().StartsWith("System.Nullable`1["))
                {
                    Type convertType;
                    NullableConverter nullableConverter = new NullableConverter(property.PropertyType);
                    convertType = nullableConverter.UnderlyingType;
                    property.SetValue(obj,
                     Convert.ChangeType(drData, convertType)
                     , null);
                }
                else
                {
                    property.SetValue(obj,
                        Convert.ChangeType(drData, property.PropertyType)
                        , null);
                }
            }


            return (T)(Convert.ChangeType(obj, type));
            //return (T)obj;
        }


        #endregion
        /// <summary>
        /// 生成异常信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public string BuilderSqlError(Connection conn, Exception ex)
        {
            StringBuilder sbrError = new StringBuilder();
            sbrError.AppendLine(ex.Message);
            //sbrError.AppendLine(conn.SqlString);
            return sbrError.ToString();
        }

        /// <summary>
        /// 获取类型的公开属性
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal PropertyInfo[] GetProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
        /// <summary>
        /// 获取属性上的属性类
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        internal DataMappingAttribute GetDataMapping(PropertyInfo property)
        {
            DataMappingAttribute attr = (DataMappingAttribute)System.Attribute.GetCustomAttribute(property, typeof(Attribute.DataMappingAttribute));
            return attr;
        }


        #region Retry 机制
        internal delegate T RetryHandler<T>();
        /// <summary>
        /// Retry 机制
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="function"></param>
        /// <returns></returns>
        internal T Retry<T>(RetryHandler<T> function)
        {
            if (function == null)
            {
                throw new ArgumentNullException("function can not be null.");
            }

            int retryTimes = 5;
            double intervalSeconds = 0.1;

            // 10054 为下面这个异常的 Number。
            // A transport-level error has occurred when sending the request
            // to the server. (provider: TCP Provider, error: 0 - An existing
            // connection was forcibly closed by the remote host.)

            //10053 An established connection was aborted by the software in your host machine. 

            T t = default(T);

            for (int i = 0; i < retryTimes; i++)
            {
                try
                {
                    t = function();
                    break;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 10054 || ex.Number == 10053)
                    {
                        if (i == retryTimes - 1)
                        {
                            throw;
                        }
                        else
                        {
                            SqlConnection.ClearAllPools();
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(intervalSeconds));
                        }
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return t;
        }
        #endregion

        internal T ExecuteEntityByDataReader<T>(IDataReader dataReader)
        {
            T t = default(T);
            using (IDataReader reader = dataReader)
            {
                while (reader.Read())
                {
                    t = BuilderEntity<T>(reader);
                }
            }
            return t;
        }

        internal IList<T> ExecuteEntitiesByDataReader<T>(IDataReader dataReader)
        {
            IList<T> list = new List<T>();
            using (SqlDataReader reader = (SqlDataReader)dataReader)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        T t = BuilderEntity<T>(reader);
                        list.Add(t);
                    }
                }
            }
            if (list.Count > 0)
                return list;
            else
                return null;
        }
    }
}
