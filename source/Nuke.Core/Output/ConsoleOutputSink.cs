// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Colorful;
using Nuke.Core.Execution;
using Nuke.Core.Utilities;

namespace Nuke.Core.Output
{
    public class ConsoleOutputSink : IOutputSink
    {
        public static IOutputSink Instance { get; } = new ConsoleOutputSink();

        private Figlet _figlet;

        protected ConsoleOutputSink ()
        {
            SetFont("Nuke.Core.Output.Fonts.cybermedium.flf");
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

        public virtual void Fail (string text, string details = null)
        {
            WriteWithColors(text, ConsoleColor.Red, ConsoleColor.DarkRed);
            if (details != null)
                WriteWithColors(details, ConsoleColor.Red, ConsoleColor.DarkRed);
        }

        public virtual IDisposable WriteBlock (string text)
        {
            Info(GetAscii(text));

            return DelegateDisposable.CreateBracket(
                () => System.Console.Title = $"Executing: {text}",
                () => System.Console.Title = $"Finished: {text}");
        }

        public virtual void WriteSummary (IReadOnlyCollection<TargetDefinition> executionList)
        {
            var longestName = executionList.Select(x => x.Name.Length).OrderByDescending(x => x).First();
            var firstColumn = Math.Max(longestName + 4, val2: 20);
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

            OutputSink.Info(string.Empty);
            OutputSink.Info(new string(c: '=', count: allColumns));
            OutputSink.Info(CreateLine("Target", "Status", "Duration"));
            OutputSink.Info(new string(c: '-', count: allColumns));
            foreach (var target in executionList.TakeWhile(x => x.Status != ExecutionStatus.None))
                OutputSink.Info(CreateLine(target.Name, target.Status.ToString(), ToMinutesAndSeconds(target.Duration)));
            OutputSink.Info(new string(c: '-', count: allColumns));
            OutputSink.Info(CreateLine("Total", "", ToMinutesAndSeconds(totalDuration)));
            OutputSink.Info(new string(c: '=', count: allColumns));
            OutputSink.Info(string.Empty);
            OutputSink.Info($"Finished build on {DateTime.Now.ToString(CultureInfo.InvariantCulture)}.");
            OutputSink.Info(string.Empty);
        }

        private void WriteWithColors (string text, ConsoleColor brightForeground, ConsoleColor darkForeground)
        {
            var previousForeground = System.Console.ForegroundColor;
            var backgroundColor = System.Console.BackgroundColor;

            var hasDarkBackground = backgroundColor == ConsoleColor.Black || backgroundColor.ToString().StartsWith("Dark");

            using (DelegateDisposable.CreateBracket(
                () => System.Console.ForegroundColor = hasDarkBackground ? brightForeground : darkForeground,
                () => System.Console.ForegroundColor = previousForeground))
            {
                System.Console.WriteLine(text);
            }
        }

        protected void SetFont (string resourceName)
        {
            var assembly = GetType().GetTypeInfo().Assembly;
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            _figlet = new Figlet(FigletFont.Load(resourceStream));
        }

        protected string GetAscii (string text)
        {
            var textWithFont = _figlet.ToAscii(text).ToString();
            return string.Join(
                EnvironmentInfo.NewLine,
                textWithFont.Split(new[] { EnvironmentInfo.NewLine }, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
