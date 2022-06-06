// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
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

        internal virtual string OutputTemplate => DefaultOutputTemplate;

        protected internal void WriteLogo()
        {
            Debug();
            new[]
            {
                "████   ████ █████  ████ █████  ████ ███████████",
                " █████  ██   ███    ██   ███  ███    ███     ▀▀",
                " ██ ██████   ███    ██   ██████      ███████",
                " ██   ████   ███    ██   ███  ███    ███     ▄▄",
                "████    ███   ███████   █████  ████ ███████████",
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
                    Debug("╬" + new string(c: '═', text.Length + 5));
                    formattedBlockText.ForEach(x => Debug($"║ {x}"));
                    Debug("╬" + new string(c: '═', Math.Max(text.Length - 4, 2)));
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

        internal virtual void WriteSummary(NukeBuild build)
        {
            WriteSevereLogEvents(Logging.InMemorySink.Instance.LogEvents);
            WriteSummaryTable(build);

            if (build.IsSuccessful)
                WriteSuccessfulBuild(build);
            else
                WriteFailedBuild();
        }

        protected virtual void WriteSevereLogEvents(IReadOnlyCollection<LogEvent> instanceLogEvents)
        {
            if (instanceLogEvents.Count == 0)
                return;

            // TODO: move to Logging
            using (WriteBlock("Warnings & Errors"))
            {
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console(
                        outputTemplate: SevereMessagesOutputTemplate,
                        theme: (ConsoleTheme)Theme,
                        applyThemeToRedirectedOutput: true)
                    .CreateLogger();

                var nonEmptyLogEvents = Logging.InMemorySink.Instance.LogEvents.Where(x => !x.MessageTemplate.Text.IsNullOrEmpty());
                nonEmptyLogEvents.ForEach(Log.Write);
            }
        }

        protected virtual void WriteSummaryTable(NukeBuild build)
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
            Debug(new string(c: '═', count: allColumns));
            Information(CreateLine("Target", "Status", "Duration"));
            //WriteInformationInternal($"{{0,-{firstColumn}}}{{1,-{secondColumn}}}{{2,{thirdColumn}}}{{3,1}}", "Target", "Status", "Duration", "Test");
            Debug(new string(c: '─', count: allColumns));
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

            Debug(new string(c: '─', count: allColumns));
            Information(CreateLine("Total", string.Empty, GetDuration(totalDuration)));
            Debug(new string(c: '═', count: allColumns));
            Debug();
        }

        protected virtual void WriteSuccessfulBuild(NukeBuild build)
        {
            Success($"Build succeeded on {DateTime.Now.ToString(CultureInfo.CurrentCulture)}. ＼（＾ᴗ＾）／");
        }

        protected virtual void WriteFailedBuild()
        {
            Error($"Build failed on {DateTime.Now.ToString(CultureInfo.CurrentCulture)}. (╯°□°）╯︵ ┻━┻");
        }

        internal class LogEventSink : ILogEventSink
        {
            public void Emit(LogEvent logEvent)
            {
                if (logEvent.Level == LogEventLevel.Warning)
                    NukeBuild.Host.ReportWarning(logEvent.RenderMessage());
                else if (logEvent.Level == LogEventLevel.Error)
                    NukeBuild.Host.ReportError(logEvent.RenderMessage());
            }
        }
    }
}
