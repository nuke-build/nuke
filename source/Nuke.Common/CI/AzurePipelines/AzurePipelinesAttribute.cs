﻿// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.CI.AzurePipelines.Configuration;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.Common.CI.AzurePipelines;

[PublicAPI]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class AzurePipelinesAttribute : ChainedConfigurationAttributeBase
{
    private readonly string _suffix;
    private readonly AzurePipelinesImage[] _images;

    private bool? _triggerBatch;
    private bool? _pullRequestsAutoCancel;
    private bool? _submodules;
    private bool? _largeFileStorage;
    private int? _fetchDepth;
    private bool? _clean;

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
        _suffix = suffix?.Replace(oldChar: ' ', newChar: '_');
        _images = new[] { image }.Concat(images).ToArray();
    }

    public override string IdPostfix => _suffix;

    public override Type HostType => typeof(AzurePipelines);
    public override AbsolutePath ConfigurationFile => ConfigurationDirectory / ConfigurationFileName;
    public override IEnumerable<AbsolutePath> GeneratedFiles => new[] { ConfigurationFile };
    protected virtual AbsolutePath ConfigurationDirectory => Build.RootDirectory;
    private string ConfigurationFileName => _suffix != null ? $"azure-pipelines.{_suffix}.yml" : "azure-pipelines.yml";

    public override IEnumerable<string> RelevantTargetNames => InvokedTargets;

    public string[] InvokedTargets { get; set; } = new string[0];

    public bool TriggerDisabled { get; set; }

    public bool Submodules
    {
        set => _submodules = value;
        get => throw new NotSupportedException();
    }

    public int FetchDepth
    {
        set => _fetchDepth = value;
        get => throw new NotSupportedException();
    }

    public bool Clean
    {
        set => _clean = value;
        get => throw new NotSupportedException();
    }

    public bool LargeFileStorage
    {
        set => _largeFileStorage = value;
        get => throw new NotSupportedException();
    }

    public bool TriggerBatch
    {
        set => _triggerBatch = value;
        get => throw new NotSupportedException();
    }

    public string[] TriggerBranchesInclude { get; set; } = new string[0];
    public string[] TriggerBranchesExclude { get; set; } = new string[0];
    public string[] TriggerTagsInclude { get; set; } = new string[0];
    public string[] TriggerTagsExclude { get; set; } = new string[0];
    public string[] TriggerPathsInclude { get; set; } = new string[0];
    public string[] TriggerPathsExclude { get; set; } = new string[0];

    public bool PullRequestsDisabled { get; set; }

    public bool? PullRequestsAutoCancel
    {
        set => _pullRequestsAutoCancel = value;
        get => throw new NotSupportedException();
    }

    public string[] PullRequestsBranchesInclude { get; set; } = new string[0];
    public string[] PullRequestsBranchesExclude { get; set; } = new string[0];
    public string[] PullRequestsPathsInclude { get; set; } = new string[0];
    public string[] PullRequestsPathsExclude { get; set; } = new string[0];

    public string[] CacheKeyFiles { get; set; } = { "**/global.json", "**/*.csproj", "**/Directory.Packages.props" };
    public string[] CachePaths { get; set; } = { AzurePipelinesCachePaths.Nuke, AzurePipelinesCachePaths.NuGet };

    public string[] ImportVariableGroups { get; set; } = new string[0];
    public string[] ImportSecrets { get; set; } = new string[0];
    public bool EnableAccessToken { get; set; }

    public override CustomFileWriter CreateWriter(StreamWriter streamWriter)
    {
        return new CustomFileWriter(streamWriter, indentationFactor: 2, commentPrefix: "#");
    }

    public override ConfigurationEntity GetConfiguration(IReadOnlyCollection<ExecutableTarget> relevantTargets)
    {
        return new AzurePipelinesConfiguration
               {
                   VariableGroups = ImportVariableGroups,
                   VcsPushTrigger = GetVcsPushTrigger(),
                   VcsPullRequestTrigger = GetVcsPullRequestTrigger(),
                   Stages = _images.Select(x => GetStage(x, relevantTargets)).ToArray()
               };
    }

    [CanBeNull]
    protected AzurePipelinesVcsPushTrigger GetVcsPushTrigger()
    {
        if (!TriggerDisabled &&
            _triggerBatch == null &&
            TriggerBranchesInclude.Length == 0 &&
            TriggerBranchesExclude.Length == 0 &&
            TriggerTagsInclude.Length == 0 &&
            TriggerTagsExclude.Length == 0 &&
            TriggerPathsInclude.Length == 0 &&
            TriggerPathsExclude.Length == 0)
            return null;

        return new AzurePipelinesVcsPushTrigger
               {
                   Disabled = TriggerDisabled,
                   Batch = _triggerBatch,
                   BranchesInclude = TriggerBranchesInclude,
                   BranchesExclude = TriggerBranchesExclude,
                   TagsInclude = TriggerTagsInclude,
                   TagsExclude = TriggerTagsExclude,
                   PathsInclude = TriggerPathsInclude,
                   PathsExclude = TriggerPathsExclude,
               };
    }

    [CanBeNull]
    protected AzurePipelinesVcsPushTrigger GetVcsPullRequestTrigger()
    {
        if (!PullRequestsDisabled &&
            _pullRequestsAutoCancel == null &&
            PullRequestsBranchesInclude.Length == 0 &&
            PullRequestsBranchesExclude.Length == 0 &&
            PullRequestsPathsInclude.Length == 0 &&
            PullRequestsPathsExclude.Length == 0)
            return null;

        return new AzurePipelinesVcsPushTrigger
               {
                   Disabled = PullRequestsDisabled,
                   AutoCancel = _pullRequestsAutoCancel,
                   BranchesInclude = PullRequestsBranchesInclude,
                   BranchesExclude = PullRequestsBranchesExclude,
                   TagsInclude = new string[0],
                   TagsExclude = new string[0],
                   PathsInclude = PullRequestsPathsInclude,
                   PathsExclude = PullRequestsPathsExclude,
               };
    }

    protected virtual AzurePipelinesStage GetStage(
        AzurePipelinesImage image,
        IReadOnlyCollection<ExecutableTarget> relevantTargets)
    {
        var lookupTable = new LookupTable<ExecutableTarget, AzurePipelinesJob>();
        var jobs = relevantTargets
            .Select(x => (ExecutableTarget: x, Job: GetJob(x, lookupTable, relevantTargets, image)))
            .ForEachLazy(x => lookupTable.Add(x.ExecutableTarget, x.Job))
            .Select(x => x.Job).ToArray();

        return new AzurePipelinesStage
               {
                   Name = image.GetValue().Replace("-", "_").Replace(".", "_"),
                   DisplayName = image.GetValue(),
                   Image = image,
                   Dependencies = new AzurePipelinesStage[0],
                   Jobs = jobs
               };
    }

    protected virtual AzurePipelinesJob GetJob(
        ExecutableTarget executableTarget,
        LookupTable<ExecutableTarget, AzurePipelinesJob> jobs,
        IReadOnlyCollection<ExecutableTarget> relevantTargets,
        AzurePipelinesImage image)
    {
        var totalPartitions = executableTarget.PartitionSize ?? 0;
        var dependencies = GetTargetDependencies(executableTarget).SelectMany(x => jobs[x]).ToArray();
        return new AzurePipelinesJob
               {
                   Name = executableTarget.Name,
                   DisplayName = executableTarget.Name,
                   Dependencies = dependencies,
                   Parallel = totalPartitions,
                   Steps = GetSteps(executableTarget, relevantTargets, image).ToArray(),
               };
    }

    protected virtual IEnumerable<AzurePipelinesStep> GetSteps(
        ExecutableTarget executableTarget,
        IReadOnlyCollection<ExecutableTarget> relevantTargets,
        AzurePipelinesImage image)
    {
        if (_submodules.HasValue || _largeFileStorage.HasValue || _fetchDepth.HasValue || _clean.HasValue)
        {
            yield return new AzurePipelineCheckoutStep
                         {
                             InclueSubmodules = _submodules,
                             IncludeLargeFileStorage = _largeFileStorage,
                             FetchDepth = _fetchDepth,
                             Clean = _clean
                         };
        }

        if (CacheKeyFiles.Any())
        {
            foreach (var cachePath in CachePaths.NotNull())
            {
                yield return new AzurePipelinesCacheStep
                             {
                                 Image = image,
                                 KeyFiles = CacheKeyFiles,
                                 Path = cachePath
                             };
            }
        }

        string GetArtifactPath(AbsolutePath path)
            => Build.RootDirectory.Contains(path)
                ? Build.RootDirectory.GetUnixRelativePathTo(path)
                : path;

        var publishedArtifacts = executableTarget.ArtifactProducts
            .Select(x => (AbsolutePath) x)
            .Select(x => x.DescendantsAndSelf(y => y.Parent).FirstOrDefault(y => !y.ToString().ContainsOrdinalIgnoreCase("*")))
            .Distinct()
            .Select(GetArtifactPath).ToArray();

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

        var chainLinkTargets = GetInvokedTargets(executableTarget, relevantTargets).ToArray();
        yield return new AzurePipelinesCmdStep
                     {
                         BuildCmdPath = BuildCmdPath,
                         PartitionSize = executableTarget.PartitionSize,
                         InvokedTargets = chainLinkTargets.Select(x => x.Name).ToArray(),
                         Imports = GetImports().ToDictionary(x => x.Key, x => x.Value)
                     };

        foreach (var publishedArtifact in publishedArtifacts)
        {
            var artifactName = publishedArtifact.Split('/').Last();
            yield return new AzurePipelinesPublishStep
                         {
                             ArtifactName = artifactName,
                             PathToPublish = publishedArtifact
                         };
        }
    }

    protected virtual IEnumerable<(string Key, string Value)> GetImports()
    {
        static string GetSecretValue(string secret) => $"$({secret})";

        if (EnableAccessToken)
            yield return ("SYSTEM_ACCESSTOKEN", GetSecretValue("System.AccessToken"));

        foreach (var secret in ImportSecrets)
            yield return (secret, GetSecretValue(secret));
    }

    protected virtual string GetArtifact(string artifact)
    {
        if (Build.RootDirectory.Contains(artifact))
            artifact = GetRelativePath(Build.RootDirectory, artifact);

        return HasPathRoot(artifact)
            ? artifact
            : (UnixRelativePath) artifact;
    }
}
