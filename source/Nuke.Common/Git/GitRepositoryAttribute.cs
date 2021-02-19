// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Git
{
    /// <summary>
    /// Injects an instance of <see cref="GitRepository"/> based on the local repository.
    /// </summary>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Default)]
    public class GitRepositoryAttribute : ValueInjectionAttributeBase
    {
        public override object GetValue(MemberInfo member, object instance)
        {
            return GitRepository.FromLocalDirectory(NukeBuild.RootDirectory);
        }
    }
}
