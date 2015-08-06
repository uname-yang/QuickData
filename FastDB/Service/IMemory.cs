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
        ISingleCache SingleCache { get; set; }
        IListCache ListCache { get; set; }
        IHashCache HashCache { get; set; }
        ITreeCache TreeCache { get; set; }
    }
}
