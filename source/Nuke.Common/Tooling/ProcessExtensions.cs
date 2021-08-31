// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using Nuke.Common.IO;
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
                throw new ProcessException(process);

            return process;
        }

        public static IReadOnlyCollection<Output> EnsureOnlyStd(this IReadOnlyCollection<Output> output)
        {
            foreach (var o in output)
                ControlFlow.Assert(o.Type == OutputType.Std, "o.Type == OutputType.Std");

            return output;
        }

        public static string StdToText(this IEnumerable<Output> output)
        {
            return output.Where(x => x.Type == OutputType.Std)
                .Select(x => x.Text)
                .JoinNewLine();
        }

        public static T StdToJson<T>(this IEnumerable<Output> output)
        {
            return SerializationTasks.JsonDeserialize<T>(output.StdToText());
        }

        public static JObject StdToJson(this IEnumerable<Output> output)
        {
            return output.StdToJson<JObject>();
        }
    }
}
