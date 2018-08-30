using Microsoft.Extensions.Caching.Memory;
using System;

namespace ViCore.Caching
{
    public class CacheManager
    {        
        static MemoryCache cache = new MemoryCache(new MemoryCacheOptions());
        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetCache(string key)
        {
            object val = null;
            if (cache.TryGetValue(key, out val))
            {
                return val;
            }
            else
            {
                return null;
            }
        }

        public static T GetCache<T>(string key) where T : class
        {
            object val = null;
            if (cache.TryGetValue(key, out val))
            {
                return val as T;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 添加缓存内容
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime">秒</param>
        public static void SetChache(string key, object value, int expireTime)
        {
            cache.Set(key, value, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromSeconds(expireTime)
            });
        }

        /// <summary>
        /// 清除缓存
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveChache(string key)
        {
            cache.Remove(key);
        }
    }
}