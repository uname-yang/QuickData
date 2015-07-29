using FastDB.Core;
using FastDB.Service;
using FastDB.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Cache.Repoistory
{
    public interface ISingleRES
    {
        StringObject Get(string key);

        void Insert(string key, StringObject entity);
    }
}
