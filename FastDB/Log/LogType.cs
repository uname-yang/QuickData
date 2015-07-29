using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Log
{
    public enum LogType
    {
        /// <summary>
        /// Write
        /// </summary>
        Write,
        /// <summary>
        /// 消息级
        /// </summary>
        Information,
        /// <summary>
        /// 警告级
        /// </summary>
        Warning,
        /// <summary>
        /// 错误级
        /// </summary>
        Error,
        /// <summary>
        /// 毁灭级
        /// </summary>
        Fatal
    }
}
