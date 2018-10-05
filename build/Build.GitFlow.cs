// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.IO;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities;
using static Nuke.Common.ChangeLog.ChangelogTasks;
using static Nuke.Common.ControlFlow;
using static Nuke.Common.Tools.Git.GitTasks;
using static Nuke.Common.Tools.GitVersion.GitVersionTasks;

partial class Build
{
    Target Changelog => _ => _
        .OnlyWhen(() => GitRepository.Branch.NotNull().StartsWith("release") ||
                        GitRepository.Branch.StartsWith("hotfix"))
        .Executes(() =>
        {
            FinalizeChangelog(ChangelogFile, GitVersion.MajorMinorPatch, GitRepository);
            Git($"add {ChangelogFile}");
            Git($"commit -m \"Finalize {Path.GetFileName(ChangelogFile)} for {GitVersion.MajorMinorPatch}\"");
        });
    
    Target Release => _ => _
        .DependsOn(Changelog)
        .Requires(() => GitHasCleanWorkingCopy())
        .Executes(() =>
        {
            if (!GitRepository.Branch.StartsWithOrdinalIgnoreCase(ReleaseBranchPrefix))
                Git($"checkout -b {ReleaseBranchPrefix}/{GitVersion.MajorMinorPatch} {DevelopBranch}");
            else
                FinishReleaseOrHotfix();
        });

    Target Hotfix => _ => _
        .DependsOn(Changelog)
        .Requires(() => GitHasCleanWorkingCopy())
        .Executes(() =>
        {
            var masterVersion = GitVersion(s => s
                .SetUrl(RootDirectory)
                .SetBranch(MasterBranch)
                .EnableNoCache()
                .DisableLogOutput()).Result;

            if (!GitRepository.Branch.StartsWithOrdinalIgnoreCase(HotfixBranchPrefix))
                Git($"checkout -b {HotfixBranchPrefix}/{masterVersion.Major}.{masterVersion.Minor}.{masterVersion.Patch + 1} {MasterBranch}");
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
}
