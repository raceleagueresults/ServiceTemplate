using System;
using System.Configuration;
using System.Linq;

namespace Infrastructure.Common.Configuration
{
    public class ApiConfiguration : IApiConfiguration
    {
        public string Version
        {
            get
            {
                return ConfigurationManager.AppSettings["ApiVersion"] ?? "v1";
            }
        }
    }
}
