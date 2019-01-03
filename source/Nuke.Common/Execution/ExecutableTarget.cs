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
    [DebuggerDisplay("{" + nameof(ToDebugString) + "}")]
    internal class ExecutableTarget
    {
        public ExecutableTarget(
            PropertyInfo property,
            Target factory,
            TargetDefinition definition,
            bool isDefault)
        {
            Property = property;
            Factory = factory;
            Definition = definition;
            IsDefault = isDefault;
        }

        public PropertyInfo Property { get; }
        public string Name => Property.Name;
        public Target Factory { get; }
        public TargetDefinition Definition { get; }
        public string Description => Definition.Description;
        public List<Func<bool>> Conditions => Definition.Conditions;
        public IReadOnlyList<LambdaExpression> Requirements => Definition.Requirements;
        public IReadOnlyList<Action> Actions => Definition.Actions;
        public ICollection<ExecutableTarget> ExecutionDependencies { get; } = new List<ExecutableTarget>();
        public ICollection<ExecutableTarget> OrderDependencies { get; } = new List<ExecutableTarget>();
        public ICollection<ExecutableTarget> TriggerDependencies { get; } = new List<ExecutableTarget>();
        public ICollection<ExecutableTarget> Triggers { get; } = new List<ExecutableTarget>();
        public IReadOnlyCollection<ExecutableTarget> AllDependencies
            => ExecutionDependencies.Concat(OrderDependencies).Concat(TriggerDependencies).ToList();
        public bool IsDefault { get; }

        public ExecutionStatus Status { get; set; }
        public TimeSpan Duration { get; set; }
        public bool Invoked { get; set; }

        internal string ToDebugString()
        {
            return Name;
        }
    }
}
