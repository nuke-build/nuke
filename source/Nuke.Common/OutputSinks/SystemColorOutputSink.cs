// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.OutputSinks
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    internal class SystemColorOutputSink : OutputSink
    {
        internal override void WriteNormal(string text)
        {
            Console.WriteLine(text);
        }

        internal override void WriteSuccess(string text)
        {
            WriteWithColors(text, ConsoleColor.Green);
        }

        internal override void WriteTrace(string text)
        {
            WriteWithColors(text, ConsoleColor.Gray);
        }

        internal override void WriteInformation(string text)
        {
            WriteWithColors(text, ConsoleColor.Cyan);
        }

        protected override void WriteWarning(string text, string details = null)
        {
            WriteWithColors(text, ConsoleColor.Yellow);
            if (details != null)
                WriteWithColors(details, ConsoleColor.Yellow);
        }

        protected override void WriteError(string text, string details = null)
        {
            WriteWithColors(text, ConsoleColor.Red);
            if (details != null)
                WriteWithColors(details, ConsoleColor.Red);
        }

        internal override void IssueWarning(string message, string filePath = null, int? line = null, int? column = null, string code = null)
        {
            WriteWarning(GetIssueDetailString("warning", filePath, line, column, code) + message);
        }

        internal override void IssueError(string message, string filePath = null, int? line = null, int? column = null, string code = null)
        {
            WriteError(GetIssueDetailString("error", filePath, line, column, code) + message);
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
