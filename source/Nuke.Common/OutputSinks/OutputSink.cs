// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.Tools.GitHub;
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

        internal readonly List<Tuple<LogLevel, string>> SevereMessages = new List<Tuple<LogLevel, string>>();

        internal virtual IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () =>
                {
                    var formattedBlockText = FormatBlockText(text)
                        .Split(new[] { EnvironmentInfo.NewLine }, StringSplitOptions.None);

                    Console.WriteLine();
                    Console.WriteLine("╬" + new string(c: '═', text.Length + 5));
                    formattedBlockText.ForEach(x => Console.WriteLine($"║ {x}"));
                    Console.WriteLine("╬" + new string(c: '═', Math.Max(text.Length - 4, 2)));
                    Console.WriteLine();
                });
        }

        protected internal void WriteLogo()
        {
            Logger.Normal("███╗   ██╗██╗   ██╗██╗  ██╗███████╗");
            Logger.Normal("████╗  ██║██║   ██║██║ ██╔╝██╔════╝");
            Logger.Normal("██╔██╗ ██║██║   ██║█████╔╝ █████╗  ");
            Logger.Normal("██║╚██╗██║██║   ██║██╔═██╗ ██╔══╝  ");
            Logger.Normal("██║ ╚████║╚██████╔╝██║  ██╗███████╗");
            Logger.Normal("╚═╝  ╚═══╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝");
        }

        internal virtual void WriteSummary(NukeBuild build)
        {
            if (SevereMessages.Count > 0)
            {
                WriteNormal();
                WriteSevereMessages();
            }

            WriteNormal();
            WriteSummaryTable(build);
            WriteNormal();

            if (build.IsSuccessful)
                WriteSuccessfulBuild();
            else
                WriteFailedBuild();

            bool HasHighUsage()
                => // global tool
                   build.GetType().GetInterfaces().Length > 1 ||
                   // configuration generation
                   build.GetType().GetCustomAttributes<ConfigurationAttributeBase>().Any() ||
                   // interface implementations
                   NukeBuild.BuildProjectFile == null;

            T TryGetValue<T>(Func<T> func)
            {
                try
                {
                    return func.Invoke();
                }
                catch
                {
                    return default;
                }
            }

            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.EqualsOrdinalIgnoreCase("zh"))
            {
                WriteNormal();
                WriteTranslationRequest();
            }
            else if (build.IsSuccessful &&
                HasHighUsage() &&
                TryGetValue(() => GitRepository.FromLocalDirectory(NukeBuild.RootDirectory)) is { } repository &&
                TryGetValue(() => repository.GetDefaultBranch().GetAwaiter().GetResult()) == null)
            {
                WriteNormal();
                WriteSponsorshipInfo();
            }
        }

        private void WriteTranslationRequest()
        {
            WriteInformation("We want to make NUKE more accessible by providing");
            WriteInformation("our documentation in simplified chinese (zh-CN). 🇨🇳");
            WriteInformation("If you're interested to help, please contact us:");
            WriteInformation("     📧 ithrowexceptions@gmail.com");
            WriteNormal();
            WriteInformation("Happy building! 🌟");
        }

        private void WriteSponsorshipInfo()
        {
            WriteInformation("If you like NUKE, you'll love what's coming! 🤓");
            WriteInformation("We're currently looking for more sponsors to release a new version.");
            WriteInformation("Please check out our tiers: https://github.com/sponsors/matkoch");
            WriteInformation("With a sponsorship you'll also gain access to various perks. 🚀");
            WriteNormal();
            WriteInformation("Happy building! 🌟");
        }

        protected virtual void WriteSuccessfulBuild()
        {
            WriteSuccess($"Build succeeded on {DateTime.Now.ToString(CultureInfo.CurrentCulture)}. ＼（＾ᴗ＾）／");
        }

        protected virtual void WriteFailedBuild()
        {
            WriteError($"Build failed on {DateTime.Now.ToString(CultureInfo.CurrentCulture)}. (╯°□°）╯︵ ┻━┻");
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
                => $"{(int) duration.TotalMinutes}:{duration:ss}".Replace("0:00", "< 1sec");

            static string GetInformation(ExecutableTarget target)
                => target.SummaryInformation.Any()
                    ? target.SummaryInformation.Select(x => $"{x.Caption}: {x.Text}").JoinComma()
                    : null;

            WriteNormal(new string(c: '═', count: allColumns));
            WriteInformation(CreateLine("Target", "Status", "Duration"));
            //WriteInformationInternal($"{{0,-{firstColumn}}}{{1,-{secondColumn}}}{{2,{thirdColumn}}}{{3,1}}", "Target", "Status", "Duration", "Test");
            WriteNormal(new string(c: '─', count: allColumns));
            foreach (var target in build.ExecutionPlan)
            {
                var line = CreateLine(target.Name, target.Status.ToString(), GetDurationOrBlank(target), GetInformation(target));
                switch (target.Status)
                {
                    case ExecutionStatus.Skipped:
                        WriteNormal(line);
                        break;
                    case ExecutionStatus.Succeeded:
                        WriteSuccess(line);
                        break;
                    case ExecutionStatus.Aborted:
                    case ExecutionStatus.NotRun:
                        WriteWarning(line);
                        break;
                    case ExecutionStatus.Failed:
                        WriteError(line);
                        break;
                    default:
                        throw new NotSupportedException(target.Status.ToString());
                }
            }

            WriteNormal(new string(c: '─', count: allColumns));
            WriteInformation(CreateLine("Total", string.Empty, GetDuration(totalDuration)));
            WriteNormal(new string(c: '═', count: allColumns));
        }

        protected virtual void WriteSevereMessages()
        {
            WriteInformation("Repeating warnings and errors:");

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

        protected abstract void WriteNormal(string text);
        protected abstract void WriteSuccess(string text);
        protected abstract void WriteTrace(string text);
        protected abstract void WriteInformation(string text);

        protected abstract void WriteWarning(string text, string details = null);
        protected abstract void WriteError(string text, string details = null);
    }
}
