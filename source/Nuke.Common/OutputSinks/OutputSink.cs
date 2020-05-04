// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.OutputSinks
{
    [PublicAPI]
    public abstract class OutputSink
    {
        public static OutputSink Default
        {
            get
            {
                var term = Environment.GetEnvironmentVariable("TERM");
                return term == null || !term.StartsWithOrdinalIgnoreCase("xterm")
                    ? (OutputSink) new SystemColorOutputSink()
                    : new AnsiColorOutputSink();
            }
        }

        private bool UseAscii { get; }

        private char CornerCharacter => UseAscii ? '#' : '╬';
        private char HorizontalEdgeCharacter  => UseAscii ? '=' : '═';
        private char SlimHorizontalEdgeCharacter  => UseAscii ? '-' : '─';
        private char VerticalEdgeCharacter  => UseAscii ? '|' : '║';
        private char PaddingCharacter  => ' ';

        internal readonly List<Tuple<LogLevel, string>> SevereMessages = new List<Tuple<LogLevel, string>>();

        protected OutputSink()
        {
            var useAscii = Environment.GetEnvironmentVariable("NUKE_USE_ASCII_OUTPUT");
            if ("true".Equals(useAscii, StringComparison.InvariantCultureIgnoreCase))
                UseAscii = true;
        }

        internal virtual IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () =>
                {
                    var formattedBlockText = FormatBlockText(text)
                        .Split(new[] { EnvironmentInfo.NewLine }, StringSplitOptions.None);

                    Console.WriteLine();
                    Console.WriteLine(CornerCharacter + new string(c: HorizontalEdgeCharacter, text.Length + 5));
                    formattedBlockText.ForEach(x => Console.WriteLine($"{VerticalEdgeCharacter} {x}"));
                    Console.WriteLine(CornerCharacter + new string(c: HorizontalEdgeCharacter, Math.Max(text.Length - 4, 2)));
                    Console.WriteLine();
                });
        }

        protected internal void WriteLogo()
        {
            if (UseAscii)
                WriteAsciiLogo();
            else
                WriteUtf8Logo();
        }

        internal virtual void WriteSummary(NukeBuild build)
        {
            if (SevereMessages.Count > 0)
            {
                WriteSevereMessages();
                WriteNormal();
            }

            WriteSummaryTable(build);
            WriteNormal();

            if (build.IsSuccessful)
                WriteSuccessfulBuild();
            else
                WriteFailedBuild();
            WriteNormal();
        }

        protected virtual void WriteSuccessfulBuild()
        {
            var smile = UseAscii ? string.Empty : " ＼（＾ᴗ＾）／";
            WriteSuccess($"Build succeeded on {DateTime.Now.ToString(CultureInfo.CurrentCulture)}.{smile}");
        }

        protected virtual void WriteFailedBuild()
        {
            var smile = UseAscii ? string.Empty : " (╯°□°）╯︵ ┻━┻";
            WriteError($"Build failed on {DateTime.Now.ToString(CultureInfo.CurrentCulture)}.{smile}");
        }

        protected virtual void WriteSummaryTable(NukeBuild build)
        {
            var firstColumn = Math.Max(build.ExecutionPlan.Max(x => x.Name.Length) + 4, val2: 19);
            var secondColumn = 10;
            var thirdColumn = 10;
            var allColumns = firstColumn + secondColumn + thirdColumn;
            var totalDuration = build.ExecutionPlan.Aggregate(TimeSpan.Zero, (t, x) => t.Add(x.Duration));

            string CreateLine(string target, string executionStatus, string duration, string appendix = null)
                => target.PadRight(firstColumn, paddingChar: PaddingCharacter)
                   + executionStatus.PadRight(secondColumn, paddingChar: PaddingCharacter)
                   + duration.PadLeft(thirdColumn, paddingChar: PaddingCharacter)
                   + (appendix != null ? $"   // {appendix}" : string.Empty);

            static string ToMinutesAndSeconds(TimeSpan duration)
                => $"{(int) duration.TotalMinutes}:{duration:ss}";

            WriteNormal(new string(c: HorizontalEdgeCharacter, count: allColumns));
            WriteInformation(CreateLine("Target", "Status", "Duration"));
            //WriteInformationInternal($"{{0,-{firstColumn}}}{{1,-{secondColumn}}}{{2,{thirdColumn}}}{{3,1}}", "Target", "Status", "Duration", "Test");
            WriteNormal(new string(c: SlimHorizontalEdgeCharacter, count: allColumns));
            foreach (var target in build.ExecutionPlan)
            {
                var line = CreateLine(target.Name, target.Status.ToString(), ToMinutesAndSeconds(target.Duration), target.SkipReason);
                switch (target.Status)
                {
                    case ExecutionStatus.Skipped:
                        WriteNormal(line);
                        break;
                    case ExecutionStatus.Executed:
                        WriteSuccess(line);
                        break;
                    case ExecutionStatus.Aborted:
                    case ExecutionStatus.NotRun:
                        WriteWarning(line);
                        break;
                    case ExecutionStatus.Failed:
                        WriteError(line);
                        break;
                }
            }

            WriteNormal(new string(c: SlimHorizontalEdgeCharacter, count: allColumns));
            WriteInformation(CreateLine("Total", "", ToMinutesAndSeconds(totalDuration)));
            WriteNormal(new string(c: HorizontalEdgeCharacter, count: allColumns));
        }

        protected virtual void WriteSevereMessages()
        {
            WriteNormal("Repeating warnings and errors:");

            foreach (var (level, message) in SevereMessages.ToList())
            {
                switch (level)
                {
                    case LogLevel.Warning:
                        WriteWarning(message);
                        break;
                    case LogLevel.Error:
                        WriteError(message);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        internal void WriteAndReportWarning(string text, string details = null)
        {
            SevereMessages.Add(Tuple.Create(LogLevel.Warning, text));
            ReportWarning(text, details);
            if (EnableWriteWarnings)
                WriteWarning(text, details);
        }

        internal void WriteAndReportError(string text, string details = null)
        {
            SevereMessages.Add(Tuple.Create(LogLevel.Error, text));
            ReportError(text, details);
            if (EnableWriteErrors)
                WriteError(text, details);
        }

        protected virtual string FormatBlockText(string text)
        {
            return text;
        }

        protected virtual bool EnableWriteWarnings => true;
        protected virtual bool EnableWriteErrors => true;

        protected virtual void ReportWarning(string text, string details = null)
        {
        }

        protected virtual void ReportError(string text, string details = null)
        {
        }

        protected void WriteNormal()
        {
            WriteNormal(string.Empty);
        }

        internal abstract void WriteNormal(string text);
        internal abstract void WriteSuccess(string text);
        internal abstract void WriteTrace(string text);
        internal abstract void WriteInformation(string text);

        protected abstract void WriteWarning(string text, string details = null);
        protected abstract void WriteError(string text, string details = null);

        private void WriteUtf8Logo()
        {
            Logger.Normal("███╗   ██╗██╗   ██╗██╗  ██╗███████╗");
            Logger.Normal("████╗  ██║██║   ██║██║ ██╔╝██╔════╝");
            Logger.Normal("██╔██╗ ██║██║   ██║█████╔╝ █████╗  ");
            Logger.Normal("██║╚██╗██║██║   ██║██╔═██╗ ██╔══╝  ");
            Logger.Normal("██║ ╚████║╚██████╔╝██║  ██╗███████╗");
            Logger.Normal("╚═╝  ╚═══╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝");
        }

        private void WriteAsciiLogo()
        {
            Logger.Normal("###    ## ##    ## ##   ## #######");
            Logger.Normal("####   ## ##    ## ##  ##  ##     ");
            Logger.Normal("## ##  ## ##    ## #####   #####  ");
            Logger.Normal("##  ## ## ##    ## ##  ##  ##     ");
            Logger.Normal("##   ####  ######  ##   ## #######");
        }
    }
}
