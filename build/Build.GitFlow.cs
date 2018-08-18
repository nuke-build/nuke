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
        .Requires(() => GitRepository.Branch.StartsWith("release") ||
                        GitRepository.Branch.StartsWith("hotfix"))
        .Executes(() =>
        {
            FinalizeChangelog(ChangelogFile, GitVersion.MajorMinorPatch, GitRepository);
            Git($"add {ChangelogFile}");
            Git($"commit -m \"Finalize {Path.GetFileName(ChangelogFile)} for {GitVersion.MajorMinorPatch}\"");
        });
    
    Target Release => _ => _
        .DependsOn(Changelog)
        .Executes(() =>
        {
            if (!GitRepository.Branch.StartsWithOrdinalIgnoreCase(ReleaseBranchPrefix))
            {
                Assert(GitHasCleanWorkingCopy(), "GitHasCleanWorkingCopy()");
                Git($"checkout -b {ReleaseBranchPrefix}/{GitVersion.MajorMinorPatch} {DevelopBranch}");
            }
            else
            {
                FinishReleaseOrHotfix();
            }
        });

    Target Hotfix => _ => _
        .Executes(() =>
        {
            if (!GitRepository.Branch.StartsWithOrdinalIgnoreCase(HotfixBranchPrefix))
            {
                Assert(GitHasCleanWorkingCopy(), "GitHasCleanWorkingCopy()");
                
                var masterVersion = GitVersion(s => s
                    .SetUrl(RootDirectory)
                    .SetBranch(MasterBranch)
                    .DisableLogOutput()).Result;
                Git($"checkout -b {HotfixBranchPrefix}/{masterVersion.Major}.{masterVersion.Minor}.{masterVersion.Patch + 1} {MasterBranch}");
            }
            else
            {
                FinishReleaseOrHotfix();
            }
        });

    void FinishReleaseOrHotfix()
    {
        Assert(GitHasCleanWorkingCopy(), "GitHasCleanWorkingCopy()");

        Git($"checkout {MasterBranch}");
        Git($"merge --no-ff --no-edit {GitRepository.Branch}");
        Git($"tag {GitVersion.MajorMinorPatch}");
        
        Git($"checkout {DevelopBranch}");
        Git($"merge --no-ff --no-edit {GitRepository.Branch}");
        
        Git($"branch -D {GitRepository.Branch}");

        Git($"push origin {MasterBranch} {DevelopBranch} {GitVersion.MajorMinorPatch}");
    }
}
