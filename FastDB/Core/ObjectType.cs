using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Core
{
    public enum ObjectType
    {
        fast_string=0,
        fast_list=1,
        fast_zlist=2,
        fast_hash = 3,
        fast_tree =4
    }
}
