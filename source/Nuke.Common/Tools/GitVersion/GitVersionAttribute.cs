// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tools.Git;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.GitVersion
{
    /// <inheritdoc/>
    /// <summary>
    /// Implements auto-injection for <see cref="GitVersionTasks"/>.
    /// <para/>
    /// <inheritdoc/>
    /// </summary>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Default)]
    public class GitVersionAttribute : StaticInjectionAttributeBase
    {
        [Parameter("Allows to bump the major or minor version.")]
        public static GitVersionBump? Bump { get; }

        public static GitVersion Value { get; private set; }

        public bool DisableOnUnix { get; set; }

        [CanBeNull]
        public override object GetStaticValue()
        {
            // TODO: https://github.com/GitTools/GitVersion/issues/1097
            if (EnvironmentInfo.IsUnix && DisableOnUnix)
            {
                Logger.Warn($"{nameof(GitVersion)} is disabled on UNIX environment.");
                return null;
            }

            if (Value != null)
                return Value;

            var version = GetVersion();
            var tag = GetTag(version);
            if (tag != null)
            {
                GitTasks.Git($"tag {tag}");
                version = GetVersion();
            }

            return Value = version;
        }

        private static GitVersion GetVersion()
        {
            return GitVersionTasks.GitVersion(
                s => GitVersionTasks.DefaultGitVersion,
                new ProcessSettings().EnableRedirectOutput());
        }

        [CanBeNull]
        private static string GetTag(GitVersion version)
        {
            if (!Bump.HasValue || Bump.Value == GitVersionBump.Patch)
                return null;

            ControlFlow.Assert(version.BranchName.Equals("master"), "Version can only be bumped on master branch.");

            return Bump.Value == GitVersionBump.Major
                ? $"{version.Major + 1}.0.0"
                : $"{version.Major}.{version.Minor + 1}.0";
        }
    }
}
