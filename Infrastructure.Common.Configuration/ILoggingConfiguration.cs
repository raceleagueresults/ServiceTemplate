using System;
namespace Infrastructure.Common.Configuration
{
    public interface ILoggingConfiguration
    {
        string LogglyKey { get; }
    }
}
