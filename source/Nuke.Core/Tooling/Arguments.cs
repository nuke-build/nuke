// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Nuke.Core.Utilities;

namespace Nuke.Core.Tooling
{
    public interface IArguments
    {
        string Filter (string text);
        string RenderForExecution ();
        string RenderForOutput ();
    }

    public sealed class Arguments : IArguments
    {
        public const string HiddenString = "[hidden]";
        private const char c_space = ' ';

        private readonly List<string> _secrets = new List<string>();
        private readonly List<Tuple<string, string>> _arguments = new List<Tuple<string, string>>();

        public Arguments Add (string argument, bool condition = true)
        {
            return Add(argument, condition ? new object() : null);
        }

        public Arguments Add<T> (string argumentFormat, T? value, char? disallowed = null, bool secret = false)
            where T : struct
        {
            return Add(argumentFormat, value.HasValue ? (object) value.Value : null, disallowed, secret);
        }

        public Arguments Add (string argumentFormat, [CanBeNull] object value, char? disallowed = null, bool secret = false)
        {
            return Add(argumentFormat, value?.ToString(), disallowed, secret);
        }

        public Arguments Add (string argumentFormat, [CanBeNull] string value, char? disallowed = null, bool secret = false)
        {
            if (string.IsNullOrWhiteSpace(value))
                return this;

            if (secret)
                _secrets.Add(value);

            _arguments.Add(Tuple.Create(argumentFormat.Replace("{value}", "{0}"), value.TrimAndDoubleQuoteIfNeeded(disallowed, c_space)));

            return this;
        }

        public Arguments Add<T> (
            string argumentFormat,
            [CanBeNull] IEnumerable<T> enumerable,
            char? mainSeparator = null,
            char? disallowed = null,
            bool secret = false)
        {
            var list = enumerable?.ToList();
            if (list == null || list.Count <= 0)
                return this;

            string Format (T value) => value.ToString().TrimAndDoubleQuoteIfNeeded(mainSeparator, disallowed);

            if (mainSeparator.HasValue)
                Add(argumentFormat, list.Select(Format).Join(mainSeparator.Value), secret: secret);
            else
                list.ForEach(x => Add(argumentFormat, x, disallowed, secret));

            return this;
        }

        public Arguments Add<TKey, TValue> (
            string argumentFormat,
            [CanBeNull] IReadOnlyDictionary<TKey, TValue> dictionary,
            char keyValueSeparator,
            char? mainSeparator = null,
            char? disallowed = null,
            bool secret = false)
            where TValue : class
        {
            if (dictionary == null || dictionary.Count <= 0)
                return this;

            string Format (TValue value) => value.ToString().TrimAndDoubleQuoteIfNeeded(mainSeparator, keyValueSeparator, disallowed);
            var pairs = dictionary.Where(x => x.Value.NotNullWarn($"Omitting '{x.Key}' because it is set to 'null'.") != null).ToList();

            if (mainSeparator.HasValue)
                Add(argumentFormat, pairs.Select(x => $"{x.Key}{keyValueSeparator}{Format(x.Value)}").Join(mainSeparator.Value), secret: secret);
            else
                pairs.ForEach(x => Add(argumentFormat, $"{x.Key}{keyValueSeparator}{Format(x.Value)}", secret: secret));

            return this;
        }

        public Arguments Add<TKey, TValue> (
            string argumentFormat,
            [CanBeNull] ILookup<TKey, TValue> lookup,
            char keyValueSeparator,
            char? mainSeparator = null,
            char? disallowed = null,
            bool secret = false)
        {
            if (lookup == null || lookup.Count <= 0)
                return this;

            string Format (TValue value) => value?.ToString().TrimAndDoubleQuoteIfNeeded(keyValueSeparator, disallowed);

            if (mainSeparator.HasValue)
            {
                foreach (var grouping in lookup)
                    Add(argumentFormat, $"{grouping.Key}{keyValueSeparator}{grouping.Select(Format).Join(mainSeparator.Value)}", secret: secret);
            }
            else
            {
                foreach (var grouping in lookup)
                foreach (var value in grouping)
                    Add(argumentFormat, $"{grouping.Key}{keyValueSeparator}{Format(value)}", secret: secret);
            }

            return this;
        }

        public string Filter (string text)
        {
            return _secrets.Aggregate(text, (str, s) => str.Replace(s, HiddenString));
        }

        private string Render (bool forOutput)
        {
            string Format (Tuple<string, string> argument)
                => !_secrets.Contains(argument.Item2) || !forOutput
                    ? argument.Item2
                    : HiddenString;

            return _arguments.Aggregate(
                new StringBuilder(),
                (sb, a) => sb.AppendFormat(a.Item1, Format(a)).Append(value: c_space),
                sb => sb.ToString().TrimEnd(c_space));
        }

        public string RenderForExecution ()
        {
            return Render(forOutput: false);
        }

        public string RenderForOutput ()
        {
            return Render(forOutput: true);
        }

        public override string ToString ()
        {
            return RenderForOutput();
        }
    }
}
