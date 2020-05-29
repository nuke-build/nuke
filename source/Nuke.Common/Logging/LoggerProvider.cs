using Microsoft.Build.Utilities;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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
            AttachLoggerToCurrentThread(logger);
            return logger;
        }

        internal static void AttachLoggerToCurrentThread(ILogger logger)
        {
            CurrentLoggers.AddOrUpdate(Thread.CurrentThread.ManagedThreadId, logger, (_, _) => logger);
        }

        internal static void RemoveCurrentLogger()
        {
            CurrentLoggers.TryRemove(Thread.CurrentThread.ManagedThreadId, out var _);
        }

        internal static void DetachLogger(ILogger logger)
        {
            CurrentLoggers
                .Where(x => x.Value == logger)
                .ForEach(x => CurrentLoggers.TryRemove(x.Key, out var _));
        }
    }
}
