// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using Nuke.Common.Execution.Theming;
using Nuke.Common.Utilities;
using Serilog.Sinks.SystemConsole.Themes;

namespace Nuke.Common.CI.AzurePipelines
{
    public partial class AzurePipelines
    {
        internal override IHostTheme Theme => new AnsiConsoleHostTheme(
            "\u001B[32;1m",
            new Dictionary<ConsoleThemeStyle, string>
            {
                [ConsoleThemeStyle.Text] = string.Empty,
                [ConsoleThemeStyle.SecondaryText] = "\u001B[90m",
                [ConsoleThemeStyle.TertiaryText] = "\u001B[90m",
                [ConsoleThemeStyle.Name] = "\u001b[37;1m",
                [ConsoleThemeStyle.Invalid] = "\u001b[46;1m",
                [ConsoleThemeStyle.Null] = "\u001b[36;1m",
                [ConsoleThemeStyle.Number] = "\u001b[36;1m",
                [ConsoleThemeStyle.String] = "\u001b[36;1m",
                [ConsoleThemeStyle.Boolean] = "\u001b[36;1m",
                [ConsoleThemeStyle.Scalar] = "\u001b[36;1m",
                [ConsoleThemeStyle.LevelVerbose] = "\u001B[90;1m",
                [ConsoleThemeStyle.LevelDebug] = "\u001B[97;1m",
                [ConsoleThemeStyle.LevelInformation] = "\u001b[36;1m",
                [ConsoleThemeStyle.LevelWarning] = "\u001b[33;1m",
                [ConsoleThemeStyle.LevelError] = "\u001B[31;1m",
                [ConsoleThemeStyle.LevelFatal] = "\u001B[41;1m"
            });

        protected internal override IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () => Group(text),
                () => EndGroup(text));
        }

        protected internal override void ReportWarning(string text, string details = null)
        {
            LogIssue(AzurePipelinesIssueType.Warning, text);
        }

        protected internal override void ReportError(string text, string details = null)
        {
            LogIssue(AzurePipelinesIssueType.Error, text);
        }

        protected internal override bool FilterMessage(string message)
        {
            if (!message.ContainsOrdinalIgnoreCase("##vso["))
                return false;

            Console.WriteLine(message);
            return true;
        }
    }
}
