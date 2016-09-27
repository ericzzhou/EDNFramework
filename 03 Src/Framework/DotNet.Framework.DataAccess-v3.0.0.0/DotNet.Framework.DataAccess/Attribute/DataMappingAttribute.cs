using System;
using System.Data;

namespace DotNet.Framework.DataAccess.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataMappingAttribute : System.Attribute
    {
        /// <summary>
        /// 属性名(数据库列名)
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public DbType DbType { get; set; }
        //public int? Length { get; set; }

        public DataMappingAttribute(string ColumnName)
        {
            this.ColumnName = ColumnName;
        }

        public DataMappingAttribute(string ColumnName, DbType DbType)
        {
            this.ColumnName = ColumnName;
            this.DbType = DbType;
        }
    }

}
