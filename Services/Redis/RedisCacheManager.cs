using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Redis
{
    internal class RedisCacheManager : IDistributedCacheManager
    {
        private IDatabase _database;
        private RedisCacheOptions options;
        private string connectionString { get; set; }
        private static ConnectionMultiplexer _connectionMultiplexer;
        public RedisCacheManager()
        {
            connectionString=ConfigurationManager.AppSettings["ConnectionStrings:Redis"];
            options = new RedisCacheOptions()
            {
                Configuration=connectionString
            };
            _connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
        }


        public bool Any(string key)
        {
            using (var redisCache = new RedisCache(options))
            {
               return  redisCache.Get(key) != null;
            }
        }

        public byte[] Get(string key)
        {
            using (var redisCache = new RedisCache(options))
            {
                return redisCache.Get((string)key);
            }
        }

        public T Get<T>(string cacheKey)
        {
            using (var redisCache = new RedisCache(options))
            {

                var valueString = redisCache.GetString(cacheKey);
                if (!string.IsNullOrEmpty(valueString))
                {
                    var valueObject = JsonConvert.DeserializeObject<T>(valueString);
                    return (T)valueObject;
                }

                return default(T);
            }
        }

        public void Refresh(string key)
        {
            using (var redisCache = new RedisCache(options))
            {
                redisCache.Refresh(key);
            }
        }

        public void Remove(object key)
        {
            using (var redisCache = new RedisCache(options))
            {
                redisCache.Remove((string)key);
            }
        }

        public void Set<T>(string cacheKey, T model)
        {
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(90)
            };

            using (var redisCache = new RedisCache(options))
            {
                var valueString = JsonConvert.SerializeObject(model);
                redisCache.SetString(cacheKey, valueString);
            }
        }

        public async Task<bool> Clear()
        {
            try
            {
                var endpoints = _connectionMultiplexer.GetEndPoints(true);
                foreach (var endpoint in endpoints)
                {
                    var server = _connectionMultiplexer.GetServer(endpoint);
                    server.FlushAllDatabases();
                }
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Contains(object key)
        {
            return _database.KeyExists((RedisKey)key);
        }
    }
}
