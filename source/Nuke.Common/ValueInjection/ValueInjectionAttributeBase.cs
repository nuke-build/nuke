// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace Nuke.Common.ValueInjection
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    [MeansImplicitUse(ImplicitUseKindFlags.Assign)]
    public abstract class ValueInjectionAttributeBase : Attribute
    {
        [CanBeNull]
        public object TryGetValue(MemberInfo member, object instance)
        {
            return ControlFlow.SuppressErrors(() => GetValue(member, instance), includeStackTrace: true);
        }

        [CanBeNull]
        public abstract object GetValue(MemberInfo member, object instance);

        public virtual int Priority => 0;
    }
}
