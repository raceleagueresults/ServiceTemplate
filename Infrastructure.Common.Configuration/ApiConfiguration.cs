using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
