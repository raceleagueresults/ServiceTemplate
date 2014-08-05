using System;
using System.Linq;

namespace Infrastructure.Common.Configuration
{
    public interface IApiConfiguration
    {
        string Version { get; }
    }
}
