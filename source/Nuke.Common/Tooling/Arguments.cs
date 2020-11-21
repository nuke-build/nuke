// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tooling
{
    public interface IArguments
    {
        string FilterSecrets(string text);
        string RenderForExecution();
        string RenderForOutput();
    }

    // TODO: extract {value} and {key} into constants
    public sealed class Arguments : IArguments
    {
        private const string HiddenString = "[hidden]";
        private const char Space = ' ';

        private readonly List<string> _secrets = new List<string>();
        private readonly List<KeyValuePair<string, List<string>>> _arguments = new List<KeyValuePair<string, List<string>>>();

        public Arguments Add(string argumentFormat, bool? condition = true)
        {
            return condition.HasValue && (condition.Value || argumentFormat.Contains("{value}"))
                ? Add(argumentFormat, (object) condition.Value)
                : this;
        }

        public Arguments Add<T>(string argumentFormat, T? value, char? disallowed = null, bool secret = false)
            where T : struct
        {
            return value.HasValue ? Add(argumentFormat, value.Value, disallowed, secret) : this;
        }

        public Arguments Add(string argumentFormat, [CanBeNull] object value, char? disallowed = null, bool secret = false)
        {
            return Add(argumentFormat, value?.ToString(), disallowed, customValue: false, secret);
        }

        public Arguments Add(
            string argumentFormat,
            [CanBeNull] string value,
            char? disallowed = null,
            bool customValue = false,
            bool secret = false)
        {
            if (string.IsNullOrWhiteSpace(value))
                return this;

            if (secret)
                _secrets.Add(value);

            argumentFormat = argumentFormat.Replace("{value}", "{0}");
            AddInternal(argumentFormat, customValue ? value : value.DoubleQuoteIfNeeded(disallowed, Space));

            return this;
        }

        public Arguments Add<T>(
            string argumentFormat,
            [CanBeNull] IEnumerable<T> values,
            char? separator = null,
            char? disallowed = null,
            bool quoteMultiple = false)
        {
            var list = values?.ToList();
            if (list == null || list.Count == 0)
                return this;

            argumentFormat = argumentFormat.Replace("{value}", "{0}");

            string Format(T value) => value.ToString().DoubleQuoteIfNeeded(separator, disallowed, Space);

            AddInternal(
                argumentFormat,
                separator.HasValue
                    ? new[] { FormatMultiple(list, Format, separator.Value, quoteMultiple) }
                    : list.Select(Format).ToArray());

            return this;
        }

        public Arguments Add<TKey, TValue>(
            string argumentFormat,
            [CanBeNull] IReadOnlyDictionary<TKey, TValue> dictionary,
            string itemFormat,
            char? separator = null,
            char? disallowed = null,
            bool quoteMultiple = false)
        {
            if (dictionary == null || dictionary.Count == 0)
                return this;

            argumentFormat = argumentFormat.Replace("{value}", "{0}");
            var keyValueSeparator = itemFormat.Replace("{key}", string.Empty).Replace("{value}", string.Empty);
            ControlFlow.Assert(keyValueSeparator.Length == 1, "keyValueSeparator.Length == 1");

            string Format(object value) => value.ToString().DoubleQuoteIfNeeded(separator, keyValueSeparator.Single(), disallowed, Space);

            string FormatPair(KeyValuePair<TKey, TValue> pair)
                => itemFormat
                    .Replace("{key}", Format(pair.Key))
                    .Replace("{value}", Format(pair.Value));

            var pairs = dictionary.Where(x => x.Value.NotNullWarn($"Value for '{x.Key}' is 'null', omitting...") != null).ToList();

            AddInternal(
                argumentFormat,
                separator.HasValue
                    ? new[] { FormatMultiple(pairs, FormatPair, separator.Value, quoteMultiple) }
                    : pairs.Select(FormatPair).ToArray());

            return this;
        }

        public Arguments Add<TKey, TValue>(
            string argumentFormat,
            [CanBeNull] ILookup<TKey, TValue> lookup,
            string itemFormat,
            char? separator = null,
            char? disallowed = null,
            bool quoteMultiple = false)
        {
            if (lookup == null || lookup.Count == 0)
                return this;

            argumentFormat = argumentFormat.Replace("{value}", "{0}");
            var listSeparator = itemFormat.Replace("{key}", string.Empty).Replace("{value}", string.Empty);
            ControlFlow.Assert(listSeparator.Length == 1, "listSeparator.Length == 1");

            string Format(object value) => value?.ToString().DoubleQuoteIfNeeded(separator, listSeparator.Single(), disallowed, Space);

            string FormatLookup(TKey key, string values)
                => itemFormat
                    .Replace("{key}", Format(key))
                    .Replace("{value}", values);

            foreach (var list in lookup)
            {
                AddInternal(
                    argumentFormat,
                    separator.HasValue
                        ? new[] { FormatLookup(list.Key, FormatMultiple(list, x => Format(x), separator.NotNull().Value, quoteMultiple)) }
                        : list.Select(x => FormatLookup(list.Key, Format(x))).ToArray());
            }

            return this;
        }

        public Arguments Concatenate(Arguments arguments)
        {
            _arguments.AddRange(arguments._arguments);
            _secrets.AddRange(arguments._secrets);
            return this;
        }

        private void AddInternal(string format, params string[] values)
        {
            var list = _arguments.LastOrDefault(x => x.Key.Equals(format, StringComparison.OrdinalIgnoreCase)).Value;
            if (list == null)
            {
                list = new List<string>();
                _arguments.Add(new KeyValuePair<string, List<string>>(format, list));
            }

            list.AddRange(values);
        }

        private string FormatMultiple<T>(IEnumerable<T> items, Func<T, string> format, char separator, bool quoteMultiple)
        {
            var values = items.Select(format).Join(separator);
            return !quoteMultiple
                ? values
                : values.DoubleQuoteIfNeeded();
        }

        public string FilterSecrets(string text)
        {
            return _secrets.Aggregate(text, (str, s) => str.Replace(s, HiddenString));
        }

        private string Render(bool forOutput)
        {
            string Format(string argument)
                => !_secrets.Contains(argument) || !forOutput
                    ? argument
                    : HiddenString;

            var builder = new StringBuilder();
            foreach (var argumentPair in _arguments)
            foreach (var argument in argumentPair.Value)
                builder.AppendFormat(argumentPair.Key, Format(argument)).Append(Space);

            return builder.ToString().TrimEnd();
        }

        public string RenderForExecution()
        {
            return Render(forOutput: false);
        }

        public string RenderForOutput()
        {
            return Render(forOutput: true);
        }

        public override string ToString()
        {
            return RenderForOutput();
        }
    }
}
