﻿// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.CI.GitHubActions.Configuration;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.GitHubActions;

/// <summary>
/// Interface according to the <a href="https://help.github.com/en/articles/workflow-syntax-for-github-actions">official website</a>.
/// </summary>
[PublicAPI]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class GitHubActionsAttribute : ConfigurationAttributeBase
{
    private readonly string _name;
    private readonly GitHubActionsImage[] _images;
    private GitHubActionsSubmodules? _submodules;
    private bool? _lfs;
    private uint? _fetchDepth;
    private bool? _progress;
    private string _filter;

    public GitHubActionsAttribute(
        string name,
        GitHubActionsImage image,
        params GitHubActionsImage[] images)
    {
        _name = name.Replace(oldChar: ' ', newChar: '_');
        _images = new[] { image }.Concat(images).ToArray();
    }

    public override string IdPostfix => _name;
    public override Type HostType => typeof(GitHubActions);
    public override AbsolutePath ConfigurationFile => Build.RootDirectory / ".github" / "workflows" / $"{_name}.yml";
    public override IEnumerable<AbsolutePath> GeneratedFiles => new[] { ConfigurationFile };

    public override IEnumerable<string> RelevantTargetNames => InvokedTargets;
    public override IEnumerable<string> IrrelevantTargetNames => new string[0];

    public GitHubActionsTrigger[] On { get; set; } = new GitHubActionsTrigger[0];
    public string[] OnPushBranches { get; set; } = new string[0];
    public string[] OnPushBranchesIgnore { get; set; } = new string[0];
    public string[] OnPushTags { get; set; } = new string[0];
    public string[] OnPushTagsIgnore { get; set; } = new string[0];
    public string[] OnPushIncludePaths { get; set; } = new string[0];
    public string[] OnPushExcludePaths { get; set; } = new string[0];
    public string[] OnPullRequestBranches { get; set; } = new string[0];
    public string[] OnPullRequestTags { get; set; } = new string[0];
    public string[] OnPullRequestIncludePaths { get; set; } = new string[0];
    public string[] OnPullRequestExcludePaths { get; set; } = new string[0];
    public string[] OnWorkflowDispatchOptionalInputs { get; set; } = new string[0];
    public string[] OnWorkflowDispatchRequiredInputs { get; set; } = new string[0];
    public string OnCronSchedule { get; set; }

    public string[] ImportSecrets { get; set; } = new string[0];
    public bool EnableGitHubToken { get; set; }
    public GitHubActionsPermissions[] WritePermissions { get; set; } = new GitHubActionsPermissions[0];
    public GitHubActionsPermissions[] ReadPermissions { get; set; } = new GitHubActionsPermissions[0];

    public string[] CacheIncludePatterns { get; set; } = { ".nuke/temp", "~/.nuget/packages" };
    public string[] CacheExcludePatterns { get; set; } = new string[0];
    public string[] CacheKeyFiles { get; set; } = { "**/global.json", "**/*.csproj", "**/Directory.Packages.props" };

    public bool PublishArtifacts { get; set; } = true;
    public string PublishCondition { get; set; }

    public int TimeoutMinutes { get; set; }
    
    public string EnvironmentName { get; set; }
    public string EnvironmentUrl { get; set; }

    public string ConcurrencyGroup { get; set; }
    public bool ConcurrencyCancelInProgress { get; set; }

    public string JobConcurrencyGroup { get; set; }
    public bool JobConcurrencyCancelInProgress { get; set; }

    public string[] InvokedTargets { get; set; } = new string[0];

    public GitHubActionsSubmodules Submodules
    {
        set => _submodules = value;
        get => throw new NotSupportedException();
    }

    public bool Lfs
    {
        set => _lfs = value;
        get => throw new NotSupportedException();
    }

    public uint FetchDepth
    {
        set => _fetchDepth = value;
        get => throw new NotSupportedException();
    }

    public bool Progress
    {
        set => _progress = value;
        get => throw new NotSupportedException();
    }

    public string Filter
    {
        set => _filter = value;
        get => throw new NotSupportedException();
    }

    public override CustomFileWriter CreateWriter(StreamWriter streamWriter)
    {
        return new CustomFileWriter(streamWriter, indentationFactor: 2, commentPrefix: "#");
    }

    public override ConfigurationEntity GetConfiguration(IReadOnlyCollection<ExecutableTarget> relevantTargets)
    {
        var configuration = new GitHubActionsConfiguration
                            {
                                Name = _name,
                                ShortTriggers = On,
                                DetailedTriggers = GetTriggers().ToArray(),
                                Permissions = WritePermissions.Select(x => (x, "write"))
                                    .Concat(ReadPermissions.Select(x => (x, "read"))).ToArray(),
                                ConcurrencyGroup = ConcurrencyGroup,
                                ConcurrencyCancelInProgress = ConcurrencyCancelInProgress,
                                Jobs = _images.Select(x => GetJobs(x, relevantTargets)).ToArray()
                            };

        Assert.True(configuration.ShortTriggers.Length == 0 || configuration.DetailedTriggers.Length == 0,
            $"Workflows can only define either shorthand '{nameof(On)}' or '{nameof(On)}*' triggers");
        Assert.True(configuration.ShortTriggers.Length > 0 || configuration.DetailedTriggers.Length > 0,
            $"Workflows must define either shorthand '{nameof(On)}' or '{nameof(On)}*' triggers");

        return configuration;
    }

    protected virtual GitHubActionsJob GetJobs(GitHubActionsImage image, IReadOnlyCollection<ExecutableTarget> relevantTargets)
    {
        return new GitHubActionsJob
               {
                   Name = image.GetValue().Replace(".", "_"),
                   EnvironmentName = EnvironmentName,
                   EnvironmentUrl = EnvironmentUrl,
                   Steps = GetSteps(image, relevantTargets).ToArray(),
                   Image = image,
                   TimeoutMinutes = TimeoutMinutes,
                   ConcurrencyGroup = JobConcurrencyGroup,
                   ConcurrencyCancelInProgress = JobConcurrencyCancelInProgress
               };
    }

    private IEnumerable<GitHubActionsStep> GetSteps(GitHubActionsImage image, IReadOnlyCollection<ExecutableTarget> relevantTargets)
    {
        yield return new GitHubActionsCheckoutStep
                     {
                         Submodules = _submodules,
                         Lfs = _lfs,
                         FetchDepth = _fetchDepth,
                         Progress = _progress,
                         Filter = _filter
                     };

        if (CacheKeyFiles.Any())
        {
            yield return new GitHubActionsCacheStep
                         {
                             IncludePatterns = CacheIncludePatterns,
                             ExcludePatterns = CacheExcludePatterns,
                             KeyFiles = CacheKeyFiles
                         };
        }

        yield return new GitHubActionsRunStep
                     {
                         BuildCmdPath = BuildCmdPath,
                         InvokedTargets = InvokedTargets,
                         Imports = GetImports().ToDictionary(x => x.Key, x => x.Value)
                     };

        if (PublishArtifacts)
        {
            var artifacts = relevantTargets
                .SelectMany(x => x.ArtifactProducts)
                .Select(x => (AbsolutePath)x)
                // TODO: https://github.com/actions/upload-artifact/issues/11
                .Select(x => x.DescendantsAndSelf(y => y.Parent).FirstOrDefault(y => !y.ToString().ContainsOrdinalIgnoreCase("*")))
                .Distinct().ToList();

            foreach (var artifact in artifacts)
            {
                yield return new GitHubActionsArtifactStep
                             {
                                 Name = artifact.ToString().TrimStart(artifact.Parent.ToString()).TrimStart('/', '\\'),
                                 Path = Build.RootDirectory.GetUnixRelativePathTo(artifact),
                                 Condition = PublishCondition
                             };
            }
        }
    }

    protected virtual IEnumerable<(string Key, string Value)> GetImports()
    {
        foreach (var input in OnWorkflowDispatchOptionalInputs.Concat(OnWorkflowDispatchRequiredInputs))
            yield return (input, $"${{{{ github.event.inputs.{input} }}}}");

        static string GetSecretValue(string secret)
            => $"${{{{ secrets.{secret.SplitCamelHumpsWithKnownWords().JoinUnderscore().ToUpperInvariant()} }}}}";

        foreach (var secret in ImportSecrets)
            yield return (secret, GetSecretValue(secret));

        if (EnableGitHubToken)
            yield return ("GITHUB_TOKEN", GetSecretValue("GITHUB_TOKEN"));
    }

    protected virtual IEnumerable<GitHubActionsDetailedTrigger> GetTriggers()
    {
        if (OnPushBranches.Length > 0 ||
            OnPushBranchesIgnore.Length > 0 ||
            OnPushTags.Length > 0 ||
            OnPushTagsIgnore.Length > 0 ||
            OnPushIncludePaths.Length > 0 ||
            OnPushExcludePaths.Length > 0)
        {
            Assert.True(
                OnPushBranches.Length == 0 && OnPushTags.Length == 0 || OnPushBranchesIgnore.Length == 0 && OnPushTagsIgnore.Length == 0,
                $"Cannot use {nameof(OnPushBranches)}/{nameof(OnPushTags)} and {nameof(OnPushBranchesIgnore)}/{nameof(OnPushTagsIgnore)} in combination");

            yield return new GitHubActionsVcsTrigger
                         {
                             Kind = GitHubActionsTrigger.Push,
                             Branches = OnPushBranches,
                             BranchesIgnore = OnPushBranchesIgnore,
                             Tags = OnPushTags,
                             TagsIgnore = OnPushTagsIgnore,
                             IncludePaths = OnPushIncludePaths,
                             ExcludePaths = OnPushExcludePaths
                         };
        }

        if (OnPullRequestBranches.Length > 0 ||
            OnPullRequestTags.Length > 0 ||
            OnPullRequestIncludePaths.Length > 0 ||
            OnPullRequestExcludePaths.Length > 0)
        {
            yield return new GitHubActionsVcsTrigger
                         {
                             Kind = GitHubActionsTrigger.PullRequest,
                             Branches = OnPullRequestBranches,
                             BranchesIgnore = new string[0],
                             Tags = OnPullRequestTags,
                             TagsIgnore = new string[0],
                             IncludePaths = OnPullRequestIncludePaths,
                             ExcludePaths = OnPullRequestExcludePaths
                         };
        }

        if (OnWorkflowDispatchOptionalInputs.Length > 0 ||
            OnWorkflowDispatchRequiredInputs.Length > 0)
        {
            yield return new GitHubActionsWorkflowDispatchTrigger
                         {
                             OptionalInputs = OnWorkflowDispatchOptionalInputs,
                             RequiredInputs = OnWorkflowDispatchRequiredInputs
                         };
        }

        if (OnCronSchedule != null)
            yield return new GitHubActionsScheduledTrigger { Cron = OnCronSchedule };
    }
}
