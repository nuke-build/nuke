// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nuke.Common.Execution
{
    internal static class InjectionUtility
    {
        public static void InjectValues<T>(T instance = default)
        {
            var anyInjected = false;

            var injectionMembers = GetInjectionMembers(typeof(T))
                .OrderByDescending(x => x.GetCustomAttribute<ParameterAttribute>() != null);

            foreach (var member in injectionMembers)
            {
                if (member.DeclaringType == typeof(NukeBuild))
                    continue;
                
                var attributes = member.GetCustomAttributes().OfType<InjectionAttributeBase>().ToList();
                if (attributes.Count == 0)
                    continue;
                ControlFlow.Assert(attributes.Count == 1, $"Member '{member.Name}' has multiple injection attributes applied.");

                var attribute = attributes.Single();
                var value = attribute.GetValue(member, instance);
                if (value == null)
                    continue;

                var valueType = value.GetType();
                ControlFlow.Assert(member.GetFieldOrPropertyType().IsAssignableFrom(valueType),
                    $"Member '{member.Name}' must be of type '{valueType.Name}' to get its valued injected from '{attribute.GetType().Name}'.");
                ReflectionService.SetValue(instance, member, value);

                anyInjected = true;
            }

            if (anyInjected)
                Logger.Log();
        }
        
        public static IReadOnlyCollection<MemberInfo> GetParameterMembers(Type type)
        {
            return GetInjectionMembers(type)
                .Where(x => x.GetCustomAttribute<ParameterAttribute>() != null).ToList();
        }

        public static IReadOnlyCollection<MemberInfo> GetInjectionMembers(Type type)
        {
            var members = type
                .GetMembers(ReflectionService.All)
                .Where(x => x.GetCustomAttributes<InjectionAttributeBase>().Any()).ToList();

            var transitiveMembers = members
                .SelectMany(x => x.GetCustomAttributes<InjectionAttributeBase>())
                .SelectMany(x => x.GetType().GetMembers(ReflectionService.All))
                .Where(x => x.GetCustomAttributes<InjectionAttributeBase>().Any()).ToList();

            return members.Concat(transitiveMembers).ToList();
        }
    }
}
