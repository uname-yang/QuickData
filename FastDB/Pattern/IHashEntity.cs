using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Pattern
{
    public  interface IHashEntity
    {
        JObject Get(string key);

        bool Insert(string key, object entity);

        bool Update(string key, object entity);

        bool Delete(string key);

        JObject Fetch(string key, string mkey);

         bool Add(string key, string mkey, object entity);

        bool Replace(string key, string mkey, object entity);

        bool Remove(string key ,string mkey);
    }
}
