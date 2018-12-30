// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
        ///   Adds a <see cref="Task"/> that will be executed for this target.
        /// </summary>
        ITargetDefinition Executes(Func<Task> action);

        /// <summary>
        ///   Adds a set of dependent targets that will be executed before this target.
        /// </summary>
        ITargetDefinition DependsOn(params Target[] targets);

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

        /// <summary>
        /// Defines if the dependencies should be skipped if the target is skipped.
        /// </summary>
        ITargetDefinition WhenSkipped(DependencyBehavior dependencyBehavior);

        /// <summary>
        ///  Defines if this target should run before other targets.
        /// </summary>
        ITargetDefinition Before(params Target[] targets);

        /// <summary>
        ///  Defines if this target should run after other targets.
        /// </summary>
        ITargetDefinition After(params Target[] targets);
    }

    /// <summary>
    /// The behavior of dependent targets if the target is skipped.
    /// </summary>
    public enum DependencyBehavior
    {
        /// <summary>
        /// Execute all dependencies.
        /// </summary>
        Execute,

        /// <summary>
        /// Skip all dependencies which are not required by another target.
        /// </summary>
        Skip
    }
}
