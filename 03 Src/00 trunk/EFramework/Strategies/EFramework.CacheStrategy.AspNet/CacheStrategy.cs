using EFramework.Core.Cache;
using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace EFramework.CacheStrategy.AspNet
{
    public class CacheStrategy : ICacheStrategy
    {
        private Cache _cache;

        public CacheStrategy()
        {
            _cache = HttpRuntime.Cache;
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void Clear()
        {
            IDictionaryEnumerator cacheEnum = _cache.GetEnumerator();
            while (cacheEnum.MoveNext())
                _cache.Remove(cacheEnum.Key.ToString());
        }

        public void Insert(string key, object data)
        {
            _cache.Insert(key, data, null, DateTime.Now.AddSeconds(_timeout), Cache.NoSlidingExpiration, CacheItemPriority.High, null);

        }

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="cacheTime"></param>
        public void Insert(string key, object data, int cacheTime)
        {
            _cache.Insert(key, data, null, DateTime.Now.AddSeconds(cacheTime), Cache.NoSlidingExpiration, CacheItemPriority.High, null);

        }

        private int _timeout = 3600;//单位秒
        public int TimeOut
        {
            get
            {
                return _timeout;
            }
            set
            {
                _timeout = value > 0 ? value : 3600;
            }
        }
    }
}
