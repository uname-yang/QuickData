using FastDB.Core;
using FastDB.Service;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Pattern.Implementation
{
    public class SingleEntity : ISingleEntity
    {
        private IAOF AOF;
        private IMemory Memory;
        public SingleEntity(IAOF _AOF, IMemory _Memory)
        {
            AOF = _AOF;
            Memory = _Memory;
        }

        public JObject Get(string key)
        {
            var value = Memory.SingleCache.Get(key);
            if (value == null)
            {
                var aof = AOF.Get(key,ObjectType.fast_string);
                if (aof != null)
                {
                    Memory.SingleCache.Load(key, aof);
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
            if (Memory.SingleCache.EnSure(key))
            {
                return false;
            }
            Memory.SingleCache.Add(key, entity);
            return true;
        }

        public bool Update(string key, object entity)
        {
            if (!Memory.SingleCache.EnSure(key))
            {
                return false;
            }
            var value = Memory.SingleCache.Get(key);
            if (value == null)
            {
                var aof = AOF.Get(key, ObjectType.fast_string);
                if (aof != null)
                {
                    Memory.SingleCache.Load(key, aof);
                    Memory.SingleCache.Update(key, entity);
                    return true;
                }
                return false;
            }
            else
            {
                Memory.SingleCache.Update(key, entity);
                return true;
            }
        }

        public bool Delete(string key)
        {
            if (!Memory.SingleCache.EnSure(key))
            {
                return false;
            }
            Memory.SingleCache.Delete(key);
            return true;
        }
    }
}
