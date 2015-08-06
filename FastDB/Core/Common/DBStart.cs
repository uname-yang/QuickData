using FastDB.Core;
using FastDB.Service;
using System;
using System.Timers;

namespace FastDB.Common
{
    public class DBStart
    {
        private IAOF AOF;
        private IMemory Memory;
        private Fastdb database = Fastdb.Instance();
        public DBStart(IAOF _AOF, IMemory _Memory)
        {
            AOF = _AOF;
            Memory = _Memory;
            start();

            Timer time = new Timer();
            time.AutoReset = true;
            time.Interval = database.loopspan;
            time.Elapsed += new ElapsedEventHandler(SC);
            time.Start();
        }

        public void SC(object sender, ElapsedEventArgs eventArgs)
        {
               everytime();
        }

        private void start()
        {
            AOF.init(database);
        }
        /// <summary>
        /// 
        /// </summary>
        private void everytime()
        {
            if(database.isrunning)
            {
                return;
            }
            database.systime = DateTime.Now;
            var timespan = (database.systime - database.lastsync).TotalMilliseconds;
            foreach (var item in database.ifsync)
            {
                if(timespan>=item.time&&database.dirty.Count>=item.changes)
                {
                    AOF.sync(database);
                }
            }
        }

    }
}
