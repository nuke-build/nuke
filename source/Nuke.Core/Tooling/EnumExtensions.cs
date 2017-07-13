// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace Nuke.Core.Tooling
{
    [PublicAPI]
    public static class EnumExtensions
    {
        [CanBeNull]
        public static string ToFriendlyString (this Enum enumValue)
        {
            var enumType = enumValue.GetType();
            var definedName = Enum.GetName(enumType, enumValue);
            return enumType.GetMembers().Single(x => x.Name == definedName)
                           .GetCustomAttribute<FriendlyStringAttribute>()?.FriendlyString
                   ?? definedName;
        }
    }
}
