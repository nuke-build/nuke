// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.GitHub;
using Nuke.Common.Tools.GitVersion;
using static Nuke.Common.ChangeLog.ChangelogTasks;
using static Nuke.Common.ControlFlow;
using static Nuke.Common.Tools.Git.GitTasks;
using static Nuke.Common.Tools.GitVersion.GitVersionTasks;

partial class Build
{
    [Parameter] readonly bool AutoStash = true;

    Target Milestone => _ => _
        .Unlisted()
        .OnlyWhenStatic(() => GitRepository.IsOnReleaseBranch() || GitRepository.IsOnHotfixBranch())
        .Executes(async () =>
        {
            var milestoneTitle = $"v{GitVersion.MajorMinorPatch}";
            var milestone = (await GitRepository.GetGitHubMilestone(milestoneTitle)).NotNull("milestone != null");
            Assert(milestone.OpenIssues == 0, "milestone.OpenIssues == 0");
            Assert(milestone.ClosedIssues != 0, "milestone.ClosedIssues != 0");
        });

    Target Changelog => _ => _
        .Unlisted()
        .DependsOn(Milestone)
        .OnlyWhenStatic(() => GitRepository.IsOnReleaseBranch() || GitRepository.IsOnHotfixBranch())
        .Executes(() =>
        {
            FinalizeChangelog(ChangelogFile, GitVersion.MajorMinorPatch, GitRepository);
            Git($"add {ChangelogFile}");
            Git($"commit -m \"Finalize {Path.GetFileName(ChangelogFile)} for {GitVersion.MajorMinorPatch}\"");
        });

    [UsedImplicitly]
    Target Release => _ => _
        .DependsOn(Changelog)
        .Requires(() => !GitRepository.IsOnReleaseBranch() || GitHasCleanWorkingCopy())
        .Executes(() =>
        {
            if (!GitRepository.IsOnReleaseBranch())
                Checkout($"{ReleaseBranchPrefix}/{GitVersion.MajorMinorPatch}", start: DevelopBranch);
            else
                FinishReleaseOrHotfix();
        });

    [UsedImplicitly]
    Target Hotfix => _ => _
        .DependsOn(Changelog)
        .Requires(() => !GitRepository.IsOnHotfixBranch() || GitHasCleanWorkingCopy())
        .Executes(() =>
        {
            var masterVersion = GitVersion(s => s
                .SetFramework("netcoreapp3.0")
                .SetUrl(RootDirectory)
                .SetBranch(MasterBranch)
                .EnableNoFetch()
                .DisableLogOutput()).Result;

            if (!GitRepository.IsOnHotfixBranch())
                Checkout($"{HotfixBranchPrefix}/{masterVersion.Major}.{masterVersion.Minor}.{masterVersion.Patch + 1}", start: MasterBranch);
            else
                FinishReleaseOrHotfix();
        });

    void FinishReleaseOrHotfix()
    {
        Git($"checkout {MasterBranch}");
        Git($"merge --no-ff --no-edit {GitRepository.Branch}");
        Git($"tag {GitVersion.MajorMinorPatch}");

        Git($"checkout {DevelopBranch}");
        Git($"merge --no-ff --no-edit {GitRepository.Branch}");

        Git($"branch -D {GitRepository.Branch}");

        Git($"push origin {MasterBranch} {DevelopBranch} {GitVersion.MajorMinorPatch}");
    }

    void Checkout(string branch, string start)
    {
        var hasCleanWorkingCopy = GitHasCleanWorkingCopy();

        if (!hasCleanWorkingCopy && AutoStash)
            Git("stash");

        Git($"checkout -b {branch} {start}");

        if (!hasCleanWorkingCopy && AutoStash)
            Git("stash apply");
    }
}
