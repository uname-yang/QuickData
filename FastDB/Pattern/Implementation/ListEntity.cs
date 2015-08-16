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
    public class ListEntity : IListEntity
    {
        private IAOF AOF;
        private IMemory Memory;
        public ListEntity(IAOF _AOF, IMemory _Memory)
        {
            AOF = _AOF;
            Memory = _Memory;
        }

        public JArray Get(string key)
        {
            var value = Memory.ListCache.Get(key);
            if (value == null)
            {
                var aof = AOF.Get(key, ObjectType.fast_list);
                if (aof != null)
                {
                    Memory.ListCache.Load(key, aof);
                    return JArray.Parse(aof);
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
            if (Memory.ListCache.EnSure(key))
            {
                return false;
            }
            Memory.ListCache.Add(key, entity);
            return true;
        }

        public bool Update(string key, object entity)
        {
            if (!Memory.ListCache.EnSure(key))
            {
                return false;
            }
            var value = Memory.ListCache.Get(key);
            if (value == null)
            {
                var aof = AOF.Get(key,ObjectType.fast_list);
                if (aof != null)
                {
                    Memory.ListCache.Load(key, aof);
                    Memory.ListCache.Update(key, entity);
                    return true;
                }
                return false;
            }
            else
            {
                Memory.ListCache.Update(key, entity);
                return true;
            }
        }

        public bool Delete(string key)
        {
            if (!Memory.ListCache.EnSure(key))
            {
                return false;
            }
            Memory.ListCache.Delete(key);
            return true;
        }
    }
}
