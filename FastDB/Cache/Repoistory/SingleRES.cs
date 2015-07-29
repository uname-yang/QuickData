using FastDB.Core;
using FastDB.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Cache.Repoistory
{
    public class SingleRES : CacheService, ISingleRES
    {
        public StringObject Get(string key)
        {
            return base.Get(key) as StringObject;
        }

        public void Insert(string key, StringObject entity)
        {
            base.Insert(key,entity);
        }
    }
}
