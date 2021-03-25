// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
        protected override string InformationCode => "36;1";
        protected override string WarningCode => "33;1";
        protected override string ErrorCode => "31;1";
        protected override string SuccessCode => "32;1";

        public override IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () => _gitlab.BeginSection(text),
                () => _gitlab.EndSection(text));
        }
    }
}
