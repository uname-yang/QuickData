using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuickData.Controllers
{
    public class SortListController : ApiController
    {
        // GET: api/SingleEntity/5
        public string Get(string key)
        {
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
