// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static partial class SerializationTasks
    {
        public static JsonSerializerSettings DefaultJsonSerializerSettings =
            new()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };

        [Obsolete($"Use {nameof(JsonExtensions)}.{nameof(JsonExtensions.WriteJson)} as {nameof(AbsolutePath)} extension method")]
        [CodeTemplate(
            searchTemplate: "JsonSerializeToFile($arg$, $expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.WriteJson($arg$)",
            ReplaceMessage = "Replace with $expr$.WriteJson($arg$)",
            Message = $"WARNING: {nameof(JsonSerializeToFile)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "SerializationTasks.JsonSerializeToFile($arg$, $expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.WriteJson($arg$)",
            ReplaceMessage = "Replace with $expr$.WriteJson($arg$)",
            Message = $"WARNING: {nameof(JsonSerializeToFile)} is obsolete")]
        public static void JsonSerializeToFile<T>(T obj, string path, Configure<JsonSerializerSettings> configurator = null)
        {
            TextTasks.WriteAllText(path, JsonSerialize(obj, configurator));
        }

        [Pure]
        [Obsolete($"Use {nameof(JsonExtensions)}.{nameof(JsonExtensions.ReadJson)} as {nameof(AbsolutePath)} extension method")]
        [CodeTemplate(
            searchTemplate: "JsonDeserializeFromFile<$type$>($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.ReadJson<$type$>($args$)",
            ReplaceMessage = "Replace with $expr$.ReadJson<$type$>($args$)",
            Message = $"WARNING: {nameof(JsonDeserializeFromFile)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "SerializationTasks.JsonDeserializeFromFile<$type$>($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.ReadJson<$type$>($args$)",
            ReplaceMessage = "Replace with $expr$.ReadJson<$type$>($args$)",
            Message = $"WARNING: {nameof(JsonDeserializeFromFile)} is obsolete")]
        public static T JsonDeserializeFromFile<T>(string path, Configure<JsonSerializerSettings> configurator = null)
        {
            Assert.FileExists(path);
            return JsonDeserialize<T>(File.ReadAllText(path), configurator);
        }

        [Pure]
        [Obsolete($"Use {nameof(JsonExtensions)}.{nameof(JsonExtensions.ToJson)} as object extension method")]
        public static string JsonSerialize<T>(T obj, Configure<JsonSerializerSettings> configurator = null)
        {
            return JsonConvert.SerializeObject(obj, configurator.InvokeSafe(DefaultJsonSerializerSettings));
        }

        [Pure]
        [Obsolete($"Use {nameof(JsonExtensions)}.{nameof(JsonExtensions.GetJson)} as string extension method")]
        public static T JsonDeserialize<T>(string content, Configure<JsonSerializerSettings> configurator = null)
        {
            return JsonConvert.DeserializeObject<T>(content, configurator.InvokeSafe(DefaultJsonSerializerSettings));
        }

        [Obsolete($"Use {nameof(JsonExtensions)}.{nameof(JsonExtensions.UpdateJson)} as {nameof(AbsolutePath)} extension method")]
        [CodeTemplate(
            searchTemplate: "JsonUpdateFile<$type$>($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.UpdateJson<$type$>($args$)",
            ReplaceMessage = "Replace with $expr$.UpdateJson<$type$>($args$)",
            Message = $"WARNING: {nameof(JsonUpdateFile)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "SerializationTasks.JsonUpdateFile<$type$>($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.UpdateJson<$type$>($args$)",
            ReplaceMessage = "Replace with $expr$.UpdateJson<$type$>($args$)",
            Message = $"WARNING: {nameof(JsonUpdateFile)} is obsolete")]
        public static void JsonUpdateFile<T>(string path, Action<T> update, Configure<JsonSerializerSettings> configurator = null)
        {
            var obj = JsonDeserializeFromFile<T>(path, configurator);
            update.Invoke(obj);
            JsonSerializeToFile(obj, path, configurator);
        }

        [Obsolete($"Use {nameof(JsonExtensions)}.{nameof(JsonExtensions.UpdateJson)} as {nameof(AbsolutePath)} extension method")]
        [CodeTemplate(
            searchTemplate: "JsonDeserializeFromFile($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.ReadJson($args$)",
            ReplaceMessage = "Replace with $expr$.ReadJson($args$)",
            Message = $"WARNING: {nameof(JsonDeserializeFromFile)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "SerializationTasks.JsonDeserializeFromFile($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.ReadJson($args$)",
            ReplaceMessage = "Replace with $expr$.ReadJson($args$)",
            Message = $"WARNING: {nameof(JsonDeserializeFromFile)} is obsolete")]
        public static JObject JsonDeserializeFromFile(string path, Configure<JsonSerializerSettings> configurator = null)
        {
            return JsonDeserializeFromFile<JObject>(path, configurator);
        }

        [Obsolete($"Use {nameof(JsonExtensions)}.{nameof(JsonExtensions.GetJson)} as string extension method")]
        public static JObject JsonDeserialize(string content, Configure<JsonSerializerSettings> configurator = null)
        {
            return JsonDeserialize<JObject>(content, configurator);
        }

        [Obsolete($"Use {nameof(JsonExtensions)}.{nameof(JsonExtensions.UpdateJson)} as {nameof(AbsolutePath)} extension method")]
        [CodeTemplate(
            searchTemplate: "JsonUpdateFile($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.UpdateJson($args$)",
            ReplaceMessage = "Replace with $expr$.UpdateJson($args$)",
            Message = $"WARNING: {nameof(JsonUpdateFile)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "SerializationTasks.JsonUpdateFile($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.UpdateJson($args$)",
            ReplaceMessage = "Replace with $expr$.UpdateJson($args$)",
            Message = $"WARNING: {nameof(JsonUpdateFile)} is obsolete")]
        public static void JsonUpdateFile(string path, Action<JObject> update, Configure<JsonSerializerSettings> configurator = null)
        {
            JsonUpdateFile<JObject>(path, update, configurator);
        }
    }
}
