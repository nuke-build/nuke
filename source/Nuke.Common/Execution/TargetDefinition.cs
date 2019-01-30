// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nuke.Common.Execution
{
    internal class TargetDefinition : ITargetDefinition
    {
        internal string Description { get; set; }
        internal bool IsDefault { get; set; }
        internal TimeSpan Duration { get; set; }
        internal ExecutionStatus Status { get; set; }
        internal List<Func<bool>> DynamicConditions { get; } = new List<Func<bool>>();
        internal List<Func<bool>> StaticConditions { get; } = new List<Func<bool>>();
        internal List<LambdaExpression> Requirements { get; } = new List<LambdaExpression>();
        internal List<Target> DependsOnTargets { get; } = new List<Target>();
        internal List<Target> DependentForTargets { get; } = new List<Target>();
        internal List<Action> Actions { get; } = new List<Action>();
        internal DependencyBehavior DependencyBehavior { get; private set; }
        internal bool ContinueOnFailure { get; private set; }
        internal bool AssureAfterFailure { get; private set; }
        internal List<Target> BeforeTargets { get; private set; } = new List<Target>();
        internal List<Target> AfterTargets { get; private set; } = new List<Target>();
        internal List<Target> TriggersTargets { get; private set; } = new List<Target>();
        internal List<Target> TriggeredByTargets { get; private set; } = new List<Target>();

        ITargetDefinition ITargetDefinition.Description(string description)
        {
            Description = description;
            return this;
        }

        public ITargetDefinition Executes(params Action[] actions)
        {
            Actions.AddRange(actions);
            return this;
        }

        public ITargetDefinition Executes<T>(Func<T> action)
        {
            return Executes(new Action(() => action()));
        }

        public ITargetDefinition Executes(Func<Task> action)
        {
            return Executes(() => action().GetAwaiter().GetResult());
        }

        public ITargetDefinition DependsOn(params Target[] targets)
        {
            DependsOnTargets.AddRange(targets);
            return this;
        }

        public ITargetDefinition DependentFor(params Target[] targets)
        {
            DependentForTargets.AddRange(targets);
            return this;
        }

        public ITargetDefinition OnlyWhenDynamic(params Func<bool>[] conditions)
        {
            DynamicConditions.AddRange(conditions);
            return this;
        }

        public ITargetDefinition OnlyWhenStatic(params Func<bool>[] conditions)
        {
            StaticConditions.AddRange(conditions);
            return this;
        }

        public ITargetDefinition Requires<T>(params Expression<Func<T>>[] parameterRequirement)
            where T : class
        {
            Requirements.AddRange(parameterRequirement);
            return this;
        }

        public ITargetDefinition Requires<T>(params Expression<Func<T?>>[] parameterRequirement)
            where T : struct
        {
            Requirements.AddRange(parameterRequirement);
            return this;
        }

        public ITargetDefinition Requires(params Expression<Func<bool>>[] requirement)
        {
            Requirements.AddRange(requirement);
            return this;
        }

        public ITargetDefinition WhenSkipped(DependencyBehavior dependencyBehavior)
        {
            DependencyBehavior = dependencyBehavior;
            return this;
        }

        public ITargetDefinition Before(params Target[] targets)
        {
            BeforeTargets.AddRange(targets);
            return this;
        }

        public ITargetDefinition After(params Target[] targets)
        {
            AfterTargets.AddRange(targets);
            return this;
        }

        public ITargetDefinition Triggers(params Target[] targets)
        {
            TriggersTargets.AddRange(targets);
            return this;
        }

        public ITargetDefinition TriggeredBy(params Target[] targets)
        {
            TriggeredByTargets.AddRange(targets);
            return this;
        }

        public ITargetDefinition AssuredAfterFailure()
        {
            AssureAfterFailure = true;
            return this;
        }

        public ITargetDefinition ContinuesOnFailure()
        {
            ContinueOnFailure = true;
            return this;
        }
    }
}
