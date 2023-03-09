// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;
// ReSharper disable MissingBaseTypeHighlighting

namespace Nuke.Common.Execution
{
    [DebuggerDisplay($"{{{nameof(Name)}}} ({{{nameof(Status)}}})")]
    public class ExecutableTarget
    {
        internal TargetDefinition Definition { get; set; }
        internal Stopwatch Stopwatch { get; } = new();
        internal Func<bool> Intercept { get; set; }

        public MemberInfo Member { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Listed { get; set; }
        public Delegate Factory { get; set; }
        public List<(string Text, Func<bool> Delegate)> DynamicConditions { get; internal set; } = new();
        public List<(string Text, Func<bool> Delegate)> StaticConditions { get; internal set; } = new();
        public DependencyBehavior DependencyBehavior { get; internal set; }
        public bool AssuredAfterFailure { get; internal set; }
        public bool ProceedAfterFailure { get; internal set; }
        public List<LambdaExpression> DelegateRequirements { get; internal set; } = new();
        public List<ToolRequirement> ToolRequirements { get; internal set; } = new();
        public List<Action> Actions { get; internal set; } = new();

        public List<ExecutableTarget> ExecutionDependencies { get; } = new();
        public List<ExecutableTarget> OrderDependencies { get; } = new();
        public List<ExecutableTarget> TriggerDependencies { get; } = new();
        public List<ExecutableTarget> Triggers { get; } = new();

        public IReadOnlyCollection<ExecutableTarget> AllDependencies
            => ExecutionDependencies.Concat(OrderDependencies).Concat(TriggerDependencies).ToList();

        public LookupTable<ExecutableTarget, string> ArtifactDependencies { get; internal set; } = new();
        public List<string> ArtifactProducts { get; internal set; } = new();

        public int? PartitionSize { get; set; }

        public TimeSpan Duration => Stopwatch.Elapsed;
        public bool IsDefault { get; set; }
        public ExecutionStatus Status { get; set; }
        public bool Invoked { get; set; }
        public Dictionary<string, string> SummaryInformation { get; internal set; } = new();

        public string Skipped
        {
            get => SummaryInformation.GetValueOrDefault(nameof(Skipped));
            set => SummaryInformation.AddPairWhenValueNotNull(nameof(Skipped), value);
        }

        public string OnlyWhen
        {
            get => SummaryInformation.GetValueOrDefault(nameof(OnlyWhen));
            set => SummaryInformation.AddPairWhenValueNotNull(nameof(OnlyWhen), value);
        }
    }
}
