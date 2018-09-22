// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.OutputSinks;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class Logger
    {
        public static IOutputSink OutputSink = new ConsoleOutputSink();
        public static LogLevel LogLevel = LogLevel.Information;
        
        public static IDisposable Block(string text)
        {
            return OutputSink.WriteBlock(text);
        }

        #region Log

        /// <summary>
        /// Logs a message unconditionally.
        /// </summary>
        [StringFormatMethod("format")]
        public static void Log(string format, params object[] args)
        {
            Log(string.Format(format, args));
        }

        /// <summary>
        /// Logs a message unconditionally.
        /// </summary>
        public static void Log(object value)
        {
            Log(value?.ToString());
        }

        /// <summary>
        /// Logs a message unconditionally.
        /// </summary>
        public static void Log(string text = null)
        {
            OutputSink.Write(text ?? string.Empty);
        }

        #endregion
        
        #region Success

        /// <summary>
        /// Logs a message as Success.
        /// </summary>
        [StringFormatMethod("format")]
        public static void Success(string format, params object[] args)
        {
            Success(string.Format(format, args));
        }

        /// <summary>
        /// Logs a message as Success.
        /// </summary>
        public static void Success(object value)
        {
            Success(value?.ToString());
        }

        /// <summary>
        /// Logs a message as Success.
        /// </summary>
        public static void Success(string text = null)
        {
            OutputSink.Success(text ?? string.Empty);
        }

        #endregion

        #region Trace

        /// <summary>
        /// Logs a message as trace if <see cref="LogLevel"/> is equal to <see cref="Nuke.Common.LogLevel.Trace"/>.
        /// </summary>
        [StringFormatMethod("format")]
        public static void Trace(string format, params object[] args)
        {
            Trace(string.Format(format, args));
        }

        /// <summary>
        /// Logs a message as trace if <see cref="LogLevel"/> is equal to <see cref="Nuke.Common.LogLevel.Trace"/>.
        /// </summary>
        public static void Trace(object value)
        {
            Trace(value?.ToString());
        }

        /// <summary>
        /// Logs a message as trace if <see cref="LogLevel"/> is equal to <see cref="Nuke.Common.LogLevel.Trace"/>.
        /// </summary>
        public static void Trace(string text = null)
        {
            if (LogLevel <= LogLevel.Trace)
                OutputSink.Trace(text ?? string.Empty);
        }

        #endregion

        #region Info

        /// <summary>
        /// Logs a message as information if <see cref="LogLevel"/> is lower or equal to <see cref="Nuke.Common.LogLevel.Information"/>.
        /// </summary>
        [StringFormatMethod("format")]
        public static void Info(string format, params object[] args)
        {
            Info(string.Format(format, args));
        }

        /// <summary>
        /// Logs a message as information if <see cref="LogLevel"/> is lower or equal to <see cref="Nuke.Common.LogLevel.Information"/>.
        /// </summary>
        public static void Info(object value)
        {
            Info(value?.ToString());
        }

        /// <summary>
        /// Logs a message as information if <see cref="LogLevel"/> is lower or equal to <see cref="Nuke.Common.LogLevel.Information"/>.
        /// </summary>
        public static void Info(string text = null)
        {
            if (LogLevel <= LogLevel.Information)
                OutputSink.Info(text ?? string.Empty);
        }

        #endregion

        #region Warn

        /// <summary>
        /// Logs a message as warning if <see cref="LogLevel"/> is lower or equal to <see cref="Nuke.Common.LogLevel.Warning"/>.
        /// </summary>
        [StringFormatMethod("format")]
        public static void Warn(string format, params object[] args)
        {
            Warn(string.Format(format, args));
        }

        /// <summary>
        /// Logs a message as warning if <see cref="LogLevel"/> is lower or equal to <see cref="Nuke.Common.LogLevel.Warning"/>.
        /// </summary>
        public static void Warn(object value)
        {
            Warn(value?.ToString());
        }

        /// <summary>
        /// Logs a message as warning if <see cref="LogLevel"/> is lower or equal to <see cref="Nuke.Common.LogLevel.Warning"/>.
        /// </summary>
        public static void Warn(string text = null)
        {
            if (LogLevel <= LogLevel.Warning)
                OutputSink.Warn(text ?? string.Empty);
        }

        /// <summary>
        /// Logs an exception as warning if <see cref="LogLevel"/> is lower or equal to <see cref="Nuke.Common.LogLevel.Warning"/>.
        /// </summary>
        public static void Warn(Exception exception)
        {
            if (LogLevel <= LogLevel.Warning)
                HandleException(exception, OutputSink.Warn);
        }
        
        #endregion

        #region Error

        /// <summary>
        /// Logs a message as error.
        /// </summary>
        [StringFormatMethod("format")]
        public static void Error(string format, params object[] args)
        {
            Error(string.Format(format, args));
        }

        /// <summary>
        /// Logs a message as error.
        /// </summary>
        public static void Error(object value)
        {
            Error(value?.ToString());
        }

        /// <summary>
        /// Logs a message as error.
        /// </summary>
        public static void Error(string text = null)
        {
            if (LogLevel <= LogLevel.Error)
                OutputSink.Error(text ?? string.Empty);
        }

        /// <summary>
        /// Logs an exception as error.
        /// </summary>
        public static void Error(Exception exception)
        {
            if (LogLevel <= LogLevel.Error)
                HandleException(exception, OutputSink.Error);
        }

        #endregion

        private static void HandleException(Exception exception, Action<string, string> exceptionOutput)
        {
            switch (exception)
            {
                case AggregateException ex:
                    ex.Flatten().InnerExceptions.ForEach(x => HandleException(x, exceptionOutput));
                    break;
                case TargetInvocationException ex:
                    HandleException(ex.InnerException, exceptionOutput);
                    break;
                case TypeInitializationException ex:
                    HandleException(ex.InnerException, exceptionOutput);
                    break;
                default:
                    exceptionOutput(exception.Message, exception.StackTrace);
                    break;
            }
        }

    }
}
