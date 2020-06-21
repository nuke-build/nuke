using System.Threading;

namespace Nuke.Common.Logging
{
    internal static class LoggerProvider
    {
        private static AsyncLocal<ILogger> CurrentLogger = new AsyncLocal<ILogger>();

        public static bool AutoFlush { get; set; } = true;

        internal static ILogger GetCurrentLogger()
        {
            return CurrentLogger.Value ??= new InMemoryLogger(Logger.LogLevel, Logger.OutputSink, AutoFlush);
        }

        internal static void RemoveCurrentLogger()
        {
            CurrentLogger.Value = null;
        }
    }
}
