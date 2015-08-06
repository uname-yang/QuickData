using FastDB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FastDB.Pattern.Implementation
{
    public class HashEntity:IHashEntity
    {
        private IAOF AOF;
        private IMemory Memory;
        public HashEntity(IAOF _AOF, IMemory _Memory)
        {
            AOF = _AOF;
            Memory = _Memory;
        }

        public JObject Get(string key)
        {
            var value = Memory.HashCache.Get(key);
            if (value == null)
            {
                var aof = AOF.Get(key);
                if (aof != null)
                {
                    Memory.HashCache.Load(key, aof);
                    return new JObject(aof);
                }
                return null;
            }
            else
            {
                return value.value;
            }
        }

        public bool Insert(string key, object entity)
        {
            //TODO Key值重复校验
            if (Memory.HashCache.EnSure(key))
            {
                return false;
            }
            Memory.HashCache.Add(key, entity);
            return true;
        }

        public bool Update(string key, object entity)
        {
            if (!Memory.HashCache.EnSure(key))
            {
                return false;
            }
            var value = Memory.HashCache.Get(key);
            if (value == null)
            {
                var aof = AOF.Get(key);
                if (aof != null)
                {
                    Memory.HashCache.Load(key, aof);
                    Memory.HashCache.Update(key, entity);
                    return true;
                }
                return false;
            }
            else
            {
                Memory.HashCache.Update(key, entity);
                return true;
            }
        }

        public bool Delete(string key)
        {
            if (!Memory.HashCache.EnSure(key))
            {
                return false;
            }
            Memory.HashCache.Delete(key);
            return true;
        }

        public JObject Fetch(string key, string mkey)
        {
            var tar = Get(key);
            return (JObject)tar.SelectToken("$.."+mkey);
        }

        public bool Add(string key,string mkey,object entity)
        {
            if (!Memory.HashCache.EnSure(key))
            {
                return false;
            }
            var value = Memory.HashCache.Get(key);
            if (value == null)
            {
                var aof = AOF.Get(key);
                if (aof != null)
                {
                    Memory.HashCache.Load(key, aof);
                    value = Memory.HashCache.Get(key);
                }
                return false;
            }
           value.value.Add(mkey, JToken.FromObject(entity));
            Memory.HashCache.Update(key, value.value);
            return true;
        }

        public bool Replace(string key, string mkey, object entity)
        {
            if (!Memory.HashCache.EnSure(key))
            {
                return false;
            }
            var value = Memory.HashCache.Get(key);
            if (value == null)
            {
                var aof = AOF.Get(key);
                if (aof != null)
                {
                    Memory.HashCache.Load(key, aof);
                    value = Memory.HashCache.Get(key);
                }
                return false;
            }
            value.value[mkey] = JToken.FromObject(entity);
            Memory.HashCache.Update(key, value.value);
            return true;
        }

        public bool Remove(string key, string mkey)
        {
            if (!Memory.HashCache.EnSure(key))
            {
                return false;
            }
            var value = Memory.HashCache.Get(key);
            if (value == null)
            {
                var aof = AOF.Get(key);
                if (aof != null)
                {
                    Memory.HashCache.Load(key, aof);
                    value = Memory.HashCache.Get(key);
                }
                return false;
            }
            value.value.Remove(mkey);
            Memory.HashCache.Update(key, value.value);
            return true;
        }
    }
}
