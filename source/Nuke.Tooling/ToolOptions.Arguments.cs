// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tooling;

public class CommandAttribute : Attribute
{
    public Type Type { get; set; }
    public string Command { get; set; }
    public string Arguments { get; set; }
}

public class ArgumentEscapeAttribute : Attribute
{
    public Type Type { get; set; }
    public string Method { get; set; }
}

public class ArgumentAttribute : Attribute
{
    public int Position { get; set; }
    public string Format { get; set; }
    public string AlternativeFormat { get; set; }
    public bool Secret { get; set; }

    public Type FormatterType { get; set; }
    public string FormatterMethod { get; set; }

    public string Separator { get; set; }
    public string InnerSeparator { get; set; }
    public bool QuoteMultiple { get; set; }
}

public class BuilderAttribute : Attribute
{
    public Type Type { get; set; }
    public string Property { get; set; }
}

partial class ToolOptions
{
    private const string KeyPlaceholder = "{key}";
    private const string ValuePlaceholder = "{value}";

    internal partial IEnumerable<string> GetArguments()
    {
        var commandAttribute = GetType().GetCustomAttribute<CommandAttribute>();
        if (commandAttribute?.Arguments != null)
            yield return commandAttribute.Arguments;

        var escapeMethod = CreateEscape();
        var arguments = InternalOptions.Properties()
            .Select(x => (Token: x.Value, Property: GetType().GetProperty(x.Name).NotNull()))
            .Select(x => (x.Token, x.Property, Attribute: x.Property.GetCustomAttribute<ArgumentAttribute>()))
            .Where(x => x.Attribute != null)
            .OrderByDescending(x => x.Attribute.Position.CompareTo(0))
            .ThenBy(x => x.Attribute.Position)
            .SelectMany(x => GetArgument(x.Token, x.Property, x.Attribute, escapeMethod))
            .WhereNotNull()
            .Concat(ProcessAdditionalArguments ?? []);

        foreach (var argument in arguments)
            yield return argument;

        Func<string, PropertyInfo, string> CreateEscape()
        {
            var toolType = commandAttribute?.Type;
            var escapeAttribute = toolType?.GetCustomAttribute<ArgumentEscapeAttribute>();
            if (escapeAttribute == null)
                return (x, _) => x.DoubleQuoteIfNeeded();

            var escapeType = escapeAttribute.Type ?? GetType();
            var formatterMethod = escapeType.GetMethod(escapeAttribute.Method, ReflectionUtility.All);
            return (value, property) => formatterMethod.GetValue<string>(obj: this, args: [value, property]);
        }
    }

