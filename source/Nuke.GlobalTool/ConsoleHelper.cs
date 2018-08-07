// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Drawing;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common;
using Console = Colorful.Console;

namespace Nuke.GlobalTool
{
    public class ConsoleHelper
    {
        private const char c_carriageReturn = '\u23CE';
        private const char c_checkMark = '\u2714';
        private const char c_pointer = '\u279C';

        private const ConsoleKey c_confirmationKey = ConsoleKey.Enter;
        private const ConsoleKey c_interruptKey = ConsoleKey.F8;

        private static bool s_interrupted = false;

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
                Console.WriteLine(c_pointer.ToString().PadRight(Console.BufferWidth), Color.DeepSkyBlue);
                Console.CursorTop--;
                Console.CursorLeft = 3;

                if (inputBuilder.Length > 0)
                {
                    Console.Write(inputBuilder.ToString());
                }
                else if (defaultValue != null)
                {
                    Console.Write(defaultValue.PadRight(totalWidth: 15) + $" {c_carriageReturn} for default", Color.DarkGray);
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
            Console.WriteLine($"{c_checkMark}  {result ?? "<null>"}".PadRight(Console.BufferWidth), Color.Lime);
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
                    var prefix = selected ? c_pointer : ' ';
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
                selection = Math.Max(0, Math.Min(options.Length - 1, selection));

                Console.CursorTop -= options.Length;
                foreach (var option in options)
                    Console.WriteLine(new string(c: ' ', Console.BufferWidth));
                Console.CursorTop -= options.Length;
            } while (!(input == c_confirmationKey || input == c_interruptKey));

            Console.WriteLine($"{c_checkMark}  {options[selection].Description}", Color.Lime);

            return options[selection].Value;
        }
    }
}
