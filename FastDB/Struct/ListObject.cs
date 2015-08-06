using FastDB.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Struct
{
    public class ListObject: FastObject
    {
        public JArray value { get; private set; }

        public ListObject(Object obj, ObjectType type, bool isShare, bool readOnly, DateTime lasttime)
        {
            base.type = type;
            base.isShare = isShare;
            base.readOnly = readOnly;
            base.refcount = 0;
            base.lasttime = lasttime;
            value = JArray.FromObject(obj);
        }

        public ListObject(string obj, ObjectType type, bool isShare, bool readOnly, DateTime lasttime)
        {
            base.type = type;
            base.isShare = isShare;
            base.readOnly = readOnly;
            base.refcount = 0;
            base.lasttime = lasttime;
            value = JArray.Parse(obj);
        }
    }
}
