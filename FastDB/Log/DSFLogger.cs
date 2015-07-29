using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Log
{
    public class DSFLogger
    {
        private static DSFLogger instance = null;

        private DSFLogger()
        {
            //list = new List<string>();
        }
        public static DSFLogger Instance()
        {
            if (instance == null)
            {
                instance = new DSFLogger();
            }
            return instance;
        }

        public bool Log()
        {
            return true;
        }
    }
}
