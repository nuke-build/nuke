// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Core
{
    /// <summary>
    /// Initializes a target.
    /// </summary>
    /// <example>
    /// <code>
    /// Target Restore => _ => _
    ///     .DependsOn(/* dependent target */)
    ///     .OnlyWhen(/* conditions for executing the target */)
    ///     .Executes(() => /* actions to be executed */);
    /// </code>
    /// </example>
    public delegate ITargetDefinition Target (ITargetDefinition definition);
}
