// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.CI.GitHubActions
{
    public static class GitHubSubmodules
    {
        public const string No = "false";
        public const string Yes = "true";
        public const string Recursive = "recursive";
    }
}
