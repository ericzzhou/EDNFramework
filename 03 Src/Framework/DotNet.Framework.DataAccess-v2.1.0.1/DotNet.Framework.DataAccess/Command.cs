using DotNet.Framework.DataAccess.Attribute;
using DotNet.Framework.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace DotNet.Framework.DataAccess
{
    /// <summary>
    /// Command
    /// </summary>
    public class Command : ICommand
    {
        private Utils utils = new Utils();
        /// <summary>
        /// 自定义 Connection ，DB连接相关数据实体
        /// </summary>
        private Connection __Conn { get; set; }

        /// <summary>
        /// 参数列表
        /// </summary>
        private IList<ParameterItem> parameters;

        /// <summary>
        /// 数据连接池  SqlConnection
        /// </summary>
        private SqlConnection _conn;
        private SqlCommand _cmd;

        #region 构造函数
        private Command() { }
        internal Command(Connection conn)
        {
            this.__Conn = conn;

            if (parameters == null)
            {
                parameters = new List<ParameterItem>();
            }
        }
        #endregion

        #region 参数设置
        /// <summary>
        /// 设置输出参数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        public void SetOutParameter(string name, DbType dbType, int? size)
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
        #endregion

        #region 获取输出参数返回值
        /// <summary>
        /// 获取输出参数返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetOutParameter<T>(string name)
        {
            return (T)Convert.ChangeType(this._cmd.Parameters[name].Value, typeof(T));
        }
        #endregion

        #region 执行 ExecuteNonQuery(),返回受影响的函数
        /// <summary>
        /// 执行 ExecuteNonQuery(),返回受影响的函数
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQuery()
        {
            int rows = 0;
            try
            {
                this.OpenConn();
                this.CreateSqlCommand();
                utils.AppendParamters(this._cmd, parameters);

                rows = this._cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(utils.BuilderSqlError(this.__Conn, ex));
            }
            finally
            {
                this.CloseConn();
                this.DisposeConn();
            }
            return rows;
        }
        #endregion

        #region 执行 ExecuteScalar，返回第一行第一列
        /// <summary>
        /// 执行 ExecuteScalar，返回第一行第一列
        /// </summary>
        /// <returns></returns>
        public object ExecuteSingle()
        {
            object obj;
            try
            {
                this.OpenConn();
                this.CreateSqlCommand();
                utils.AppendParamters(this._cmd, parameters);
                obj = this._cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(utils.BuilderSqlError(this.__Conn, ex));
            }
            finally
            {
                this.CloseConn();
                this.DisposeConn();
            }
            return obj;
        }

        /// <summary>
        /// 执行 ExecuteScalar，返回第一行第一列并转换为 T 类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ExecuteSingle<T>()
        {
            object obj = ExecuteSingle();
            if (obj == null)
            {
                return default(T);
            }
            return (T)(Convert.ChangeType(obj, typeof(T)));
        }
        #endregion

        #region 执行sql语句，返回 DataReader
        /// <summary>
        /// 执行sql语句，返回 DataReader
        /// </summary>
        /// <returns></returns>
        public IDataReader ExecuteDataReader()
        {
            IDataReader reader;
            try
            {
                this.OpenConn();
                this.CreateSqlCommand();
                utils.AppendParamters(this._cmd, parameters);
                reader = this._cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception(utils.BuilderSqlError(this.__Conn, ex));
            }
            return reader;
        }
        #endregion

        #region 执行sql语句，返回DataSet
        /// <summary>
        /// 执行sql语句，返回DataSet
        /// </summary>
        /// <returns></returns>
        public DataSet ExecuteDataSet()
        {
            DataSet ds;
            try
            {
                this.OpenConn();
                this.CreateSqlCommand();
                utils.AppendParamters(this._cmd, parameters);
                using (SqlDataAdapter da = new SqlDataAdapter(this._cmd))
                {
                    ds = new DataSet();
                    da.Fill(ds, "ds");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(utils.BuilderSqlError(this.__Conn, ex));
            }
            finally
            {
                this.CloseConn();
                this.DisposeConn();
            }
            return ds;
        }
        #endregion

        #region 执行sql语句，返回数据实体
        /// <summary>
        /// 执行sql语句，返回数据实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ExecuteEntity<T>()
        {
            DataSet ds = ExecuteDataSet();
            return utils.ExecuteEntity<T>(ds);
        }

        /// <summary>
        /// 执行sql语句，返回数据实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ExecuteEntityByDataReader<T>()
        {
            return utils.ExecuteEntityByDataReader<T>(ExecuteDataReader());
        }

        /// <summary>
        /// 执行sql语句，返回数据实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IList<T> ExecuteEntities<T>()
        {
            DataSet ds = ExecuteDataSet();
            return utils.ExecuteEntities<T>(ds);
        }

        /// <summary>
        /// 执行sql语句，DataReader返回的List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IList<T> ExecuteEntitiesByDataReader<T>()
        {
            return utils.ExecuteEntitiesByDataReader<T>(ExecuteDataReader());
        }
        #endregion

        #region 私有方法
        #region 连接池 打开/关闭/销毁
        private void OpenConn()
        {
            if (_conn == null)
            {
                _conn = new SqlConnection(__Conn.ConnectionString);
                _conn.Open();
            }
            else
            {
                switch (_conn.State)
                {
                    case ConnectionState.Broken:
                        _conn.Close();
                        _conn.Open();
                        break;
                    case ConnectionState.Closed:
                        _conn.Open();
                        break;
                    case ConnectionState.Connecting:
                        break;
                    case ConnectionState.Executing:
                        break;
                    case ConnectionState.Fetching:
                        break;
                    case ConnectionState.Open:
                        break;
                    default:
                        break;
                }
            }
        }
        private void CloseConn()
        {
            if (_conn != null)
            {
                if (this._conn.State != ConnectionState.Closed)
                {
                    _conn.Close();
                }
            }
        }
        private void DisposeConn()
        {
            if (_conn != null)
            {
                switch (this._conn.State)
                {
                    case ConnectionState.Open:
                    case ConnectionState.Broken:
                    case ConnectionState.Connecting:
                    case ConnectionState.Executing:
                    case ConnectionState.Fetching:
                        _conn.Close();
                        break;
                    case ConnectionState.Closed:
                    default:
                        break;
                }
                _conn.Dispose();
                _conn = null;
            }
        }
        private void CreateSqlCommand()
        {
            if (this._cmd == null)
            {
                this._cmd = new SqlCommand(this.__Conn.SqlString, this._conn);
            }
        }
        #endregion
        #endregion








    }
}
