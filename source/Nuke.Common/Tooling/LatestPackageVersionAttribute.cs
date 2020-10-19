// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using NuGet.Versioning;
using Nuke.Common.Execution;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public class LatestPackageVersionAttribute : ValueInjectionAttributeBase
    {
        private readonly string _packageId;

        public LatestPackageVersionAttribute(string packageId)
        {
            _packageId = packageId;
        }

        public bool IncludePrerelease { get; set; }
        public bool IncludeUnlisted { get; set; }

        public override object GetValue(MemberInfo member, object instance)
        {
            var result = NuGetPackageResolver.GetLatestPackageVersion(_packageId, IncludePrerelease, IncludeUnlisted)
                .GetAwaiter().GetResult();
            return member.GetMemberType() == typeof(string)
                ? (object) result
                : NuGetVersion.Parse(result);
        }
    }
}
