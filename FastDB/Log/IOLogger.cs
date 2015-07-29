using FastDB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Log
{
    public  class IOLogger:ILogger
    {
        protected internal DSFLogger Logger { get; set; }

        public IOLogger()
        {
            Logger = DSFLogger.Instance();
        }

        public bool Log(LogType type, string format, params object[] args)
        {
            return Logger.Log();
        }
    }
}
