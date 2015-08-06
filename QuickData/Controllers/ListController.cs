using FastDB.Query;
using FastDB.Service;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Mvc;

namespace QuickData.Controllers
{
    public class ListController : ApiController
    {
        private readonly IFastDB _fastdb;
        public ListController(IFastDB fastdb)
        {
            _fastdb = fastdb;
        }

        [JsonQuery]
        public JArray Get(string key)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
           var Data = _fastdb.ListEntity.Get(key);
            sw.Stop();
            var tt = sw.Elapsed;
            return Data;
        }

        public void Post(string key, [FromBody]object value)
        {
            _fastdb.ListEntity.Insert(key, value);
        }

        public void Put(string key, [FromBody]object value)
        {
            _fastdb.ListEntity.Update(key, value);
        }

        public void Delete(string key)
        {
            _fastdb.ListEntity.Delete(key);
        }


    }
}
