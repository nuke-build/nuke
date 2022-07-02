// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

namespace Nuke.Common;

using System;
using System.Linq;
using JetBrains.Annotations;

/// <summary>
///     Allows to disable the output of things like the summary or the headers in the build output. 
/// </summary>
[PublicAPI]
[AttributeUsage(AttributeTargets.Class)]
public class DisableDefaultOutputAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DisableDefaultOutputAttribute"/> class.
    /// </summary>
    /// <param name="disabledOutputs">
    ///     The output kinds that should be disabled.   
    /// </param>
    public DisableDefaultOutputAttribute(params DefaultOutputKind[] disabledOutputs)
    {
        DisabledOutputs = disabledOutputs.Length > 0
            ? disabledOutputs
            : Enum.GetValues(typeof(DefaultOutputKind)).Cast<DefaultOutputKind>().ToArray();
    }

    public DefaultOutputKind[] DisabledOutputs { get; }
}

/// <summary>
///     Defines the types of default outputs that the host can display.
/// </summary>
public enum DefaultOutputKind
{
    /// <summary>
    ///     The NUKE logo at the start of the build.
    /// </summary>
    Logo,

    /// <summary>
    ///     The header of the targets
    ///     (only applicable for hosts that output a target header).
    /// </summary>
    TargetHeader,

    /// <summary>
    ///     The expand and collapse markup that surrounds whole target output
    ///     (only applicable for hosts that support expand and collapse).
    /// </summary>
    TargetCollapse,

    ErrorsAndWarnings,
    TargetOutcome,
    BuildOutcome,
    Timestamps
}
