#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Core.Execution
{
    public enum ExecutionStatus
    {
        None,
        Skipped,
        Executed,
        Failed,
        Absent
    }
}
