// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Tools.Git;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.GitVersion
{
    /// <inheritdoc/>
    /// <summary>
    /// Injects an instance of <see cref="GitVersion"/> based on the local repository.
    /// <para/>
    /// <inheritdoc/>
    /// </summary>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Default)]
    public class GitVersionAttribute : InjectionAttributeBase
    {
        public bool DisableOnUnix { get; set; }

        public override object GetValue(MemberInfo member, Type buildType)
        {
            // TODO: https://github.com/GitTools/GitVersion/issues/1097
            if (EnvironmentInfo.IsUnix && DisableOnUnix)
            {
                Logger.Warn($"{nameof(GitVersion)} is disabled on UNIX environment.");
                return null;
            }

            return ControlFlow.SuppressErrors(() =>
                GitVersionTasks.GitVersion(s => s
                        .SetWorkingDirectory(NukeBuild.RootDirectory)
                        .DisableLogOutput())
                    .Result);
        }
    }
}
