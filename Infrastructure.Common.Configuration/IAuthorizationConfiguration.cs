using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Configuration
{
    public interface IAuthorizationConfiguration
    {
        bool BasicAuthorizationEnabled { get; }
    }
}
