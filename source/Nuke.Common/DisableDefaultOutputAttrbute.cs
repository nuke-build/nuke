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
    private readonly DefaultOutputKind[] _disabledOutputs;

    /// <summary>
    /// Initializes a new instance of the <see cref="DisableDefaultOutputAttribute"/> class.
    /// </summary>
    /// <param name="disabledOutputs">
    ///     The output kinds that should be disabled.   
    /// </param>
    public DisableDefaultOutputAttribute(params DefaultOutputKind[] disabledOutputs)
    {
        _disabledOutputs = disabledOutputs;
    }

    /// <summary>
    ///     Indicates whether the specified output kind should not be displayed by the host.
    /// </summary>
    /// <param name="outputKind">The output kind to check.</param>
    /// <returns>
    ///     <see langword="true"/> if the output kind specified by <paramref name="outputKind"/> should not be output,
    ///     <see langword="false"/> otherwise.
    /// </returns>
    public bool IsOutputDisabled(DefaultOutputKind outputKind)
    {
        return _disabledOutputs.Length == 0 || _disabledOutputs.Contains(outputKind);
    }
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

    /// <summary>
    ///     The build summary at the end of the build.
    /// </summary>
    Summary
}
