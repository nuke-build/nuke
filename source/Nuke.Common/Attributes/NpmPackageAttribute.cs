// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public class NpmPackageAttribute : ToolInjectionAttributeBase
    {
        private readonly string _packageId;
        private readonly string _packageExecutable;

        public NpmPackageAttribute(string packageId, string packageExecutable = null)
        {
            _packageId = packageId;
            _packageExecutable = packageExecutable;
        }

        public string Version { get; set; }

        public override ToolRequirement GetRequirement(MemberInfo member)
        {
            return NpmPackageRequirement.Create(_packageId, Version);
        }

        public override object GetValue(MemberInfo member, object instance)
        {
            var name = _packageExecutable ?? member.Name.ToLowerInvariant();
            return ToolResolver.TryGetEnvironmentTool(name) ??
                   ToolResolver.GetNpmTool(name);
        }
    }
}
