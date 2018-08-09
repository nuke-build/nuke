// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.IO;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Utilities;
using static Nuke.Common.ChangeLog.ChangelogTasks;
using static Nuke.Common.ControlFlow;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.Tools.Git.GitTasks;

partial class Build
{
    Target Release => _ => _
        .Executes(() =>
        {
            if (!GitRepository.Branch.StartsWithOrdinalIgnoreCase("release"))
            {
                Assert(GitHasCleanWorkingCopy(), "GitHasCleanWorkingCopy()");
                Git($"checkout -b release/{GitVersion.MajorMinorPatch} {DevelopBranch}");
            }
            else
            {
                FinishReleaseOrHotfix();
            }
        });

    Target Hotfix => _ => _
        .Executes(() =>
        {
            if (!GitRepository.Branch.StartsWithOrdinalIgnoreCase("hotfix"))
            {
                Assert(GitHasCleanWorkingCopy(), "GitHasCleanWorkingCopy()");
                Git($"checkout -b hotfix/{GitVersion.Major}.{GitVersion.Minor}.{GitVersion.Patch + 1} {MasterBranch}");
            }
            else
            {
                FinishReleaseOrHotfix();
            }
        });

    void FinishReleaseOrHotfix()
    {
        FinalizeChangelog(ChangelogFile, GitVersion.MajorMinorPatch, GitRepository);
        Git($"add {ChangelogFile}");
        Git($"commit -m \"Finalize {Path.GetFileName(ChangelogFile)} for {GitVersion.MajorMinorPatch}\"");
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
