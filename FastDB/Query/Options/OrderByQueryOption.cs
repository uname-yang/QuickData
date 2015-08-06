using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Query.Options
{
    public class OrderByQueryOption
    {
        public string RawValue { get; private set; }

        public OrderByQueryOption(string rawValue)
        {
            if (String.IsNullOrEmpty(rawValue))
            {
                throw new Exception(" OrderBy rawValue is null");
            }
            RawValue = rawValue;
        }

        internal IEnumerable<JToken> ApplyTo(IEnumerable<JToken> result)
        {
            return result;
        }
    }
}
