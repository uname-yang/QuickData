using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Core
{
    public enum ObjectEncoding
    {
        fast_endcoding_int=0,
        fast_endcoding_string=1,
        fast_endcoding_list=2,
        fast_endcoding_dic=3,
        fast_endcoding_set=4,
        fast_endcoding_slist=5,
        fast_endcoding_tree=6
    }
}
