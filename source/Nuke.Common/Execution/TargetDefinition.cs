// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Nuke.Common.Execution
{
    internal class TargetDefinition : ITargetDefinition
    {
        public static TargetDefinition Create(string name, Target factory = null)
        {
            return new TargetDefinition(name, factory);
        }

        private TargetDefinition(string name, Target factory = null)
        {
            Name = name;
            Factory = factory;
            FactoryDependencies = new List<Target>();
            Actions = new List<Action>();
            Conditions = new List<Func<bool>>();
            Requirements = new List<LambdaExpression>();
            TargetDefinitionDependencies = new List<TargetDefinition>();
            RunBeforeTargets = new List<Target>();
            RunAfterTargets = new List<Target>();
            DependencyBehavior = DependencyBehavior.Execute;

            factory?.Invoke(this);
        }

        internal string Name { get; }

        [CanBeNull]
        internal Target Factory { get; }

        internal string Description { get; set; }
        internal bool IsDefault { get; set; }
        internal TimeSpan Duration { get; set; }
        internal ExecutionStatus Status { get; set; }
        internal List<Func<bool>> Conditions { get; }
        internal List<LambdaExpression> Requirements { get; }
        internal List<Target> FactoryDependencies { get; }
        internal List<TargetDefinition> TargetDefinitionDependencies { get; }
        internal List<Action> Actions { get; }
        internal DependencyBehavior DependencyBehavior { get; private set; }
        internal bool Skip { get; set; }
        internal List<Target> RunBeforeTargets { get; private set; }
        internal List<Target> RunAfterTargets { get; private set; }

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
            FactoryDependencies.AddRange(targets);
            return this;
        }

        public ITargetDefinition OnlyWhen(params Func<bool>[] conditions)
        {
            Conditions.AddRange(conditions);
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
            RunBeforeTargets.AddRange(targets);
            return this;
        }

        public ITargetDefinition After(params Target[] targets)
        {
            RunAfterTargets.AddRange(targets);
            return this;
        }

        public override string ToString()
        {
            return $"Target '{Name}'";
        }
    }
}
