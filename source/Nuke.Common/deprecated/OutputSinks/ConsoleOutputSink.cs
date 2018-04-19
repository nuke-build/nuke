#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Nuke.Core.Execution;
using Nuke.Core.Utilities;

namespace Nuke.Core.OutputSinks
{
    [UsedImplicitly]
    internal class ConsoleOutputSink : IOutputSink
    {
        public virtual void Write(string text)
        {
            WriteWithColors(text, ConsoleColor.White);
        }

        public virtual IDisposable WriteBlock(string text)
        {
            Info(FigletTransform.GetText(text));

            return DelegateDisposable.CreateBracket(
                () => Console.Title = $"Executing: {text}",
                () => Console.Title = $"Finished: {text}");
        }

        public virtual void Trace(string text)
        {
            WriteWithColors(text, ConsoleColor.DarkGray);
        }

        public virtual void Info(string text)
        {
            WriteWithColors(text, ConsoleColor.White);
        }

        public virtual void Warn(string text, string details = null)
        {
            WriteWithColors(text, ConsoleColor.DarkYellow);
            if (details != null)
                WriteWithColors(details, ConsoleColor.DarkYellow);
        }

        public virtual void Error(string text, string details = null)
        {
            WriteWithColors(text, ConsoleColor.DarkRed);
            if (details != null)
                WriteWithColors(details, ConsoleColor.DarkRed);
        }

        public virtual void WriteSummary(IReadOnlyCollection<TargetDefinition> executionList)
        {
            var firstColumn = Math.Max(executionList.Max(x => x.Name.Length) + 4, val2: 20);
            var secondColumn = 10;
            var thirdColumn = 10;
            var allColumns = firstColumn + secondColumn + thirdColumn;
            var totalDuration = executionList.Aggregate(TimeSpan.Zero, (t, x) => t.Add(x.Duration));

            string CreateLine(string target, string executionStatus, string duration)
                => target.PadRight(firstColumn, paddingChar: ' ')
                   + executionStatus.PadRight(secondColumn, paddingChar: ' ')
                   + duration.PadLeft(thirdColumn, paddingChar: ' ');

            string ToMinutesAndSeconds(TimeSpan duration)
                => $"{(int) duration.TotalMinutes}:{duration:ss}";

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

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void WriteWithColors(string text, ConsoleColor foregroundColor)
        {
            var previousForegroundColor = Console.ForegroundColor;

            using (DelegateDisposable.CreateBracket(
                () => Console.ForegroundColor = foregroundColor,
                () => Console.ForegroundColor = previousForegroundColor))
            {
                Console.WriteLine(text);
            }
        }
    }
}
