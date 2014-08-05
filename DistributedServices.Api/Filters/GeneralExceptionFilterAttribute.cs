using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace DistributedServices.Api.Filters
{
    public class GeneralExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is Exception)
                actionExecutedContext.Response = new HttpResponseMessage()
                {
                    Content = new StringContent(actionExecutedContext.Exception.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                };
        }
    }
}