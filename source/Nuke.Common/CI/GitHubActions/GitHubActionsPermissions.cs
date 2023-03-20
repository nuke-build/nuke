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
    public enum GitHubActionsPermissions
    {
        [EnumValue("actions")] Actions,
        [EnumValue("checks")] Checks,
        [EnumValue("contents")] Contents,
        [EnumValue("deployments")] Deployments,
        [EnumValue("id-token")] IdToken,
        [EnumValue("issues")] Issues,
        [EnumValue("discussions")] Discussions,
        [EnumValue("packages")] Packages,
        [EnumValue("pages")] Pages,
        [EnumValue("pull-requests")] PullRequests,
        [EnumValue("repository-projects")] RepositoryProjects,
        [EnumValue("security-events")] SecurityEvents,
        [EnumValue("statuses")] Statuses,
    }
}
