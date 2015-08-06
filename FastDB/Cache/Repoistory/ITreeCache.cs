using FastDB.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Cache.Repoistory
{
    public interface ITreeCache
    {
        bool EnSure(string key);
        TreeObject Get(string key);
        void Add(string key, object entity);
        void Load(string key, object entity);
        void Update(string key, object entity);
        void Delete(string key);
    }
}
