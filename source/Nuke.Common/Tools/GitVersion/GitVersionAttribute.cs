// Copyright 2018 Maintainers of NUKE.
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

            return Value = GitVersionTasks.GitVersion(s => s
                    .SetWorkingDirectory(NukeBuild.Instance.RootDirectory)
                    .DisableLogOutput())
                .Result;
        }
    }
}
