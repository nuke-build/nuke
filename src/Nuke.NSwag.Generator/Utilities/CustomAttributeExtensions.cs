// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Linq;
using Mono.Cecil;

namespace Nuke.NSwag.Generator.Utilities
{
    internal static class CustomAttributeExtensions
    {
        public static bool TryGetAttributeProperty<T>(this CustomAttribute attribute, string propertyName, out T value)
        {
            value = default(T);
            if (!attribute.HasProperties || attribute.Properties.All(x => x.Name != propertyName)) return false;
            value = (T) attribute.Properties.Single(x => x.Name == propertyName).Argument.Value;
            return true;
        }

        public static T GetPropertyValue<T>(this CustomAttribute attribute, string propertyName)
        {
            TryGetAttributeProperty(attribute, propertyName, out T value);
            return value;
        }
    }
}