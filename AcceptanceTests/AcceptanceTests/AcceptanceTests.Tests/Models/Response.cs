﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTests.Tests.Models
{
    public class Response<T>
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
