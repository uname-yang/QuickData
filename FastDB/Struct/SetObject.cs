using FastDB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Struct
{
    public class SetObject: FastObject
    {
        public HashSet<string> value;
    }
}
