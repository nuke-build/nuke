// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.CI.GitHubActions
{
    [PublicAPI]
    public enum GitHubActionsOn
    {
        Push,
        PullRequest
    }

    public static class GitHubActionsOnExtensions
    {
        public static string ConvertToString(this GitHubActionsOn githubActionsOn)
        {
            return githubActionsOn == GitHubActionsOn.Push
                ? "push:"
                : "pull_request:";
        }
    }
}
