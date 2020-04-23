using Microsoft.Extensions.Caching.Distributed;
using System;

namespace DotnetRedis
{
    public class RedisRepository : ICacheRepository
    {
        private IDistributedCache _cache;

        public RedisRepository(IDistributedCache cache)
            => _cache = cache;

        public string GetString(string key)
            => _cache.GetString(key);

        public void SetString(string key, string value, int timeOutHours)
        {
            DistributedCacheEntryOptions opcoesCache = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(timeOutHours));

            _cache.SetString(key, value, opcoesCache);
        }
    }
}