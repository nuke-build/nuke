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

        public static bool AutoFlush { get; set; } = true;

        internal static ILogger GetCurrentLogger()
        {
            return CurrentLoggers.GetOrAdd(
                Thread.CurrentThread.ManagedThreadId,
                _ => new InMemoryLogger(Logger.LogLevel, Logger.OutputSink, AutoFlush)
                );
        }

        internal static ILogger CreateLogger(bool autoFlush = true)
        {
            var logger = new InMemoryLogger(Logger.LogLevel, Logger.OutputSink, autoFlush);
            if (AttachLoggerToCurrentThread(logger))
                return logger;

            return null;
        }

        internal static bool AttachLoggerToCurrentThread(ILogger logger)
        {
            return CurrentLoggers.TryAdd(Thread.CurrentThread.ManagedThreadId, logger);
        }

        internal static void RemoveCurrentLogger()
        {
            CurrentLoggers.TryRemove(Thread.CurrentThread.ManagedThreadId, out var _);
        }
    }
}
