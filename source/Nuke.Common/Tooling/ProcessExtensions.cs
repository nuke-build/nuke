// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public static class ProcessExtensions
    {
        [AssertionMethod]
        public static IProcess AssertWaitForExit(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)] [CanBeNull]
            this IProcess process)
        {
            ControlFlow.Assert(process != null && process.WaitForExit(), "process != null && process.WaitForExit()");
            return process;
        }

        [AssertionMethod]
        public static IProcess AssertZeroExitCode(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)] [CanBeNull]
            this IProcess process)
        {
            const string indentation = "   ";
            
            process.AssertWaitForExit();
            if (process.ExitCode != 0)
            {
                var messageBuilder = new StringBuilder()
                    .AppendLine($"Process '{Path.GetFileName(process.FileName)}' exited with code {process.ExitCode}.")
                    .AppendLine("Invocation:")
                    .AppendLine($"{indentation}{process.FileName.DoubleQuoteIfNeeded()} {process.Arguments}")
                    .AppendLine("Working directory:")
                    .AppendLine($"{indentation}{process.WorkingDirectory}");

                var errorOutput = process.Output.Where(x => x.Type == OutputType.Err).ToList();
                if (errorOutput.Count > 0)
                {
                    messageBuilder.AppendLine("Error output:");
                    errorOutput.ForEach(x => messageBuilder.Append(indentation).AppendLine(x.Text));
                }
                else if (Logger.LogLevel <= LogLevel.Trace)
                {
                    messageBuilder.AppendLine("Standard output:");
                    process.Output.ForEach(x => messageBuilder.Append(indentation).AppendLine(x.Text));
                }

                ControlFlow.Fail(messageBuilder.ToString());
            }

            return process;
        }

        public static IReadOnlyCollection<Output> EnsureOnlyStd(this IReadOnlyCollection<Output> output)
        {
            foreach (var o in output)
                ControlFlow.Assert(o.Type == OutputType.Std, "o.Type == OutputType.Std");

            return output;
        }
    }
}
