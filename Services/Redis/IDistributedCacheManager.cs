using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Redis
{
    public interface IDistributedCacheManager
    {
        byte[] Get(string key);
        T Get<T>(string key);
        void Set<T>(string key, T model);
        void Refresh(string key);
        bool Any(string key);
        void Remove(object key);
        Task<bool> Clear();
        bool Contains(object key);
    }
}
