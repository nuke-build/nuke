// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzureDevOps;
using Nuke.Common.CI.Bitrise;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.CI.GitLab;
using Nuke.Common.CI.Jenkins;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.CI.TravisCI;
using Nuke.Common.Execution;
using Nuke.Common.Tools.Git;

namespace Nuke.Common.Git
{
    /// <summary>
    /// Injects an instance of <see cref="GitRepository"/> based on the local repository.
    /// </summary>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Default)]
    public class GitRepositoryAttribute : InjectionAttributeBase
    {
        [CanBeNull]
        public string Branch { get; set; }

        [CanBeNull]
        public string Remote { get; set; }

        public override object GetValue(MemberInfo member, object instance)
        {
            return ControlFlow.SuppressErrors(() =>
                GitRepository.FromLocalDirectory(
                    NukeBuild.RootDirectory,
                    Branch ?? GetBranch(),
                    Remote ?? "origin"));
        }

        private string GetBranch()
        {
            return
                AppVeyor.Instance?.RepositoryBranch ??
                Bitrise.Instance?.GitBranch ??
                GitLab.Instance?.CommitRefName ??
                Jenkins.Instance?.GitBranch ??
                Jenkins.Instance?.BranchName ??
                TeamCity.Instance?.BranchName ??
                AzureDevOps.Instance?.SourceBranchName ??
                TravisCI.Instance?.Branch ??
                GitHubActions.Instance?.GitHubRef ??
                GitTasks.GitCurrentBranch();
        }
    }
}
