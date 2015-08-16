using FastDB.Query;
using FastDB.Service;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.Cors;

namespace QuickData.Controllers
{
    public class SingleController : ApiController
    {
        private readonly IFastDB _fastdb;

        public SingleController(IFastDB fastdb)
        {
            _fastdb = fastdb;
        }

       // [EnableCors(origins: "http://localhost:7921", headers: "*", methods: "*")]
        public string Get()
        {
            return "SB";
        }

        [JsonQuery]
      //  [EnableCors(origins: "*", headers: "*", methods: "*")]
        public JObject Get(string  key)
        { 
            var data = _fastdb.SingleEntity.Get(key);
            return data;
        }


        public bool Post(string key, [FromBody]object value)
        {
             var data = _fastdb.SingleEntity.Insert(key, value);
            return data;       
        }

        public bool Put(string key, [FromBody]object value)
        {
            var Data = _fastdb.SingleEntity.Update(key, value);
            return Data;        
        }

        public bool Delete(string key)
        {
            var Data = _fastdb.SingleEntity.Delete(key);
            return Data;
        }

        public string Options()
        {
            return null;
        }
    }
}
