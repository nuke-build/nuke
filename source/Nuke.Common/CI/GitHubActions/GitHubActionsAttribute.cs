// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.CI.GitHubActions.Configuration;
using Nuke.Common.Execution;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.Common.CI.GitHubActions
{
    /// <summary>
    /// Interface according to the <a href="https://help.github.com/en/articles/workflow-syntax-for-github-actions">official website</a>.
    /// </summary>
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class GitHubActionsAttribute : ConfigurationGenerationAttributeBase
    {
        private readonly string _name;

        public GitHubActionsAttribute(string name)
        {
            _name = name;
        }

        private AbsolutePath GitHubDirectory => NukeBuild.RootDirectory / ".github";
        private AbsolutePath WorkflowsDirectory => GitHubDirectory / "workflows";
        private string ConfigurationFile => WorkflowsDirectory / $"{_name}.yml";

        protected override IEnumerable<string> GeneratedFiles => new[] { ConfigurationFile };

        protected override HostType HostType => HostType.GitHubActions;

        public GitHubActionsVirtualEnvironments[] RunsOn { get; set; }

        public GitHubActionsOn[] On { get; set; }
        public string[] OnPushBranches { get; set; }
        public string[] OnPushTags { get; set; }
        public string[] OnPushIncludePaths { get; set; }
        public string[] OnPushExcludePaths { get; set; }
        public string[] OnPullRequestBranches { get; set; }
        public string[] OnPullRequestTags { get; set; }
        public string[] OnPullRequestIncludePaths { get; set; }
        public string[] OnPullRequestExcludePaths { get; set; }
        public string OnCronSchedule { get; set; }

        public string[] ImportSecrets { get; set; }
        public bool ImportGitHubToken { get; set; }

        public string[] InvokedTargets { get; set; }

        protected override void Generate(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            var relevantTargets = InvokedTargets
                .SelectMany(x => ExecutionPlanner.GetExecutionPlan(executableTargets, new[] { x }))
                .Distinct().ToList();
            var configuration = GetConfiguration(build, relevantTargets);

            using (var writer = new CustomFileWriter(ConfigurationFile, indentationFactor: 2))
            {
                configuration.Write(writer);
            }
        }

        protected virtual GitHubActionsConfiguration GetConfiguration(NukeBuild targets, IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            var configuration = new GitHubActionsConfiguration
                                {
                                    Name = _name,
                                    ShortTriggers = On,
                                    DetailedTriggers = GetTriggers().ToArray(),
                                    Jobs = RunsOn.Select(x => GetJobs(x, relevantTargets)).ToArray()
                                };
            ControlFlow.Assert(configuration.ShortTriggers == null || configuration.DetailedTriggers.Length == 0,
                "configuration.ShortTriggers == null || configuration.DetailedTriggers.Length == 0");

            return configuration;
        }

        protected virtual GitHubActionsJob GetJobs(GitHubActionsVirtualEnvironments environment, IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            return new GitHubActionsJob
                   {
                       Name = environment.ConvertToString().Replace(".", "_"),
                       Steps = GetSteps(environment, relevantTargets).ToArray(),
                       Environment = environment
                   };
        }

        private IEnumerable<GitHubActionsStep> GetSteps(GitHubActionsVirtualEnvironments environment, IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            yield return new GitHubActionsUsingStep
                         {
                             Using = "actions/checkout@v1"
                         };

            var invocationCommand = environment.ToString().StartsWithOrdinalIgnoreCase("Windows")
                ? "powershell .\\build.ps1"
                : "./build.sh";
            yield return new GitHubActionsRunStep
                         {
                             Command = $"{invocationCommand} {InvokedTargets.JoinSpace()}",
                             Imports = GetImports().ToDictionary(x => x.key, x => x.value)
                         };

            var artifacts = relevantTargets
                .Select(x => ArtifactExtensions.ArtifactProducts[x.Definition])
                .SelectMany(x => x)
                .Select(x => (AbsolutePath) x)
                // TODO: https://github.com/actions/upload-artifact/issues/11
                .Select(x => x.DescendantsAndSelf(y => y.Parent).FirstOrDefault(y => !y.ToString().ContainsOrdinalIgnoreCase("*")))
                .Distinct().ToList();
            foreach (var artifact in artifacts)
            {
                yield return new GitHubActionsArtifactStep
                             {
                                 Name = artifact.ToString().TrimStart(artifact.Parent.ToString()).TrimStart('/', '\\'),
                                 Path = GetRelativePath(NukeBuild.RootDirectory, artifact)
                             };
            }
        }

        protected virtual IEnumerable<(string key, string value)> GetImports()
        {
            foreach (var secret in GetSecrets())
                yield return (secret, $"{{{{ secret.{secret} }}}}");
        }

        protected virtual IEnumerable<string> GetSecrets()
        {
            if (ImportGitHubToken)
                yield return "GITHUB_TOKEN";

            foreach (var secret in ImportSecrets ?? new string[0])
                yield return secret;
        }

        protected virtual IEnumerable<GitHubActionsTrigger> GetTriggers()
        {
            if (OnPushBranches != null ||
                OnPushTags != null ||
                OnPushIncludePaths != null ||
                OnPushExcludePaths != null)
            {
                yield return new GitHubActionsVcsTrigger
                             {
                                 Kind = GitHubActionsOn.Push,
                                 Branches = OnPushBranches,
                                 Tags = OnPushTags,
                                 IncludePaths = OnPushIncludePaths,
                                 ExcludePaths = OnPushExcludePaths
                             };
            }

            if (OnPullRequestBranches != null ||
                OnPullRequestTags != null ||
                OnPullRequestIncludePaths != null ||
                OnPullRequestExcludePaths != null)
            {
                yield return new GitHubActionsVcsTrigger
                             {
                                 Kind = GitHubActionsOn.PullRequest,
                                 Branches = OnPullRequestBranches,
                                 Tags = OnPullRequestTags,
                                 IncludePaths = OnPullRequestIncludePaths,
                                 ExcludePaths = OnPullRequestExcludePaths
                             };
            }

            if (OnCronSchedule != null)
                yield return new GitHubActionsScheduledTrigger { Cron = OnCronSchedule };
        }
    }
}
