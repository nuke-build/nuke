#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Nuke.Core.OutputSinks;

namespace Nuke.Core.Execution
{
    internal class ExecutionListRunner
    {
        public int Run(IReadOnlyCollection<TargetDefinition> executionList)
        {
            foreach (var target in executionList)
            {
                if (target.Factory == null)
                {
                    target.Status = ExecutionStatus.Absent;
                    continue;
                }

                if (target.Conditions.Any(x => !x()))
                {
                    target.Status = ExecutionStatus.Skipped;
                    continue;
                }

                using (Logger.Block(target.Name))
                {
                    var stopwatch = Stopwatch.StartNew();
                    try
                    {
                        target.Actions.ForEach(x => x());
                        target.Duration = stopwatch.Elapsed;

                        target.Status = ExecutionStatus.Executed;
                    }
                    catch (Exception exception)
                    {
                        OutputSink.Error(exception.Message, exception.StackTrace);
                        target.Status = ExecutionStatus.Failed;

                        break;
                    }
                    finally
                    {
                        target.Duration = stopwatch.Elapsed;
                    }
                }
            }

            OutputSink.WriteSummary(executionList);

            return -executionList.Count(x => x.Status == ExecutionStatus.Failed);
        }
    }
}
