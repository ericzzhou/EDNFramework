using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DotNet.Framework.DataAccess.Attribute
{
    internal class DataMappingCache
    {
        /// <summary>
        /// Single Model
        /// </summary>
        private readonly static DataMappingCache CACHE = new DataMappingCache();
        private Dictionary<Type, Dictionary<DataMappingAttribute, PropertyInfo>> m_Mapping;
        private DataMappingCache()
        {
            m_Mapping = new Dictionary<Type, Dictionary<DataMappingAttribute, PropertyInfo>>(10);
        }

        /// <summary>
        /// 返回当前实例
        /// </summary>
        internal static DataMappingCache Current
        {
            get
            {
                return CACHE;
            }
        }

        /// <summary>
        /// Get DataMapping & PropertyInfo 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal Dictionary<DataMappingAttribute, PropertyInfo> this[Type type]
        {
            get
            {
                return this.Get(type);
            }
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="type">类型</param>
        internal void Add(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (this.m_Mapping.ContainsKey(type))
            {
                return;
            }
            Dictionary<DataMappingAttribute, PropertyInfo> mapping = Reflect(type);

            if (!this.m_Mapping.ContainsKey(type))
            {
                this.m_Mapping[type] = mapping;
            }

        }

        /// <summary>
        /// Get DataMapping & PropertyInfo 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal Dictionary<DataMappingAttribute, PropertyInfo> Get(Type type)
        {
            Dictionary<DataMappingAttribute, PropertyInfo> mapping = null;

            if (this.m_Mapping.ContainsKey(type))
            {
                mapping = new Dictionary<DataMappingAttribute, PropertyInfo>(this.m_Mapping[type]);
                return mapping;
            }

            this.Add(type);

            mapping = new Dictionary<DataMappingAttribute, PropertyInfo>(this.m_Mapping[type]);

            return mapping;
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="type"></param>
        internal void Remove(Type type)
        {
            this.m_Mapping.Remove(type);
        }

        /// <summary>
        /// 反射类型中的DataMapping属性
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private Dictionary<DataMappingAttribute, PropertyInfo> Reflect(Type type)
        {
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Dictionary<DataMappingAttribute, PropertyInfo> mapping = new Dictionary<DataMappingAttribute, PropertyInfo>(properties.Length);
            PropertyInfo property = null;
            for (int i = 0; i < properties.Length; i++)
            {
                property = properties[i];
                DataMappingAttribute attr = GetDataMapping(property);
                if (attr != null)
                {
                    mapping[attr] = property;
                }
            }

            return mapping;
        }

        /// <summary>
        /// 获取属性上的属性类
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private DataMappingAttribute GetDataMapping(PropertyInfo property)
        {
            DataMappingAttribute attr = (DataMappingAttribute)System.Attribute.GetCustomAttribute(property, typeof(DataMappingAttribute));
            return attr;
        }
    }
}
