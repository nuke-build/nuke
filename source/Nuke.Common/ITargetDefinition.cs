// Copyright 2019 Maintainers of NUKE.
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
        ///   Adds a set of dependent targets that will be executed before this target.
        /// </summary>
        ITargetDefinition DependsOn<T>(params Func<T, Target>[] targets);

        /// <summary>
        ///   Adds a set of dependent targets that will be executed before this target.
        /// </summary>
        ITargetDefinition TryDependsOn<T>(params Func<T, Target>[] targets);

        /// <summary>
        ///   Adds a set of targets that are dependent for this target.
        /// </summary>
        ITargetDefinition DependentFor(params Target[] targets);

        /// <summary>
        ///   Adds a set of targets that are dependent for this target.
        /// </summary>
        ITargetDefinition DependentFor<T>(params Func<T, Target>[] targets);

        /// <summary>
        ///   Adds a set of targets that are dependent for this target.
        /// </summary>
        ITargetDefinition TryDependentFor<T>(params Func<T, Target>[] targets);

        /// <summary>
        ///   Adds a set of conditions that will be checked before executing this target.
        /// </summary>
        ITargetDefinition OnlyWhenDynamic(params Expression<Func<bool>>[] conditions);

        /// <summary>
        ///   Adds a set of conditions that will be checked prior to build execution.
        /// </summary>
        ITargetDefinition OnlyWhenStatic(params Expression<Func<bool>>[] conditions);

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
        ///  Defines if this target should run before other targets.
        /// </summary>
        ITargetDefinition Before<T>(params Func<T, Target>[] targets);

        /// <summary>
        ///  Defines if this target should run before other targets.
        /// </summary>
        ITargetDefinition TryBefore<T>(params Func<T, Target>[] targets);

        /// <summary>
        ///  Defines if this target should run after other targets.
        /// </summary>
        ITargetDefinition After(params Target[] targets);

        /// <summary>
        ///  Defines if this target should run after other targets.
        /// </summary>
        ITargetDefinition After<T>(params Func<T, Target>[] targets);

        /// <summary>
        ///  Defines if this target should run after other targets.
        /// </summary>
        ITargetDefinition TryAfter<T>(params Func<T, Target>[] targets);

        /// <summary>
        ///  Defines targets that will be triggered after this target.
        /// </summary>
        ITargetDefinition Triggers(params Target[] targets);

        /// <summary>
        ///  Defines targets that will be triggered after this target.
        /// </summary>
        ITargetDefinition Triggers<T>(params Func<T, Target>[] targets);

        /// <summary>
        ///  Defines targets that will be triggered after this target.
        /// </summary>
        ITargetDefinition TryTriggers<T>(params Func<T, Target>[] targets);

        /// <summary>
        ///  Defines targets that will trigger this target.
        /// </summary>
        ITargetDefinition TriggeredBy(params Target[] targets);

        /// <summary>
        ///  Defines targets that will trigger this target.
        /// </summary>
        ITargetDefinition TriggeredBy<T>(params Func<T, Target>[] targets);

        /// <summary>
        ///  Defines targets that will trigger this target.
        /// </summary>
        ITargetDefinition TryTriggeredBy<T>(params Func<T, Target>[] targets);

        /// <summary>
        ///  Defines that this target is guaranteed to be executed, even if other targets fail.
        /// </summary>
        ITargetDefinition AssuredAfterFailure();

        /// <summary>
        ///  Defines that even if this target fails, the execution will continue.
        /// </summary>
        ITargetDefinition ProceedAfterFailure();

        /// <summary>
        ///  Defines that this target should not be listed.
        /// </summary>
        ITargetDefinition Unlisted();

        /// <summary>
        ///  Inherits base target definition.
        /// </summary>
        ITargetDefinition Base();

        /// <summary>
        ///   Inherits target definition.
        /// </summary>
        ITargetDefinition Inherit(params Target[] targets);

        /// <summary>
        ///   Inherits target definition.
        /// </summary>
        ITargetDefinition Inherit<T>(params Expression<Func<T, Target>>[] targets);

        /// <summary>
        ///   Defines produced artifacts.
        /// </summary>
        ITargetDefinition Produces(params string[] artifacts);

        /// <summary>
        ///   Defines which targets artifacts are consumed.
        /// </summary>
        ITargetDefinition Consumes(params Target[] targets);

        /// <summary>
        ///   Defines which targets artifacts are consumed.
        /// </summary>
        ITargetDefinition Consumes<T>(params Func<T, Target>[] targets);

        /// <summary>
        ///   Defines which targets artifacts are consumed.
        /// </summary>
        ITargetDefinition Consumes(Target target, params string[] artifacts);

        /// <summary>
        ///   Defines which targets artifacts are consumed.
        /// </summary>
        ITargetDefinition Consumes<T>(Func<T, Target> target, params string[] artifacts);

        /// <summary>
        ///   Defines which targets artifacts are consumed.
        /// </summary>
        ITargetDefinition Consumes<T>(params string[] artifacts);


        /// <summary>
        ///   Defines the partition size. Default is <c>1</c>.
        /// </summary>
        ITargetDefinition Partition(int size);
    }

    /// <summary>
    /// The behavior of dependent targets if the target is skipped.
    /// </summary>
    public enum DependencyBehavior
    {
        /// <summary>
        /// Skip all dependencies which are not required by another target.
        /// </summary>
        Skip,

        /// <summary>
        /// Execute all dependencies.
        /// </summary>
        Execute
    }
}
