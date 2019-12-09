// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.CI.GitHubActions.Configuration;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
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
    public class GitHubActionsAttribute : ConfigurationAttributeBase
    {
        private readonly string _name;
        private readonly GitHubActionsImage[] _images;

        public GitHubActionsAttribute(
            string name,
            GitHubActionsImage image,
            params GitHubActionsImage[] images)
        {
            _name = name;
            _images = new[] { image }.Concat(images).ToArray();
        }

        private string ConfigurationFile => NukeBuild.RootDirectory / ".github" / "workflows" / $"{_name}.yml";

        protected override HostType HostType => HostType.GitHubActions;
        protected override IEnumerable<string> GeneratedFiles => new[] { ConfigurationFile };
        protected override IEnumerable<string> RelevantTargetNames => InvokedTargets;
        protected override IEnumerable<string> IrrelevantTargetNames => new string[0];

        public GitHubActionsTrigger[] On { get; set; } = new GitHubActionsTrigger[0];
        public string[] OnPushBranches { get; set; } = new string[0];
        public string[] OnPushTags { get; set; } = new string[0];
        public string[] OnPushIncludePaths { get; set; } = new string[0];
        public string[] OnPushExcludePaths { get; set; } = new string[0];
        public string[] OnPullRequestBranches { get; set; } = new string[0];
        public string[] OnPullRequestTags { get; set; } = new string[0];
        public string[] OnPullRequestIncludePaths { get; set; } = new string[0];
        public string[] OnPullRequestExcludePaths { get; set; } = new string[0];
        public string OnCronSchedule { get; set; }

        public string[] ImportSecrets { get; set; } = new string[0];
        public string ImportGitHubTokenAs { get; set; }

        public string[] InvokedTargets { get; set; } = new string[0];

        protected override CustomFileWriter CreateWriter()
        {
            return new CustomFileWriter(ConfigurationFile, indentationFactor: 2, commentPrefix: "#");
        }

        protected override ConfigurationEntity GetConfiguration(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            var configuration = new GitHubActionsConfiguration
                                {
                                    Name = _name,
                                    ShortTriggers = On,
                                    DetailedTriggers = GetTriggers().ToArray(),
                                    Jobs = _images.Select(x => GetJobs(x, relevantTargets)).ToArray()
                                };
            ControlFlow.Assert(configuration.ShortTriggers == null || configuration.DetailedTriggers.Length == 0,
                "configuration.ShortTriggers == null || configuration.DetailedTriggers.Length == 0");

            return configuration;
        }

        protected virtual GitHubActionsJob GetJobs(GitHubActionsImage image, IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            return new GitHubActionsJob
                   {
                       Name = image.GetValue().Replace(".", "_"),
                       Steps = GetSteps(image, relevantTargets).ToArray(),
                       Image = image
                   };
        }

        private IEnumerable<GitHubActionsStep> GetSteps(GitHubActionsImage image, IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            yield return new GitHubActionsUsingStep
                         {
                             Using = "actions/checkout@v1"
                         };

            var invocationCommand = image.ToString().StartsWithOrdinalIgnoreCase("Windows")
                ? $"powershell .\\{PowerShellScript}"
                : $"./{BashScript}";
            yield return new GitHubActionsRunStep
                         {
                             Command = $"{invocationCommand} {InvokedTargets.JoinSpace()}",
                             Imports = GetImports().ToDictionary(x => x.key, x => x.value)
                         };

            var artifacts = relevantTargets
                .SelectMany(x => ArtifactExtensions.ArtifactProducts[x.Definition])
                .Select(x => (AbsolutePath) x)
                // TODO: https://github.com/actions/upload-artifact/issues/11
                .Select(x => x.DescendantsAndSelf(y => y.Parent).FirstOrDefault(y => !y.ToString().ContainsOrdinalIgnoreCase("*")))
                .Distinct().ToList();
            foreach (var artifact in artifacts)
            {
                yield return new GitHubActionsArtifactStep
                             {
                                 Name = artifact.ToString().TrimStart(artifact.Parent.ToString()).TrimStart('/', '\\'),
                                 Path = NukeBuild.RootDirectory.GetUnixRelativePathTo(artifact)
                             };
            }
        }

        protected virtual IEnumerable<(string key, string value)> GetImports()
        {
            string GetSecretValue(string secret) => $"${{{{ secrets.{secret} }}}}";

            if (ImportGitHubTokenAs != null)
                yield return (ImportGitHubTokenAs, GetSecretValue("GITHUB_TOKEN"));

            foreach (var secret in ImportSecrets)
                yield return (secret, GetSecretValue(secret));
        }

        protected virtual IEnumerable<GitHubActionsDetailedTrigger> GetTriggers()
        {
            if (OnPushBranches.Length > 0 ||
                OnPushTags.Length > 0 ||
                OnPushIncludePaths.Length > 0 ||
                OnPushExcludePaths.Length > 0)
            {
                yield return new GitHubActionsVcsTrigger
                             {
                                 Kind = GitHubActionsTrigger.Push,
                                 Branches = OnPushBranches,
                                 Tags = OnPushTags,
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
