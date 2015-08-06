using FastDB.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Core
{
   public  class Fastdb
    {
        private static class FastdbHolder
        {
            public static Fastdb INSTANCE = new Fastdb();
        }
        private Fastdb()
        {
            keys = new Dictionary<string, FastObject>();
            auths = new Dictionary<string, string>();
            users = new Dictionary<string, string>();
            ifsync = new List<saveparam>();
            hotkeys = new LinkedList<string>();
            dirty = new Queue<changelog>();
            systime = DateTime.Now;
            lastsync = systime;
            isrunning = false;
            try {
                max = int.Parse(ConfigurationManager.AppSettings["max"]);
                loopspan = int.Parse(ConfigurationManager.AppSettings["loopspan"]);
                foreach (var item in ConfigurationManager.AppSettings["ifsnyc"].Split('|'))
                {
                    var param = item.Split(',');
                    ifsync.Add(new saveparam { time = int.Parse(param[0]), changes = int.Parse(param[1]) });
                }
            }
            catch
            {
                max = 1000;
                ifsync.Add(new saveparam { time =60000, changes =1});
            }
        }

        public static Fastdb Instance()
        {
            return FastdbHolder.INSTANCE;
        }

        public  Dictionary<string, FastObject> keys { get; set; }

        public   Dictionary<string, string> auths { get; set; }

        public  Dictionary<string, string> users { get; set; }

        public LinkedList<string> hotkeys { get; set; }
        /// <summary>
        /// 变更
        /// </summary>
        public Queue<changelog> dirty { get; set; }
        /// <summary>
        /// 循环时间时间，单位 毫秒
        /// </summary>
        public int loopspan { get; private set; }
        /// <summary>
        /// 系统时间
        /// </summary>
        public DateTime systime { get; set; }
        /// <summary>
        /// 最后同步时间
        /// </summary>
        public DateTime lastsync { get; set; }
        /// <summary>
        /// 同步条件
        /// </summary>
        public List<saveparam> ifsync { get; private set; }
        /// <summary>
        /// 最大容量
        /// </summary>
        public int max { get;private  set; }

        public bool isrunning { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class saveparam
    {
        /// <summary>
        /// 设置时间，单位 毫秒
        /// </summary>
        public int time { get; set; }
        /// <summary>
        /// 设置次数
        /// </summary>
        public int changes { get; set; }
    }

    public class changelog
    {
        public OperationType operaType { get; set; }
        public FastObject Value { get; set; }
        public string Key { get; set; }
    }
}
