// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Git;
using Nuke.Common.Tools.GitVersion;
using Nuke.Core;

namespace Nuke.Common
{
    /// <summary>
    /// In addition to <see cref="Build"/>, automatically loads <see cref="GitVersion"/> and <see cref="GitRepository"/>.
    /// </summary>
    [PublicAPI]
    [SuppressMessage ("ReSharper", "VirtualMemberNeverOverridden.Global")]
    public abstract class GitHubBuild : Build
    {
        public new static GitHubBuild Instance { get; private set; }

        protected GitHubBuild ()
        {
            Instance = this;

            // ReSharper disable once VirtualMemberCallInConstructor
            Initialize ();
        }

        public GitRepository GitRepository { get; protected set; }
        public GitVersion GitVersion { get; protected set; }

        // ReSharper disable once VirtualMemberNeverOverridden.Global
        // ReSharper disable once CyclomaticComplexity
        public virtual void Initialize ()
        {
            GitRepository = GitRepository ?? GetGitRepository (RootDirectory);
            GitVersion = GitVersion ?? GetGitVersion (RootDirectory);
        }

        [CanBeNull]
        public virtual GitRepository GetGitRepository ([CanBeNull] string rootDirectory)
        {
            if (rootDirectory == null)
                return null;

            var gitConfig = Path.Combine (rootDirectory, ".git", "config");
            var configContent = File.ReadAllLines (gitConfig);
            var url = configContent
                    .Select (x => x.Trim ())
                    .SkipWhile (x => x != "[remote \"origin\"]")
                    .Skip (count: 1)
                    .TakeWhile (x => !x.StartsWith ("["))
                    .Single (x => x.StartsWith ("url = ", StringComparison.OrdinalIgnoreCase))
                    .Split ('=')[1];

            return GitRepository.TryParse (url);
        }

        [CanBeNull]
        public virtual GitVersion GetGitVersion ([CanBeNull] string rootDirectory)
        {
            return EnvironmentInfo.IsWin && rootDirectory != null && File.Exists (DefaultSettings.GitVersion.ToolPath)
                ? GitVersionTasks.GitVersion (DefaultSettings.GitVersion)
                : null;
        }
    }
}
