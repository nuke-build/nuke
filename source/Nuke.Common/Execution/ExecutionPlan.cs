using Nuke.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuke.Common.Execution
{
    public class ExecutionPlan
    {
        public bool IsParallel { get; set; }

        public IReadOnlyCollection<ExecutionItem> ExecutionItems { get; set; }

        public IReadOnlyCollection<ExecutableTarget> AllExecutionTargets { get; set; }

        public ExecutionPlan(IReadOnlyCollection<ExecutableTarget> targets)
        {
            AllExecutionTargets = targets;
            ExecutionItems = new[] {
                new ExecutionItem
                {
                    Targets = new Stack<ExecutableTarget>(targets.Reverse())
                }
            };
            IsParallel = false;
        }

        public ExecutionPlan(IReadOnlyCollection<ExecutionItem> executionItems, IReadOnlyCollection<ExecutableTarget> targets)
        {
            AllExecutionTargets = targets;
            ExecutionItems = executionItems;
            IsParallel = executionItems.Count > 1;
        }
    }
}
