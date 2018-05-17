// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            process.AssertWaitForExit();
            if (process.HasOutput) process.Output.Where(x => x.Type == OutputType.Err).ForEach(x => Logger.Error(x.Text));
            ControlFlow.Assert(process.ExitCode == 0,
                new[]
                {
                    $"Process '{Path.GetFileName(process.FileName)}' exited with code {process.ExitCode}. Please verify the invocation.",
                    $"> {process.FileName.DoubleQuoteIfNeeded()} {process.Arguments}"
                }.JoinNewLine());
            return process;
        }

        public static IEnumerable<Output> EnsureOnlyStd(this IEnumerable<Output> output)
        {
            var outputList = output.ToList();
            foreach (var o in outputList)
                ControlFlow.Assert(o.Type == OutputType.Std, "o.Type == OutputType.Std");

            return outputList;
        }
    }
}
