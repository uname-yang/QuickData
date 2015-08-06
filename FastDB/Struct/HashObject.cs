using FastDB.Core;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace FastDB.Struct
{
     public class HashObject: FastObject
    {
        public JObject value { get; private set; }

        public object _value { get; private set; }

        public HashObject(Object obj, ObjectType type, bool isShare, bool readOnly, DateTime lasttime)
        {
            base.type = type;
            base.isShare = isShare;
            base.readOnly = readOnly;
            base.refcount = 0;
            base.lasttime = lasttime;
            _value = obj;
            value = JObject.FromObject(obj);
        }

        public HashObject(string obj, ObjectType type, bool isShare, bool readOnly, DateTime lasttime)
        {
            base.type = type;
            base.isShare = isShare;
            base.readOnly = readOnly;
            base.refcount = 0;
            base.lasttime = lasttime;
            _value = obj;
            value = JObject.Parse(obj);
        }

    }
}
