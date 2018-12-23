// Copyright 2018 Maintainers of NUKE.
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

        private const ConsoleKey c_confirmationKey = ConsoleKey.Enter;
        private const ConsoleKey c_interruptKey = ConsoleKey.F8;

        private static bool s_interrupted;

        [CanBeNull]
        public static string PromptForInput(string question, string defaultValue)
        {
            if (s_interrupted)
                return defaultValue;

            Logger.Log(question);

            ConsoleKeyInfo input;
            var inputBuilder = new StringBuilder();
            do
            {
                Console.CursorLeft = 0;
                Console.WriteLine(Selected.PadRight(BufferWidth), Color.DeepSkyBlue);
                Console.CursorTop--;
                Console.CursorLeft = 3;

                if (inputBuilder.Length > 0)
                {
                    Console.Write(inputBuilder.ToString());
                }
                else if (defaultValue != null)
                {
                    Console.Write($"               {string.Format(Default, defaultValue)}", Color.DarkGray);
                    Console.CursorLeft = 3;
                }

                input = Console.ReadKey(intercept: true);
                if (ConsoleKey.A <= input.Key && input.Key <= ConsoleKey.Z
                    || new[] { '.', '/', '\\', '_', '-' }.Any(x => x == input.KeyChar))
                    inputBuilder.Append(input.KeyChar);
                else if (input.Key == ConsoleKey.Backspace && inputBuilder.Length > 0)
                    inputBuilder.Remove(inputBuilder.Length - 1, length: 1);
                else if (input.Key == c_interruptKey)
                    s_interrupted = true;
            } while (!(input.Key == c_confirmationKey || input.Key == c_interruptKey));

            var result = inputBuilder.Length > 0 ? inputBuilder.ToString() : defaultValue;
            Console.CursorLeft = 0;
            Console.WriteLine($"{Confirmed}  {result ?? "<null>"}".PadRight(BufferWidth), Color.Lime);
            return result;
        }

        public static T PromptForChoice<T>(string question, params (T Value, string Description)[] options)
        {
            if (s_interrupted)
                return options.First().Value;

            var selection = 0;
            ConsoleKey input;

            Logger.Log(question);
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

                input = Console.ReadKey(intercept: true).Key;
                if (input == ConsoleKey.UpArrow)
                    selection--;
                else if (input == ConsoleKey.DownArrow)
                    selection++;
                else if (input == c_interruptKey)
                    s_interrupted = true;
                selection = Math.Max(val1: 0, Math.Min(options.Length - 1, selection));

                Console.CursorTop -= options.Length;
                foreach (var option in options)
                    Console.WriteLine(new string(c: ' ', BufferWidth));
                Console.CursorTop -= options.Length;
            } while (!(input == c_confirmationKey || input == c_interruptKey));

            Console.WriteLine($"{Confirmed}  {options[selection].Description}", Color.Lime);

            return options[selection].Value;
        }
        
        public static string ReadSecret()
        {
            var secret = string.Empty;

            do
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Backspace ||
                    key.KeyChar == 23 ||
                    key.KeyChar == 21)
                {
                    if (secret.Length > 0)
                    {
                        var charsToRemove = (key.Modifiers & ConsoleModifiers.Control) != 0 ? secret.Length : 1;
                        secret = secret.Substring(startIndex: 0, length: secret.Length - charsToRemove);
                        Console.Write(string.Concat(Enumerable.Repeat("\b \b", charsToRemove)));
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Write(Environment.NewLine);
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
