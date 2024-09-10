// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using Nuke.Common.IO;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Utilities;

public static class CompletionUtility
{
    public static IReadOnlyDictionary<string, string[]> GetItemsFromSchema(AbsolutePath schemaFile, IEnumerable<string> profileNames)
    {
        var schema = JsonDocument.Parse(schemaFile.ReadAllText());
        return GetItemsFromSchema(schema, profileNames);
    }

    public static IReadOnlyDictionary<string, string[]> GetItemsFromSchema(JsonDocument schema, IEnumerable<string> profileNames)
    {
        var definitions = schema.RootElement.GetProperty("definitions").EnumerateObject().ToDictionary(x => x.Name, x => x);

        var parameterProperties = schema.RootElement.GetProperty("definitions").TryGetProperty("NukeBuild", out var nukebuildProperty)
            ? nukebuildProperty.GetProperty("properties").EnumerateObject()
                .Concat(schema.RootElement.TryGetProperty("properties", out var properties) ? properties.EnumerateObject() : [])
            : definitions["build"].Value.GetProperty("properties").EnumerateObject();

        return parameterProperties
            .Select(x => (x.Name, Values: GetValues(x)))
            .Where(x => x.Values != null)
            .ToDictionary(x => x.Name, x => x.Values)
            .SetKeyValue(Constants.LoadedLocalProfilesParameterName, profileNames.ToArray()).AsReadOnly();

        string[] GetValues(JsonProperty property)
        {
            if (property.Value.TryGetProperty("type", out var typeProperty))
            {
                var types = typeProperty.ValueKind != JsonValueKind.Array
                    ? [typeProperty.GetString()]
                    : typeProperty.EnumerateArray().Select(x => x.GetString()).ToArray();
                if (types.ContainsAnyOrdinalIgnoreCase(["string", "boolean", "integer"]))
                {
                    return property.Value.TryGetProperty("enum", out var enumProperty)
                        ? enumProperty.EnumerateArray().Select(x => x.GetString()).ToArray()
                        : [];
                }

                if (types.Single() == "array")
                    return GetValues(property.Value.EnumerateObject().Single(x => x.Name == "items"));

                if (types.Single() == "object")
                    return null;
            }
            else if (property.Value.TryGetProperty("$ref", out var refProperty))
            {
                var definition = definitions.GetValueOrDefault(refProperty.GetString().NotNull().Split('/').LastOrDefault());
                return GetValues(definition);
            }

            throw new NotSupportedException();
        }
    }

    // ReSharper disable once CognitiveComplexity
    public static IEnumerable<string> GetRelevantItems(
        string words,
        IReadOnlyDictionary<string, string[]> completionItems)
    {
        completionItems = new Dictionary<string, string[]>(completionItems.ToDictionary(x => x.Key, x => x.Value), StringComparer.OrdinalIgnoreCase).AsReadOnly();
        var suggestedItems = new List<string>();

        var parts = words.Split(separator: ' ');
        var currentWord = parts.Last() != string.Empty ? parts.Last() : null;
        var parameters = parts.Where(ArgumentParser.IsArgument).Select(ArgumentParser.GetArgumentMemberName).ToList();
        var lastParameter = parameters.LastOrDefault();

        void AddParameters()
        {
            var useDashes = currentWord == null ||
                            currentWord.TrimStart('-').Length == 0 ||
                            currentWord.StartsWith("--");
            var items = completionItems.Keys
                .Except(parameters, StringComparer.InvariantCultureIgnoreCase)
                .Select(x => useDashes
                    ? $"--{ArgumentParser.GetParameterDashedName(x)}"
                    : $"-{x}");

            AddItems(items);
        }

        void AddTargetsOrValues(string parameter)
        {
            var passedItems = parts
                .Reverse()
                .TakeUntil(ArgumentParser.IsArgument)
                .Select(ArgumentParser.GetArgumentMemberName);

            var items = completionItems.GetValueOrDefault(parameter)?.Except(passedItems, StringComparer.OrdinalIgnoreCase) ??
                        new string[0];

            if (parameter.EqualsOrdinalIgnoreCase(Constants.InvokedTargetsParameterName))
                items = items.Select(x => x.SplitCamelHumpsWithKnownWords().JoinDash());

            AddItems(items);
        }

        void AddItems(IEnumerable<string> items)
        {
            foreach (var item in items)
            {
                if (currentWord == null)
                    suggestedItems.Add(item);
                else if (item.StartsWithOrdinalIgnoreCase(currentWord))
                {
                    var normalizedItem = item.ReplaceRegex(currentWord, _ => currentWord, RegexOptions.IgnoreCase);
                    if (normalizedItem != item)
                    {
                        var letters = currentWord.Where(char.IsLetter).ToList();
                        if (letters.All(char.IsUpper))
                            normalizedItem = normalizedItem.ToUpperInvariant();
                        else if (letters.All(char.IsLower))
                            normalizedItem = normalizedItem.ToLowerInvariant();
                    }

                    suggestedItems.Add(normalizedItem);
                }
            }
        }

        if (lastParameter == null)
            AddTargetsOrValues(Constants.InvokedTargetsParameterName);
        else if (currentWord != lastParameter)
            AddTargetsOrValues(lastParameter);

        if (currentWord == null || ArgumentParser.IsArgument(currentWord))
            AddParameters();

        return suggestedItems;
    }
}
