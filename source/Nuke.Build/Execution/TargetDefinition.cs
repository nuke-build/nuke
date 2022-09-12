// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Execution
{
    internal class TargetDefinition : ITargetDefinition
    {
        private readonly Stack<PropertyInfo> _baseMembers;

        public TargetDefinition(PropertyInfo target, INukeBuild build, Stack<PropertyInfo> baseMembers)
        {
            Target = target;
            Build = build;
            _baseMembers = baseMembers;
        }

        public PropertyInfo Target { get; }
        public string Name => Target.GetDisplayShortName();
        public INukeBuild Build { get; }

        internal Func<bool> Intercept { get; set; }

        internal string Description { get; set; }
        internal List<Expression<Func<bool>>> DynamicConditions { get; } = new List<Expression<Func<bool>>>();
        internal List<Expression<Func<bool>>> StaticConditions { get; } = new List<Expression<Func<bool>>>();
        internal List<LambdaExpression> Requirements { get; } = new List<LambdaExpression>();
        internal List<Delegate> DependsOnTargets { get; } = new List<Delegate>();
        internal List<Delegate> DependentForTargets { get; } = new List<Delegate>();
        internal List<Action> Actions { get; } = new List<Action>();
        internal DependencyBehavior DependencyBehavior { get; private set; }
        internal bool IsProceedAfterFailure { get; private set; }
        internal bool IsAssuredAfterFailure { get; private set; }
        internal bool IsInternal { get; private set; }
        internal List<Delegate> BeforeTargets { get; } = new List<Delegate>();
        internal List<Delegate> AfterTargets { get; } = new List<Delegate>();
        internal List<Delegate> TriggersTargets { get; } = new List<Delegate>();
        internal List<Delegate> TriggeredByTargets { get; } = new List<Delegate>();
        internal int? PartitionSize { get; private set; }
        internal List<string> ArtifactProducts { get; } = new List<string>();
        internal LookupTable<Target, string[]> ArtifactDependencies { get; } = new LookupTable<Target, string[]>();

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
            return DependsOn(GetTargetsOrShorthand<T>(targets.Select(x => x((T) (object) Build)).ToArray()));
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
            return DependentFor(GetTargetsOrShorthand<T>(targets.Select(x => x((T) (object) Build)).ToArray()));
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
            return Before(GetTargetsOrShorthand<T>(targets.Select(x => x((T) (object) Build)).ToArray()));
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
            return After(GetTargetsOrShorthand<T>(targets.Select(x => x((T) (object) Build)).ToArray()));
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
            return Triggers(GetTargetsOrShorthand<T>(targets.Select(x => x((T) (object) Build)).ToArray()));
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
            return TriggeredBy(GetTargetsOrShorthand<T>(targets.Select(x => x((T) (object) Build)).ToArray()));
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
            var properties = targets.Length > 0
                ? targets.Select(x => x.GetMemberInfo())
                : new[] { GetSingleTargetProperty<T>("shorthand inheritance") };
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
            return Consumes(GetTargetsOrShorthand<T>(targets.Select(x => x((T) (object) Build)).ToArray()));
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
            return Consumes(GetTargetsOrShorthand<T>().Single(), artifacts);
        }

        public ITargetDefinition DependsOnContext<T>()
            where T : INukeBuild
        {
            Assert.True(Build is T, $"'{Build.GetType().Name}' must implement context '{typeof(T).Name}'");
            var setup = (Setup) GetSingleTargetProperty<T>("context dependency (missing setup)", targetType: typeof(Setup)).GetValue(Build);
            var cleanup = (Cleanup) GetSingleTargetProperty<T>("context dependency (missing cleanup)", targetType: typeof(Cleanup)).GetValue(Build);
            DependsOnTargets.Add(setup);
            BeforeTargets.Add(cleanup);
            return this;
        }

        public ITargetDefinition Partition(int size)
        {
            Assert.True(size > 1);
            PartitionSize = size;
            return this;
        }

        private Target[] GetTargetsOrShorthand<T>(params Target[] targets)
        {
            return targets.Length > 0
                ? targets
                : new[] { (Target) GetSingleTargetProperty<T>("shorthand dependency").GetValue(Build) };
        }

        private PropertyInfo GetSingleTargetProperty<T>(string kind, Type targetType = null)
        {
            var interfaceTargets = typeof(T).GetProperties(ReflectionUtility.Instance)
                .Where(x => x.PropertyType == (targetType ?? typeof(Target))).ToList();
            if (interfaceTargets.Count != 1)
            {
                Assert.Fail($"Target '{Target.DeclaringType}.{Target.Name}' cannot have {kind} on component '{typeof(T).Name}'."
                    .Concat(new[] { interfaceTargets.Count > 1 ? "Too many relevant targets:" : "No relevant targets." })
                    .Concat(interfaceTargets.Select(x => $"  - {x.Name}")).JoinNewLine());
            }

            return interfaceTargets.Single();
        }
    }
}
