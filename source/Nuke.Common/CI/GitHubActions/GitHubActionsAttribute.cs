// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.GitHubActions
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class GitHubActionsAttribute : ConfigurationGeneratorAttributeBase
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
        public string OnCronSchedule { get; set; }

        public string[] ImportSecrets { get; set; } = new string[0];
        public string ImportGitHubTokenAs { get; set; }

        public bool PublishArtifacts { get; set; } = true;

        public string[] InvokedTargets { get; set; } = new string[0];

        public override IConfigurationGenerator GetConfigurationGenerator()
        {
            return new GitHubActionsConfigurationGenerator(_name, _images)
                   {
                       AutoGenerate = AutoGenerate,
                       On = On,
                       OnPushBranches = OnPushBranches,
                       OnPushBranchesIgnore = OnPushBranchesIgnore,
                       OnPushTags = OnPushTags,
                       OnPushTagsIgnore = OnPushTagsIgnore,
                       OnPushIncludePaths = OnPushIncludePaths,
                       OnPushExcludePaths = OnPushExcludePaths,
                       OnPullRequestBranches = OnPullRequestBranches,
                       OnPullRequestTags = OnPullRequestTags,
                       OnPullRequestIncludePaths = OnPullRequestIncludePaths,
                       OnPullRequestExcludePaths = OnPullRequestExcludePaths,
                       OnCronSchedule = OnCronSchedule,
                       ImportSecrets = ImportSecrets,
                       ImportGitHubTokenAs = ImportGitHubTokenAs,
                       PublishArtifacts = PublishArtifacts,
                       InvokedTargets = InvokedTargets
                   };
        }
    }
}
