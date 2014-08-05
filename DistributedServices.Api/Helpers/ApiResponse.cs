using System;
using System.Linq;
using System.Net;

namespace DistributedServices.Api.Helpers
{
    public static class ApiResponse<T> where T : class
    {
        public static  Response<T> Success(T data)
        {
            return new Response<T>
            {
                HttpStatusCode = HttpStatusCode.OK,
                Message = "Success",
                Data = data
            };
        }

        public static Response<T> NotFound(string message)
        {
            return new Response<T>
            {
                HttpStatusCode = HttpStatusCode.NotFound,
                Message = message,
                Data = null
            };
        }

        public static Response<T> BadRequest(string message)
        {
            return new Response<T>
            {
                HttpStatusCode = HttpStatusCode.BadRequest,
                Message = message,
                Data = null
            };
        }

        public static Response<T> InternalServerError(string message)
        {
            return new Response<T>
            {
                HttpStatusCode = HttpStatusCode.InternalServerError,
                Message = message,
                Data = null
            };
        }
    }
}