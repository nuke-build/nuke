// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;

namespace Nuke.Core.Execution
{
    internal static class InjectionService
    {
        public static void InjectValues(NukeBuild build)
        {
            var anyInjected = false;

            var injectionMembers = build.GetInjectionMembers()
                .OrderByDescending(x => x.GetCustomAttribute<ParameterAttribute>() != null);

            foreach (var member in injectionMembers)
            {
                var attributes = member.GetCustomAttributes().OfType<InjectionAttributeBase>().ToList();
                if (attributes.Count == 0)
                    continue;
                ControlFlow.Assert(attributes.Count == 1, $"Member '{member.Name}' has multiple injection attributes applied.");

                var attribute = attributes.Single();
                var memberType = (member as FieldInfo)?.FieldType ?? ((PropertyInfo) member).PropertyType;
                var value = attribute.GetValue(member.Name, memberType);
                if (value == null)
                    continue;

                var valueType = value.GetType();
                ControlFlow.Assert(memberType.IsAssignableFrom(valueType),
                    $"Field '{member.Name}' must be of type '{valueType.Name}' to get its valued injected from '{attribute.GetType().Name}'.");
                ReflectionService.SetValue(build, member, value);

                anyInjected = true;
            }

            if (anyInjected)
                Logger.Log();
        }
    }
}
