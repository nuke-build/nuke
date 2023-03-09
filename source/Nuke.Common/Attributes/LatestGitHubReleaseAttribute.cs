// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Git;
using Nuke.Common.Tools.GitHub;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public class LatestGitHubReleaseAttribute : ValueInjectionAttributeBase
    {
        private readonly string _identifier;

        public LatestGitHubReleaseAttribute(string identifier)
        {
            _identifier = identifier;
        }

        public bool IncludePrerelease { get; set; }
        public bool TrimPrefix { get; set; }

        public override object GetValue(MemberInfo member, object instance)
        {
            var repository = GitRepository.FromUrl($"https://github.com/{_identifier}");
            return repository.GetLatestRelease(IncludePrerelease, TrimPrefix).GetAwaiter().GetResult();
        }
    }
}
