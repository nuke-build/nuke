// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Nuke.Core.Utilities;
using Nuke.Core.Utilities.Collections;

namespace Nuke.Core.Tooling
{
    public interface IArguments
    {
        string Filter (string text);
        string RenderForExecution ();
        string RenderForOutput ();
    }

    public class Arguments : IArguments
    {
        public const string HiddenString = "[hidden]";

        private readonly List<string> _secrets = new List<string>();
        private readonly List<Tuple<string, string>> _arguments = new List<Tuple<string, string>>();

        public Arguments Add (string argument, bool condition = true)
        {
            return condition
                ? Add(argument, new object())
                : this;
        }

        public Arguments Add<T> (string argumentFormat, T? value, bool secret = false)
            where T : struct
        {
            return value.HasValue
                ? Add(argumentFormat, value.Value, secret)
                : this;
        }

        public Arguments Add (string argumentFormat, [CanBeNull] string value, bool secret = false)
        {
            return Add(argumentFormat, (object) value, secret);
        }

        public Arguments Add (string argumentFormat, [CanBeNull] object value, bool secret = false)
        {
            if (value != null)
            {
                if (secret)
                    _secrets.Add(value.ToString());

                _arguments.Add(Tuple.Create(argumentFormat.Replace("{value}", "{0}"), value.ToString()));
            }
            return this;
        }

        public Arguments Add<T> (
            string argumentFormat,
            [CanBeNull] IEnumerable<T> enumerable,
            string mainSeparator = null,
            bool secret = false)
        {
            var list = enumerable?.ToList();
            if (list == null || list.Count <= 0)
                return this;

            if (mainSeparator != null)
                Add(argumentFormat, string.Join(mainSeparator, list.Select(x => x.ToString())), secret);
            else
                list.ForEach(x => Add(argumentFormat, x, secret));

            return this;
        }

        public Arguments Add<TKey, TValue> (
            string argumentFormat,
            [CanBeNull] IReadOnlyDictionary<TKey, TValue> dictionary,
            string keyValueSeparator,
            string mainSeparator = null,
            bool secret = false)
        {
            if (dictionary == null || dictionary.Count <= 0)
                return this;

            if (mainSeparator != null)
                Add(argumentFormat, string.Join(mainSeparator, dictionary.Select(x => $"{x.Key}{keyValueSeparator}{x.Value}")), secret);
            else
                dictionary.ForEach(x => Add(argumentFormat, $"{x.Key}{keyValueSeparator}{x.Value}", secret));

            return this;
        }

        public Arguments Add<TKey, TValue> (
            string argumentFormat,
            [CanBeNull] ILookup<TKey, TValue> lookup,
            string keyValueSeparator,
            bool secret = false)
        {
            if (lookup == null || lookup.Count <= 0)
                return this;

            foreach (var grouping in lookup)
            foreach (var value in grouping)
                Add(argumentFormat, $"{grouping.Key}{keyValueSeparator}{value}", secret);

            return this;
        }

        public string Filter (string text)
        {
            return _secrets.Aggregate(text, (str, s) => str.Replace(s, HiddenString));
        }

        private string Render (bool forOutput)
        {
            return _arguments
                    .Aggregate(
                        new StringBuilder(),
                        (sb, a) => sb.AppendFormat(a.Item1, forOutput && _secrets.Contains(a.Item2) ? HiddenString : a.Item2.Trim().DoubleQuoteIfNeeded())
                                .Append(value: ' '),
                        sb => sb.ToString().TrimEnd(' '));
        }

        public string RenderForExecution()
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
