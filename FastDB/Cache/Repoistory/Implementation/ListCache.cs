using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using FastDB.Struct;

namespace FastDB.Cache.Repoistory
{
    public class ListCache : CacheService, IListCache
    {
        public void Add(string key, object entity)
        {
            base.Insert(key, new FastDB.Struct.ListObject (entity,  FastDB.Core.ObjectType.fast_list,  true,  false, base.database.systime ));
        }

        public void Load(string key, object entity)
        {
            base.Load(key, new FastDB.Struct.ListObject(entity, FastDB.Core.ObjectType.fast_list, true, false, base.database.systime));
        }

        public void Update(string key, object entity)
        {
            base.Update(key, new FastDB.Struct.ListObject(entity, FastDB.Core.ObjectType.fast_list, true, false, base.database.systime));
        }

        ListObject IListCache.Get(string key)
        {
            if (base.EnSure(key))
            {
                var tar = base.Get(key);
                if (tar.type == Core.ObjectType.fast_list)
                {
                    return (tar as ListObject);
                }
            }
            return null;
        }
    }
}
