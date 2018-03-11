// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Text.RegularExpressions;
using Nuke.Core.Utilities;

namespace Nuke.Core.OutputSinks
{
    public static class AnsiColorFormatter
    {
        private const string ControlSequenceIntroducer = "\u001b[";
        private const string ResetColorAttribute = ControlSequenceIntroducer + "0m";

        public static string ColorizeString(string text, ConsoleColor? textColor = null, ConsoleColor? backgroundColor = null)
        {
            var textColorSequence = textColor.HasValue ? GetAnsiColorSequence(textColor.Value) : string.Empty;
            var bgColorSequence = backgroundColor.HasValue ? GetAnsiColorSequence(backgroundColor.Value, backgroundColor: true) : string.Empty;
            return $"{textColorSequence}{bgColorSequence}{text}{ResetColorAttribute}";
        }

        public static string FormatAnsiString(string text)
        {
            var matches = Regex.Matches(text, "{(!?[A-Za-z]+)}");
            if (matches.Count == 0)
                return text;
            return matches.Cast<Match>().Reverse().Aggregate(text,
                (current, match) => current.Replace(match.Index, match.Length, ReplacePattern(match.Groups[groupnum: 1].Value)));
        }

        private static string GetAnsiColorSequence(ConsoleColor color, bool backgroundColor = false)
        {
            int colorCode;
            switch (color)
            {
                case ConsoleColor.Black:
                case ConsoleColor.DarkGray:
                    colorCode = 30;
                    break;

                case ConsoleColor.Blue:
                case ConsoleColor.DarkBlue:
                    colorCode = 34;
                    break;
                case ConsoleColor.Green:
                case ConsoleColor.DarkGreen:
                    colorCode = 32;
                    break;
                case ConsoleColor.Cyan:
                case ConsoleColor.DarkCyan:
                    colorCode = 36;
                    break;
                case ConsoleColor.Red:
                case ConsoleColor.DarkRed:
                    colorCode = 31;
                    break;
                case ConsoleColor.Magenta:
                case ConsoleColor.DarkMagenta:
                    colorCode = 35;
                    break;
                case ConsoleColor.Yellow:
                case ConsoleColor.DarkYellow:
                    colorCode = 33;
                    break;
                case ConsoleColor.White:
                case ConsoleColor.Gray:
                    colorCode = 37;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, message: null);
            }

            var isBrightColorFlag = color != ConsoleColor.DarkGray && color.ToString().StartsWith("Dark")
                                    || color == ConsoleColor.Black
                                    || color == ConsoleColor.Gray;
            colorCode = backgroundColor ? colorCode + 10 : colorCode;

            return $"{ControlSequenceIntroducer}{colorCode}{(isBrightColorFlag ? string.Empty : ";1")}m";
        }

        private static string ReplacePattern(string pattern)
        {
            var isBackgroundColor = pattern.StartsWith("!");
            pattern = pattern.TrimStart('!');

            if (pattern == "rst")
                return ResetColorAttribute;

            if (!Enum.TryParse(pattern, ignoreCase: true, result: out ConsoleColor color))
                throw new ArgumentException($"{pattern} is not a valid ConsoleColor.", nameof(pattern));
            return GetAnsiColorSequence(color, isBackgroundColor);
        }
    }
}
