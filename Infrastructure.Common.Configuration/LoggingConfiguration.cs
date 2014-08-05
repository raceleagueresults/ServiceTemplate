using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Configuration
{
    public class LoggingConfiguration : Infrastructure.Common.Configuration.ILoggingConfiguration
    {
        public string LogglyKey { get { return ConfigurationManager.AppSettings["LogglyKey"]; } }
    }
}
