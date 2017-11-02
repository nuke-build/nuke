// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Humanizer;
using JetBrains.Annotations;

namespace Nuke.CodeGeneration.Generators
{
    public static class StringExtensions
    {
        public static string ToInstance (this string text)
        {
            var firstLowerCaseIndex = text.TakeWhile(char.IsUpper).Count();
            return text.Substring(startIndex: 0, length: firstLowerCaseIndex).ToLower(CultureInfo.InvariantCulture) +
                   text.Substring(firstLowerCaseIndex);
        }

        public static string Escape(this string text)
        {
            return new[] { "namespace", "class" }.Contains(text) ? "@" + text : text;
        }

        public static string ToMember (this string text)
        {
            return text.Substring(startIndex: 0, length: 1).ToUpper(CultureInfo.InvariantCulture) +
                   text.Substring(startIndex: 1);
        }

        public static string Paragraph ([CanBeNull] this string text)
        {
            if (text == null)
                return string.Empty;

            return !text.StartsWith("<p>") ? $"<p>{text}</p>" : text;
        }

        public static string ToSingular (this string name)
        {
            return name.Singularize(inputIsKnownToBePlural: false);
        }

        public static string ToPlural (this string name)
        {
            return name.Pluralize(inputIsKnownToBeSingular: false);
        }

        public static string DoubleQuote (this string text)
        {
            return $"\"{text}\"";
        }

        public static string DoubleQuoteInterpolated (this string text)
        {
            return $"${text.DoubleQuote()}";
        }

        public static string SingleQuote (this char? text)
        {
            Trace.Assert(text.HasValue, "text.HasValue");
            return $"\'{text.Value}\'";
        }

        public static string Join (this IEnumerable<string> values, string separator = ", ")
        {
            return string.Join(separator, values);
        }

        public static string ToSeeCref (this string reference)
        {
            return $"<see cref={reference.DoubleQuote()}/>";
        }
    }
}
