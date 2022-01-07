// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.CI;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace Nuke.Common.Execution
{
    [PublicAPI]
    public static class Logging
    {
        public static readonly LoggingLevelSwitch LevelSwitch = new LoggingLevelSwitch();

        public static LogLevel Level
        {
            get => LevelSwitch.MinimumLevel switch
            {
                LogEventLevel.Verbose => LogLevel.Trace,
                LogEventLevel.Debug => LogLevel.Normal,
                LogEventLevel.Warning => LogLevel.Warning,
                LogEventLevel.Error => LogLevel.Error,
                _ => throw new ArgumentOutOfRangeException(nameof(LevelSwitch), LevelSwitch.MinimumLevel, message: null)
            };
            set => LevelSwitch.MinimumLevel = value switch
            {
                LogLevel.Trace => LogEventLevel.Verbose,
                LogLevel.Normal => LogEventLevel.Debug,
                LogLevel.Warning => LogEventLevel.Warning,
                LogLevel.Error => LogEventLevel.Error,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, message: null)
            };
        }

        public static void Configure(NukeBuild build = null)
        {
            if (build != null)
                DeleteOldLogFiles();

            Log.Logger = new LoggerConfiguration()
                .Enrich.With<TargetLogEventEnricher>()
                .ConfigureHost(build)
                .ConfigureConsole(build)
                .ConfigureInMemory(build)
                .ConfigureFiles(build)
                .ConfigureLevel()
                .ConfigureFilter()
                .CreateLogger();
        }

        public static LoggerConfiguration ConfigureLevel(this LoggerConfiguration configuration)
        {
            return configuration.MinimumLevel.Verbose();
        }

        public static LoggerConfiguration ConfigureFilter(this LoggerConfiguration configuration)
        {
            return configuration.Filter.ByExcluding(x => NukeBuild.Host.FilterMessage(x.MessageTemplate.Text));
        }

        public static LoggerConfiguration ConfigureConsole(this LoggerConfiguration configuration, [CanBeNull] NukeBuild build)
        {
            return configuration
                .WriteTo.Console(
                    outputTemplate: build != null ? NukeBuild.Host.OutputTemplate : Host.DefaultOutputTemplate,
                    theme: (ConsoleTheme)(build != null ? NukeBuild.Host.Theme : Host.DefaultTheme),
                    applyThemeToRedirectedOutput: true,
                    levelSwitch: LevelSwitch);
        }

        public static LoggerConfiguration ConfigureHost(this LoggerConfiguration configuration, [CanBeNull] NukeBuild build)
        {
            if (build == null)
                return configuration;

            return configuration
                .WriteTo.Sink<Host.LogEventSink>(restrictedToMinimumLevel: LogEventLevel.Warning);
        }

        public static LoggerConfiguration ConfigureInMemory(this LoggerConfiguration configuration, [CanBeNull] NukeBuild build)
        {
            if (build == null)
                return configuration;

            return configuration
                .WriteTo.Sink(InMemorySink.Instance, LogEventLevel.Warning);
        }

        public static LoggerConfiguration ConfigureFiles(this LoggerConfiguration configuration, [CanBeNull] NukeBuild build)
        {
            if (build == null || NukeBuild.Host is IBuildServer)
                return configuration;

            var buildLogFile = NukeBuild.TemporaryDirectory / "build.log";
            var targetPadding = build.TargetNames.Max(x => x.Length);
            return configuration
                .WriteTo.File(
                    path: buildLogFile,
                    outputTemplate: $"{{Timestamp:HH:mm:ss.fff}} | {{Level:u1}} | {{Target,{targetPadding}}} | {{Message:l}}{{NewLine}}{{Exception}}")
                .WriteTo.File(
                    path: Path.ChangeExtension(buildLogFile, $".{DateTime.Now:s}.log"),
                    outputTemplate: $"{{Level:u1}} | {{Target,{targetPadding}}} | {{Message:l}}{{NewLine}}{{Exception}}");
        }

        private static void DeleteOldLogFiles()
        {
            var configurationId = EnvironmentInfo.GetParameter<string>(BuildServerConfigurationGenerationAttributeBase.ConfigurationParameterName);
            if (configurationId != null)
                return;

            NukeBuild.TemporaryDirectory.GlobFiles("build.*.log").OrderByDescending(x => x.ToString()).Skip(5)
                .ForEach(FileSystemTasks.DeleteFile);

            var buildLogFile = NukeBuild.TemporaryDirectory / "build.log";
            if (File.Exists(buildLogFile))
            {
                using var filestream = File.OpenWrite(buildLogFile);
                filestream.SetLength(0);
            }
        }

        internal static void Test()
        {
            const string Esc = "\u001b[";
            const string Reset = "\u001b[0m";

            for (var i = 30; i < 47; i++)
                Console.Write($"{Esc}{i}m{i}  {Reset} ");
            Console.WriteLine();
            for (var i = 30; i < 47; i++)
                Console.Write($"{Esc}{i};1m{i};1{Reset} ");
            Console.WriteLine();
            for (var i = 30; i < 47; i++)
                Console.Write($"{Esc}{i};2m{i};2{Reset} ");
            Console.WriteLine();
            for (var i = 30; i < 47; i++)
                Console.Write($"{Esc}{i};3m{i};2{Reset} ");
            Console.WriteLine();

            for (var i = 90; i < 107; i++)
                Console.Write($"{Esc}{i}m{i}  {Reset} ");
            Console.WriteLine();
            for (var i = 90; i < 107; i++)
                Console.Write($"{Esc}{i};1m{i};1{Reset} ");
            Console.WriteLine();
            for (var i = 90; i < 107; i++)
                Console.Write($"{Esc}{i};2m{i};2{Reset} ");
            Console.WriteLine();
            for (var i = 90; i < 107; i++)
                Console.Write($"{Esc}{i};3m{i};2{Reset} ");
            Console.WriteLine();

            for (var i = 0; i < 255; i++)
            {
                var code = i.ToString().PadLeft(3, '0');
                Console.Write($"{Esc}38;5;{code}m{code}{Reset} ");
                if ((i + 1) % 16 == 0)
                    Console.WriteLine();
            }

            Console.WriteLine();

            for (var i = 0; i <= 255; i++)
            {
                var code = i.ToString().PadLeft(3, '0');
                Console.Write($"{Esc}38;5;{code};1m{code}{Reset} ");
                if ((i + 1) % 16 == 0)
                    Console.WriteLine();
            }
        }

        public static IDisposable SetTarget(string name)
        {
            return DelegateDisposable.CreateBracket(
                () => TargetLogEventEnricher.Property = new LogEventProperty("Target", new ScalarValue(name)),
                () => TargetLogEventEnricher.Property = null);
        }

        public class InMemorySink : ILogEventSink, IDisposable
        {
            public static InMemorySink Instance { get; } = new InMemorySink();

            private readonly List<LogEvent> _logEvents;

            private InMemorySink()
            {
                _logEvents = new List<LogEvent>();
            }

            public IReadOnlyCollection<LogEvent> LogEvents => _logEvents.AsReadOnly();

            public void Emit(LogEvent logEvent)
            {
                logEvent.AddOrUpdateProperty(TargetLogEventEnricher.Current);
                _logEvents.Add(logEvent);
            }

            public void Dispose()
            {
                _logEvents.Clear();
            }
        }

        internal class TargetLogEventEnricher : ILogEventEnricher
        {
            private static LogEventProperty s_defaultProperty = new LogEventProperty("Target", new ScalarValue(""));

            public  static LogEventProperty Property;

            public static LogEventProperty Current => Property ?? s_defaultProperty;

            public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
            {
                logEvent.AddOrUpdateProperty(Current);
            }
        }
    }
}
