// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Humanizer;
using Nuke.Common;

namespace Nuke.CodeGeneration.Generators
{
    public static class StringExtensions
    {
        private static readonly string[] s_reservedWords =
        {
            "abstract",
            "as",
            "base",
            "bool",
            "break",
            "byte",
            "case",
            "catch",
            "char",
            "checked",
            "class",
            "const",
            "continue",
            "decimal",
            "default",
            "delegate",
            "do",
            "double",
            "else",
            "enum",
            "event",
            "explicit",
            "extern",
            "false",
            "finally",
            "fixed",
            "float",
            "for",
            "foreach",
            "goto",
            "if",
            "implicit",
            "in",
            "int",
            "interface",
            "internal",
            "is",
            "lock",
            "long",
            "namespace",
            "new",
            "null",
            "object",
            "operator",
            "out",
            "override",
            "params",
            "private",
            "protected",
            "public",
            "readonly",
            "ref",
            "return",
            "sbyte",
            "sealed",
            "short",
            "sizeof",
            "stackalloc",
            "static",
            "string",
            "struct",
            "switch",
            "this",
            "throw",
            "true",
            "try",
            "typeof",
            "uint",
            "ulong",
            "unchecked",
            "unsafe",
            "ushort",
            "using",
            "virtual",
            "void",
            "volatile",
            "while"
        };

        public static string ToInstance(this string text)
        {
            var firstLowerCaseIndex = text.TakeWhile(char.IsUpper).Count();
            return text.Substring(startIndex: 0, length: firstLowerCaseIndex).ToLower(CultureInfo.InvariantCulture) +
                   text.Substring(firstLowerCaseIndex);
        }

        public static string EscapeParameter(this string parameterName)
        {
            return s_reservedWords.Contains(parameterName) ? "@" + parameterName : parameterName;
        }

        public static string EscapeProperty(this string propertyName)
        {
            return s_reservedWords.Contains(propertyName) ? propertyName + "_" : propertyName;
        }

        public static string Paragraph(this string text)
        {
            return text == null || text.StartsWith("<p>") && text.EndsWith("</p>")
                ? text
                : $"<p>{text}</p>";
        }

        public static string Emphasize(this string text)
        {
            return $"<em>{text}</em>";
        }

        public static string ToSingular(this string name)
        {
            return name.Singularize(inputIsKnownToBePlural: false);
        }

        public static string ToPlural(this string name)
        {
            return name.Pluralize(inputIsKnownToBeSingular: false);
        }

        public static string DoubleQuote(this string text)
        {
            return $"\"{text}\"";
        }

        public static string DoubleQuoteInterpolated(this string text)
        {
            return $"${text.DoubleQuote()}";
        }

        public static string SingleQuote(this char? text)
        {
            Trace.Assert(text.HasValue, "text.HasValue");
            return $"\'{text.NotNull().Value}\'";
        }

        public static string ToSeeCref(this string reference)
        {
            return $"<see cref={reference.DoubleQuote()}/>";
        }
    }
}
