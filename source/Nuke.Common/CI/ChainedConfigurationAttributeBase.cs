// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI
{
    [PublicAPI]
    public abstract class ChainedConfigurationAttributeBase : ConfigurationAttributeBase
    {
        public override IEnumerable<string> IrrelevantTargetNames => NonEntryTargets.Concat(ExcludedTargets);

        public string[] NonEntryTargets { get; set; } = new string[0];
        public string[] ExcludedTargets { get; set; } = new string[0];

        protected IEnumerable<ExecutableTarget> GetInvokedTargets(ExecutableTarget executableTarget, IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            var invokedTargets = new List<ExecutableTarget> { executableTarget };
            ICollection<ExecutableTarget> additionalInvokedTargets;
            do
            {
                additionalInvokedTargets = invokedTargets.SelectMany(x => x.ExecutionDependencies)
                    .Concat(invokedTargets.SelectMany(x => x.Triggers))
                    .Except(invokedTargets)
                    .Where(x => NonEntryTargets.Contains(x.Name))
                    .Where(x => !ExcludedTargets.Contains(x.Name)).ToList();
                invokedTargets.AddRange(additionalInvokedTargets);
            } while (additionalInvokedTargets.Count > 0);

            ControlFlow.Assert(invokedTargets.Except(new[] { executableTarget }).Count(x => x.PartitionSize != null) == 0,
                $"Non-entry targets for {executableTarget.Name} cannot define partitions.");
            return ExecutionPlanner.GetExecutionPlan(invokedTargets, new[] { executableTarget.Name });
        }

        protected IEnumerable<ExecutableTarget> GetTargetDependencies(ExecutableTarget executableTarget)
        {
            return executableTarget.ExecutionDependencies.Where(x => !IrrelevantTargetNames.Contains(x.Name));
        }
    }
}
