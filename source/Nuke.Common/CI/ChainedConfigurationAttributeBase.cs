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

        protected IEnumerable<ExecutableTarget> GetInvokedTargets(ExecutableTarget executableTarget)
        {
            return executableTarget
                .DescendantsAndSelf(x => x.ExecutionDependencies.Concat(x.Triggers), x => IrrelevantTargetNames.Contains(x.Name))
                .Where(x => x == executableTarget || NonEntryTargets.Contains(x.Name))
                .Reverse();
        }

        protected IEnumerable<ExecutableTarget> GetTargetDependencies(ExecutableTarget executableTarget)
        {
            return executableTarget.ExecutionDependencies.Where(x => !IrrelevantTargetNames.Contains(x.Name));
        }
    }
}
