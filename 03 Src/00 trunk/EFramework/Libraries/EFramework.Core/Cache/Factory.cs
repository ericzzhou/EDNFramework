using System;
using System.Configuration;
using System.IO;

namespace EFramework.Core.Cache
{
    public static class Factory
    {
        private static object _locker = new object();//锁对象
        private static ICacheStrategy _cachestrategy = null;//缓存策略

        static Factory()
        {
            Load();
        }

        /// <summary>
        /// 加载缓存策略
        /// </summary>
        private static void Load()
        {
            try
            {
                _cachestrategy = (ICacheStrategy)Activator.CreateInstance(
                    Type.GetType(ConfigurationManager.AppSettings["CacheStrategy"],
                    false
                    , true));
            }
            catch
            {
                throw new Exception(Resource.FormatStrategyError("缓存", "CacheStrategy"));                
            }
        }

        /// <summary>
        /// 缓存过期时间
        /// </summary>
        public static int TimeOut
        {
            get
            {
                return _cachestrategy.TimeOut;
            }
            set
            {
                lock (_locker)
                {
                    _cachestrategy.TimeOut = value;
                }
            }
        }

        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        public static object Get(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return null;
            return _cachestrategy.Get(key);
        }

        /// <summary>
        /// 将指定键的对象添加到缓存中
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        public static void Insert(string key, object data)
        {
            if (string.IsNullOrWhiteSpace(key) || data == null)
                return;
            lock (_locker)
            {
                _cachestrategy.Insert(key, data);
            }
        }

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间</param>
        public static void Insert(string key, object data, int cacheTime)
        {
            if (string.IsNullOrWhiteSpace(key) || data == null)
                return;
            lock (_locker)
            {
                _cachestrategy.Insert(key, data, cacheTime);
            }
        }

        /// <summary>
        /// 从缓存中移除指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        public static void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            lock (_locker)
            {
                _cachestrategy.Remove(key);
            }
        }

        /// <summary>
        /// 清空缓存所有对象
        /// </summary>
        public static void Clear()
        {
            lock (_locker)
            {
                _cachestrategy.Clear();
            }
        }
    }
}
