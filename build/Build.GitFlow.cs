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
            Assert(GitHasCleanWorkingCopy(), "GitHasCleanWorkingCopy()");

            if (!GitRepository.Branch.StartsWithOrdinalIgnoreCase("release"))
                Git($"checkout -b release/{GitVersion.MajorMinorPatch} {DevelopBranch}");
            else
                ReleaseFrom($"release/{GitVersion.MajorMinorPatch}");
        });

    Target Hotfix => _ => _
        .Executes(() =>
        {
            Assert(GitHasCleanWorkingCopy(), "GitHasCleanWorkingCopy()");

            if (!GitRepository.Branch.StartsWithOrdinalIgnoreCase("hotfix"))
            {
                Assert(CommandLineArguments.Length == 3, "CommandLineArguments.Length == 3");
                Git($"checkout -b hotfix/{CommandLineArguments.ElementAt(index: 2)} {MasterBranch}");
            }
            else
            {
                ReleaseFrom(GitRepository.Branch);
            }
        });

    void ReleaseFrom(string branch)
    {
        Assert(GitHasCleanWorkingCopy(), "GitHasCleanWorkingCopy()");

        Git($"checkout {DevelopBranch}");
        Git($"merge --no-ff --no-edit {branch}");
        Git($"checkout {MasterBranch}");
        Git($"merge --no-ff --no-edit {branch}");
        Git($"tag {GitVersion.MajorMinorPatch}");
        Git($"branch -D {branch}");

        Git($"push origin {MasterBranch} {DevelopBranch} {GitVersion.MajorMinorPatch}");
    }
}
