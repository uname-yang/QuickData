using FastDB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using FastDB.Core;

namespace FastDB.Pattern.Implementation
{
    public class TreeEntity: ITreeEntity
    {
        private IAOF AOF;
        private IMemory Memory;
        public TreeEntity(IAOF _AOF, IMemory _Memory)
        {
            AOF = _AOF;
            Memory = _Memory;
        }

        public bool Delete(string key)
        {
            if (!Memory.TreeCache.EnSure(key))
            {
                return false;
            }
            Memory.TreeCache.Delete(key);
            return true;
        }

        public JObject Get(string key)
        {
            var value = Memory.TreeCache.Get(key);
            if (value == null)
            {
                var aof = AOF.Get(key, ObjectType.fast_tree);
                if (aof != null)
                {
                    Memory.TreeCache.Load(key, aof);
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
            if (Memory.TreeCache.EnSure(key))
            {
                return false;
            }
            Memory.TreeCache.Add(key, entity);
            return true;
        }

        public bool Update(string key, object entity)
        {
            if (!Memory.TreeCache.EnSure(key))
            {
                return false;
            }
            var value = Memory.TreeCache.Get(key);
            if (value == null)
            {
                var aof = AOF.Get(key, ObjectType.fast_tree);
                if (aof != null)
                {
                    Memory.TreeCache.Load(key, aof);
                    Memory.TreeCache.Update(key, entity);
                    return true;
                }
                return false;
            }
            else
            {
                Memory.TreeCache.Update(key, entity);
                return true;
            }
        }
    }
}
