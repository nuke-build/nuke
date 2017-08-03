// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.Utilities;

namespace Nuke.Core.Tooling
{
    [PublicAPI]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public static class ProcessExtensions
    {
        [AssertionMethod]
        public static void AssertWaitForExit ([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] [CanBeNull] this IProcess process)
        {
            ControlFlow.Assert(process != null && process.WaitForExit(), "process != null && process.WaitForExit()");
        }

        [AssertionMethod]
        public static void AssertZeroExitCode ([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] [CanBeNull] this IProcess process)
        {
            process.AssertWaitForExit();
            ControlFlow.Assert(process.ExitCode == 0,
                new[]
                {
                    $"Process '{Path.GetFileName(process.StartInfo.FileName)}' exited with code {process.ExitCode}. Please verify the invocation:",
                    $"> {process.StartInfo.FileName.DoubleQuoteIfNeeded()} {process.StartInfo.Arguments}"
                }.Join(EnvironmentInfo.NewLine));
        }

        public static IEnumerable<Output> EnsureOnlyStd (this IEnumerable<Output> output)
        {
            foreach (var o in output)
            {
                ControlFlow.Assert(o.Type == OutputType.Std, "o.Type == OutputType.Std");
                yield return o;
            }
        }
    }
}
