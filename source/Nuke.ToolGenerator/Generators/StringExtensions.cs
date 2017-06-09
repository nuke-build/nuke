using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Nuke.ToolGenerator.Generators
{
    public static class StringExtensions
    {
        public static string ToInstance (this string text)
        {
            var firstLowerCaseIndex = text.TakeWhile(char.IsUpper).Count();
            return (text.Substring(startIndex: 0, length: firstLowerCaseIndex).ToLower(CultureInfo.InvariantCulture) +
                    text.Substring(startIndex: firstLowerCaseIndex))
                    .Replace("namespace", "ns");
        }

        public static string ToMember (this string text)
        {
            return text.Substring (startIndex: 0, length: 1).ToUpper (CultureInfo.InvariantCulture) +
                   text.Substring (startIndex: 1);
        }

        public static string Paragraph(this string text)
        {
            return !text.StartsWith("<p>") ? $"<p>{text}</p>" : text;
        }

        public static string ToSingular (this string name)
        {
            if (name.EndsWith("ies"))
                return name.Substring(startIndex: 0, length: name.Length - 3) + "y";

            if (name.EndsWith("s"))
                return name.Substring(startIndex: 0, length: name.Length - 1);

            return name;
        }

        public static string Quote (this string text, bool interpolation = true)
        {
            return $"{(interpolation ? "$" : null)}\"{text}\"";
        }

        public static string Join (this IEnumerable<string> values, string separator = ", ")
        {
            return string.Join(separator, values);
        }

        public static string ToSeeCref(this string reference)
        {
            return $"<see cref={reference.Quote(interpolation: false)}/>";
        }
    }
}
