using FastDB.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Service
{
    public class FastDBService : IFastDB
    {
        public IAOF AOF
        {
            get;
            set;
        }

        public ILogger Logger
        {
            get;
            set;
        }

        public IMemory Memory
        {
            get;
            set;
        }

        public FastDBService(IAOF _AOF, ILogger _Logger,IMemory _Memory)
        {
            AOF = _AOF;
            Logger = _Logger;
            Memory = _Memory;
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Loop()
        {
            throw new NotImplementedException();
        }

        public void End()
        {
            throw new NotImplementedException();
        }
    }
}
