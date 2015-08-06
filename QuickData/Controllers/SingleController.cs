using FastDB.Query;
using FastDB.Service;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Web.Http;

namespace QuickData.Controllers
{
    public class SingleController : ApiController
    {
        private readonly IFastDB _fastdb;

        public SingleController(IFastDB fastdb)
        {
            _fastdb = fastdb;
        }
        [JsonQuery]
        public JObject Get(string  key)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();        
            var data = _fastdb.SingleEntity.Get(key);
            sw.Stop();
            var tt=sw.Elapsed;
            return data;
        }


        public bool Post(string key, [FromBody]object value)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
             var data = _fastdb.SingleEntity.Insert(key, value);
            sw.Stop();
            var tt = sw.Elapsed;
            return data;
            
        }

        public bool Put(string key, [FromBody]object value)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var Data = _fastdb.SingleEntity.Update(key, value);
            sw.Stop();
            var tt = sw.Elapsed;
            return Data;        
        }

        public bool Delete(string key)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var Data = _fastdb.SingleEntity.Delete(key);
            sw.Stop();
            var tt = sw.Elapsed;
            return Data;
        }
    }
}
