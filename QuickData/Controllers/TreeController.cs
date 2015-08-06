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
        public JObject Get(string key)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var data = _fastdb.TreeEntity.Get(key);
            sw.Stop();
            var tt = sw.Elapsed;
            return data;
        }

        public bool Post(string key, [FromBody]object value)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var data = _fastdb.TreeEntity.Insert(key, value);
            sw.Stop();
            var tt = sw.Elapsed;
            return data;

        }

        public bool Put(string key, [FromBody]object value)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var Data = _fastdb.TreeEntity.Update(key, value);
            sw.Stop();
            var tt = sw.Elapsed;
            return Data;
        }

        public bool Delete(string key)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var Data = _fastdb.TreeEntity.Delete(key);
            sw.Stop();
            var tt = sw.Elapsed;
            return Data;
        }

        [JsonQuery]
        public JObject Get(string key, string node)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var data = _fastdb.TreeEntity.Get(key);
            sw.Stop();
            var tt = sw.Elapsed;
            return data;
        }

        [JsonQuery]
        public JArray Get(string key, string child,bool includechildren)
        {
            var data = _fastdb.TreeEntity.Get(key);

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
    }
}
