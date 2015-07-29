using FastDB.Cache.Repoistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Service
{
    public interface IMemory
    {
        ISingleRES SingleRES { get; set; }
    }
}
