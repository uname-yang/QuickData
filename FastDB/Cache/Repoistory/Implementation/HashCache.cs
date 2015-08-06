using FastDB.Struct;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Cache.Repoistory
{
    public class HashCache : CacheService, IHashCache
    {
        new public HashObject Get(string key)
        {
            if (base.EnSure(key))
            {
                var tar = base.Get(key);
                if (tar.type == Core.ObjectType.fast_hash)
                {
                    return (tar as HashObject);
                }
            }
            return null;
        }
        public void Load(string key, object entity)
        {
            base.Load(key, new FastDB.Struct.HashObject(entity,  FastDB.Core.ObjectType.fast_hash,  true,  false,  base.database.systime ));
        }
        public void Add(string key, object entity)
        {
            base.Insert(key, new FastDB.Struct.HashObject(entity, FastDB.Core.ObjectType.fast_hash, true, false, base.database.systime));
        }
        public void Update(string key, object entity)
        {
            base.Update(key, new FastDB.Struct.HashObject(entity, FastDB.Core.ObjectType.fast_hash, true, false, base.database.systime));
        }
    }
}
