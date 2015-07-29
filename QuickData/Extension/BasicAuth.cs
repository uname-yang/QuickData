using FastDB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace QuickData.Extension
{
    public class BasicAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                HandleUnauthorizedRequest(actionContext);
            }
            else
            {
                string userinfo = Convert.FromBase64String(actionContext.Request.Headers.Authorization.Parameter).ToString();

                //Fastdb.users[]
                if (true)
                {
                    IsAuthorized(actionContext);
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }

        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
        }
    }
}