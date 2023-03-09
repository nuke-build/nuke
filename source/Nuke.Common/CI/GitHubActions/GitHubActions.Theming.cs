// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using Nuke.Common.Execution.Theming;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.GitHubActions
{
    public partial class GitHubActions
    {
        internal override IHostTheme Theme => AnsiConsoleHostTheme.Default256AnsiColorTheme;

        protected internal override IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () => Group(text),
                () => EndGroup(text));
        }

        protected internal override void ReportWarning(string text, string details = null)
        {
            WriteWarning(text);
        }

        protected internal override void ReportError(string text, string details = null)
        {
            WriteError(text);
        }

        protected internal override bool FilterMessage(string message)
        {
            if (!message.StartsWith("::") && !message.StartsWith("##["))
                return false;

            Console.WriteLine(message);
            return true;
        }
    }
}
