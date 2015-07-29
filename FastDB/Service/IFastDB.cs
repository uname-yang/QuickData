using FastDB.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Service
{
    public interface IFastDB
    {
         IAOF AOF { get; set; }
         ILogger Logger { get; set; }
        IMemory Memory { get; set; }

        void Start();
        void Loop();
        void End();


    }
}
