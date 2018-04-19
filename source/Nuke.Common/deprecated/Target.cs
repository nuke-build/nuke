#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Core
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
    [Obsolete("Namespace 'Core' is deprecated. Simply do a text replace from 'Nuke.Core' to 'Nuke.Common' to resolve all warnings.")]
    public delegate ITargetDefinition Target(ITargetDefinition definition);
}
