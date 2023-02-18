// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public class NpmPackageAttribute : ValueInjectionAttributeBase
    {
        private readonly string _name;

        public NpmPackageAttribute(string name = null)
        {
            _name = name;
        }

        public override object GetValue(MemberInfo member, object instance)
        {
            var name = _packageExecutable ?? member.Name.ToLowerInvariant();
            return ToolResolver.TryGetEnvironmentTool(name) ??
                   ToolResolver.GetNpmTool(name);
        }
    }
}
