using System;

namespace Nuke.Common.Logging
{
    internal interface ILogger
    {
        void Error(string text = null);
        void Error(Exception exception);
        void Info(string text = null);
        void Log(LogLevel level, string text = null, Exception exception = null);
        void Normal(string text = null);
        void Trace(string text = null);
        void Warn(string text = null);
        void Warn(Exception exception);

        void Flush();
        string PeekLastMessage();
    }
}
