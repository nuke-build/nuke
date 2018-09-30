// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Nuke.CodeGeneration.Model;
using Nuke.Common;
using Nuke.Common.Utilities;

namespace Nuke.CodeGeneration
{
    public static class ToolSerializer
    {
        public static Tool Load(string file)
        {
            try
            {
                var content = File.ReadAllText(file);
                return JsonConvert.DeserializeObject<Tool>(content);
            }
            catch (Exception exception)
            {
                Logger.Error($"Couldn't load metadata file '{Path.GetFileName(file)}'.");
                Logger.Error(exception.Message);
                throw;
            }
        }

        public static void Save(Tool tool, string file)
        {
            var content = JsonConvert.SerializeObject(
                tool,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new CustomContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

            File.WriteAllText(file, content);
        }

        private class CustomContractResolver : CamelCasePropertyNamesContractResolver
        {
            protected override JsonProperty CreateProperty([NotNull] MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);
                property.ShouldSerialize = x =>
                {
                    var propertyInfo = (PropertyInfo) member;

                    if (propertyInfo.GetSetMethod(nonPublic: true) == null)
                        return false;

                    if (property.PropertyType == typeof(string))
                        return true;

                    if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                        return ((IEnumerable) propertyInfo.GetValue(x)).GetEnumerator().MoveNext();

                    if (x is SettingsClass && property.PropertyType == typeof(bool))
                    {
                        var defaultTrueProperties = new[] { nameof(DataClass.ArgumentConstruction), nameof(DataClass.ExtensionMethods) };
                        if (defaultTrueProperties.Any(y => y.EqualsOrdinalIgnoreCase(property.PropertyName)))
                            return false;
                    }

                    return true;
                };
                return property;
            }
        }
    }
}
