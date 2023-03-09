// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Nuke.Common.Execution;
using Nuke.Common.Execution.Theming;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace Nuke.Common
{
    [TypeConverter(typeof(TypeConverter))]
    public partial class Host
    {
        protected Host()
        {
            // TODO: check assertion
            // ControlFlow.Assert(Instance == null, "Instance == null");
            Instance = this;
        }

        internal virtual IHostTheme Theme => Logging.DefaultTheme;

        internal virtual string OutputTemplate => Logging.TimestampOutputTemplate;

        protected internal void WriteLogo()
        {
            Debug();
            new[]
            {
                "███╗   ██╗██╗   ██╗██╗  ██╗███████╗",
                "████╗  ██║██║   ██║██║ ██╔╝██╔════╝",
                "██╔██╗ ██║██║   ██║█████╔╝ █████╗  ",
                "██║╚██╗██║██║   ██║██╔═██╗ ██╔══╝  ",
                "██║ ╚████║╚██████╔╝██║  ██╗███████╗",
                "╚═╝  ╚═══╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝"
            }.ForEach(x => Debug(x.Replace(" ", " ")));
            Debug();
        }

        protected internal virtual IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () =>
                {
                    var formattedBlockText = text
                        .Split(new[] { EnvironmentInfo.NewLine }, StringSplitOptions.None)
                        .Select(Theme.FormatInformation);

                    Debug();
                    Debug("╬" + '═'.Repeat(text.Length + 5));
                    formattedBlockText.ForEach(x => Debug($"║ {x}"));
                    Debug("╬" + '═'.Repeat(Math.Max(text.Length - 4, 2)));
                    Debug();
                });
        }

        protected internal virtual void ReportWarning(string text, string details = null)
        {
        }

        protected internal virtual void ReportError(string text, string details = null)
        {
        }

        protected internal virtual bool FilterMessage(string message)
        {
            return false;
        }

        protected internal virtual void WriteErrorsAndWarnings()
        {
            if (Logging.InMemorySink.Instance.LogEvents.Count == 0)
                return;

            // TODO: move to Logging
            using (WriteBlock("Errors & Warnings"))
            {
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console(
                        outputTemplate: Logging.ErrorsAndWarningsOutputTemplate,
                        theme: (ConsoleTheme)Theme,
                        applyThemeToRedirectedOutput: true)
                    .CreateLogger();

                var nonEmptyLogEvents = Logging.InMemorySink.Instance.LogEvents.Where(x => !x.MessageTemplate.Text.IsNullOrEmpty());
                nonEmptyLogEvents.ForEach(Log.Write);
            }
        }

        protected internal virtual void WriteTargetOutcome(INukeBuild build)
        {
            var firstColumn = Math.Max(build.ExecutionPlan.Max(x => x.Name.Length) + 4, val2: 19);
            var secondColumn = 10;
            var thirdColumn = 10;
            var allColumns = firstColumn + secondColumn + thirdColumn;
            var totalDuration = build.ExecutionPlan.Aggregate(TimeSpan.Zero, (t, x) => t.Add(x.Duration));

            string CreateLine(string target, string executionStatus, string duration, string information = null)
                => target.PadRight(firstColumn, paddingChar: ' ')
                   + executionStatus.PadRight(secondColumn, paddingChar: ' ')
                   + duration.PadLeft(thirdColumn, paddingChar: ' ')
                   + (information != null ? $"   // {information}" : string.Empty);

            static string GetDurationOrBlank(ExecutableTarget target)
                => target.Status == ExecutionStatus.Succeeded ||
                   target.Status == ExecutionStatus.Failed ||
                   target.Status == ExecutionStatus.Aborted
                    ? GetDuration(target.Duration)
                    : string.Empty;

            static string GetDuration(TimeSpan duration)
                => $"{(int)duration.TotalMinutes}:{duration:ss}".Replace("0:00", "< 1sec");

            static string GetInformation(ExecutableTarget target)
                => target.SummaryInformation.Any()
                    ? target.SummaryInformation.Select(x => $"{x.Key}: {x.Value}").JoinCommaSpace()
                    : null;

            Debug();
            Debug('═'.Repeat(allColumns));
            Information(CreateLine("Target", "Status", "Duration"));
            //WriteInformationInternal($"{{0,-{firstColumn}}}{{1,-{secondColumn}}}{{2,{thirdColumn}}}{{3,1}}", "Target", "Status", "Duration", "Test");
            Debug('─'.Repeat(allColumns));
            foreach (var target in build.ExecutionPlan)
            {
                var line = CreateLine(target.Name, target.Status.ToString(), GetDurationOrBlank(target), GetInformation(target));
                switch (target.Status)
                {
                    case ExecutionStatus.Skipped:
                        Debug(line);
                        break;
                    case ExecutionStatus.Succeeded:
                        Success(line);
                        break;
                    case ExecutionStatus.Aborted:
                    case ExecutionStatus.NotRun:
                        Warning(line);
                        break;
                    case ExecutionStatus.Failed:
                        Error(line);
                        break;
                    case ExecutionStatus.Collective:
                        break;
                    default:
                        throw new NotSupportedException(target.Status.ToString());
                }
            }

            Debug('─'.Repeat(allColumns));
            Information(CreateLine("Total", string.Empty, GetDuration(totalDuration)));
            Debug('═'.Repeat(allColumns));
        }

        protected internal virtual void WriteBuildOutcome(INukeBuild build)
        {
            Debug();
            if (build.IsSuccessful)
                Success($"Build succeeded on {DateTime.Now.ToString(CultureInfo.CurrentCulture)}. ＼（＾ᴗ＾）／");
            else
                Error($"Build failed on {DateTime.Now.ToString(CultureInfo.CurrentCulture)}. (╯°□°）╯︵ ┻━┻");
        }

        internal class LogEventSink : ILogEventSink
        {
            private readonly Host _host;

            public LogEventSink(Host host)
            {
                _host = host;
            }

            public void Emit(LogEvent logEvent)
            {
                if (logEvent.Level == LogEventLevel.Warning)
                    _host.ReportWarning(logEvent.RenderMessage());
                else if (logEvent.Level == LogEventLevel.Error)
                    _host.ReportError(logEvent.RenderMessage());
            }
        }
    }
}
