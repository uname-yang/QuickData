using FastDB.Query.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace FastDB.Query
{
    public  class JsonQueryOptions
    {
        public JsonQueryOptions( HttpRequestMessage request)
        {
            if (request == null)
            {
                throw new Exception("request is null");
            }

            // remember the context and request
            Request = request;

            // Parse the query from request Uri
            RawValues = new RawQueryOptions();
            IEnumerable<KeyValuePair<string, string>> queryParameters = request.GetQueryNameValuePairs();
            foreach (KeyValuePair<string, string> kvp in queryParameters)
            {
                switch (kvp.Key)
                {
                    case "$where":
                        RawValues.Where = kvp.Value;
                        ThrowIfEmpty(kvp.Value, "$where");
                        Where = new FilterQueryOption(kvp.Value);
                        break;
                    case "$orderby":
                        RawValues.OrderBy = kvp.Value;
                        ThrowIfEmpty(kvp.Value, "$orderby");
                        OrderBy = new OrderByQueryOption(kvp.Value);
                        break;
                    case "$top":
                        RawValues.Top = kvp.Value;
                        ThrowIfEmpty(kvp.Value, "$top");
                        Top = new TopQueryOption(kvp.Value);
                        break;
                    case "$skip":
                        RawValues.Skip = kvp.Value;
                        ThrowIfEmpty(kvp.Value, "$skip");
                        Skip = new SkipQueryOption(kvp.Value, RawValues);
                        break;
                    case "$skiptoken":
                        RawValues.SkipToken = kvp.Value;
                        break;
                    default:
                        // we don't throw if we can't recognize the query
                        break;
                }
            }
        }

        public HttpRequestMessage Request { get; private set; }

        public RawQueryOptions RawValues { get; private set; }

        public FilterQueryOption Where { get; private set; }

        public OrderByQueryOption OrderBy { get; private set; }

        public SkipQueryOption Skip { get; private set; }

        public TopQueryOption Top { get; private set; }



        private static void ThrowIfEmpty(string queryValue, string queryName)
        {
            if (String.IsNullOrWhiteSpace(queryValue))
            {
                throw new Exception("queryValue is empty");
            }
        }

        public static bool IsSystemQueryOption(string queryOptionName)
        {
            return queryOptionName == "$orderby" ||
                 queryOptionName == "$where" ||
                 queryOptionName == "$top" ||
                 queryOptionName == "$skip" ||
                 queryOptionName == "$skiptoken";
        }

        public JObject ApplyTo(JObject query)
        {
            JObject entity = query;
            if( OrderBy != null || Top != null || Skip != null)
            {
                throw new Exception("Only support $select on single entities.");
            }

            if (Where != null)
            {
                return (JObject)Where.ApplyTo(entity);
            }

            return entity;
        }

        public  JArray ApplyTo(JArray query)
        {
            IEnumerable<JToken> result= query;

            // Construct the actual query and apply them in the following order: filter, orderby, skip, top
            if (Where != null)
            {
                result = Where.ApplyTo(result);
            }

            if (OrderBy != null)
            {
                result = OrderBy.ApplyTo(result);
            }

            if (Skip != null)
            {
                result = Skip.ApplyTo(result);
            }

            if (Top != null)
            {
                result = Top.ApplyTo(result);
            }

            return JArray.FromObject(result);
        }
    }
}
