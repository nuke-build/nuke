// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.OutputSinks
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    internal class BitriseOutputSink : ConsoleOutputSink
    {
        public override IDisposable WriteBlock(string text)
        {
            Info(FigletTransform.GetText(text, "ansi-shadow"));
            return DelegateDisposable.CreateBracket();
        }
        
        // public override void WriteSummary(IReadOnlyCollection<TargetDefinition> executionList)
        // {
        //     string CreateLine(string target, string executionStatus, string duration)
        //         => new StringBuilder()
        //             .Append("| ")
        //             .Append(target.PadRight(42, ' '))
        //             .Append(executionStatus.PadRight(19, paddingChar: ' '))
        //             .Append((duration + " min").PadRight(15, paddingChar: ' '))
        //             .Append(" |").ToString();
        //
        //     string ToMinutesAndSeconds(TimeSpan duration)
        //         => $"{(int) duration.TotalMinutes}:{duration:ss}";
        //
        //     Logger.Log("+------------------------------------------------------------------------------+");
        //     Logger.Log("|                                build summary                                 |");
        //     Logger.Log("+---+---------------------------------------------------------------+----------+");
        //     Logger.Log("|   | target                                                        | time (s) |");
        //     Logger.Log("+---+---------------------------------------------------------------+----------+");
        //     
        //     
        //     Logger.Log("| Target                                    Status             Duration        |");
        //     Logger.Log("+" + new string(c: '-', count: 78) + "+");
        //
        //     foreach (var target in executionList)
        //     {
        //         var line = CreateLine(target.Name, target.Status.ToString(), ToMinutesAndSeconds(target.Duration));
        //         switch (target.Status)
        //         {
        //             case ExecutionStatus.Absent:
        //             case ExecutionStatus.NotRun:
        //             case ExecutionStatus.Skipped:
        //                 Logger.Trace(line);
        //                 break;
        //             case ExecutionStatus.Executed:
        //                 Logger.Success(line);
        //                 break;
        //             case ExecutionStatus.Failed:
        //                 Logger.Error(line);
        //                 break;
        //         }
        //     }
        //     
        //     Logger.Log("+" + new string(c: '-', count: 78) + "+");
        //     Logger.Log(CreateLine("Total", "", ToMinutesAndSeconds(executionList.Aggregate(TimeSpan.Zero, (t, x) => t.Add(x.Duration)))));
        //     Logger.Log("+---+---------------------------------------------------------------+----------+");
        //     Logger.Log("| ✓ | Run build.sh                                                  | 130 sec  |");
        //     Logger.Log("+---+---------------------------------------------------------------+----------+");
        // }
    }
}
