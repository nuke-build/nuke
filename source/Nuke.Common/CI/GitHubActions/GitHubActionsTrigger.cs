// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.CI.GitHubActions
{
    [PublicAPI]
    public enum GitHubActionsTrigger
    {
        Push,
        PullRequest
    }

    public static class GitHubActionsTriggerExtensions
    {
        public static string ConvertToString(this GitHubActionsTrigger trigger)
        {
            return trigger switch
            {
                GitHubActionsTrigger.Push => "push",
                GitHubActionsTrigger.PullRequest => "pull_request",
                _ => throw new ArgumentOutOfRangeException(nameof(trigger), trigger, message: null)
            };
        }
    }
}
