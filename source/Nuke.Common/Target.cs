// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common
{
    /// <summary>
    /// Defines a target.
    /// </summary>
    /// <example>
    /// <code>
    /// Target Restore => _ => _
    ///     .DependsOn(/* dependent target */)
    ///     .OnlyWhen(/* conditions for executing the target */)
    ///     .Executes(() => /* actions to be executed */);
    /// </code>
    /// </example>
    public delegate ITargetDefinition Target(ITargetDefinition definition);
}
