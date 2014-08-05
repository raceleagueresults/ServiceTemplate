using Infrastructure.Common.Configuration;
using Loggly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Logging
{
    public class AppLogger : Infrastructure.Common.Logging.IAppLogger
    {
        private readonly string _logglyKey;

        private readonly Logger _logger;

        public AppLogger(ILoggingConfiguration loggingConfiguration)
        {
            _logglyKey = loggingConfiguration.LogglyKey;

            _logger = new Logger(_logglyKey);
        }

        public void Log(string text)
        {
            _logger.LogInfo(text);
        }
    }
}
