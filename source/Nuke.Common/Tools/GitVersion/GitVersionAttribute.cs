// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tools.Git;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.GitVersion
{
    /// <inheritdoc/>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Default)]
    public class GitVersionAttribute : StaticInjectionAttributeBase
    {
        public static GitVersion Value { get; private set; }

        [CanBeNull]
        public override object GetStaticValue()
        {
            if (Value != null)
                return Value;

            // TODO: https://github.com/GitTools/GitVersion/issues/1097
            if (EnvironmentInfo.IsUnix)
            {
                Logger.Warn($"{nameof(GitVersion)} does not work in UNIX environments.");
                return null;
            }

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
            if (!EnvironmentInfo.ParameterSwitch("major") &&
                !EnvironmentInfo.ParameterSwitch("minor"))
                return null;

            ControlFlow.Assert(version.BranchName.Equals("master"), "Version can only be bumped on master branch.");

            return EnvironmentInfo.ParameterSwitch("major")
                ? $"{version.Major + 1}.0.0"
                : $"{version.Major}.{version.Minor + 1}.0";
        }
    }
}
