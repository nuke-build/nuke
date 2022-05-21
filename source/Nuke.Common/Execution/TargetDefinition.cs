// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Docker;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Execution
{
    internal class TargetDefinition : ITargetDefinition
    {
        private readonly Stack<PropertyInfo> _baseMembers;

        public TargetDefinition(PropertyInfo target, NukeBuild build, Stack<PropertyInfo> baseMembers)
        {
            Target = target;
            Build = build;
            _baseMembers = baseMembers;
        }

        public PropertyInfo Target { get; }
        public NukeBuild Build { get; }

        internal string Description { get; set; }
        internal List<Expression<Func<bool>>> DynamicConditions { get; } = new List<Expression<Func<bool>>>();
        internal List<Expression<Func<bool>>> StaticConditions { get; } = new List<Expression<Func<bool>>>();
        internal List<LambdaExpression> Requirements { get; } = new List<LambdaExpression>();
        internal List<Target> DependsOnTargets { get; } = new List<Target>();
        internal List<Target> DependentForTargets { get; } = new List<Target>();
        internal List<Action> Actions { get; } = new List<Action>();
        internal DependencyBehavior DependencyBehavior { get; private set; }
        internal bool IsProceedAfterFailure { get; private set; }
        internal bool IsAssuredAfterFailure { get; private set; }
        internal bool IsInternal { get; private set; }
        internal List<Target> BeforeTargets { get; } = new List<Target>();
        internal List<Target> AfterTargets { get; } = new List<Target>();
        internal List<Target> TriggersTargets { get; } = new List<Target>();
        internal List<Target> TriggeredByTargets { get; } = new List<Target>();
        internal int? PartitionSize { get; private set; }
        internal List<string> ArtifactProducts { get; } = new List<string>();
        internal LookupTable<Target, string[]> ArtifactDependencies { get; } = new LookupTable<Target, string[]>();
        internal ExecuteInDockerSettings ExecuteInDockerSettings { get; private set; }

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

        public ITargetDefinition DependsOn<T>(params Func<T, Target>[] targets)
        {
            return DependsOn(GetTargetsOrSingleOf<T>(targets.Select(x => x((T) (object) Build)).ToArray()));
        }

        public ITargetDefinition TryDependsOn<T>(params Func<T, Target>[] targets)
        {
            return Build is T ? DependsOn(targets) : this;
        }

        public ITargetDefinition DependentFor(params Target[] targets)
        {
            DependentForTargets.AddRange(targets);
            return this;
        }

        public ITargetDefinition DependentFor<T>(params Func<T, Target>[] targets)
        {
            return DependentFor(GetTargetsOrSingleOf<T>(targets.Select(x => x((T) (object) Build)).ToArray()));
        }

        public ITargetDefinition TryDependentFor<T>(params Func<T, Target>[] targets)
        {
            return Build is T ? DependentFor(targets) : this;
        }

        public ITargetDefinition OnlyWhenDynamic(params Expression<Func<bool>>[] conditions)
        {
            DynamicConditions.AddRange(conditions);
            return this;
        }

        public ITargetDefinition OnlyWhenStatic(params Expression<Func<bool>>[] conditions)
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

        public ITargetDefinition Before<T>(params Func<T, Target>[] targets)
        {
            return Before(GetTargetsOrSingleOf<T>(targets.Select(x => x((T) (object) Build)).ToArray()));
        }

        public ITargetDefinition TryBefore<T>(params Func<T, Target>[] targets)
        {
            return Build is T ? Before(targets) : this;
        }

        public ITargetDefinition After(params Target[] targets)
        {
            AfterTargets.AddRange(targets);
            return this;
        }

        public ITargetDefinition After<T>(params Func<T, Target>[] targets)
        {
            return After(GetTargetsOrSingleOf<T>(targets.Select(x => x((T) (object) Build)).ToArray()));
        }

        public ITargetDefinition TryAfter<T>(params Func<T, Target>[] targets)
        {
            return Build is T ? After(targets) : this;
        }

        public ITargetDefinition Triggers(params Target[] targets)
        {
            TriggersTargets.AddRange(targets);
            return this;
        }

        public ITargetDefinition Triggers<T>(params Func<T, Target>[] targets)
        {
            return Triggers(GetTargetsOrSingleOf<T>(targets.Select(x => x((T) (object) Build)).ToArray()));
        }

        public ITargetDefinition TryTriggers<T>(params Func<T, Target>[] targets)
        {
            return Build is T ? Triggers(targets) : this;
        }

        public ITargetDefinition TriggeredBy(params Target[] targets)
        {
            TriggeredByTargets.AddRange(targets);
            return this;
        }

        public ITargetDefinition TriggeredBy<T>(params Func<T, Target>[] targets)
        {
            return TriggeredBy(GetTargetsOrSingleOf<T>(targets.Select(x => x((T) (object) Build)).ToArray()));
        }

        public ITargetDefinition TryTriggeredBy<T>(params Func<T, Target>[] targets)
        {
            return Build is T ? TriggeredBy(targets) : this;
        }

        public ITargetDefinition AssuredAfterFailure()
        {
            IsAssuredAfterFailure = true;
            return this;
        }

        public ITargetDefinition ProceedAfterFailure()
        {
            IsProceedAfterFailure = true;
            return this;
        }

        public ITargetDefinition Unlisted()
        {
            IsInternal = true;
            return this;
        }

        public ITargetDefinition Base()
        {
            Assert.True(_baseMembers.Count > 0,
                $"Target '{Target.DeclaringType}.{Target.Name}' does not have any base members."
                + $" To inherit from an interface default implementation, use {nameof(Inherit)}<T> instead.");
            Inherit(_baseMembers.Pop().GetValueNonVirtual<Target>(Build));
            return this;
        }

        public ITargetDefinition Inherit(params Target[] targets)
        {
            targets.ForEach(x => x.Invoke(this));
            return this;
        }

        public ITargetDefinition Inherit<T>(params Expression<Func<T, Target>>[] targets)
        {
            var properties = targets.Length > 0 ? targets.Select(x => x.GetMemberInfo()) : new[] { GetSingleTargetProperty<T>() };
            Inherit(properties.Select(x => x.GetValueNonVirtual<Target>(Build)).ToArray());
            return this;
        }

        public ITargetDefinition Produces(params string[] artifacts)
        {
            ArtifactProducts.AddRange(artifacts);
            return this;
        }

        public ITargetDefinition Consumes(params Target[] targets)
        {
            targets.ForEach(x => Consumes(x));
            return this;
        }

        public ITargetDefinition Consumes<T>(params Func<T, Target>[] targets)
        {
            return Consumes(GetTargetsOrSingleOf<T>(targets.Select(x => x((T) (object) Build)).ToArray()));
        }

        public ITargetDefinition Consumes(Target target, params string[] artifacts)
        {
            ArtifactDependencies.Add(target, artifacts);
            return this;
        }

        public ITargetDefinition Consumes<T>(Func<T, Target> target, params string[] artifacts)
        {
            return Consumes(target.Invoke((T) (object) Build), artifacts);
        }

        public ITargetDefinition Consumes<T>(params string[] artifacts)
        {
            return Consumes(GetTargetsOrSingleOf<T>().Single(), artifacts);
        }

        public ITargetDefinition Partition(int size)
        {
            Assert.True(size > 1);
            PartitionSize = size;
            return this;
        }

        public ITargetDefinition DockerRun(Configure<ExecuteInDockerSettings> configure)
        {
            ExecuteInDockerSettings = configure.InvokeSafe(new ExecuteInDockerSettings());
            return this;
        }

        private Target[] GetTargetsOrSingleOf<T>(params Target[] targets)
        {
            return targets.Length > 0 ? targets : new[] { (Target) GetSingleTargetProperty<T>().GetValue(Build) };
        }

        private PropertyInfo GetSingleTargetProperty<T>()
        {
            var interfaceTargets = typeof(T).GetProperties(ReflectionUtility.Instance).Where(x => x.PropertyType == typeof(Target)).ToList();
            if (interfaceTargets.Count != 1)
            {
                Assert.Fail($"Target '{Target.DeclaringType}.{Target.Name}' cannot have a shorthand dependency on component '{typeof(T).Name}'."
                    .Concat(new[] { interfaceTargets.Count > 1 ? "Available targets are:" : "No targets available." })
                    .Concat(interfaceTargets.Select(x => $"  - {x.Name}")).JoinNewLine());
            }

            return interfaceTargets.Single();
        }
    }
}
