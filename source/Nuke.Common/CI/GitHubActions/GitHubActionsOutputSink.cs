// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.OutputSinks;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.GitHubActions
{
    internal class GitHubActionsOutputSink : AnsiColorOutputSink
    {
        private readonly GitHubActions _githubActions;

        public GitHubActionsOutputSink(GitHubActions githubActions)
        {
            _githubActions = githubActions;
        }

        protected override string TraceCode => "90";
        protected override string InformationCode => "36;1";
        protected override string WarningCode => "33;1";
        protected override string ErrorCode => "31;1";
        protected override string SuccessCode => "32;1";

        internal override IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () => _githubActions.Group(text),
                () => _githubActions.EndGroup(text));
        }

        protected override bool EnableWriteWarnings => false;
        protected override bool EnableWriteErrors => false;

        protected override void ReportWarning(string text, string details = null)
        {
            _githubActions.WriteWarning(text);
            if (details != null)
                base.WriteWarning(details);
        }

        protected override void ReportError(string text, string details = null)
        {
            _githubActions.WriteError(text);
            if (details != null)
                base.WriteError(details);
        }

        internal override void IssueWarning(string message, string filePath = null, int? line = null, int? column = null, string code = null)
        {
            _githubActions.LogWarning(message, filePath, line, column);
        }

        internal override void IssueError(string message, string filePath = null, int? line = null, int? column = null, string code = null)
        {
            _githubActions.LogError(message, filePath, line, column);
        }
    }
}
