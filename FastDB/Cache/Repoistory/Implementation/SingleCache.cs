using FastDB.Common;
using FastDB.Core;
using FastDB.Struct;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Cache.Repoistory
{
    public class SingleCache : CacheService, ISingleCache
    {
        new public StringObject Get(string key)
        {
            if (base.EnSure(key))
            {
                var tar = base.Get(key);
                if (tar.type == Core.ObjectType.fast_string)
                {
                    return (tar as StringObject);
                }
            }
            return null;
        }
        public void Load(string key, object entity)
        {
            base.Load(key, new FastDB.Struct.StringObject (entity, FastDB.Core.ObjectType.fast_string, true,  false, base.database.systime ));
        }
        public void Add(string key, object entity)
        {
            base.Insert(key, new FastDB.Struct.StringObject(entity, FastDB.Core.ObjectType.fast_string, true, false, base.database.systime));
        }
        public void Update(string key, object entity)
        {
            base.Update(key, new FastDB.Struct.StringObject(entity, FastDB.Core.ObjectType.fast_string, true, false, base.database.systime));
        }


    }
}
