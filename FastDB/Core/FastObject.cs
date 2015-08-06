using FastDB.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Core
{
    public class FastObject
    {
        public ObjectType type { get; set; }

        public bool isShare { get; set; }

        public bool readOnly { get; set; }

        public int refcount { get; set; }

        public DateTime lasttime { get; set; }

    }
}
