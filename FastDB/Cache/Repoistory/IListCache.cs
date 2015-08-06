using FastDB.Struct;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Cache.Repoistory
{
    public interface IListCache
    {
        bool EnSure(string key);
        ListObject Get(string key);
        void Add(string key, object entity);
        void Load(string key, object entity);
        void Update(string key, object entity);
        void Delete(string key);
    }
}
