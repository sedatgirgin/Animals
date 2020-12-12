using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Caching.Abstract
{
    public interface ICache
    {
        Task<object> GetCacheAsync(string cacheKey);

        Task SetCacheAsync(object value, string cacheKey);
    }
}
