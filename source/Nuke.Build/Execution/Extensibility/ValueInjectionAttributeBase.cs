// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Serilog;

namespace Nuke.Common.ValueInjection
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    [MeansImplicitUse(ImplicitUseKindFlags.Assign)]
    public abstract class ValueInjectionAttributeBase : Attribute
    {
        public INukeBuild Build { get; internal set; }

        [CanBeNull]
        public object TryGetValue(MemberInfo member, object instance)
        {
            try
            {
                return GetValue(member, instance);
            }
            catch (Exception exception)
            {
                if (!SuppressWarnings && !member.HasCustomAttribute<OptionalAttribute>())
                    Log.Warning(exception.Unwrap(), "Could not inject value for {Member}", member.GetDisplayName());

                return null;
            }
        }

        [CanBeNull]
        public abstract object GetValue(MemberInfo member, object instance);

        public virtual int Priority => 0;
        public virtual bool SuppressWarnings => false;

        [CanBeNull]
        protected T GetMemberValue<T>(string memberName, object instance)
        {
            var type = instance.GetType();
            var member = type
                .GetAllMembers(
                    x => x.Name == memberName,
                    bindingFlags: ReflectionUtility.All,
                    allowAmbiguity: true,
                    filterQuasiOverridden: true)
                .FirstOrDefault()
                .NotNull($"No member '{memberName}' found in '{type.Name}'");
            Assert.True(typeof(T).IsAssignableFrom(member.GetMemberType()), $"Member '{type.Name}.{member.Name}' must be of type '{typeof(T).Name}'");
            return member.GetValue<T>(instance);
        }

        [CanBeNull]
        protected T GetMemberValueOrNull<T>([CanBeNull] string memberName, object instance)
        {
            return memberName != null ? GetMemberValue<T>(memberName, instance) : default;
        }
    }
}
