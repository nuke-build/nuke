// Copyright Matthias Koch 2018.
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
using Nuke.Core;

namespace Nuke.CodeGeneration
{
    public static class ToolSerializer
    {
        public static Tool Load(string file)
        {
            try
            {
                var content = File.ReadAllText(file);
                var tool = JsonConvert.DeserializeObject<Tool>(content);
                tool.DefinitionFile = file;
                return tool;
            }
            catch (Exception exception)
            {
                Logger.Error($"Couldn't load metadata file '{Path.GetFileName(file)}'.");
                Logger.Error(exception.Message);
                throw;
            }
        }

        public static void Save(Tool tool)
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

            File.WriteAllText(tool.DefinitionFile, content);
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

                    if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string))
                        return ((IEnumerable) propertyInfo.GetValue(x)).GetEnumerator().MoveNext();

                    return true;
                };
                return property;
            }
        }
    }
}
