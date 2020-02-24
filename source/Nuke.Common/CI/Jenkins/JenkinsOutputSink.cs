// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.OutputSinks;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.Jenkins 
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    internal class JenkinsOutputSink : OutputSink
    {
        internal override IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () =>
                {
                    var formattedBlockText = FormatBlockText(text)
                        .Split(new[] { EnvironmentInfo.NewLine }, StringSplitOptions.None);

                    Console.WriteLine();
                    Console.WriteLine("+" + new string(c: '-', text.Length + 5));
                    formattedBlockText.ForEach(x => Console.WriteLine($"| {x}"));
                    Console.WriteLine("+" + new string(c: '-', Math.Max(text.Length - 4, 2)));
                    Console.WriteLine();
                });
        }
        
        protected override void WriteSummaryTable(NukeBuild build)
        {
            var firstColumn = Math.Max(build.ExecutionPlan.Max(x => x.Name.Length) + 4, val2: 19);
            var secondColumn = 10;
            var thirdColumn = 10;
            var allColumns = firstColumn + secondColumn + thirdColumn;
            var totalDuration = build.ExecutionPlan.Aggregate(TimeSpan.Zero, (t, x) => t.Add(x.Duration));

            string CreateLine(string target, string executionStatus, string duration, string appendix = null)
                => target.PadRight(firstColumn, paddingChar: ' ')
                   + executionStatus.PadRight(secondColumn, paddingChar: ' ')
                   + duration.PadLeft(thirdColumn, paddingChar: ' ')
                   + (appendix != null ? $"   // {appendix}" : string.Empty);

            string ToMinutesAndSeconds(TimeSpan duration)
                => $"{(int) duration.TotalMinutes}:{duration:ss}";

            WriteNormal(new string(c: '=', count: allColumns));
            WriteInformation(CreateLine("Target", "Status", "Duration"));
            WriteNormal(new string(c: '-', count: allColumns));
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

            WriteNormal(new string(c: '-', count: allColumns));
            WriteInformation(CreateLine("Total", "", ToMinutesAndSeconds(totalDuration)));
            WriteNormal(new string(c: '=', count: allColumns));
        }

        protected internal override void WriteLogo()
        {
            Logger.Normal("###    ## ##    ## ##   ## #######");
            Logger.Normal("####   ## ##    ## ##  ##  ##     ");
            Logger.Normal("## ##  ## ##    ## #####   #####  ");
            Logger.Normal("##  ## ## ##    ## ##  ##  ##     ");
            Logger.Normal("##   ####  ######  ##   ## #######");
        }

        protected override void WriteSuccessfulBuild()
        {
            WriteSuccess($"[NUKE] Build succeeded on {DateTime.Now.ToString(CultureInfo.CurrentCulture)}.");
        }

        protected override void WriteFailedBuild()
        {
            WriteError($"[NUKE] Build failed on {DateTime.Now.ToString(CultureInfo.CurrentCulture)}.");
        }

        internal override void WriteNormal(string text) 
        {
            Console.WriteLine(text);
        }

        internal override void WriteSuccess(string text) 
        {
            Console.WriteLine($"[SUCCESS] {text}");
        }

        internal override void WriteTrace(string text)
        {
            Console.WriteLine($"[TRACE] {text}");
        }

        internal override void WriteInformation(string text)
        {
            Console.WriteLine($"[INFO] {text}");
        }

        protected override void WriteWarning(string text, string details = null)
        {
            Console.WriteLine($"[WARNING] {text}");
            WriteDetails(details);
        }

        protected override void WriteError(string text, string details = null)
        {
            Console.WriteLine($"[ERROR] {text}");
            WriteDetails(details);
        }
        
        private void WriteDetails(string details = null) 
        {
            if (!string.IsNullOrEmpty(details))
            {
                Console.WriteLine($"[DETAILS]\n{details}");
            }
        }
    }
}
