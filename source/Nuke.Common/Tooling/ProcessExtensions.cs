// Copyright 2018 Maintainers and Contributors of NUKE.
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
            process.AssertWaitForExit();
            if (process.ExitCode != 0)
            {
                var messageBuilder = new StringBuilder()
                    .AppendLine($"Process '{Path.GetFileName(process.FileName)}' exited with code {process.ExitCode}. Verify the invocation.")
                    .AppendLine($"> {process.FileName.DoubleQuoteIfNeeded()} {process.Arguments}");

                var errorOutput = process.Output.Where(x => x.Type == OutputType.Err).Select(x => x.Text).ToList();
                if (errorOutput.Count > 0)
                {
                    messageBuilder.AppendLine("Error output:");
                    errorOutput.ForEach(x => messageBuilder.AppendLine(x));
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
