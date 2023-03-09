// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.ValueInjection
{
    internal static class ValueInjectionUtility
    {
        private static readonly Dictionary<MemberInfo, object> s_valueCache = new();

        [CanBeNull]
        public static T TryGetValue<T>(Expression<Func<T>> parameterExpression)
            where T : class
        {
            return TryGetValueWithCache<T>(parameterExpression);
        }

        [CanBeNull]
        public static T TryGetValue<T>(Expression<Func<object>> parameterExpression)
        {
            return TryGetValueWithCache<T>(parameterExpression);
        }

        private static T TryGetValueWithCache<T>(LambdaExpression lambdaExpression)
        {
            var parameter = lambdaExpression.GetMemberInfo();

            object GetValue()
            {
                var attribute = parameter.GetCustomAttribute<ValueInjectionAttributeBase>().NotNull();
                var instance = lambdaExpression.GetTarget();
                attribute.Build = instance as INukeBuild;
                return attribute.TryGetValue(parameter, instance);
            }

            return (T) (s_valueCache[parameter] = s_valueCache.GetValueOrDefault(parameter) ?? GetValue());
        }

        public static void InjectValues<T>(T instance = default, Func<ValueInjectionAttributeBase, bool> filter = null)
        {
            filter ??= _ => true;
            InjectValuesInternal(instance, GetInjectionMembers(instance?.GetType() ?? typeof(T)).Where(x => filter(x.Attribute)));
        }

        private static void InjectValuesInternal<T>(
            [CanBeNull] T instance,
            IEnumerable<(MemberInfo Member, ValueInjectionAttributeBase Attribute)> tuples)
        {
            tuples = tuples
                .OrderBy(x => x.Member.DeclaringType.Descendants(y => y.BaseType).Count())
                .ThenByDescending(x => x.Attribute.Priority);

            foreach (var (member, attribute) in tuples)
            {
                if (member.DeclaringType == typeof(NukeBuild) &&
                    !new[]
                     {
                         nameof(NukeBuild.Plan),
                         nameof(NukeBuild.Help),
                         nameof(NukeBuild.Continue),
                         nameof(NukeBuild.NoLogo),
                         nameof(NukeBuild.Verbosity),
                         nameof(NukeBuild.Partition)
                     }.Contains(member.Name))
                    continue;

                if (member.ReflectedType.NotNull().IsInterface)
                    continue;

                attribute.Build = instance as INukeBuild;
                var value = attribute.TryGetValue(member, instance);
                if (value == null)
                    continue;

                var valueType = value.GetType();
                Assert.True(member.GetMemberType().IsAssignableFrom(valueType),
                    $"Member '{member.Name}' must be of type '{valueType.Name}' to get its valued injected from '{attribute.GetType().Name}'");
                member.SetValue(instance, value);
            }
        }

        public static IReadOnlyCollection<MemberInfo> GetParameterMembers(Type type, bool includeUnlisted)
        {
            // TODO: check duplicated names
            return GetInjectionMembers(type)
                .Where(x => x.Attribute is ParameterAttribute attribute && (includeUnlisted || attribute.List))
                .Select(x => x.Member)
                .OrderBy(ParameterService.GetParameterMemberName).ToList();
        }

        public static IReadOnlyCollection<(MemberInfo Member, ValueInjectionAttributeBase Attribute)> GetInjectionMembers(Type type)
        {
            return type
                .GetAllMembers(
                    x => x.HasCustomAttribute<ValueInjectionAttributeBase>(),
                    bindingFlags: ReflectionUtility.All,
                    allowAmbiguity: true)
                .OrderBy(x => x.Name)
                .Select(x => (Member: x, Attribute: x.GetCustomAttribute<ValueInjectionAttributeBase>())).ToList();
        }
    }
}
