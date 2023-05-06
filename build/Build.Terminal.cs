// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Execution;

[DisableDefaultOutput<Terminal>(
    DefaultOutput.Logo,
    DefaultOutput.Timestamps,
    DefaultOutput.TargetHeader,
    DefaultOutput.ErrorsAndWarnings,
    DefaultOutput.TargetOutcome,
    DefaultOutput.BuildOutcome)]
partial class Build
{
}

public class DisableDefaultOutputAttribute<T> : DisableDefaultOutputAttribute
    where T : Host
{
    public DisableDefaultOutputAttribute(params DefaultOutput[] disabledOutputs)
        : base(disabledOutputs)
    {
    }

    public override bool IsApplicable(INukeBuild build) => build.Host is T;
}
