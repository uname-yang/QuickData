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
        public ISingleCache SingleCache { get; set;}
        public IListCache ListCache { get; set; }
        public IHashCache HashCache { get; set; }
        public ITreeCache TreeCache { get; set; }

        public Memory(ISingleCache _SingleCache,IListCache _ListCache, IHashCache _HashCache, ITreeCache _TreeCache)
        {
            SingleCache = _SingleCache;
            ListCache = _ListCache;
            HashCache = _HashCache;
            TreeCache = _TreeCache;
        }
    }
}
