using FastDB.Struct;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Cache.Repoistory
{
    public class TreeCache : CacheService, ITreeCache
    {
        new public TreeObject Get(string key)
        {
            if (base.EnSure(key))
            {
                var tar = base.Get(key);
                if (tar.type == Core.ObjectType.fast_tree)
                {
                    return (tar as TreeObject);
                }
            }
            return null;
        }
        public void Load(string key, object entity)
        {
            base.Load(key, new FastDB.Struct.TreeObject { value = JObject.FromObject(entity), type = FastDB.Core.ObjectType.fast_tree, isShare = true, readOnly = false, refcount = 0, lasttime =base.database.systime });
        }
        public void Add(string key, object entity)
        {
            base.Insert(key, new FastDB.Struct.TreeObject { value = JObject.FromObject(entity), type = FastDB.Core.ObjectType.fast_tree, isShare = true, readOnly = false, refcount = 0, lasttime = base.database.systime });
        }
        public void Update(string key, object entity)
        {
            base.Update(key, new FastDB.Struct.TreeObject { value = JObject.FromObject(entity), type = FastDB.Core.ObjectType.fast_tree, isShare = true, readOnly = false, refcount = 0, lasttime = base.database.systime });
        }
    }
}
