using log4net;
using Loggly;
using Microsoft.Practices.Unity.InterceptionExtension;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Logging
{
    public class LoggingInterceptBehavior : IInterceptionBehavior
    {
        private readonly IAppLogger _appLogger;

        public LoggingInterceptBehavior(IAppLogger appLogger)
        {
            _appLogger = appLogger;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            _appLogger.Log(String.Format("Invoking method {0} at {1}", input.MethodBase, DateTime.Now.ToLongTimeString()));

            var result = getNext()(input, getNext);

            if (result.Exception != null)
                _appLogger.Log(String.Format("Method {0} threw exception {1} at {2}", input.MethodBase, result.Exception.Message, DateTime.Now.ToLongTimeString()));
            else
            {
                var returnValue = JsonConvert.SerializeObject(result.ReturnValue);

                _appLogger.Log(String.Format("Method {0} returned {1} at {2}", input.MethodBase, returnValue, DateTime.Now.ToLongTimeString()));
            }
                
            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
