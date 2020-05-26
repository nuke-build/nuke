using System;
using System.Collections.Generic;
using System.Text;

namespace Nuke.Common.Logging
{
    internal struct LogEntry
    {
        public LogLevel Level { get; }

        public string Message { get; }

        public Exception Exception { get; }

        public LogEntry(LogLevel level, string message = null, Exception exception = null)
        {
            Level = level;
            Message = message;
            Exception = exception;
        }
    }
}
