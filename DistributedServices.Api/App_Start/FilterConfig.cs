﻿using DistributedServices.Api.Filters;
using System.Web;
using System.Web.Mvc;

namespace DistributedServices.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // filters.Add(new GeneralExceptionFilterAttribute());
        }
    }
}
