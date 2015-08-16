using FastDB.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Struct
{
    public class StringObject: FastObject
    {
        public JObject value { get; private set; }

       // public object _value { get; private set; }

        public StringObject(Object obj, ObjectType type,bool isShare,bool readOnly,DateTime lasttime)
        {
            base.type = type;
            base.isShare = isShare;
            base.readOnly = readOnly;
            base.refcount = 0;
            base.lasttime = lasttime;
            //_value = obj;
            value = JObject.FromObject(obj);
        }

        public StringObject(string obj, ObjectType type, bool isShare, bool readOnly, DateTime lasttime)
        {
            base.type = type;
            base.isShare = isShare;
            base.readOnly = readOnly;
            base.refcount = 0;
            base.lasttime = lasttime;
           // _value = obj;
            value = JObject.Parse(obj);
        }
    }
}
