// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class Logger
    {
        [Obsolete("Use Serilog.Log.Write instead")]
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

        [Obsolete]
        public static IDisposable Block(string text)
        {
            return NukeBuild.Host.WriteBlock(text);
        }

        [Obsolete("Use Serilog.Log.Write instead")]
        public static void Log(LogLevel level, string format, params object[] args)
        {
            throw new NotSupportedException();
        }

        [Obsolete("Use Serilog.Log.Write instead")]
        public static void Log(LogLevel level, object value)
        {
            throw new NotSupportedException();
        }

        [Obsolete("Use Serilog.Log.Debug instead")]
        public static void Normal(string format, params object[] args)
        {
            Serilog.Log.Debug(format, args);
        }

        [Obsolete("Use Serilog.Log.Debug instead")]
        public static void Normal(object value)
        {
            Serilog.Log.Debug("{Object}", value);
        }

        [Obsolete("Use Serilog.Log.Debug instead")]
        public static void Normal(string text = null)
        {
            Serilog.Log.Debug(text);
        }

        [Obsolete("Removed")]
        public static void Success(string format, params object[] args)
        {
            throw new NotSupportedException();
        }

        [Obsolete("Removed")]
        public static void Success(object value)
        {
            throw new NotSupportedException();
        }

        [Obsolete("Removed")]
        public static void Success(string text = null)
        {
            throw new NotSupportedException();
        }

        [Obsolete("Use Serilog.Log.Verbose instead")]
        [CodeTemplate(
            searchTemplate: "Trace($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Verbose($args$)",
            ReplaceMessage = "Replace with Serilog")]
        [CodeTemplate(
            searchTemplate: "Logger.Trace($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Verbose($args$)",
            ReplaceMessage = "Replace with Serilog")]
        public static void Trace(string format, params object[] args)
        {
            Serilog.Log.Verbose(format, args);
        }

        [Obsolete("Use Serilog.Log.Verbose instead")]
        [CodeTemplate(
            searchTemplate: "Trace($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Verbose($args$)",
            ReplaceMessage = "Replace with Serilog")]
        [CodeTemplate(
            searchTemplate: "Logger.Trace($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Verbose($args$)",
            ReplaceMessage = "Replace with Serilog")]
        public static void Trace(object value)
        {
            Serilog.Log.Verbose("{Object}", value);
        }

        [Obsolete("Use Serilog.Log.Verbose instead")]
        [CodeTemplate(
            searchTemplate: "Trace($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Verbose($args$)",
            ReplaceMessage = "Replace with Serilog")]
        [CodeTemplate(
            searchTemplate: "Logger.Trace($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Verbose($args$)",
            ReplaceMessage = "Replace with Serilog")]
        public static void Trace(string text = null)
        {
            Serilog.Log.Verbose(text);
        }

        [Obsolete("Use Serilog.Log.Information instead")]
        [CodeTemplate(
            searchTemplate: "Info($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Information($args$)",
            ReplaceMessage = "Replace with Serilog")]
        [CodeTemplate(
            searchTemplate: "Logger.Info($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Information($args$)",
            ReplaceMessage = "Replace with Serilog")]
        public static void Info(string format, params object[] args)
        {
            Serilog.Log.Information(format, args);
        }

        [Obsolete("Use Serilog.Log.Information instead")]
        [CodeTemplate(
            searchTemplate: "Info($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Information($args$)",
            ReplaceMessage = "Replace with Serilog")]
        [CodeTemplate(
            searchTemplate: "Logger.Info($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Information($args$)",
            ReplaceMessage = "Replace with Serilog")]
        public static void Info(object value)
        {
            Serilog.Log.Information("{Object}", value);
        }

        [Obsolete("Use Serilog.Log.Information instead")]
        [CodeTemplate(
            searchTemplate: "Info($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Information($args$)",
            ReplaceMessage = "Replace with Serilog")]
        [CodeTemplate(
            searchTemplate: "Logger.Info($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Information($args$)",
            ReplaceMessage = "Replace with Serilog")]
        public static void Info(string text = null)
        {
            Serilog.Log.Information(text);
        }

        [Obsolete("Use Serilog.Log.Warning instead")]
        [CodeTemplate(
            searchTemplate: "Warn($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Warning($args$)",
            ReplaceMessage = "Replace with Serilog")]
        [CodeTemplate(
            searchTemplate: "Logger.Warn($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Warning($args$)",
            ReplaceMessage = "Replace with Serilog")]
        public static void Warn(string format, params object[] args)
        {
            Serilog.Log.Warning(format, args);
        }

        [Obsolete("Use Serilog.Log.Warning instead")]
        [CodeTemplate(
            searchTemplate: "Warn($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Warning($args$)",
            ReplaceMessage = "Replace with Serilog")]
        [CodeTemplate(
            searchTemplate: "Logger.Warn($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Warning($args$)",
            ReplaceMessage = "Replace with Serilog")]
        public static void Warn(object value)
        {
            Serilog.Log.Warning("{Object}", value);
        }

        [Obsolete("Use Serilog.Log.Warning instead")]
        [CodeTemplate(
            searchTemplate: "Warn($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Warning($args$)",
            ReplaceMessage = "Replace with Serilog")]
        [CodeTemplate(
            searchTemplate: "Logger.Warn($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Warning($args$)",
            ReplaceMessage = "Replace with Serilog")]
        public static void Warn(string text = null)
        {
            Serilog.Log.Warning(text);
        }

        [Obsolete("Use Serilog.Log.Warning instead")]
        [CodeTemplate(
            searchTemplate: "Warn($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Warning($args$)",
            ReplaceMessage = "Replace with Serilog")]
        [CodeTemplate(
            searchTemplate: "Logger.Warn($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Warning($args$)",
            ReplaceMessage = "Replace with Serilog")]
        public static void Warn(Exception exception)
        {
            Serilog.Log.Warning(exception, exception.Message);
        }

        [Obsolete("Use Serilog.Log.Error instead")]
        [CodeTemplate(
            searchTemplate: "Error($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Error($args$)",
            ReplaceMessage = "Replace with Serilog")]
        [CodeTemplate(
            searchTemplate: "Logger.Error($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Error($args$)",
            ReplaceMessage = "Replace with Serilog")]
        public static void Error(string format, params object[] args)
        {
            Serilog.Log.Error(format, args);
        }

        [Obsolete("Use Serilog.Log.Error instead")]
        [CodeTemplate(
            searchTemplate: "Error($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Error($args$)",
            ReplaceMessage = "Replace with Serilog")]
        [CodeTemplate(
            searchTemplate: "Logger.Error($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Error($args$)",
            ReplaceMessage = "Replace with Serilog")]
        public static void Error(object value)
        {
            Serilog.Log.Error("{Object}", value);
        }

        [Obsolete("Use Serilog.Log.Error instead")]
        [CodeTemplate(
            searchTemplate: "Error($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Error($args$)",
            ReplaceMessage = "Replace with Serilog")]
        [CodeTemplate(
            searchTemplate: "Logger.Error($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Error($args$)",
            ReplaceMessage = "Replace with Serilog")]
        public static void Error(string text = null)
        {
            Serilog.Log.Error(text);
        }

        [Obsolete("Use Serilog.Log.Error instead")]
        [CodeTemplate(
            searchTemplate: "Error($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Error($args$)",
            ReplaceMessage = "Replace with Serilog")]
        [CodeTemplate(
            searchTemplate: "Logger.Error($args$)",
            Message = $"WARNING: {nameof(Logger)} is obsolete",
            ReplaceTemplate = "Serilog.Log.Error($args$)",
            ReplaceMessage = "Replace with Serilog")]
        public static void Error(Exception exception)
        {
            Serilog.Log.Error(exception, exception.Message);
        }
    }
}
