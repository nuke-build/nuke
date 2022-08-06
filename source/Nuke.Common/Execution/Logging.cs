// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.CI;
using Nuke.Common.Execution.Theming;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog.Sinks.SystemConsole.Themes;

namespace Nuke.Common.Execution
{
    [PublicAPI]
    public static class Logging
    {
        public static readonly LoggingLevelSwitch LevelSwitch = new LoggingLevelSwitch();

        internal static bool SupportsAnsiOutput => Environment.GetEnvironmentVariable("TERM") is { } term && term.StartsWithOrdinalIgnoreCase("xterm");
        internal static IHostTheme DefaultTheme { get; } = SupportsAnsiOutput
                ? AnsiConsoleHostTheme.Default256AnsiColorTheme
                : SystemConsoleHostTheme.DefaultSystemColorTheme;

        internal static string ErrorsAndWarningsOutputTemplate => "[{Level:u3}] {ExecutingTarget}: {Message:l}{NewLine}";
        internal static string StandardOutputTemplate => "[{Level:u3}] {Message:l}{NewLine}{Exception}";
        internal static string TimestampOutputTemplate => $"{{Timestamp:HH:mm:ss}} {StandardOutputTemplate}";

        private const int TargetNameLength = 20;

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
            if (NukeBuild.IsInterceptorExecution)
            {
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console(new CompactJsonFormatter())
                    .CreateLogger();
                return;
            }

            if (build != null)
                DeleteOldLogFiles();

            Log.Logger = new LoggerConfiguration()
                .Enrich.With<ExecutingTargetLogEventEnricher>()
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
                .WriteTo.Console(outputTemplate: build != null && build.IsOutputEnabled(DefaultOutput.Timestamps)
                        ? NukeBuild.Host.OutputTemplate
                        : StandardOutputTemplate,
                    theme: (ConsoleTheme)(build != null ? NukeBuild.Host.Theme : DefaultTheme),
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
            return configuration
                .WriteTo.File(
                    path: buildLogFile,
                    outputTemplate: $"{{Timestamp:HH:mm:ss.fff}} | {{Level:u1}} | {{ExecutingTarget,-{TargetNameLength}}} | {{Message:l}}{{NewLine}}{{Exception}}")
                .WriteTo.File(
                    path: Path.ChangeExtension(buildLogFile, $".{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.log"),
                    outputTemplate: $"{{Level:u1}} | {{ExecutingTarget,-{TargetNameLength}}} | {{Message:l}}{{NewLine}}{{Exception}}");
        }

        private static void DeleteOldLogFiles()
        {
            if (BuildServerConfigurationGeneration.IsActive)
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
            return ExecutingTargetLogEventEnricher.SetTargetEventProperty(name);
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
                logEvent.AddOrUpdateProperty(ExecutingTargetLogEventEnricher.Current);
                _logEvents.Add(logEvent);
            }

            public void Dispose()
            {
                _logEvents.Clear();
            }
        }

        internal class ExecutingTargetLogEventEnricher : ILogEventEnricher
        {
            public static LogEventProperty Current => s_property ?? s_defaultProperty;

            private static readonly LogEventProperty s_defaultProperty = GetTargetEventProperty(string.Empty);
            private static LogEventProperty s_property;

            public static IDisposable SetTargetEventProperty(string name)
            {
                return DelegateDisposable.CreateBracket(
                    () => s_property = GetTargetEventProperty(name),
                    () => s_property = null);
            }

            private static LogEventProperty GetTargetEventProperty(string name)
            {
                var paddedName = name.Substring(startIndex: 0, Math.Min(name.Length, TargetNameLength));
                return new LogEventProperty("ExecutingTarget", new ScalarValue(paddedName));
            }

            public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
            {
                logEvent.AddOrUpdateProperty(Current);
            }
        }
    }
}
