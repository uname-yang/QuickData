using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Query.Options
{
    public class FilterQueryOption
    {
        public string RawValue { get; private set; }

        public FilterQueryOption(string rawValue)
        {
            if (String.IsNullOrEmpty(rawValue))
            {
                throw new Exception("filter rawValue is null");
            }
            RawValue = rawValue;
        }

        internal IEnumerable<JToken> ApplyTo(IEnumerable<JToken> result)
        {
            var data =(JArray)result;
            return data.SelectTokens(RawValue);
        }

        internal IEnumerable<JToken> ApplyTo(JObject result)
        {
            return result.SelectTokens(RawValue);
        }
    }
}
