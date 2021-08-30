// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

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

        [CanBeNull]
        protected T GetMemberValue<T>(string memberName, object instance)
        {
            var type = instance.GetType();
            var member = type.GetMember(memberName, ReflectionUtility.All)
                .SingleOrDefaultOrError($"Found multiple members with the name '{memberName}' in '{type.Name}'.")
                .NotNull($"No member '{memberName}' found in '{type.Name}'.");
            ControlFlow.Assert(member.GetMemberType().IsInstanceOfType(typeof(T)), $"Member '{type.Name}.{member.Name} must be of type {typeof(T).Name}");
            return member.GetValue<T>(instance);
        }

        [CanBeNull]
        protected T GetMemberValueOrNull<T>([CanBeNull] string memberName, object instance)
        {
            return memberName != null ? GetMemberValue<T>(memberName, instance) : default;
        }
    }
}
