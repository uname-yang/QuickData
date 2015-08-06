using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Query.Options
{
    public class TopQueryOption
    {
        public int RawValue { get; private set; }

        public TopQueryOption(string rawValue)
        {
            if (String.IsNullOrEmpty(rawValue))
            {
                throw new Exception("Top rawValue is null");
            }
            int tem;
            if (int.TryParse(rawValue, out tem))
            {
                RawValue = tem;
            }
            else
            {
                throw new Exception("Top rawValue is not a int");
            }
        }

        internal IEnumerable<JToken> ApplyTo(IEnumerable<JToken> result)
        {
            return result.Take(RawValue);
        }
    }
}
