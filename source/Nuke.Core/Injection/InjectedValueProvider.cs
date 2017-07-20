// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace Nuke.Core.Injection
{
    [PublicAPI]
    public static class InjectedValueProvider
    {
        [CanBeNull]
        public static TValue GetValue<TValue, TAttribute> (InjectionKey<TValue, TAttribute> key)
            where TAttribute : InjectionAttributeBase
        {
            return GetValue<TValue, TAttribute>();
        }

        public static TValue GetNonNullValue<TValue, TAttribute> (InjectionKey<TValue, TAttribute> key)
            where TValue : class
            where TAttribute : InjectionAttributeBase
        {
            return GetNonNullValue<TValue, TAttribute>();
        }

        public static TValue GetNonNullValue<TValue, TAttribute>()
            where TValue : class
            where TAttribute : InjectionAttributeBase
        {
            return GetValue<TValue, TAttribute>()
                    .NotNull($"Value for '{typeof(TValue).Name}' provided from '{typeof(TAttribute).Name}' was never injected");
        }

        [CanBeNull]
        public static TValue GetValue<TValue, TAttribute> ()
            where TAttribute : InjectionAttributeBase
        {
            var buildInstance = NukeBuild.Instance;

            var buildType = buildInstance.GetType();
            var attributeType = typeof(TAttribute);

            var fields = buildType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(x => x.GetCustomAttribute(attributeType) != null).ToList();
            if (fields.Count == 0)
                return default(TValue);
            ControlFlow.Assert(fields.Count == 1, $"Multiple fields are injected from '{attributeType.Name}'.");

            var field = fields.Single();
            var injectionType = field.GetCustomAttribute<InjectionAttributeBase>().InjectionType;
            ControlFlow.Assert(injectionType == typeof(TValue),
                $"Field '{field.Name}' must have type '{injectionType.Name}' to be valid for injection from '{attributeType.Name}'.");

            return (TValue) field.GetValue(buildInstance);
        }
    }
}
