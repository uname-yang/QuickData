using FastDB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Service
{
    public interface  IAOF
    {
        void init(Fastdb sdb);
        void stop(Fastdb sdb);
        void sync(Fastdb sdb);
        string Get(string key);
        void Insert(string key, FastObject entity);
        void Update(string key, FastObject entity);
        void Delete(string key);

    }
}
