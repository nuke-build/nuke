﻿// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Execution
{
    public static class InjectionUtility
    {
        public static T GetInjectionValue<T>(Expression<Func<T>> parameterExpression)
        {
            // TODO: caching?
            var parameter = parameterExpression.GetMemberInfo();
            var attribute = parameter.GetCustomAttribute<InjectionAttributeBase>().NotNull();
            return (T) attribute.GetValue(parameter, instance: null);
        }

        public static void InjectValues<T>(T instance = default, Func<InjectionAttributeBase, bool> filter = null)
        {
            filter ??= x => true;
            InjectValuesInternal(instance, GetInjectionMembers(typeof(T)).Where(x => filter(x.Attribute)));
        }

        private static void InjectValuesInternal<T>(
            [CanBeNull] T instance,
            IEnumerable<(MemberInfo Member, InjectionAttributeBase Attribute)> tuples)
        {
            tuples = tuples
                .OrderBy(x => x.Member.DeclaringType.Descendants(y => y.BaseType).Count())
                .ThenByDescending(x => x.Attribute.Priority);

            foreach (var (member, attribute) in tuples)
            {
                if (member.DeclaringType == typeof(NukeBuild))
                    continue;

                if (member.ReflectedType.NotNull().IsInterface)
                    continue;

                var value = attribute.GetValue(member, instance);
                if (value == null)
                    continue;

                var valueType = value.GetType();
                ControlFlow.Assert(member.GetMemberType().IsAssignableFrom(valueType),
                    $"Member '{member.Name}' must be of type '{valueType.Name}' to get its valued injected from '{attribute.GetType().Name}'.");
                member.SetValue(instance, value);
            }
        }

        public static IReadOnlyCollection<MemberInfo> GetParameterMembers(Type type, bool includeUnlisted)
        {
            return GetInjectionMembers(type)
                .Where(x => x.Attribute is ParameterAttribute attribute && (includeUnlisted || attribute.List))
                .Select(x => x.Member).ToList();
        }

        public static IReadOnlyCollection<(MemberInfo Member, InjectionAttributeBase Attribute)> GetInjectionMembers(Type type)
        {
            return type
                .GetMembers(ReflectionService.All)
                .Concat(type.GetInterfaces().SelectMany(x => x.GetMembers(ReflectionService.All)))
                .Select(x => (Member: x, Attribute: x.GetCustomAttribute<InjectionAttributeBase>()))
                .Where(x => x.Attribute != null).ToList();
        }
    }
}
