// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.GitVersion
{
    /// <summary>
    /// Injects an instance of <see cref="GitVersion"/> based on the local repository.
    /// </summary>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Default)]
    public class GitVersionAttribute : InjectionAttributeBase
    {
        public bool DisableOnUnix { get; set; }
        public bool UpdateAssemblyInfo { get; set; }

        public override object GetValue(MemberInfo member, object instance)
        {
            // TODO: https://github.com/GitTools/GitVersion/issues/1097
            if (EnvironmentInfo.IsUnix && DisableOnUnix)
            {
                Logger.Warn($"{nameof(GitVersion)} is disabled on UNIX environment.");
                return null;
            }

            return GitVersionTasks.GitVersion(s => s
                    .SetFramework("netcoreapp3.0")
                    .DisableLogOutput()
                    .SetUpdateAssemblyInfo(UpdateAssemblyInfo))
                .Result;
        }
    }
}
