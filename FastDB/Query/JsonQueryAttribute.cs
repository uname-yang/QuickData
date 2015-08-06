using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FastDB.Query
{
    public class JsonQuery : ActionFilterAttribute
    {
        public JsonQuery()
        {

        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext == null)
            {
                throw new Exception("HttpActionExecutedContext is null");
            }

            HttpRequestMessage request = actionExecutedContext.Request;
            if (request == null)
            {
                throw new Exception("HttpRequestMessage is null");
            }

            HttpConfiguration configuration = request.GetConfiguration();
            if (configuration == null)
            {
                throw new Exception("HttpConfiguration is null");
            }

            if (actionExecutedContext.ActionContext == null)
            {
                throw new Exception("ActionContext is null");
            }

            HttpActionDescriptor actionDescriptor = actionExecutedContext.ActionContext.ActionDescriptor;
            if (actionDescriptor == null)
            {
                throw new Exception("HttpActionDescriptor is null");
            }

            HttpResponseMessage response = actionExecutedContext.Response;

            if (response != null && response.IsSuccessStatusCode && response.Content != null)
            {
                ObjectContent responseContent = response.Content as ObjectContent;
                if (responseContent == null)
                {
                    throw new Exception("responseContent is null");
                }

                if (responseContent.Value != null && request.RequestUri != null)
                {
                    try
                    {
                        object queryResult = ExecuteQuery(responseContent.Value, request, actionDescriptor);
                        if (queryResult == null)
                        {
                            actionExecutedContext.Response = request.CreateResponse(HttpStatusCode.NotFound);
                        }
                        else
                        {
                            responseContent.Value = queryResult;
                        }
                    }
                    catch (Exception e)
                    {
                        actionExecutedContext.Response = request.CreateErrorResponse(
                            HttpStatusCode.BadRequest,
                             e.Message,
                            e);
                        return;
                    }
                }
            }
        }

        private object ExecuteQuery(object response, HttpRequestMessage request, HttpActionDescriptor actionDescriptor)
        {

            JsonQueryOptions queryOptions = new JsonQueryOptions(request);
            ValidateQuery(request);

          //  apply the query
           JArray enumerable = response as JArray;
            if (enumerable == null)
            {
                // response is not a collection; we only support $select on single entities.

                JObject single = response as JObject;
                return ApplyQuery( single,queryOptions);
            }
            else
            {
                // response is a collection.
                return ApplyQuery(enumerable, queryOptions);
            }
        }

        public void ValidateQuery(HttpRequestMessage request)
        {
            IEnumerable<KeyValuePair<string, string>> queryParameters = request.GetQueryNameValuePairs();
            foreach (KeyValuePair<string, string> kvp in queryParameters)
            {
                if (!JsonQueryOptions.IsSystemQueryOption(kvp.Key) &&
                     kvp.Key.StartsWith("$", StringComparison.Ordinal))
                {
                    // we don't support any custom query options that start with $
                    throw new Exception("Is not SystemQueryOption");
                }
            }
        }

        public  JArray ApplyQuery(JArray queryable, JsonQueryOptions queryOptions)
        {
            return queryOptions.ApplyTo(queryable);
        }

        public  JObject ApplyQuery(JObject entity, JsonQueryOptions queryOptions)
        {
            return queryOptions.ApplyTo(entity);
        }
    }
}
