using System;
namespace Infrastructure.Common.Logging
{
    public interface IAppLogger
    {
        void Log(string text);
    }
}
