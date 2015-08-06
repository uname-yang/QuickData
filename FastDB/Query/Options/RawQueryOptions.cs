using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Query.Options
{
    public class RawQueryOptions
    {
        /// <summary>
        ///  Gets the raw $filter query value from the incoming request Uri if exists.
        /// </summary>
        public string Where { get; internal set; }

        /// <summary>
        ///  Gets the raw $orderby query value from the incoming request Uri if exists.
        /// </summary>
        public string OrderBy { get; internal set; }

        /// <summary>
        ///  Gets the raw $top query value from the incoming request Uri if exists.
        /// </summary>
        public string Top { get; internal set; }

        /// <summary>
        ///  Gets the raw $skip query value from the incoming request Uri if exists.
        /// </summary>
        public string Skip { get; internal set; }

        /// <summary>
        ///  Gets the raw $skiptoken query value from the incoming request Uri if exists.
        /// </summary>
        public string SkipToken { get; internal set; }
    }
}
