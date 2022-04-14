// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Execution.Theming;
using Nuke.Common.Utilities;

namespace Nuke.Common
{
    public partial class Host
    {
        private const string SevereMessagesOutputTemplate = "[{Level:u3}] {ExecutingTarget}: {Message:l}{NewLine}";

        internal static IHostTheme DefaultTheme { get; } =
            Environment.GetEnvironmentVariable("TERM") is { } term && term.StartsWithOrdinalIgnoreCase("xterm")
                ? AnsiConsoleHostTheme.Default256AnsiColorTheme
                : SystemConsoleHostTheme.DefaultSystemColorTheme;

        internal static string DefaultOutputTemplate => "{Timestamp:HH:mm:ss} [{Level:u3}] {Message:l}{NewLine}{Exception}";

        internal static void Success(string text = null)
        {
            (Instance?.Theme ?? DefaultTheme).WriteSuccess(text);
        }

        internal static void Verbose(string text = null)
        {
            (Instance?.Theme ?? DefaultTheme).WriteVerbose(text);
        }

        internal static void Debug(string text = null)
        {
            (Instance?.Theme ?? DefaultTheme).WriteDebug(text);
        }

        internal static void Information(string text = null)
        {
            (Instance?.Theme ?? DefaultTheme).WriteInformation(text);
        }

        internal static void Warning(string text = null)
        {
            (Instance?.Theme ?? DefaultTheme).WriteWarning(text);
        }

        internal static void Error(string text = null)
        {
            (Instance?.Theme ?? DefaultTheme).WriteError(text);
        }
    }
}
