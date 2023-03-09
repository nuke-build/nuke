// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using Nuke.Common.Utilities;
using Serilog.Sinks.SystemConsole.Themes;

namespace Nuke.Common.Execution.Theming
{
    public class SystemConsoleHostTheme : SystemConsoleTheme, IHostTheme
    {
        public static IHostTheme DefaultSystemColorTheme => new SystemConsoleHostTheme(
            new SystemConsoleThemeStyle { Foreground = ConsoleColor.Green },
            new Dictionary<ConsoleThemeStyle, SystemConsoleThemeStyle>
            {
                [ConsoleThemeStyle.Text] = new(),
                [ConsoleThemeStyle.SecondaryText] = new() { Foreground = ConsoleColor.Gray },
                [ConsoleThemeStyle.TertiaryText] = new() { Foreground = ConsoleColor.Gray },
                [ConsoleThemeStyle.Name] = new() { Foreground = ConsoleColor.Blue },
                [ConsoleThemeStyle.Invalid] = new() { Foreground = ConsoleColor.DarkRed },
                [ConsoleThemeStyle.Null] = new() { Foreground = ConsoleColor.Magenta },
                [ConsoleThemeStyle.String] = new() { Foreground = ConsoleColor.Magenta },
                [ConsoleThemeStyle.Number] = new() { Foreground = ConsoleColor.Magenta },
                [ConsoleThemeStyle.Boolean] = new() { Foreground = ConsoleColor.Magenta },
                [ConsoleThemeStyle.Scalar] = new() { Foreground = ConsoleColor.Magenta },
                [ConsoleThemeStyle.LevelVerbose] = new() { Foreground = ConsoleColor.Gray },
                [ConsoleThemeStyle.LevelDebug] = new(),
                [ConsoleThemeStyle.LevelInformation] = new() { Foreground = ConsoleColor.Cyan },
                [ConsoleThemeStyle.LevelWarning] = new() { Foreground = ConsoleColor.Yellow },
                [ConsoleThemeStyle.LevelError] = new() { Foreground = ConsoleColor.Red },
                [ConsoleThemeStyle.LevelFatal] = new() { Foreground = ConsoleColor.White, Background = ConsoleColor.Red }
            });

        private readonly SystemConsoleThemeStyle _successStyle;
        private readonly IReadOnlyDictionary<ConsoleThemeStyle, SystemConsoleThemeStyle> _styles;

        public SystemConsoleHostTheme(
            SystemConsoleThemeStyle successStyle,
            IReadOnlyDictionary<ConsoleThemeStyle, SystemConsoleThemeStyle> styles)
            : base(styles)
        {
            _successStyle = successStyle;
            _styles = styles;
        }

        public void WriteSuccess(string text)
        {
            Write(text, _successStyle);
        }

        public void WriteVerbose(string text = null)
        {
            Write(text, _styles[ConsoleThemeStyle.LevelVerbose]);
        }

        public void WriteDebug(string text)
        {
            Write(text, _styles[ConsoleThemeStyle.LevelDebug]);
        }

        public void WriteInformation(string text)
        {
            Write(text, _styles[ConsoleThemeStyle.LevelInformation]);
        }

        public void WriteWarning(string text)
        {
            Write(text, _styles[ConsoleThemeStyle.LevelWarning]);
        }

        public void WriteError(string text)
        {
            Write(text, _styles[ConsoleThemeStyle.LevelError]);
        }

        string IHostTheme.FormatSuccess(string text)
        {
            return text;
        }

        string IHostTheme.FormatVerbose(string text)
        {
            return text;
        }

        string IHostTheme.FormatDebug(string text)
        {
            return text;
        }

        string IHostTheme.FormatInformation(string text)
        {
            return text;
        }

        string IHostTheme.FormatWarning(string text)
        {
            return text;
        }

        string IHostTheme.FormatError(string text)
        {
            return text;
        }

        private void Write(string text, SystemConsoleThemeStyle style)
        {
            using (DelegateDisposable.SetAndRestore(() => Console.ForegroundColor, style.Foreground))
            using (DelegateDisposable.SetAndRestore(() => Console.BackgroundColor, style.Background))
            {
                Console.WriteLine(!text.IsNullOrWhiteSpace() ? text : "​");
            }
        }
    }
}
