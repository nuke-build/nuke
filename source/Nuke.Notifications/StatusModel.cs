// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.Tools.Slack;

namespace Nuke.Notifications
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public class BuildStatusMessage
    {
        public Guid Cookie { get; set; }
        public UpdateReason UpdateReason { get; set; }
        public DateTime TimeCreated { get; set; }
        public BuildStatus Status { get; set; }
    }

    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public class BuildStatus
    {
        public DateTime Started { get; set; }
        public string Host { get; set; }
        public string HostInformation { get; set; }
        public string Repository { get; set; }
        public string Branch { get; set; }
        public string Version { get; set; }
        public string IconUrl { get; set; }
        public IReadOnlyCollection<Commit> Commits { get; set; }
        public List<TargetStatus> Targets { get; set; }
        public string ErrorMessage { get; set; }
        public int? ExitCode { get; set; }
        public bool IsFinished { get; set; }
        public bool IsSuccessful { get; set; }
        public string OperatingSystem { get; set; }
        public List<BuildAction> Actions { get; set; }
        public List<SlackMessageAttachment> SlackAttachments { get; set; }
        public int Partition { get; set; }
    }

    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public class TargetStatus
    {
        public TimeSpan Duration { get; set; }
        public ExecutionStatus Status { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Data { get; set; }
        public int? PartitionsSize { get; set; }
    }

    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public class Commit
    {
        public string Sha { get; set; }
        public string Message { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
    }

    public enum UpdateReason
    {
        BuildCreated,
        TargetStarted,
        TargetUpdated,
        BuildFinished
    }

    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public class BuildAction
    {
        public string Id { get; set; }
        public BuildActionType Type { get; set; }
        public BuildActionStyle Style { get; set; }
        public string Caption { get; set; }
        public BuildActionConfirmation Confirmation { get; set; }
        public string Data { get; set; }
    }

    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public class BuildActionConfirmation
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string ConfirmText { get; set; }
        public string DismissText { get; set; }
    }

    public enum BuildActionType
    {
        Link,
        Local,
        Remote
    }

    public enum BuildActionStyle
    {
        Normal,
        Primary,
        Danger
    }
}
