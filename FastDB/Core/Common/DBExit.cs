using FastDB.Core;
using FastDB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Common
{
    public class DBExit
    {
        private IAOF AOF;
        private IMemory Memory;
        private Fastdb database = Fastdb.Instance();
        public DBExit(IAOF _AOF, IMemory _Memory)
        {
            AOF = _AOF;
            Memory = _Memory;

            exit();
        }

        private void exit()
        {
            AOF.stop(database);
        }

    }
}
