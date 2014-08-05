using System;
using System.Linq;
using System.Net;

namespace DistributedServices.Api.Helpers
{
    public class Response<T>
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public string Message { get; set; }
        
        public T Data { get; set; }
    }
}