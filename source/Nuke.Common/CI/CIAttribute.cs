// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.CI
{
    [MeansImplicitUse(ImplicitUseTargetFlags.WithMembers)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property)]
    public class CIAttribute : ValueInjectionAttributeBase
    {
        public override object GetValue(MemberInfo member, object instance)
        {
            var memberType = member.GetMemberType();
            var instanceProperty = memberType.GetProperty(nameof(TeamCity.TeamCity.Instance), ReflectionService.Static);
            ControlFlow.Assert(instanceProperty != null,
                $"Type '{memberType}' is not compatible for injection via '{nameof(CIAttribute)}'.");
            return instanceProperty.GetValue(obj: null);
        }
    }
}
