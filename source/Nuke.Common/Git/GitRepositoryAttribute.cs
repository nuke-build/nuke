// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.BuildServers;
using Nuke.Common.Execution;

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

        [CanBeNull]
        public string Branch { get; set; } = AppVeyor.Instance?.RepositoryBranch ??
                                             Bitrise.Instance?.GitBranch ??
                                             GitLab.Instance?.CommitRefName ??
                                             Jenkins.Instance?.GitBranch ??
                                             TeamCity.Instance?.BranchName ??
                                             TeamServices.Instance?.SourceBranchName ??
                                             Travis.Instance?.Branch;

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
