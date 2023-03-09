// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using NuGet.Versioning;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public class LatestNuGetVersionAttribute : ValueInjectionAttributeBase
    {
        private readonly string _packageId;

        public LatestNuGetVersionAttribute(string packageId)
        {
            _packageId = packageId;
        }

        public bool IncludePrerelease { get; set; }
        public bool IncludeUnlisted { get; set; }

        public override object GetValue(MemberInfo member, object instance)
        {
            var version = NuGetVersionResolver.GetLatestVersion(_packageId, IncludePrerelease, IncludeUnlisted).GetAwaiter().GetResult();
            return member.GetMemberType() == typeof(string)
                ? version
                : NuGetVersion.Parse(version);
        }
    }
}
