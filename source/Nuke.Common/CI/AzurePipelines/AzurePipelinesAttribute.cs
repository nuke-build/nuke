// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.CI.AzurePipelines.Configuration;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.Common.CI.AzurePipelines
{
    [PublicAPI]
    public class AzurePipelinesAttribute : ConfigurationGenerationAttributeBase
    {
        private readonly AzurePipelinesImage[] _images;

        public AzurePipelinesAttribute(AzurePipelinesImage image, params AzurePipelinesImage[] images)
        {
            _images = new[] { image }.Concat(images).ToArray();
        }

        public string[] InvokedTargets { get; set; }
        public string[] NonEntryTargets { get; set; }
        public string[] ExcludedTargets { get; set; }

        public bool TriggerBatch { get; set; }
        public string[] TriggerBranchesInclude { get; set; }
        public string[] TriggerBranchesExclude { get; set; }
        public string[] TriggerTagsInclude { get; set; }
        public string[] TriggerTagsExclude { get; set; }
        public string[] TriggerPathsInclude { get; set; }
        public string[] TriggerPathsExclude { get; set; }

        public bool PullRequestsAutoCancel { get; set; }
        public string[] PullRequestsBranchesInclude { get; set; }
        public string[] PullRequestsBranchesExclude { get; set; }
        public string[] PullRequestsPathsInclude { get; set; }
        public string[] PullRequestsPathsExclude { get; set; }

        protected virtual string ConfigurationFile => NukeBuild.RootDirectory / "azure-pipelines.yml";

        protected override IEnumerable<string> GeneratedFiles => new[] { ConfigurationFile };

        protected override HostType HostType => HostType.AzurePipelines;

        protected override void Generate(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            var relevantTargets = InvokedTargets
                .SelectMany(x => ExecutionPlanner.GetExecutionPlan(executableTargets, new[] { x }))
                .Distinct()
                .Where(x => !ExcludedTargets.Contains(x.Name) && !NonEntryTargets.Contains(x.Name)).ToList();

            var configuration = GetConfiguration(relevantTargets);

            using var writer = new CustomFileWriter(ConfigurationFile, indentationFactor: 2);
            configuration.Write(writer);
        }

        protected virtual AzurePipelinesConfiguration GetConfiguration(IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            return new AzurePipelinesConfiguration
                   {
                       Stages = _images.Select(x => GetStage(x, relevantTargets)).ToArray()
                   };
        }

        protected virtual AzurePipelinesStage GetStage(
            AzurePipelinesImage image,
            IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            var lookupTable = new LookupTable<ExecutableTarget, AzurePipelinesJob>();
            var jobs = relevantTargets
                .Select(x => (ExecutableTarget: x, Job: GetJob(x, lookupTable)))
                .ForEachLazy(x => lookupTable.Add(x.ExecutableTarget, x.Job))
                .Select(x => x.Job).ToArray();

            return new AzurePipelinesStage
                   {
                       Name = image.GetValue(),
                       Image = image,
                       Dependencies = new AzurePipelinesStage[0],
                       Jobs = jobs
                   };
        }

        protected virtual AzurePipelinesJob GetJob(
            ExecutableTarget executableTarget,
            LookupTable<ExecutableTarget, AzurePipelinesJob> jobs)
        {
            var (partitionName, totalPartitions) = ArtifactExtensions.Partitions.GetValueOrDefault(executableTarget.Definition);
            var publishedArtifacts = ArtifactExtensions.ArtifactProducts[executableTarget.Definition]
                .Select(x => (AbsolutePath) x)
                .Select(x => x.DescendantsAndSelf(y => y.Parent).FirstOrDefault(y => !y.ToString().ContainsOrdinalIgnoreCase("*")))
                .Distinct()
                .Select(x => x.ToString().TrimStart(x.Parent.ToString()).TrimStart('/', '\\')).ToArray();

            // var artifactDependencies = (
            //     from artifactDependency in ArtifactExtensions.ArtifactDependencies[executableTarget.Definition]
            //     let dependency = executableTarget.ExecutionDependencies.Single(x => x.Factory == artifactDependency.Item1)
            //     let rules = (artifactDependency.Item2.Any()
            //             ? artifactDependency.Item2
            //             : ArtifactExtensions.ArtifactProducts[dependency.Definition])
            //         .Select(GetArtifactRule).ToArray()
            //     select new TeamCityArtifactDependency
            //            {
            //                BuildType = buildTypes[dependency].Single(x => x.Partition == null),
            //                ArtifactRules = rules
            //            }).ToArray<TeamCityDependency>();

            var invokedTargets = executableTarget
                .DescendantsAndSelf(x => x.ExecutionDependencies, x => NonEntryTargets.Contains(x.Name))
                .Where(x => x == executableTarget || NonEntryTargets.Contains(x.Name))
                .Reverse()
                .Select(x => x.Name).ToArray();

            var dependencies = executableTarget.ExecutionDependencies
                .Where(x => !ExcludedTargets.Contains(x.Name) && !NonEntryTargets.Contains(x.Name))
                .SelectMany(x => jobs[x]).ToArray();
            return new AzurePipelinesJob
                   {
                       Name = executableTarget.Name,
                       ScriptPath = PowerShellScript,
                       Dependencies = dependencies,
                       Parallel = totalPartitions,
                       PartitionName = partitionName,
                       InvokedTargets = invokedTargets,
                       PublishArtifacts = publishedArtifacts
                   };
        }

        protected virtual string GetArtifact(string artifact)
        {
            if (IsDescendantPath(NukeBuild.RootDirectory, artifact))
                artifact = GetRelativePath(NukeBuild.RootDirectory, artifact);

            return HasPathRoot(artifact)
                ? artifact
                : (UnixRelativePath) artifact;
        }
    }
}
