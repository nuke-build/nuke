// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.CI
{
    [MeansImplicitUse(ImplicitUseTargetFlags.WithMembers)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property)]
    public class CIAttribute : ValueInjectionAttributeBase
    {
        public override object GetValue(MemberInfo member, object instance)
        {
            // TODO: allow with conversion?
            var memberType = member.GetMemberType();
            var instanceProperty = memberType.GetProperty(nameof(Host.Instance), ReflectionUtility.Static);
            Assert.True(instanceProperty != null, $"Type '{memberType}' is not compatible for injection via '{nameof(CIAttribute)}'");
            return instanceProperty.GetValue(obj: null);
        }
    }
}
