// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.CI.GitHubActions
{
    [PublicAPI]
    public enum GitHubActionsTrigger
    {
        [EnumValue("push")] Push,
        [EnumValue("pull_request")] PullRequest,
        [EnumValue("workflow_dispatch")] WorkflowDispatch
    }
}
