using FastDB.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Service
{
    public interface ILogger
    {
        bool Log(LogType type,string format, params object[] args);
    }
}
