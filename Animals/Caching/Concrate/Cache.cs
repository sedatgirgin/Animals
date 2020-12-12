using Animals.Caching.Abstract;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Caching.Concrate
{

    public  class Cache:ICache
    {
        private readonly IMemoryCache _memoryCache;
        public Cache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public async Task<object> GetCacheAsync(string cacheKey)
        {
            if (!_memoryCache.TryGetValue(cacheKey, out object response))
            {
                _memoryCache.Set(cacheKey, response, DateTime.Now.AddDays(1));
            }
            return response;
        }
        public async Task SetCacheAsync(object value,string cacheKey)
        {
            if (!_memoryCache.TryGetValue(cacheKey, out object response))
            {
                _memoryCache.Set(cacheKey, value, DateTime.Now.AddDays(1));
            }
        }

        public async Task<bool> RemoveCacheAsync(string cacheKey)
        {
            if (_memoryCache.TryGetValue(cacheKey, out object response))
            {
                _memoryCache.Remove(cacheKey);
                return true;
            }
            return false;
        }
    }
}
