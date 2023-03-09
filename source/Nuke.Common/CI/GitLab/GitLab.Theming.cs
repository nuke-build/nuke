// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using Nuke.Common.Execution.Theming;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.GitLab
{
    public partial class GitLab
    {
        internal override IHostTheme Theme => AnsiConsoleHostTheme.Default256AnsiColorTheme;

        protected internal override IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () => BeginSection(text),
                () => EndSection(text));
        }
    }
}
