// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.AzurePipelines.Configuration;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;

partial class Build
{
    public class AzurePipelinesAttribute : Nuke.Common.CI.AzurePipelines.AzurePipelinesAttribute
    {
        private readonly string _suffix;
        private readonly AzurePipelinesImage[] _images;

        public AzurePipelinesAttribute(
            string suffix,
            AzurePipelinesImage image,
            params AzurePipelinesImage[] images)
            : base(suffix, image, images)
        {
            _suffix = suffix;
            _images = new[] { image }.Concat(images).ToArray();
        }

        public override IConfigurationGenerator GetConfigurationGenerator()
        {
            return new AzurePipelinesConfigurationGenerator(_suffix, _images)
                   {
                       AutoGenerate = AutoGenerate,
                       NonEntryTargets = NonEntryTargets,
                       ExcludedTargets = ExcludedTargets,
                       InvokedTargets = InvokedTargets,
                       TriggerDisabled = TriggerDisabled,
                       TriggerBatch = TriggerBatch,
                       TriggerBranchesInclude = TriggerBranchesInclude,
                       TriggerBranchesExclude = TriggerBranchesExclude,
                       TriggerTagsInclude = TriggerTagsInclude,
                       TriggerTagsExclude = TriggerTagsExclude,
                       TriggerPathsInclude = TriggerPathsInclude,
                       TriggerPathsExclude = TriggerPathsExclude,
                       PullRequestsAutoCancel = PullRequestsAutoCancel,
                       PullRequestsBranchesInclude = PullRequestsBranchesInclude,
                       PullRequestsBranchesExclude = PullRequestsBranchesExclude,
                       PullRequestsPathsInclude = PullRequestsPathsInclude,
                       PullRequestsPathsExclude = PullRequestsPathsExclude,
                       ImportVariableGroups = ImportVariableGroups,
                       ImportSecrets = ImportSecrets,
                       ImportSystemAccessTokenAs = ImportSystemAccessTokenAs
                   };
        }

        class AzurePipelinesConfigurationGenerator : Nuke.Common.CI.AzurePipelines.AzurePipelinesConfigurationGenerator
        {
            public AzurePipelinesConfigurationGenerator([CanBeNull] string suffix, IEnumerable<AzurePipelinesImage> images)
                : base(suffix, images)
            {
            }

            protected override AzurePipelinesJob GetJob(
                ExecutableTarget executableTarget,
                LookupTable<ExecutableTarget, AzurePipelinesJob> jobs,
                IReadOnlyCollection<ExecutableTarget> relevantTargets)
            {
                var job = base.GetJob(executableTarget, jobs, relevantTargets);

                var dictionary = new Dictionary<string, string>
                                 {
                                     { nameof(Compile), "⚙️" },
                                     { nameof(Test), "🚦" },
                                     { nameof(Pack), "📦" },
                                     { nameof(Coverage), "📊" },
                                     { nameof(Publish), "🚚" },
                                     { nameof(Announce), "🗣" }
                                 };
                var symbol = dictionary.GetValueOrDefault(job.Name).NotNull("symbol != null");
                job.DisplayName = job.PartitionName == null
                    ? $"{symbol} {job.DisplayName}"
                    : $"{symbol} {job.DisplayName} 🧩";
                return job;
            }
        }
    }
}
