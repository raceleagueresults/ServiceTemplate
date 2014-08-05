using Infrastructure.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Caching
{
    public class MemoryCache<T> : ICache<T>
    {
        private static MemoryCache _cache = MemoryCache.Default;

        private readonly ICacheConfiguration _configuration;

        public MemoryCache(ICacheConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Add(T obj, string id)
        {
            _cache.Add(id, obj, _configuration.CacheExpiration);
        }

        public T Get(string id)
        {
            return (T)_cache.Get(id);
        }

        public void Remove(string id)
        {
            _cache.Remove(id);
        }

        public void Update(T obj, string id)
        {
            _cache.Remove(id);

            _cache.Add(id, obj, _configuration.CacheExpiration);
        }

        public List<T> GetAll(string id)
        {
            _cache.Get(id);

            return (List<T>)_cache.Get(id);
        }

        public void Add(List<T> obj, string id)
        {
            _cache.Add(id, obj, _configuration.CacheExpiration);
        }
    } 
}
