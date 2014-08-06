using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Configuration
{
    public class AuthorizationConfiguration : IAuthorizationConfiguration
    {
        public bool BasicAuthorizationEnabled
        {
            get { return ConfigurationManager.AppSettings["BasicAuthorizationEnabled"].ToLower() == "true"; }
        }
    }
}
