// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Tooling;

namespace Nuke.Common.CI.GitHubActions.Configuration;

public enum GitHubActionsIssueCommentType
{
    [EnumValue("created")] Created,
    [EnumValue("edited")] Edited,
    [EnumValue("deleted")] Deleted
}
