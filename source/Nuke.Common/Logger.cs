// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.OutputSinks;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class Logger
    {
        public static void WriteTest()
        {
            Console.WriteLine("╔═╗");
            Console.WriteLine("║ ║");
            Console.WriteLine("╚═╝");

            Warn("Warn");
            Error("Error");
            Normal("Normal");
            Info("Info");
            Trace("Trace");
            Success("Success");

            const string Esc = "\u001b[";
            const string Reset = "\u001b[0m";

            for (var i = 0; i < 200; i++)
            {
                Console.Write($"{Esc}{i}m{i}{Reset}  ");
                Console.Write($"{Esc}{i};1m{i};1{Reset}  ");
                Console.Write($"{Esc}{i};2m{i};1{Reset}  ");
                Console.Write($"{Esc}{i};3m{i};1{Reset}  ");
                Console.Write($"{Esc}{i};4m{i};1{Reset}  ");
                Console.Write($"{Esc}{i};5m{i};1{Reset}  ");
                if (i % 10 == 0)
                    Console.WriteLine();
            }
        }

        internal static OutputSink OutputSink = OutputSink.Default;

        public static LogLevel LogLevel;

        public static IDisposable Block(string text)
        {
            return OutputSink.WriteBlock(text);
        }

        #region Log

        /// <summary>
        /// Logs a message with <paramref name="level"/> severity if it is lower or equal to <see cref="NukeBuild.LogLevel"/>.
        /// </summary>
        [StringFormatMethod("format")]
        public static void Log(LogLevel level, string format, params object[] args)
        {
            Log(level, string.Format(format, args));
        }

        /// <summary>
        /// Logs a message with <paramref name="level"/> severity if it is lower or equal to <see cref="NukeBuild.LogLevel"/>.
        /// </summary>
        public static void Log(LogLevel level, object value)
        {
            Log(level, value?.ToString());
        }

        /// <summary>
        /// Logs a message with <paramref name="level"/> severity if it is lower or equal to <see cref="NukeBuild.LogLevel"/>.
        /// </summary>
        public static void Log(LogLevel level, string text = null)
        {
            switch (level)
            {
                case LogLevel.Trace:
                    Trace(text);
                    break;
                case LogLevel.Normal:
                    Normal(text);
                    break;
                case LogLevel.Warning:
                    Warn(text);
                    break;
                case LogLevel.Error:
                    Error(text);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level));
            }
        }

        #endregion

        #region Normal

        /// <summary>
        /// Logs a message as information if <see cref="LogLevel"/> is lower or equal to <see cref="Common.LogLevel.Normal"/>.
        /// </summary>
        [StringFormatMethod("format")]
        public static void Normal(string format, params object[] args)
        {
            Normal(string.Format(format, args));
        }

        /// <summary>
        /// Logs a message as information if <see cref="LogLevel"/> is lower or equal to <see cref="Common.LogLevel.Normal"/>.
        /// </summary>
        public static void Normal(object value)
        {
            Normal(value?.ToString());
        }

        /// <summary>
        /// Logs a message as information if <see cref="LogLevel"/> is lower or equal to <see cref="Common.LogLevel.Normal"/>.
        /// </summary>
        public static void Normal(string text = null)
        {
            if (LogLevel <= LogLevel.Normal)
                OutputSink.WriteNormal(text ?? string.Empty);
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
            OutputSink.WriteSuccess(text ?? string.Empty);
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
                OutputSink.WriteTrace(text ?? string.Empty);
        }

        #endregion

        #region Info

        /// <summary>
        /// Logs a message as information if <see cref="LogLevel"/> is lower or equal to <see cref="Common.LogLevel.Normal"/>.
        /// </summary>
        [StringFormatMethod("format")]
        public static void Info(string format, params object[] args)
        {
            Info(string.Format(format, args));
        }

        /// <summary>
        /// Logs a message as information if <see cref="LogLevel"/> is lower or equal to <see cref="Common.LogLevel.Normal"/>.
        /// </summary>
        public static void Info(object value)
        {
            Info(value?.ToString());
        }

        /// <summary>
        /// Logs a message as information if <see cref="LogLevel"/> is lower or equal to <see cref="Common.LogLevel.Normal"/>.
        /// </summary>
        public static void Info(string text = null)
        {
            if (LogLevel <= LogLevel.Normal)
                OutputSink.WriteInformation(text ?? string.Empty);
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
                OutputSink.WriteAndReportWarning(text ?? string.Empty);
        }

        /// <summary>
        /// Logs an exception as warning if <see cref="LogLevel"/> is lower or equal to <see cref="Nuke.Common.LogLevel.Warning"/>.
        /// </summary>
        public static void Warn(Exception exception)
        {
            if (LogLevel <= LogLevel.Warning)
                HandleException(exception, OutputSink.WriteAndReportWarning);
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
                OutputSink.WriteAndReportError(text ?? string.Empty);
        }

        /// <summary>
        /// Logs an exception as error.
        /// </summary>
        public static void Error(Exception exception)
        {
            if (LogLevel <= LogLevel.Error)
                HandleException(exception, OutputSink.WriteAndReportError);
        }

        #endregion

        private static void HandleException(Exception exception, Action<string, string> exceptionOutput, string prefix = null)
        {
            static string GetTrimmedStackTrace(Exception exception)
                => exception.StackTrace.SplitLineBreaks()
                    .Where(x => !x.TrimStart().StartsWith($"at {typeof(ControlFlow).FullName}"))
                    .JoinNewLine();

            switch (exception)
            {
                case AggregateException ex:
                    var exceptions = ex.Flatten().InnerExceptions;
                    exceptions.ForEach((x, i) => HandleException(x, exceptionOutput, $"[{i + 1}/{exceptions.Count}] "));
                    break;
                case TargetInvocationException ex:
                    HandleException(ex.InnerException, exceptionOutput);
                    break;
                case TypeInitializationException ex:
                    HandleException(ex.InnerException, exceptionOutput);
                    break;
                default:
                    exceptionOutput.Invoke(
                        $"{prefix}{exception.GetType().Name}: ".TrimStart("Exception: ") + exception.Message,
                        GetTrimmedStackTrace(exception) + EnvironmentInfo.NewLine);
                    break;
            }
        }
    }
}
