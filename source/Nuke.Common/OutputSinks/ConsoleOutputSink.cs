// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.OutputSinks
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    internal class ConsoleOutputSink : IOutputSink
    {
        public virtual void Write(string text)
        {
            WriteWithColors(text, Console.ForegroundColor);
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
            WriteWithColors(text, ConsoleColor.Gray);
        }

        public virtual void Info(string text)
        {
            WriteWithColors(text, Console.ForegroundColor);
        }

        public virtual void Warn(string text, string details = null)
        {
            WriteWithColors(text, ConsoleColor.Yellow);
            if (details != null)
                WriteWithColors(details, ConsoleColor.Yellow);
        }

        public virtual void Error(string text, string details = null)
        {
            WriteWithColors(text, ConsoleColor.Red);
            if (details != null)
                WriteWithColors(details, ConsoleColor.Red);
        }

        public virtual void Success(string text)
        {
            WriteWithColors(text, ConsoleColor.Green);
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
