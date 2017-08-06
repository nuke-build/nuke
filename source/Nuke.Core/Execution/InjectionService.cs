// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using Nuke.Core.Injection;
using Nuke.Core.Utilities.Collections;

namespace Nuke.Core.Execution
{
    internal static class InjectionService
    {
        private const BindingFlags c_bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        public static void InjectValues (NukeBuild build)
        {
            var injectionMembers = build.GetType()
                    .GetMembers(c_bindingFlags)
                    .Where(x => x.GetCustomAttributes<InjectionAttributeBase>().Any()).ToList();

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
                SetValue(build, member, value);
            }
        }

        private static void SetValue (NukeBuild build, MemberInfo member, object value)
        {
            if (member is FieldInfo field)
            {
                field.SetValue(build, value);
            }
            else if (member is PropertyInfo property)
            {
                var backingField = build.GetType().DescendantsAndSelf(x => x.GetTypeInfo().BaseType)
                    .SelectMany(x => x.GetFields(BindingFlags.NonPublic | BindingFlags.Public |BindingFlags.Instance))
                    .SingleOrDefault(x => x.Name.StartsWith($"<{member.Name}>"));

                if (backingField != null)
                {
                    backingField.SetValue(build, value);
                }
                else
                {
                    ControlFlow.Assert(property.SetMethod != null, $"Property '{member.Name}' is not settable.");
                    property.SetValue(build, value);
                }
            }
        }
    }
}
