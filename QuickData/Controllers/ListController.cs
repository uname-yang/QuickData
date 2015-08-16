using FastDB.Query;
using FastDB.Service;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.Cors;
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
      //  [EnableCors(origins: "*", headers: "*", methods: "*")]
        public JArray Get(string key)
        {
           var Data = _fastdb.ListEntity.Get(key);
            return Data;
        }

        public bool Post(string key, [FromBody]object value)
        {
            return _fastdb.ListEntity.Insert(key, value);
        }

        public bool Put(string key, [FromBody]object value)
        {
            return _fastdb.ListEntity.Update(key, value);
        }

        public bool Delete(string key)
        {
            return  _fastdb.ListEntity.Delete(key);
        }

        public string Options()
        {
            return null;
        }
    }
}
