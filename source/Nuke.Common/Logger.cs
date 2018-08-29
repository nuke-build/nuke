// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.BuildServers;
using Nuke.Common.OutputSinks;

namespace Nuke.Common
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class Logger
    {
        /// <summary>
        /// Provides a logging block for better readability. The actual output is dependent on the executing environment.
        /// <ul>
        ///   <li><b>Console:</b> logs message with figlet font <em>cybermedium</em></li>
        ///   <li><b>TeamCity:</b> calls <see cref="TeamCity.OpenBlock"/> and <see cref="TeamCity.CloseBlock"/></li>
        ///   <li><b>Bitrise:</b> logs message with figlet font <em>ansi-shadow</em></li>
        /// </ul>
        /// </summary>
        /// <returns>
        /// Returns an <see cref="IDisposable"/> which will automatically end the block.
        /// </returns>
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

        /// <summary>
        /// Logs a message unconditionally.
        /// </summary>
        public static T Log<T>(this T obj, Func<T, string> text)
        {
            Log(text(obj));
            return obj;
        }

        #endregion

        #region Trace

        /// <summary>
        /// Logs a message as trace if <see cref="NukeBuild.LogLevel"/> is greater or equal to <see cref="LogLevel.Trace"/>.
        /// </summary>
        [StringFormatMethod("format")]
        public static void Trace(string format, params object[] args)
        {
            Trace(string.Format(format, args));
        }

        /// <summary>
        /// Logs a message as trace if <see cref="NukeBuild.LogLevel"/> is greater or equal to <see cref="LogLevel.Trace"/>.
        /// </summary>
        public static void Trace(object value)
        {
            Trace(value?.ToString());
        }

        /// <summary>
        /// Logs a message as trace if <see cref="NukeBuild.LogLevel"/> is greater or equal to <see cref="LogLevel.Trace"/>.
        /// </summary>
        public static void Trace(string text = null)
        {
            OutputSink.Trace(text ?? string.Empty);
        }

        /// <summary>
        /// Logs a message as trace if <see cref="NukeBuild.LogLevel"/> is greater or equal to <see cref="LogLevel.Trace"/>.
        /// </summary>
        public static T Trace<T>(this T obj, Func<T, string> text)
        {
            Trace(text(obj));
            return obj;
        }

        #endregion

        #region Info

        /// <summary>
        /// Logs a message as information if <see cref="NukeBuild.LogLevel"/> is greater or equal to <see cref="LogLevel.Information"/>.
        /// </summary>
        [StringFormatMethod("format")]
        public static void Info(string format, params object[] args)
        {
            Info(string.Format(format, args));
        }

        /// <summary>
        /// Logs a message as information if <see cref="NukeBuild.LogLevel"/> is greater or equal to <see cref="LogLevel.Information"/>.
        /// </summary>
        public static void Info(object value)
        {
            Info(value?.ToString());
        }

        /// <summary>
        /// Logs a message as information if <see cref="NukeBuild.LogLevel"/> is greater or equal to <see cref="LogLevel.Information"/>.
        /// </summary>
        public static void Info(string text = null)
        {
            OutputSink.Info(text ?? string.Empty);
        }

        /// <summary>
        /// Logs a message as information if <see cref="NukeBuild.LogLevel"/> is greater or equal to <see cref="LogLevel.Information"/>.
        /// </summary>
        public static T Info<T>(this T obj, Func<T, string> text)
        {
            Info(text(obj));
            return obj;
        }

        #endregion

        #region Warn

        /// <summary>
        /// Logs a message as warning if <see cref="NukeBuild.LogLevel"/> is greater or equal to <see cref="LogLevel.Warning"/>.
        /// </summary>
        [StringFormatMethod("format")]
        public static void Warn(string format, params object[] args)
        {
            Warn(string.Format(format, args));
        }

        /// <summary>
        /// Logs a message as warning if <see cref="NukeBuild.LogLevel"/> is greater or equal to <see cref="LogLevel.Warning"/>.
        /// </summary>
        public static void Warn(object value)
        {
            Warn(value?.ToString());
        }

        /// <summary>
        /// Logs a message as warning if <see cref="NukeBuild.LogLevel"/> is greater or equal to <see cref="LogLevel.Warning"/>.
        /// </summary>
        public static void Warn(string text = null)
        {
            OutputSink.Warn(text ?? string.Empty);
        }

        /// <summary>
        /// Logs a message as warning if <see cref="NukeBuild.LogLevel"/> is greater or equal to <see cref="LogLevel.Warning"/>.
        /// </summary>
        public static T Warn<T>(this T obj, Func<T, string> text)
        {
            Warn(text(obj));
            return obj;
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
            OutputSink.Error(text ?? string.Empty);
        }

        /// <summary>
        /// Logs a message as error.
        /// </summary>
        public static T Error<T>(this T obj, Func<T, string> text)
        {
            Error(text(obj));
            return obj;
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

        /// <summary>
        /// Logs a message as Success.
        /// </summary>
        public static T Success<T>(this T obj, Func<T, string> text)
        {
            Success(text(obj));
            return obj;
        }

        #endregion
    }
}
