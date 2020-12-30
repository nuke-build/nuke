// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.AzurePipelines
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AzurePipelinesAttribute : ConfigurationGeneratorAttributeBase
    {
        private readonly string _suffix;
        private readonly AzurePipelinesImage[] _images;

        public AzurePipelinesAttribute(
            AzurePipelinesImage image,
            params AzurePipelinesImage[] images)
            : this(suffix: null, image, images)
        {
        }

        public AzurePipelinesAttribute(
            [CanBeNull] string suffix,
            AzurePipelinesImage image,
            params AzurePipelinesImage[] images)
        {
            _suffix = suffix;
            _images = new[] { image }.Concat(images).ToArray();
        }

        public string[] InvokedTargets { get; set; } = new string[0];
        public string[] NonEntryTargets { get; set; } = new string[0];
        public string[] ExcludedTargets { get; set; } = new string[0];

        public bool TriggerDisabled { get; set; }
        public bool? TriggerBatch { get; set; }
        public string[] TriggerBranchesInclude { get; set; } = new string[0];
        public string[] TriggerBranchesExclude { get; set; } = new string[0];
        public string[] TriggerTagsInclude { get; set; } = new string[0];
        public string[] TriggerTagsExclude { get; set; } = new string[0];
        public string[] TriggerPathsInclude { get; set; } = new string[0];
        public string[] TriggerPathsExclude { get; set; } = new string[0];

        public bool PullRequestsAutoCancel { get; set; }
        public string[] PullRequestsBranchesInclude { get; set; } = new string[0];
        public string[] PullRequestsBranchesExclude { get; set; } = new string[0];
        public string[] PullRequestsPathsInclude { get; set; } = new string[0];
        public string[] PullRequestsPathsExclude { get; set; } = new string[0];

        public string[] ImportVariableGroups { get; set; } = new string[0];
        public string[] ImportSecrets { get; set; } = new string[0];
        public string ImportSystemAccessTokenAs { get; set; }

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
    }
}
