using FastDB.Query;
using FastDB.Service;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace QuickData.Controllers
{
    public class TreeController : ApiController
    {
        private readonly IFastDB _fastdb;

        public TreeController(IFastDB fastdb)
        {
            _fastdb = fastdb;
        }

        [JsonQuery]
      //  [EnableCors(origins: "*", headers: "*", methods: "*")]
        public JObject Get(string key)
        {
            return _fastdb.TreeEntity.Get(key);
        }

        public bool Post(string key, [FromBody]object value)
        {
            return  _fastdb.TreeEntity.Insert(key, value);
        }

        public bool Put(string key, [FromBody]object value)
        {
            return _fastdb.TreeEntity.Update(key, value);
        }

        public bool Delete(string key)
        {
            return _fastdb.TreeEntity.Delete(key);
        }

        [JsonQuery]
        public JObject Get(string key, string node)
        {
            return _fastdb.TreeEntity.Get(key);
        }

        [JsonQuery]
        public JArray Get(string key, string child,bool includechildren)
        {
            return null;
        }

        public bool Post(string key, string parent, [FromBody]object node)
        {
            return true;
        }

        public bool Delete(string key, string node)
        {
            return true;
        }

        public string Options()
        {
            return null;
        }
    }
}
