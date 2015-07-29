using FastDB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        // GET: api/SingleEntity/5
        public string Get(string  key)
        {

            var aa = new FastDB.Struct.StringObject { value = "3s",encoding=FastDB.Core.ObjectEncoding.fast_endcoding_string,type=FastDB.Core.ObjectType.fast_string };
            _fastdb.Memory.SingleRES.Insert("sss",aa);

            _fastdb.Memory.SingleRES.Get("sss");
            return "value";
        }

        // GET: api/SingleEntity
        public IEnumerable<string> Get(string[] keys)
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/SingleEntity
        public void Post(string key, [FromBody]string value)
        {
         
        }

        // PUT: api/SingleEntity/5
        public void Put(string key, [FromBody]string value)
        {

        }

        // DELETE: api/SingleEntity/5
        public void Delete(string key)
        {
        }
    }
}
