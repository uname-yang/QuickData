using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Query.Options
{
    public class SkipQueryOption
    {
        private RawQueryOptions rawValues;

        public int RawValue { get; private set; }

        public SkipQueryOption(string rawValue, RawQueryOptions rawValues)
        {
            this.rawValues = rawValues;
            if (String.IsNullOrEmpty(rawValue))
            {
                throw new Exception(" Skip rawValue is null");
            }
            int tem;
            if (int.TryParse(rawValue, out tem))
            {
                RawValue = tem;
            }
            else
            {
                throw new Exception("Skip rawValue is not a int");
            }


        }

        internal IEnumerable<JToken> ApplyTo(IEnumerable<JToken> result)
        {
            if (rawValues.SkipToken==null||rawValues.SkipToken==String.Empty)
            {
                return result.Skip(RawValue);
            }
            else
            {
                int tem;
                if (int.TryParse(rawValues.SkipToken, out tem))
                {
                    RawValue = tem;
                }
                else
                {
                    throw new Exception("SkipToken rawValue is not a int");
                }

                return result.Skip(RawValue).Take(tem);
            }
           
        }
    }
}
