// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.OutputSinks
{
    internal abstract class ConsoleOutputSink : IOutputSink
    {
        public static IOutputSink Default
        {
            get
            {
                var term = Environment.GetEnvironmentVariable("TERM");
                return term == null || !term.StartsWithOrdinalIgnoreCase("xterm")
                    ? (IOutputSink) new SystemColorOutputSink()
                    : new AnsiColorOutputSink();
            }
        }

        public static void WriteTest()
        {
            Console.WriteLine("╔═╗");
            Console.WriteLine("║ ║");
            Console.WriteLine("╚═╝");

            Logger.Warn("Warn");
            Logger.Error("Error");
            Logger.Normal("Normal");
            Logger.Info("Info");
            Logger.Trace("Trace");
            Logger.Success("Success");

            const string ESC = "\u001b[";
            const string RESET = "\u001b[0m";

            for (var i = 0; i < 120; i++)
            {
                Console.Write($"{ESC}{i}m{i}{RESET}  ");
                Console.Write($"{ESC}{i};1m{i};1{RESET}  ");
                if (i % 10 == 0)
                    Console.WriteLine();
            }
        }

        public virtual IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () =>
                {
                    var formattedBlockText = FormatBlockText(text)
                        .Split(new[] { EnvironmentInfo.NewLine }, StringSplitOptions.None);

                    Console.WriteLine();
                    Console.WriteLine("╬" + new string(c: '═', text.Length + 5));
                    formattedBlockText.ForEach(x => Console.WriteLine($"║ {x}"));
                    Console.WriteLine("╬" + new string(c: '═', Math.Max(text.Length - 4, 2)));
                    Console.WriteLine();
                });
        }

        protected virtual string FormatBlockText(string text)
        {
            return text;
        }

        public abstract void WriteNormal(string text);
        public abstract void WriteTrace(string text);
        public abstract void WriteInformation(string text);
        public abstract void WriteWarning(string text, string details = null);
        public abstract void WriteError(string text, string details = null);
        public abstract void WriteSuccess(string text);
    }
}
