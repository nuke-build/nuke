// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Nuke.Common.OutputSinks;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.GitLab
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    internal class GitLabOutputSink : AnsiColorOutputSink
    {
        private readonly GitLab _gitlab;

        internal GitLabOutputSink(GitLab gitlab)
        {
            _gitlab = gitlab;
        }

        protected override string TraceCode => "90";
        protected override string InformationCode => "36";
        protected override string WarningCode => "33";
        protected override string ErrorCode => "31";
        protected override string SuccessCode => "32";

        internal override IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () => _gitlab.Section(text),
                () => _gitlab.EndGroup(text));
        }
    }
}
