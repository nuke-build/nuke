// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Execution
{
    public enum ExecutionStatus
    {
        NotRun,
        Skipped,
        Executed,
        Failed,
        Executing,
        Aborted,
        Collective
    }

    public static class ExecutionStatusExtensions
    {
        public static bool IsCompleted(this ExecutionStatus status)
        {
            return status != ExecutionStatus.NotRun
                && status != ExecutionStatus.Executing;
        }

        public static bool IsSuccessful(this ExecutionStatus status)
        {
            return status == ExecutionStatus.Executed
                || status == ExecutionStatus.Skipped;
        }
    }
}
