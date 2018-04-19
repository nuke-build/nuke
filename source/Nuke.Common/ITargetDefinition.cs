// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace Nuke.Common
{
    /// <summary>
    ///   Public API for defining targets.
    /// </summary>
    [PublicAPI]
    public interface ITargetDefinition
    {
        /// <summary>
        ///   Adds a description for this target.
        /// </summary>
        ITargetDefinition Description(string description);

        /// <summary>
        ///   Adds a set of actions that will be executed for this target.
        /// </summary>
        ITargetDefinition Executes(params Action[] actions);

        /// <summary>
        ///   Adds a set of actions that will be executed for this target.
        /// </summary>
        ITargetDefinition Executes<T>(Func<T> action);

        /// <summary>
        ///   Adds a set of dependent targets that will be executed before this target.
        /// </summary>
        ITargetDefinition DependsOn(params Target[] targets);

        /// <summary>
        ///   Adds a set of dependent shadow targets that will be executed before this target.
        ///   Non-existent shadow targets will automatically being skipped.
        /// </summary>
        ITargetDefinition DependsOn(params string[] shadowTargets);

        /// <summary>
        ///   Adds a set of conditions that will be checked before executing this target.
        /// </summary>
        ITargetDefinition OnlyWhen(params Func<bool>[] conditions);

        /// <summary>
        ///   Adds a required parameter that will be checked prior to build execution.
        /// </summary>
        ITargetDefinition Requires<T>(params Expression<Func<T>>[] parameterRequirement)
            where T : class;

        /// <summary>
        ///   Adds a required parameter that will be checked prior to build execution.
        /// </summary>
        ITargetDefinition Requires<T>(params Expression<Func<T?>>[] parameterRequirement)
            where T : struct;

        /// <summary>
        ///   Adds a requirement that will be checked prior to build execution.
        /// </summary>
        ITargetDefinition Requires(params Expression<Func<bool>>[] requirement);
    }
}
