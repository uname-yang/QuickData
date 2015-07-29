using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Core
{
   public  class Fastdb
    {
        private static Fastdb instance = null;

        private Fastdb()
        {
            keys = new Dictionary<string, FastObject>();
            auths = new Dictionary<string, string>();
            users = new Dictionary<string, string>();
            dirty = 0;
            lastsave = DateTime.Now;
        }

        public static Fastdb Instance()
        {
            if (instance == null)
            {
                instance = new Fastdb();
            }
            return instance;
        }

        public   Dictionary<string, FastObject> keys { get; set; }

        public  Dictionary<string, string> auths { get; set; }

        public  Dictionary<string, string> users { get; set; }

        public  int dirty { get; set; }

        public  DateTime lastsave { get; set; }

        public  int max { get; set; }
    }
}
