using FastDB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Cache
{
    public interface IMemoryCache
    {
        bool EnSure(string key);
        FastObject Get(string key);
        void Insert(string key, FastObject entity);
        void Update(string key, FastObject entity);
        void Delete(string key);
        void Load(string key, FastObject entity);
        //FastObject Find(string key, object[] param);
        //void Excute(string key, object[] param);
    }
}
