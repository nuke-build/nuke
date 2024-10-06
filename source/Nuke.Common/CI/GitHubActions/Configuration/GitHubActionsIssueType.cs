// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Tooling;

namespace Nuke.Common.CI.GitHubActions.Configuration;

public enum GitHubActionsIssueType
{
    [EnumValue("opened")]
    Opened,
    
    [EnumValue("edited")]
    Edited,
    
    [EnumValue("deleted")]
    Deleted,
    
    [EnumValue("transferred")]
    Transferred,
    
    [EnumValue("pinned")]
    Pinned,
    
    [EnumValue("unpinned")]
    Unpinned,
    
    [EnumValue("closed")]
    Closed,
    
    [EnumValue("reopened")]
    Reopened,
    
    [EnumValue("assigned")]
    Assigned,
    
    [EnumValue("unassigned")]
    Unassigned,
    
    [EnumValue("labeled")]
    Labeled,
    
    [EnumValue("unlabeled")]
    Unlabeled,
    
    [EnumValue("locked")]
    Locked,
    
    [EnumValue("unlocked")]
    Unlocked,
    
    [EnumValue("milestoned")]
    Milestoned,
    
    [EnumValue("demilestoned")]
    Demilestoned
}
