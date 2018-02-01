// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using Nuke.Core.Utilities.Collections;

namespace Nuke.Core.Execution
{
    internal static class PrivateInvoke
    {
        public static void SetValue(NukeBuild build, string memberName, object value)
        {
            var member = build.GetType().GetMember(memberName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .SingleOrDefault()
                .NotNull($"Could not find member '{memberName}' on type '{build.GetType()}'.");
            SetValue(build, member, value);
        }

        public static void SetValue(NukeBuild build, MemberInfo member, object value)
        {
            if (member is FieldInfo field)
            {
                field.SetValue(build, value);
            }
            else if (member is PropertyInfo property)
            {
                var backingField = build.GetType().DescendantsAndSelf(x => x.GetTypeInfo().BaseType)
                    .SelectMany(x => x.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
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
