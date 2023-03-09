// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using Nuke.Common.Execution.Theming;
using Serilog.Sinks.SystemConsole.Themes;

namespace Nuke.Common.CI.AppVeyor
{
    public partial class AppVeyor
    {
        internal override IHostTheme Theme => new AnsiConsoleHostTheme(
            "\u001B[92;1m",
            new Dictionary<ConsoleThemeStyle, string>
            {
                [ConsoleThemeStyle.Text] = string.Empty,
                [ConsoleThemeStyle.SecondaryText] = "\u001B[37;2m",
                [ConsoleThemeStyle.TertiaryText] = "\u001B[37;2m",
                [ConsoleThemeStyle.Name] = "\u001b[37;1m",
                [ConsoleThemeStyle.Invalid] = "\u001b[46;1m",
                [ConsoleThemeStyle.Null] = "\u001b[36;1m",
                [ConsoleThemeStyle.Number] = "\u001b[36;1m",
                [ConsoleThemeStyle.String] = "\u001b[36;1m",
                [ConsoleThemeStyle.Boolean] = "\u001b[36;1m",
                [ConsoleThemeStyle.Scalar] = "\u001b[36;1m",
                [ConsoleThemeStyle.LevelVerbose] = "\u001B[37;2m",
                [ConsoleThemeStyle.LevelDebug] = "\u001B[98;1m",
                [ConsoleThemeStyle.LevelInformation] = "\u001b[36;1m",
                [ConsoleThemeStyle.LevelWarning] = "\u001b[33;1m",
                [ConsoleThemeStyle.LevelError] = "\u001B[31;1m",
                [ConsoleThemeStyle.LevelFatal] = "\u001B[41;1m"
            });

        protected internal override void ReportWarning(string text, string details = null)
        {
            WriteWarning(text, details);
        }

        protected internal override void ReportError(string text, string details = null)
        {
            WriteError(text, details);
        }
    }
}
