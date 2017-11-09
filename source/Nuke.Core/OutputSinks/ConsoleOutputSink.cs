// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.Execution;
using Nuke.Core.Utilities;
using Console = System.Console;

namespace Nuke.Core.OutputSinks
{
    [PublicAPI]
    public class ConsoleOutputSink : IOutputSink
    {
        public static IOutputSink Instance { get; } = new ConsoleOutputSink();
        
        public virtual void Write (string text)
        {
            WriteWithColors(text, ConsoleColor.White, ConsoleColor.Black);
        }

        public virtual IDisposable WriteBlock (string text)
        {
            Info(FigletTransform.GetText(text));

            return DelegateDisposable.CreateBracket(
                () => Console.Title = $"Executing: {text}",
                () => Console.Title = $"Finished: {text}");
        }

        public virtual void Trace (string text)
        {
            WriteWithColors(text, ConsoleColor.Gray, ConsoleColor.DarkGray);
        }

        public virtual void Info (string text)
        {
            WriteWithColors(text, ConsoleColor.White, ConsoleColor.Black);
        }

        public virtual void Warn (string text, string details = null)
        {
            WriteWithColors(text, ConsoleColor.Yellow, ConsoleColor.DarkYellow);
            if (details != null)
                WriteWithColors(details, ConsoleColor.Yellow, ConsoleColor.DarkYellow);
        }

        public virtual void Error (string text, string details = null)
        {
            WriteWithColors(text, ConsoleColor.Red, ConsoleColor.DarkRed);
            if (details != null)
                WriteWithColors(details, ConsoleColor.Red, ConsoleColor.DarkRed);
        }

        public virtual void WriteSummary (IReadOnlyCollection<TargetDefinition> executionList)
        {
            var firstColumn = Math.Max(executionList.Max(x => x.Name.Length) + 4, val2: 20);
            var secondColumn = 10;
            var thirdColumn = 10;
            var allColumns = firstColumn + secondColumn + thirdColumn;
            var totalDuration = executionList.Aggregate(TimeSpan.Zero, (t, x) => t.Add(x.Duration));

            string CreateLine (string target, string executionStatus, string duration)
                => target.PadRight(firstColumn, paddingChar: ' ')
                   + executionStatus.PadRight(secondColumn, paddingChar: ' ')
                   + duration.PadLeft(thirdColumn, paddingChar: ' ');

            string ToMinutesAndSeconds (TimeSpan duration)
                => $"{(int) duration.TotalMinutes}:{duration:ss}";

            Logger.Log();
            Logger.Log(new string(c: '=', count: allColumns));
            Logger.Log(CreateLine("Target", "Status", "Duration"));
            Logger.Log(new string(c: '-', count: allColumns));
            foreach (var target in executionList.TakeWhile(x => x.Status != ExecutionStatus.None))
                Logger.Log(CreateLine(target.Name, target.Status.ToString(), ToMinutesAndSeconds(target.Duration)));
            Logger.Log(new string(c: '-', count: allColumns));
            Logger.Log(CreateLine("Total", "", ToMinutesAndSeconds(totalDuration)));
            Logger.Log(new string(c: '=', count: allColumns));
            Logger.Log();
            Logger.Log($"Finished build on {DateTime.Now.ToString(CultureInfo.CurrentCulture)}.");
            Logger.Log();
        }

        private void WriteWithColors (string text, ConsoleColor brightForeground, ConsoleColor darkForeground)
        {
            var previousForeground = Console.ForegroundColor;
            var backgroundColor = Console.BackgroundColor;

            // TODO: can we determine the actual console background color?
            var hasDarkBackground = (int) backgroundColor == -1
                                    || backgroundColor == ConsoleColor.Black
                                    || backgroundColor.ToString().StartsWith("Dark");

            using (DelegateDisposable.CreateBracket(
                () => Console.ForegroundColor = hasDarkBackground ? brightForeground : darkForeground,
                () => Console.ForegroundColor = previousForeground))
            {
                Console.WriteLine(text);
            }
        }
    }
}
