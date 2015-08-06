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
        protected Fastdb database;

        public bool EnSure(string key)
        {
            database = Fastdb.Instance();
            return database.keys.ContainsKey(key);
        }

        public FastObject Get(string key)
        {
            database = Fastdb.Instance();
           var value= database.keys[key];
            value.refcount++;
            value.lasttime = database.systime;
            return value;
        }

        public void Insert(string key, FastObject entity)
        {
            database = Fastdb.Instance();
            database.keys.Add(key, entity);
            database.dirty.Enqueue(new changelog { operaType=OperationType.Insert,Key= key,Value= entity });
        }

        public void Load(string key, FastObject entity)
        {
            database = Fastdb.Instance();
            database.keys.Add(key, entity);
        }

        public void Update(string key, FastObject entity)
        {
            database = Fastdb.Instance();
           if( database.keys.ContainsKey(key))
            {
                database.keys[key] = entity;
            }
            database.dirty.Enqueue(new changelog { operaType = OperationType.Update, Key = key, Value = entity });
        }

        public void Delete(string key)
        {
            database = Fastdb.Instance();
            if (database.keys.ContainsKey(key))
            {
                database.keys.Remove(key);
            }
            database.dirty.Enqueue(new changelog { operaType = OperationType.Delete, Key = key, Value = null });
        }

    }
}
