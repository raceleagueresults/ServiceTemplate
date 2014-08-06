﻿using DistributedServices.Api.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DistributedServices.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // config.Filters.Add((BasicAuthorizationFilter)config.DependencyResolver.GetService(typeof(BasicAuthorizationFilter)));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
