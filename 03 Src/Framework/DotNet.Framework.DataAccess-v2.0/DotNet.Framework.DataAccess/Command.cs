using DotNet.Framework.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace DotNet.Framework.DataAccess
{
    public class Command : ICommand
    {
        private Connection __Conn { get; set; }
        private IList<ParameterItem> parameters;
        private Command() { }

        private object outputParamterValue = null;
        internal Command(Connection conn)
        {
            this.__Conn = conn;

            if (parameters == null)
            {
                parameters = new List<ParameterItem>();
            }
        }

        public object GetOutParamter(string name, DbType dbType)
        {
            return outputParamterValue;
        }

       
        /// <summary>
        /// 设置输出参数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        public void AddOutParameter(string name, DbType dbType, int? size)
        {
            parameters.Add(new ParameterItem()
            {
                ParameterName = name,
                Direction = ParameterDirection.Output,
                DbType = dbType,
                Size = size
            });
        }
        /// <summary>
        /// 设置输入参数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetParamter(string name, object value)
        {
            if (value == null)
            {
                value = DBNull.Value;
            }

            else if (value.ToString() == default(DateTime).ToString())
            {
                value = DBNull.Value;
            }
            parameters.Add(new ParameterItem()
            {
                ParameterName = name,
                ParameterValue = value
            });
        }
        /// <summary>
        /// 设置替换参数（需要先检查sql安全性）
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetReplaceParamter(string name, string value)
        {
            __Conn.SqlString =
                !string.IsNullOrWhiteSpace(__Conn.SqlString)
                && __Conn.SqlString.Contains(name)
                ? __Conn.SqlString.Replace(name, value)
                : __Conn.SqlString;
            //if (!string.IsNullOrWhiteSpace(__Conn.SqlString) && __Conn.SqlString.Contains(key))
            //{
            //    __Conn.SqlString = __Conn.SqlString.Replace(key, value);
            //}
        }

        private void SetParamters(SqlCommand cmd)
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
                    outputParamterValue = cmd.Parameters[item.ParameterName].Value;
                }
                cmd.Parameters.Add(param);

            }
        }

        /// <summary>
        /// 执行 ExecuteNonQuery(),返回受影响的函数
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQuery()
        {
            return Retry<int>(delegate
            {
                using (SqlConnection connection = new SqlConnection(__Conn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(__Conn.SqlString, connection))
                    {
                        try
                        {
                            SetParamters(cmd);
                            connection.Open();
                            int rows = cmd.ExecuteNonQuery();
                            return rows;
                        }
                        catch (System.Data.SqlClient.SqlException e)
                        {
                            throw e;
                        }
                        finally
                        {
                            cmd.Dispose();
                            connection.Close();
                        }
                    }
                }
            });
        }


        /// <summary>
        /// 执行 ExecuteScalar，返回第一行第一列并转换为 T 类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ExecuteSingle<T>()
        {
            object obj = ExecuteSingle();
            return (T)(Convert.ChangeType(obj, typeof(T)));
        }

        /// <summary>
        /// 执行 ExecuteScalar，返回第一行第一列
        /// </summary>
        /// <returns></returns>
        public object ExecuteSingle()
        {
            return Retry<object>(delegate
            {
                using (SqlConnection connection = new SqlConnection(__Conn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(__Conn.SqlString, connection))
                    {
                        try
                        {
                            SetParamters(cmd);
                            connection.Open();
                            return cmd.ExecuteScalar();
                        }
                        catch (System.Data.SqlClient.SqlException e)
                        {
                            throw e;
                        }
                        finally
                        {
                            cmd.Dispose();
                            connection.Close();
                        }
                    }
                }
            });
        }

        public T ExecuteEntity<T>()
        {
            DataSet ds = ExecuteDataSet();
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

            Type type = typeof(T);
            PropertyInfo[] Properties = type.GetProperties();
            object obj = Activator.CreateInstance(type, true);
            if (Properties != null && Properties.Count() > 0)
            {
                foreach (var item in Properties)
                {
                    Attribute.DataMappingAttribute attr =
                        (Attribute.DataMappingAttribute)System.Attribute.GetCustomAttribute(item, typeof(Attribute.DataMappingAttribute));

                    if (attr == null)
                        continue;

                    //获取当前公开属性 Attribute 标记的 Name
                    string attName = attr.ColumnName;

                    DataColumn dtColumns = dt.Columns[attName];

                    object value;
                    if (dtColumns == null)
                        continue;

                    else
                    {
                        value = dt.Rows[0][dtColumns];
                        if (value.GetType() == typeof(DBNull))
                            continue;
                        else
                        {
                            //if (value.GetType() == typeof(string))
                            //    value = DotNet.Framework.Utils.Web.XssHelper.HtmlEncode(value.ToString().Trim());
                        }
                    }

                    if (item.PropertyType.ToString().StartsWith("System.Nullable`1["))
                    {
                        Type convertType;
                        NullableConverter nullableConverter = new NullableConverter(item.PropertyType);
                        convertType = nullableConverter.UnderlyingType;
                        item.SetValue(obj,
                         Convert.ChangeType(value, convertType)
                         , null);
                    }
                    else
                    {
                        item.SetValue(obj,
                            Convert.ChangeType(value, item.PropertyType)
                            , null);
                    }
                }
            }

            return (T)obj;
        }

        public IList<T> ExecuteEntities<T>()
        {
            DataSet ds = ExecuteDataSet();

            #region 处理数据
            DataTable dt = new DataTable();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dt.Clear();
                dt = ds.Tables[0];
            }

            //ds.Clear();
            //ds.Dispose();

            if (dt == null || dt.Columns.Count <= 0)
            {
                return null;
            }
            #endregion

            Type type = typeof(T);
            PropertyInfo[] Properties = type.GetProperties();

            IList<T> returnList = new List<T>();
            if (Properties != null && Properties.Count() > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    object obj = Activator.CreateInstance(type, true);
                    foreach (var item in Properties)
                    {
                        Attribute.DataMappingAttribute attr =
                            (Attribute.DataMappingAttribute)System.Attribute.GetCustomAttribute(item, typeof(Attribute.DataMappingAttribute));

                        if (attr == null)
                            continue;

                        //获取当前公开属性 Attribute 标记的 Name
                        string attName = attr.ColumnName;

                        DataColumn dtColumns = dt.Columns[attName];

                        object value;
                        if (dtColumns == null)
                            continue;

                        else
                        {
                            value = dt.Rows[i][dtColumns];

                            if (value.GetType() == typeof(DBNull))
                                continue;

                            else
                            {
                                //if (value.GetType() == typeof(string))
                                //    value = DotNet.Framework.Utils.Web.XssHelper.HtmlEncode(value.ToString().Trim());
                            }
                        }

                        //var value = dt.Rows[i][dtColumns];
                        if (item.PropertyType.ToString().StartsWith("System.Nullable`1["))
                        {
                            Type convertType;
                            NullableConverter nullableConverter = new NullableConverter(item.PropertyType);
                            convertType = nullableConverter.UnderlyingType;

                            item.SetValue(obj,
                             Convert.ChangeType(value, convertType)
                             , null);
                        }
                        else
                        {
                            item.SetValue(obj,
                                Convert.ChangeType(value, item.PropertyType)
                                , null);
                        }
                    }

                    returnList.Add((T)obj);

                }
            }

            if (returnList.Count > 0)
                return returnList;
            else
                return null;
        }




        public DataSet ExecuteDataSet()
        {
            return Retry<DataSet>(delegate
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(__Conn.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(__Conn.SqlString, connection))
                    {
                        try
                        {
                            SetParamters(cmd);
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(ds, "ds");
                                cmd.Parameters.Clear();
                            }
                        }
                        catch (System.Data.SqlClient.SqlException ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                return ds;
            });
        }

        private T Retry<T>(RetryHandler<T> function)
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

        private delegate T RetryHandler<T>();
    }
}
