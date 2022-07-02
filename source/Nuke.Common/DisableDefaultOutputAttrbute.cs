// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

namespace Nuke.Common;

using System;
using System.Linq;
using JetBrains.Annotations;

[PublicAPI]
[AttributeUsage(AttributeTargets.Class)]
public class DisableDefaultOutputAttribute : Attribute
{
    public DisableDefaultOutputAttribute(params DefaultOutput[] disabledOutputs)
    {
        DisabledOutputs = disabledOutputs.Length > 0
            ? disabledOutputs
            : Enum.GetValues(typeof(DefaultOutput)).Cast<DefaultOutput>().ToArray();
    }

    public DefaultOutput[] DisabledOutputs { get; }
}

public enum DefaultOutput
{
    Logo,
    TargetHeader,
    TargetCollapse,
    RepeatedErrorsAndWarnings,
    TargetOutcome,
    BuildOutcome,
    Timestamps
}
