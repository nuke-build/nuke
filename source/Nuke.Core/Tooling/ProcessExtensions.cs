// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

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
            ControlFlow.Assert(process.ExitCode == 0, "process.ExitCode == 0");
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
