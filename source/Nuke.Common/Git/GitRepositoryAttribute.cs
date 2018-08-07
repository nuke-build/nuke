// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.BuildServers;
using Nuke.Common.Execution;
using Nuke.Common.Tools.Git;

namespace Nuke.Common.Git
{
    /// <inheritdoc/>
    /// <summary>
    /// Implements auto-injection for <see cref="GitRepository"/>.
    /// <para/>
    /// <inheritdoc/>
    /// </summary>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Default)]
    public class GitRepositoryAttribute : StaticInjectionAttributeBase
    {
        public static GitRepository Value { get; private set; }

        private static Lazy<string> s_branch = new Lazy<string>(()
            => AppVeyor.Instance?.RepositoryBranch ??
               Bitrise.Instance?.GitBranch ??
               GitLab.Instance?.CommitRefName ??
               Jenkins.Instance?.GitBranch ??
               TeamCity.Instance?.BranchName ??
               TeamServices.Instance?.SourceBranchName ??
               Travis.Instance?.Branch ??
               GitTasks.GitCurrentBranch());

        [CanBeNull]
        public string Branch { get; set; } = s_branch.Value;

        public string Remote { get; set; } = "origin";

        [CanBeNull]
        public override object GetStaticValue()
        {
            return Value = Value
                           ?? ControlFlow.SuppressErrors(() =>
                               GitRepository.FromLocalDirectory(NukeBuild.Instance.RootDirectory, Branch, Remote.NotNull()));
        }
    }
}
