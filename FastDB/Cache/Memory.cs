using FastDB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastDB.Cache.Repoistory;

namespace FastDB.Cache
{
    public class Memory : IMemory
    {
        public ISingleRES SingleRES{ get; set;}

        public Memory(ISingleRES _SingleRE)
        {
            SingleRES = _SingleRE;
        }
    }
}
