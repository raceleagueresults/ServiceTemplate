using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Configuration
{
    public class CacheConfiguration : ICacheConfiguration
    {
        public DateTimeOffset CacheExpiration
        {
            get
            {
                var cacheExpiration = ConfigurationManager.AppSettings["CacheExpiration"];

                var minutes = cacheExpiration == "" ? 0 : int.Parse(cacheExpiration);

                var expiration = DateTimeOffset.Now.AddMinutes(minutes);

                return expiration;
            }
        }
    }
}