    private IEnumerable<string> GetArgument(
        JToken token,
        PropertyInfo property,
        ArgumentAttribute attribute,
        Func<string, PropertyInfo, string> escape)
    {
        var format = attribute.Format;
        var formatParts = format.SplitSpace();

        if (!property.PropertyType.IsGenericType || property.PropertyType.IsNullableType())
            return GetScalarArguments();

        if (property.PropertyType.GetGenericTypeDefinition() == typeof(IReadOnlyList<>))
            return GetListArguments();

        if (property.PropertyType.GetGenericTypeDefinition() == typeof(IReadOnlyDictionary<,>))
            return GetDictionaryArguments();

        if (property.PropertyType.GetGenericTypeDefinition() == typeof(ILookup<,>))
            return GetLookupArguments();

        return [];

        string Parse(JToken token, Type type)
        {
            string value;
            if (attribute.FormatterMethod != null)
            {
                var formatterType = attribute.FormatterType ?? GetType();
                var formatterMethod = formatterType.GetMethod(attribute.FormatterMethod, ReflectionUtility.All);
                var objValue = type != typeof(object) ? token.ToObject(type) : token.ToObject<string>();
                value = formatterMethod.GetValue<string>(obj: this, args: [objValue, property]);
            }
            else
            {
                value = token.ToObject<string>();
                if (new[] { typeof(bool), typeof(bool?) }.Contains(type) ||
                    (type == typeof(object) && new[] { bool.TrueString, bool.FalseString }.Contains(value)))
                    value = value.ToLowerInvariant();
            }

            return escape.Invoke(value, property);
        }

        IEnumerable<string> GetScalarArguments()
        {
            if (property.PropertyType == typeof(bool?) &&
                !format.ContainsOrdinalIgnoreCase(ValuePlaceholder) &&
                !token.Value<bool>())
                yield break;

            var value = Parse(token, property.PropertyType);
            foreach (var part in formatParts)
                yield return part.Replace(ValuePlaceholder, value);
        }

        IEnumerable<string> GetListArguments()
        {
            Assert.True(formatParts.Length <= 2);

            var valueType = property.PropertyType.GetScalarType();
            var values = token.Value<JArray>().Select(x => Parse(x, valueType));

            if (attribute.Separator == null)
            {
                Assert.False(attribute.QuoteMultiple);
                return from value in values
                       from part in formatParts
                       select part.Replace(ValuePlaceholder, value);
            }

            return formatParts.SelectMany(part =>
            {
                var valueStart = part.IndexOf(ValuePlaceholder, StringComparison.OrdinalIgnoreCase);
                if (valueStart == -1)
                    return [part];

                if (attribute.Separator.IsNullOrWhiteSpace() && !attribute.QuoteMultiple)
                    return values.Select(x => part.Replace(ValuePlaceholder, x));

                var joinedValues = values.Join(attribute.Separator);
                if (attribute.QuoteMultiple)
                    joinedValues = joinedValues.DoubleQuote();

                return [part.Replace(ValuePlaceholder, joinedValues)];
            });
        }

        IEnumerable<string> GetDictionaryArguments()
        {
            var valueType = property.PropertyType.GetGenericArguments().Last();
            var pairs = token.Value<JObject>().Properties().Select(x => (Key: x.Name, Value: Parse(x, valueType)));

            if (attribute.Separator == null)
            {
                return from pair in pairs
                       from part in formatParts
                       select part.Replace(KeyPlaceholder, pair.Key).Replace(ValuePlaceholder, pair.Value);
            }

            return formatParts.SelectMany(part =>
            {
                var pairStart = part.IndexOf(KeyPlaceholder, StringComparison.OrdinalIgnoreCase);
                var pairLength = part.IndexOf(ValuePlaceholder, StringComparison.OrdinalIgnoreCase) - pairStart + ValuePlaceholder.Length;

                if (pairStart == -1)
                    return [part];

                if (attribute.Separator.IsNullOrWhiteSpace())
                    return pairs.Select(x => part.Replace(KeyPlaceholder, x.Key).Replace(ValuePlaceholder, x.Value));

                var pairPart = part.Substring(pairStart, pairLength);
                var replacedPairs = pairs.Select(x => pairPart.Replace(KeyPlaceholder, x.Key).Replace(ValuePlaceholder, x.Value));
                return [part.Substring(startIndex: 0, length: pairStart) + replacedPairs.Join(attribute.Separator)];
            });
        }

        IEnumerable<string> GetLookupArguments()
        {
            var valueType = property.PropertyType.GetGenericArguments().Last();
            var pairs = token.Value<JObject>().Properties()
                .Select(x => (Key: x.Name, Values: x.Value.Value<JArray>().Select(x => Parse(x, valueType))));

            if (attribute.Separator == null)
            {
                if (attribute.InnerSeparator == null)
                {
                    return from pair in pairs
                           from value in pair.Values
                           from part in formatParts
                           select part.Replace(KeyPlaceholder, pair.Key).Replace(ValuePlaceholder, value);
                }
                else
                {
                    return from pair in pairs
                           from part in formatParts
                           select part.Replace(KeyPlaceholder, pair.Key).Replace(ValuePlaceholder, pair.Values.Join(attribute.InnerSeparator));
                }
            }

            Assert.NotNull(attribute.InnerSeparator);

            return formatParts.SelectMany(part =>
            {
                var pairStart = part.IndexOf(KeyPlaceholder, StringComparison.OrdinalIgnoreCase);
                var pairLength = part.IndexOf(ValuePlaceholder, StringComparison.OrdinalIgnoreCase) - pairStart + ValuePlaceholder.Length;

                if (pairStart == -1)
                    return [part];

                if (attribute.Separator.IsNullOrWhiteSpace())
                    return pairs.Select(x => part.Replace(KeyPlaceholder, x.Key).Replace(ValuePlaceholder, x.Values.Join(attribute.InnerSeparator)));

                var pairPart = part.Substring(pairStart, pairLength);
                var replacedPairs = pairs.Select(x => pairPart.Replace(KeyPlaceholder, x.Key).Replace(ValuePlaceholder, x.Values.Join(attribute.InnerSeparator)));
                return [part.Substring(startIndex: 0, length: pairStart) + replacedPairs.Join(attribute.Separator)];
            });
        }
    }
}
