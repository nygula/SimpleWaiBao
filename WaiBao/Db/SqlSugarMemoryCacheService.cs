using Microsoft.Extensions.Caching.Memory;
using SqlSugar;
using System.Collections;
using System.Reflection;

namespace WaiBao
{

    /// <summary>
    /// 实现SqlSugar的ICacheService接口，为了让SqlSugar直接支持简单缓存操作。
    /// </summary>
    public class SqlSugarMemoryCacheService : ICacheService //继承空类BaseService，会统一Ioc注册
    {
        protected IMemoryCache _memoryCache;
        public SqlSugarMemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public void Add<V>(string key, V value)
        {
            _memoryCache.Set(key, value);
        }
        public void Add<V>(string key, V value, int cacheDurationInSeconds)
        {
            _memoryCache.Set(key, value, DateTimeOffset.Now.AddSeconds(cacheDurationInSeconds));
        }
        public bool ContainsKey<V>(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public V Get<V>(string key)
        {
            return _memoryCache.Get<V>(key);
        }

        public IEnumerable<string> GetAllKey<V>()
        {
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            var entries = _memoryCache.GetType().GetField("_entries", flags).GetValue(_memoryCache);

            //.NET 7
            //var coherentState = _memoryCache.GetType().GetField("_coherentState", flags).GetValue(_memoryCache);
            //var entries = coherentState.GetType().GetField("_entries", flags).GetValue(coherentState);

            var cacheItems = entries as IDictionary;
            var keys = new List<string>();
            if (cacheItems == null) return keys;
            foreach (DictionaryEntry cacheItem in cacheItems)
            {
                keys.Add(cacheItem.Key.ToString());
            }
            return keys;
        }

        public V GetOrCreate<V>(string cacheKey, Func<V> create, int cacheDurationInSeconds = int.MaxValue)
        {
            if (!_memoryCache.TryGetValue<V>(cacheKey, out V value))
            {
                value = create();
                _memoryCache.Set(cacheKey, value);
            }
            return value;
        }

        public void Remove<V>(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
