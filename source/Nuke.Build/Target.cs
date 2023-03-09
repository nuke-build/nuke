// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Execution;

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

    public delegate ITargetDefinition Setup(ITargetDefinition definition);

    public delegate ITargetDefinition Cleanup(ITargetDefinition definition);

    [PublicAPI]
    public static class ExecutableTargetExtensions
    {
        public static bool Contains(this IEnumerable<ExecutableTarget> targets, Target target)
        {
            return targets.Any(x => x.Factory.Equals(target));
        }

        public static bool Contains(this IEnumerable<ExecutableTarget> targets, Setup target)
        {
            return targets.Any(x => x.Factory.Equals(target));
        }

        public static bool Contains(this IEnumerable<ExecutableTarget> targets, Cleanup target)
        {
            return targets.Any(x => x.Factory.Equals(target));
        }
    }
}
