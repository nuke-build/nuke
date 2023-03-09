// Copyright 2023 Maintainers of NUKE.
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
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Serilog;

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
                // TODO: update metadata -> specification
                Log.Error(exception, "Couldn't load metadata file {File}", Path.GetFileName(file));
                throw;
            }
        }

        public static void Save(Tool tool, AbsolutePath file)
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

            file.WriteAllText(content);
        }

        private class CustomContractResolver : CamelCasePropertyNamesContractResolver
        {
            // ReSharper disable once CognitiveComplexity
            protected override JsonProperty CreateProperty([NotNull] MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);
                property.ShouldSerialize = x =>
                {
                    var propertyInfo = (PropertyInfo) member;

                    if (property.DeclaringType == typeof(Tool) && propertyInfo.Name == nameof(Tool.Schema))
                        return true;

                    if (propertyInfo.GetSetMethod(nonPublic: true) == null)
                        return false;

                    if (property.PropertyType == typeof(string))
                        return true;

                    if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                    {
                        var propertyValue = (IEnumerable) propertyInfo.GetValue(x);
                        return propertyValue?.GetEnumerator().MoveNext() ?? false;
                    }

                    if (x is SettingsClass && property.PropertyType == typeof(bool))
                    {
                        var defaultTrueProperties = new[] { nameof(DataClass.ExtensionMethods) };
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
