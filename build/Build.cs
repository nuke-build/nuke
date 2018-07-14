// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Nuke.Common.Git;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.InspectCode;
using Nuke.Common.Tools.OpenCover;
using Nuke.Common.Tools.Xunit;
using Nuke.Common;
using Nuke.Common.Tools.ReportGenerator;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.ChangeLog.ChangelogTasks;
using static Nuke.Common.ControlFlow;
using static Nuke.Common.Gitter.GitterTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.Git.GitTasks;
using static Nuke.Common.Tools.InspectCode.InspectCodeTasks;
using static Nuke.Common.Tools.OpenCover.OpenCoverTasks;
using static Nuke.Common.Tools.Xunit.XunitTasks;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.Tools.ReportGenerator.ReportGeneratorTasks;

partial class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Pack);

    [Parameter("Indicates to push to nuget.org feed.")] readonly bool NuGet;
    [Parameter("ApiKey for the specified source.")] readonly string ApiKey;
    [Parameter("Gitter authentication token.")] readonly string GitterAuthToken;
    [Parameter("Amount of changes to announce in Gitter.")] readonly int? AnnounceChanges;
    [Parameter("Install global tool.")] readonly bool InstallGlobalTool;

    string Source => NuGet
        ? "https://api.nuget.org/v3/index.json"
        : "https://www.myget.org/F/nukebuild/api/v2/package";

    string SymbolSource => NuGet
        ? "https://nuget.smbsrc.net/"
        : "https://www.myget.org/F/nukebuild/symbols/api/v2/package";

    [GitVersion] readonly GitVersion GitVersion;
    [GitRepository] readonly GitRepository GitRepository;
    [Solution] readonly Solution Solution;
    
    readonly string MasterBranch = "master";
    readonly string DevelopBranch = "develop";
    
    Target Clean => _ => _
        .Executes(() =>
        {
            DeleteDirectories(GlobDirectories(SourceDirectory, "*/bin", "*/obj"));
            EnsureCleanDirectory(OutputDirectory);
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetRestore(s => DefaultDotNetRestore);
        });

    Project GlobalToolProject => Solution.GetProject("Nuke.GlobalTool").NotNull();
    Project CodeGenerationProject => Solution.GetProject("Nuke.CodeGeneration").NotNull();

    Target Compile => _ => _
        .DependsOn(Restore)
        .Requires(() => IsUnix || GitVersion != null)
        .Executes(() =>
        {
            DotNetBuild(s => DefaultDotNetBuild);

            DotNetPublish(s => DefaultDotNetPublish
                .SetProject(GlobalToolProject));

            DotNetPublish(s => DefaultDotNetPublish
                .SetProject(CodeGenerationProject)
                .SetFramework("netstandard2.0"));
            DotNetPublish(s => DefaultDotNetPublish
                .SetProject(CodeGenerationProject)
                .SetFramework("net461"));
        });

    string ChangelogFile => RootDirectory / "CHANGELOG.md";
    
    IEnumerable<string> ChangelogSectionNotes => ExtractChangelogSectionNotes(ChangelogFile);

    Target Pack => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            var releaseNotes = ChangelogSectionNotes
                .Select(x => x.Replace("- ", "\u2022 ").Replace("`", string.Empty).Replace(",", "%2C"))
                .Concat(string.Empty)
                .Concat($"Full changelog at {GitRepository.GetGitHubBrowseUrl(ChangelogFile)}")
                .JoinNewLine();

            DotNetPack(s => DefaultDotNetPack
                .SetPackageReleaseNotes(releaseNotes));

            if (InstallGlobalTool)
            {
                SuppressErrors(() => DotNet($"tool uninstall -g {GlobalToolProject.Name}"));
                DotNet($"tool install -g {GlobalToolProject.Name} --add-source {OutputDirectory} --version {GitVersion.NuGetVersionV2}");
            }
        });

    Target Publish => _ => _
        .DependsOn(Test, Pack)
        .Requires(() => ApiKey)
        .Requires(() => GitHasCleanWorkingCopy())
        .Requires(() => !NuGet || Configuration.EqualsOrdinalIgnoreCase("release"))
        .Requires(() => !NuGet || GitRepository.Branch.EqualsOrdinalIgnoreCase(MasterBranch))
        .Executes(() =>
        {
            GlobFiles(OutputDirectory, "*.nupkg").NotEmpty()
                .Where(x => !x.EndsWith(".symbols.nupkg"))
                .ForEach(x => DotNetNuGetPush(s => s
                    .SetTargetPath(x)
                    .SetSource(Source)
                    .SetSymbolSource(SymbolSource)
                    .SetApiKey(ApiKey)));
            
            if (NuGet)
            {
                Git($"push origin {MasterBranch} {DevelopBranch} {GitVersion.MajorMinorPatch}");
                
                var releaseUrl = $"https://www.nuget.org/packages/Nuke.Common/{GitVersion.SemVer}). ";
                var message = GitVersion.Patch == 0
                    ? new StringBuilder()
                        .AppendLine("@/all :mega::shipit: **NUKE {GitVersion.SemVer} IS OUT!!!**")
                        .AppendLine($"This release includes [{ChangelogSectionNotes.Count()} changes]({releaseUrl}). Most notably, we have:")
                        .AppendLine(ChangelogSectionNotes
                            .Take(AnnounceChanges ?? 4)
                            .Select(x => x.Replace("- ", "* "))
                            .JoinNewLine()).ToString()
                    : new StringBuilder()
                        .AppendLine($"@/all :beetle::fire: **BUGFIX RELEASE {GitVersion.SemVer} IS OUT!**")
                        .AppendLine($"Check out the [release notes]({releaseUrl}) for details!").ToString();

                SendGitterMessage(message,
                    roomId: "593f3dadd73408ce4f66db89",
                    token: GitterAuthToken);
            }
        });

    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            var xunitSettings = new Xunit2Settings()
                .AddTargetAssemblies(GlobFiles(SolutionDirectory, $"*/bin/{Configuration}/net4*/Nuke.*.Tests.dll").NotEmpty())
                .AddResultReport(Xunit2ResultFormat.Xml, OutputDirectory / "tests.xml");

            if (IsWin)
            {
                OpenCover(s => DefaultOpenCover
                    .SetOutput(OutputDirectory / "coverage.xml")
                    .SetTargetSettings(xunitSettings)
                    .SetSearchDirectories(xunitSettings.TargetAssemblyWithConfigs.Select(x => Path.GetDirectoryName(x.Key)))
                    .AddFilters("-[Nuke.Common]Nuke.Core.*"));

                ReportGenerator(s => s
                    .AddReports(OutputDirectory / "coverage.xml")
                    .AddReportTypes(ReportTypes.Html)
                    .SetTargetDirectory(OutputDirectory / "coverage"));
            }
            else
                Xunit2(s => xunitSettings);
        });

    Target Analysis => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            InspectCode(s => DefaultInspectCode
                .AddExtensions(
                    "EtherealCode.ReSpeller",
                    "PowerToys.CyclomaticComplexity",
                    "ReSharper.ImplicitNullability",
                    "ReSharper.SerializationInspections",
                    "ReSharper.XmlDocInspections"));
        });

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
                FinalizeChangelog(ChangelogFile, GitVersion.MajorMinorPatch, GitRepository);
                Git($"add {ChangelogFile}");
                Git($"commit -m \"Finalize {Path.GetFileName(ChangelogFile)} for {GitVersion.MajorMinorPatch}\"");
                Assert(GitHasCleanWorkingCopy(), "GitHasCleanWorkingCopy()");

                Git($"checkout {DevelopBranch}");
                Git($"merge --no-ff --no-edit release/{GitVersion.MajorMinorPatch}");
                Git($"checkout {MasterBranch}");
                Git($"merge --no-ff --no-edit release/{GitVersion.MajorMinorPatch}");
                Git($"tag {GitVersion.MajorMinorPatch}");
                Git($"branch -d release/{GitVersion.MajorMinorPatch}");
            }
        });
}
