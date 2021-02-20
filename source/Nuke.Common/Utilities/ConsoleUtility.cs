// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Drawing;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Console = Colorful.Console;

namespace Nuke.Common.Utilities
{
    public class ConsoleUtility
    {
        private static int BufferWidth => EnvironmentInfo.IsWin ? Console.BufferWidth - 1 : Console.BufferWidth;

        private static string Default => "[default: {0}]";
        private static string Confirmed => "¬";
        private static string Selected => "»";
        private static string Unselected => " ";

        private const ConsoleKey ConfirmationKey = ConsoleKey.Enter;
        private const ConsoleKey InterruptKey = ConsoleKey.F8;

        private static bool s_interrupted;

        // ReSharper disable once CognitiveComplexity
        [CanBeNull]
        public static string PromptForInput(string question, string defaultValue)
        {
            if (s_interrupted)
                return defaultValue;

            Logger.Normal(question);

            ConsoleKeyInfo key;
            var input = new StringBuilder();
            do
            {
                Console.CursorLeft = 0;
                Console.WriteLine(Selected.PadRight(BufferWidth), Color.DeepSkyBlue);
                Console.CursorTop--;
                Console.CursorLeft = 3;

                if (input.Length > 0)
                {
                    Console.Write(input.ToString());
                }
                else if (defaultValue != null)
                {
                    Console.Write($"               {string.Format(Default, defaultValue)}", Color.DarkGray);
                    Console.CursorLeft = 3;
                }

                key = Console.ReadKey(intercept: true);
                if (ConsoleKey.A <= key.Key && key.Key <= ConsoleKey.Z
                    || ConsoleKey.D0 <= key.Key && key.Key <= ConsoleKey.D9
                    || new[] { '.', '/', '\\', '_', '-' }.Any(x => x == key.KeyChar))
                    input.Append(key.KeyChar);
                else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                    input.Remove(input.Length - 1, length: 1);
                else if (key.Key == InterruptKey)
                    s_interrupted = true;
            } while (!(key.Key == ConfirmationKey || key.Key == InterruptKey));

            var result = input.Length > 0 ? input.ToString() : defaultValue;
            Console.CursorLeft = 0;
            Console.WriteLine($"{Confirmed}  {result ?? "<null>"}".PadRight(BufferWidth), Color.Lime);
            return result;
        }

        // ReSharper disable once CognitiveComplexity
        public static T PromptForChoice<T>(string question, params (T Value, string Description)[] options)
        {
            if (s_interrupted)
                return options.First().Value;

            var selection = 0;
            ConsoleKey key;

            Logger.Normal(question);
            do
            {
                for (var i = 0; i < options.Length; i++)
                {
                    var option = options[i];
                    var selected = i == selection;
                    var prefix = selected ? Selected : Unselected;
                    var color = selected ? Color.DeepSkyBlue : Color.DarkGray;
                    Console.WriteLine($"{prefix}  {option.Description}", color);
                }

                key = Console.ReadKey(intercept: true).Key;
                if (key == ConsoleKey.UpArrow)
                    selection--;
                else if (key == ConsoleKey.DownArrow)
                    selection++;
                else if (key == InterruptKey)
                    s_interrupted = true;
                selection = Math.Max(val1: 0, Math.Min(options.Length - 1, selection));

                Console.CursorTop -= options.Length;
                foreach (var option in options)
                    Console.WriteLine(new string(c: ' ', BufferWidth));
                Console.CursorTop -= options.Length;
            } while (!(key == ConfirmationKey || key == InterruptKey));

            Console.WriteLine($"{Confirmed}  {options[selection].Description}", Color.Lime);

            return options[selection].Value;
        }

        // ReSharper disable once CognitiveComplexity
        public static string ReadSecret()
        {
            var secret = string.Empty;

            do
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Backspace)
                {
                    if (secret.Length > 0)
                    {
                        var charsToRemove =
                            (key.Modifiers & ConsoleModifiers.Control) != 0 && !EnvironmentInfo.IsOsx ||
                            (key.Modifiers & ConsoleModifiers.Alt) != 0 && EnvironmentInfo.IsOsx
                                ? secret.Length
                                : 1;
                        secret = secret.Substring(startIndex: 0, length: secret.Length - charsToRemove);
                        Console.Write(string.Concat(Enumerable.Repeat("\b \b", charsToRemove)));
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    secret += key.KeyChar;
                    Console.Write("*");
                }
            } while (true);

            return secret;
        }
    }
}
