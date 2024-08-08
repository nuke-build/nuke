// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

namespace Nuke.Common;

/// <summary>
/// Options for the execution of a build.
/// </summary>
public class ExecuteOptions
{
    /// <summary>
    /// Disable default log configuration
    /// </summary>
    public bool DisableDefaultLogConfiguration { get; set; }
}
