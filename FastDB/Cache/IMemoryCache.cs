using FastDB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Cache
{
    public interface IMemoryCache
    {
        bool EnSure(string key,FastObject entity);
        void Insert(string key, FastObject entity);
        void Update(string key, FastObject entity);
        void Delete(string key);
        FastObject Find(params object[] keyValues);
        FastObject Get(string key);
        void Excute(string sql, object[] param);
    }
}
