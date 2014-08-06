using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace DistributedServices.Api.Filters
{
    public class BasicAuthorizationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var user = string.Empty;

            var password = string.Empty;

            var auth = actionContext.Request.Headers.Authorization;

            if (auth != null && auth.Scheme == "Basic")
            {
                user = auth.Parameter.Substring(0, auth.Parameter.IndexOf(":"));

                password = auth.Parameter.Substring(auth.Parameter.IndexOf(":") + 1, auth.Parameter.Length - auth.Parameter.IndexOf(":") - 1);
            }
            
            base.OnAuthorization(actionContext);
        }
    }
}