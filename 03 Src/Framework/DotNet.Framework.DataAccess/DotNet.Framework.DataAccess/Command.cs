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
    public class Command : ICommand
    {
        private Connection __Conn { get; set; }
        Dictionary<string, object> parameters;

        private Command() { }

        internal Command(Connection conn)
        {
            this.__Conn = conn;

            if (parameters == null)
                parameters = new Dictionary<string, object>();
        }

        public void SetParamter(string key, object value)
        {
            if (value == null)
            {
                value = DBNull.Value;
            }

            else if (value.ToString() == default(DateTime).ToString())
            {
                value = DBNull.Value;
            }
            parameters.Add(key, value);
        }

        public int ExecuteNonQuery()
        {
            using (SqlConnection connection = new SqlConnection(__Conn.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(__Conn.SqlString, connection))
                {
                    try
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }

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
        }

        public T ExecuteSingle<T>()
        {
            using (SqlConnection connection = new SqlConnection(__Conn.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(__Conn.SqlString, connection))
                {
                    try
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        return (T)(Convert.ChangeType(obj, typeof(T)));
                        //return (T)cmd.ExecuteScalar();
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
        }

        public object ExecuteSingle()
        {
            using (SqlConnection connection = new SqlConnection(__Conn.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(__Conn.SqlString, connection))
                {
                    try
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
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
        }

        public T ExecuteEntity<T>()
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(__Conn.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(__Conn.SqlString, connection))
                {
                    try
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
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
                return default(T);
            }

            Type type = typeof(T);
            PropertyInfo[] Properties = type.GetProperties();
            object obj = Activator.CreateInstance(type, true);
            if (Properties != null && Properties.Count() > 0)
            {
                foreach (var item in Properties)
                {
                    //if (System.Attribute.IsDefined(item, type))
                    //{
                    //}
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

                    //item.SetValue(item, value, null);
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
            DataSet ds = new DataSet();

            #region 读取数据到 DataSet
            using (SqlConnection connection = new SqlConnection(__Conn.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(__Conn.SqlString, connection))
                {
                    try
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
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
            #endregion

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
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(__Conn.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(__Conn.SqlString, connection))
                {
                    try
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
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
        }
    }
}
