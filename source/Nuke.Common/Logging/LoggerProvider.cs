using Microsoft.Build.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Nuke.Common.Logging
{
    internal static class LoggerProvider
    {
        private static ConcurrentDictionary<int, ILogger> CurrentLoggers { get; } = new ConcurrentDictionary<int, ILogger>();

        internal static ILogger GetCurrentLogger()
        {
            if (CurrentLoggers.TryGetValue(Thread.CurrentThread.ManagedThreadId, out var logger))
                return logger;

            return null;
        }

        internal static ILogger CreateLogger(bool autoFlush)
        {
            var logger = new InMemoryLogger(Logger.LogLevel, Logger.OutputSink, autoFlush);
            if (CurrentLoggers.TryAdd(Thread.CurrentThread.ManagedThreadId, logger))
                return logger;

            return null;
        }
    }
}
