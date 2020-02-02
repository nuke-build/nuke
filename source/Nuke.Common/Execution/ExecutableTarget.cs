// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Nuke.Common.Execution
{
    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public class ExecutableTarget
    {
        internal TargetDefinition Definition { get; set; }
        public MemberInfo Member { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Listed { get; set; }
        public Target Factory { get; set; }
        public ICollection<Expression<Func<bool>>> DynamicConditions { get; internal set; } = new List<Expression<Func<bool>>>();
        public ICollection<Expression<Func<bool>>> StaticConditions { get; internal set; } = new List<Expression<Func<bool>>>();
        public DependencyBehavior DependencyBehavior { get; set; }
        public bool AssuredAfterFailure { get; set; }
        public bool ProceedAfterFailure { get; set; }
        public ICollection<LambdaExpression> Requirements { get; internal set; } = new List<LambdaExpression>();
        public ICollection<Action> Actions { get; internal set; } = new List<Action>();
        public ICollection<ExecutableTarget> ExecutionDependencies { get; } = new List<ExecutableTarget>();
        public ICollection<ExecutableTarget> OrderDependencies { get; } = new List<ExecutableTarget>();
        public ICollection<ExecutableTarget> TriggerDependencies { get; } = new List<ExecutableTarget>();
        public ICollection<ExecutableTarget> Triggers { get; } = new List<ExecutableTarget>();

        public IReadOnlyCollection<ExecutableTarget> AllDependencies
            => ExecutionDependencies.Concat(OrderDependencies).Concat(TriggerDependencies).ToList();

        public bool IsDefault { get; set; }
        public ExecutionStatus Status { get; set; }
        public TimeSpan Duration { get; set; }
        public bool Invoked { get; set; }
        public string SkipReason { get; set; }
    }
}
