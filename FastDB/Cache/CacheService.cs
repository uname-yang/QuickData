using FastDB.Core;
using FastDB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Cache
{
    public abstract class CacheService : IMemoryCache
    {
        private Fastdb database;

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }

        public bool EnSure(string key, FastObject entity)
        {
            throw new NotImplementedException();
        }

        public void Excute(string sql, object[] param)
        {
            throw new NotImplementedException();
        }

        public FastObject Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public FastObject Get(string key)
        {
            database = Fastdb.Instance();
           return database.keys[key];
        }

        public void Insert(string key, FastObject entity)
        {
            database = Fastdb.Instance();
            database.keys.Add(key, entity);
        }

        public void Update(string key, FastObject entity)
        {
            throw new NotImplementedException();
        }

    }
}
