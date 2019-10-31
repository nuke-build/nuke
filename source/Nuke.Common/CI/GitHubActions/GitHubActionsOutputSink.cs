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
            : base(
                traceCode: "90",
                informationCode: "36;1",
                warningCode: "33;1",
                errorCode: "31;1",
                successCode: "32;1")
        {
            _githubActions = githubActions;
        }

        public override IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () => _githubActions.Group(text),
                () => _githubActions.EndGroup(text));
        }

        public override void WriteError(string text, string details = null)
        {
            _githubActions.WriteError(text);
            if (details != null)
                _githubActions.WriteError(details);
        }

        public override void WriteWarning(string text, string details = null)
        {
            _githubActions.WriteWarning(text);
            if (details != null)
                _githubActions.WriteWarning(details);
        }

        public override void WriteTrace(string text)
        {
            _githubActions.WriteDebug(text);
        }
    }
}
