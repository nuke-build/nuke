// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using Nuke.Common.Execution.Theming;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.TeamCity
{
    public partial class TeamCity
    {
        internal override IHostTheme Theme => AnsiConsoleHostTheme.Default256AnsiColorTheme;
        internal override string OutputTemplate => "[{Level:u3}] {Message:l}{NewLine}{Exception}";

        protected internal override IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () => OpenBlock(text),
                () => CloseBlock(text));
        }

        protected internal override void ReportWarning(string text, string details = null)
        {
            WriteWarning(text);
        }

        protected internal override void ReportError(string text, string details = null)
        {
            WriteError(text, details);
        }
    }
}
