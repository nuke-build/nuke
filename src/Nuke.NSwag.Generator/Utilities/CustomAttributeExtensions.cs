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
        public static T GetPropertyValue<T> (this CustomAttribute attribute, string propertyName)
        {
            if (!attribute.HasProperties || attribute.Properties.All(x => x.Name != propertyName)) return default(T);
            return (T) attribute.Properties.Single(x => x.Name == propertyName).Argument.Value;
        }
    }
}