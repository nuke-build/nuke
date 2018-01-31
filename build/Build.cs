// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.Git;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.InspectCode;
using Nuke.Common.Tools.OpenCover;
using Nuke.Common.Tools.Xunit;
using Nuke.Core;
using Nuke.Core.Utilities;
using Nuke.Core.Utilities.Collections;
using static Nuke.CodeGeneration.CodeGenerator;
using static Nuke.Common.ChangeLog.ChangelogTasks;
using static Nuke.Common.Gitter.GitterTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.Git.GitTasks;
using static Nuke.Common.Tools.InspectCode.InspectCodeTasks;
using static Nuke.Common.Tools.OpenCover.OpenCoverTasks;
using static Nuke.Common.Tools.Xunit.XunitTasks;
using static Nuke.Core.IO.FileSystemTasks;
using static Nuke.Core.IO.PathConstruction;
using static Nuke.Core.EnvironmentInfo;

class Build : NukeBuild
{
    public static int Main () => Execute<Build>(x => x.Pack);

    [Parameter("Indicates to push to nuget.org feed.")] readonly bool NuGet;
    [Parameter("ApiKey for the specified source.")] readonly string ApiKey;
    [Parameter("Gitter authentication token")] readonly string GitterAuthToken;
    [Parameter("Amount of changes to announce in Gitter.")] int? AnnounceChanges;

    string Source => NuGet
            ? "https://api.nuget.org/v3/index.json"
            : "https://www.myget.org/F/nukebuild/api/v2/package";

    [GitVersion] readonly GitVersion GitVersion;
    [GitRepository(Branch = "master")] readonly GitRepository GitRepository;

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

    Target Compile => _ => _
            .DependsOn(Restore)
            .Requires(() => IsUnix || GitVersion != null)
            .Executes(() =>
            {
                DotNetBuild(s => DefaultDotNetBuild);
            });

    Target Publish => _ => _
            .DependsOn(Restore)
            .Executes(() =>
            {
                var project = SourceDirectory / "Nuke.CodeGeneration" / "Nuke.CodeGeneration.csproj";
                DotNetPublish(s => DefaultDotNetPublish
                        .SetProject(project)
                        .SetFramework("netstandard2.0"));
                DotNetPublish(s => DefaultDotNetPublish
                        .SetProject(project)
                        .SetFramework("net461"));
            });
    
    string ChangelogFile => RootDirectory / "CHANGELOG.md";

    IEnumerable<string> ChangelogSectionNotes => ExtractChangelogSectionNotes(ChangelogFile);

    Target Changelog => _ => _
            .OnlyWhen(() => NuGet || InvokedTargets.Contains(nameof(Changelog)))
            .Executes(() =>
            {
                FinalizeChangelog(ChangelogFile, GitVersion.FullSemVer, GitRepository);

                Git($"add {ChangelogFile}");
                Git($"commit -m \"Finalize changelog for {GitVersion.FullSemVer}.\"");
                Git($"tag -f {GitVersion.FullSemVer}");
            });

    Target Pack => _ => _
            .DependsOn(Compile, Publish, Changelog)
            .Executes(() =>
            {
                var releaseNotes = ChangelogSectionNotes
                        .Select(x => x.Replace("- ", "\u2022 "))
                        .Concat(string.Empty)
                        .Concat($"Full changelog at {GitRepository.GetGitHubBrowseUrl(ChangelogFile)}")
                        .JoinNewLine();

                DotNetPack(s => DefaultDotNetPack
                        .SetPackageReleaseNotes(releaseNotes));
            });

    Target Push => _ => _
            .DependsOn(Pack)
            .Requires(() => ApiKey)
            .Requires(() => !NuGet || Configuration.EqualsOrdinalIgnoreCase("release"))
            .Requires(() => !NuGet || GitVersion.BranchName.Equals("master"))
            .Executes(() =>
            {
                GlobFiles(OutputDirectory, "*.nupkg").NotEmpty()
                        .Where(x => !x.EndsWith("symbols.nupkg"))
                        .ForEach(x => DotNetNuGetPush(s => s
                                .SetTargetPath(x)
                                .SetSource(Source)
                                .SetApiKey(ApiKey)));

                if (NuGet)
                {
                    SendGitterMessage(
                        new[]
                            {
                                ":mega::shipit: @/all",
                                string.Empty,
                                $"**NUKE {GitVersion.SemVer} IS OUT!!!**",
                                string.Empty,
                                $"This release includes [{ChangelogSectionNotes.Count()} changes](https://www.nuget.org/packages/Nuke.Common/{GitVersion.SemVer}). Most notably, we have:"
                            }.Concat(ChangelogSectionNotes
                                .Take(AnnounceChanges ?? 4)
                                .Select(x => x.Replace("- ", "* ")))
                            .JoinNewLine(),
                        "593f3dadd73408ce4f66db89",
                        GitterAuthToken);
                }
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

    Target Test => _ => _
            .DependsOn(Compile)
            .Executes(() =>
            {
                void TestXunit ()
                    => Xunit2(GlobFiles(SolutionDirectory, $"*/bin/{Configuration}/net4*/Nuke.*.Tests.dll").NotEmpty(),
                        s => s.AddResultReport(Xunit2ResultFormat.Xml, OutputDirectory / "tests.xml"));

                if (IsWin)
                    OpenCover(TestXunit, s => DefaultOpenCover
                            .SetOutput(OutputDirectory / "coverage.xml"));
                else
                    TestXunit();
            });

    string MetadataDirectory => RootDirectory / ".." / "tools" / "metadata";
    string GenerationDirectory => RootDirectory / "source" / "Nuke.Common" / "Tools";

    Target Generate => _ => _
            .Executes(() =>
            {
                GenerateCode(
                    MetadataDirectory,
                    GenerationDirectory,
                    baseNamespace: "Nuke.Common.Tools",
                    useNestedNamespaces: true,
                    gitRepository: GitRepository.FromLocalDirectory(MetadataDirectory).NotNull());
            });

    Target Full => _ => _
            .DependsOn(Test, Analysis, Push);
}
