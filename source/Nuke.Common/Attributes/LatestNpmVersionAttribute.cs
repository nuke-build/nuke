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
    public class LatestNpmVersionAttribute : ValueInjectionAttributeBase
    {
        private readonly string _packageId;

        public LatestNpmVersionAttribute(string packageId)
        {
            _packageId = packageId;
        }

        public override object GetValue(MemberInfo member, object instance)
        {
            var version = NpmVersionResolver.GetLatestVersion(_packageId).GetAwaiter().GetResult();
            return member.GetMemberType() == typeof(string)
                ? version
                : SemanticVersion.Parse(version);
        }
    }
}
