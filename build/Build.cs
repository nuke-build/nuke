// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Nuke.CodeGeneration.Model;
using Nuke.Common.Git;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.InspectCode;
using Nuke.Common.Tools.OpenCover;
using Nuke.Common.Tools.Xunit;
using Nuke.Common;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.CodeGeneration.CodeGenerator;
using static Nuke.CodeGeneration.ReferenceUpdater;
using static Nuke.CodeGeneration.SchemaGenerator;
using static Nuke.Common.ChangeLog.ChangelogTasks;
using static Nuke.Common.Gitter.GitterTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.Git.GitTasks;
using static Nuke.Common.Tools.InspectCode.InspectCodeTasks;
using static Nuke.Common.Tools.OpenCover.OpenCoverTasks;
using static Nuke.Common.Tools.Xunit.XunitTasks;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.EnvironmentInfo;

class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Pack);

    [Parameter("Indicates to push to nuget.org feed.")] readonly bool NuGet;
    [Parameter("ApiKey for the specified source.")] readonly string ApiKey;
    [Parameter("Gitter authentication token.")] readonly string GitterAuthToken;
    [Parameter("Amount of changes to announce in Gitter.")] readonly int? AnnounceChanges;

    string Source => NuGet
        ? "https://api.nuget.org/v3/index.json"
        : "https://www.myget.org/F/nukebuild/api/v2/package";

    string SymbolSource => NuGet
        ? "https://nuget.smbsrc.net/"
        : "https://www.myget.org/F/nukebuild/symbols/api/v2/package";

    [GitVersion] readonly GitVersion GitVersion;
    [GitRepository] readonly GitRepository GitRepository;
    [Solution] readonly Solution Solution;

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
    
    Project GlobalToolProject => Solution.GetProject("Nuke.GlobalTool");
    Project CodeGenerationProject => Solution.GetProject("Nuke.CodeGeneration");

    Target Publish => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
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

    Target Changelog => _ => _
        .OnlyWhen(() => NuGet || InvokedTargets.Contains(nameof(Changelog)))
        .Executes(() =>
        {
            FinalizeChangelog(ChangelogFile, GitVersion.SemVer, GitRepository);

            Git($"add {ChangelogFile}");
            Git($"commit -m \"Finalize {Path.GetFileName(ChangelogFile)} for {GitVersion.SemVer}.\"");
            Git($"tag -f {GitVersion.SemVer}");
        });

    Target Pack => _ => _
        .DependsOn(Compile, Publish, Changelog)
        .Executes(() =>
        {
            var releaseNotes = ChangelogSectionNotes
                .Select(x => x.Replace("- ", "\u2022 ").Replace("`", string.Empty).Replace(",", "%2C"))
                .Concat(string.Empty)
                .Concat($"Full changelog at {GitRepository.GetGitHubBrowseUrl(ChangelogFile)}")
                .JoinNewLine();

            DotNetPack(s => DefaultDotNetPack
                .SetPackageReleaseNotes(releaseNotes));
        });

    Target Push => _ => _
        .DependsOn(Pack)
        .Requires(() => ApiKey)
        .Requires(() => !GitHasUncommitedChanges())
        .Requires(() => !NuGet || GitVersionAttribute.Bump.HasValue)
        .Requires(() => !NuGet || Configuration.EqualsOrdinalIgnoreCase("release"))
        .Requires(() => !NuGet || GitVersion.BranchName.Equals("master"))
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
                SendGitterMessage(new StringBuilder()
                        .AppendLine(":mega::shipit: @/all")
                        .AppendLine()
                        .AppendLine($"**NUKE {GitVersion.SemVer} IS OUT!!!**")
                        .AppendLine()
                        .AppendLine($"This release includes [{ChangelogSectionNotes.Count()} changes]"
                                    + $"(https://www.nuget.org/packages/Nuke.Common/{GitVersion.SemVer}). "
                                    + "Most notably, we have:")
                        .AppendLine(ChangelogSectionNotes
                            .Take(AnnounceChanges ?? 4)
                            .Select(x => x.Replace("- ", "* "))
                            .JoinNewLine()).ToString(),
                    roomId: "593f3dadd73408ce4f66db89",
                    token: GitterAuthToken);
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
            var xunitSettings = new Xunit2Settings()
                .AddTargetAssemblies(GlobFiles(SolutionDirectory, $"*/bin/{Configuration}/net4*/Nuke.*.Tests.dll").NotEmpty())
                .AddResultReport(Xunit2ResultFormat.Xml, OutputDirectory / "tests.xml");

            if (IsWin)
            {
                OpenCover(s => DefaultOpenCover
                    .SetOutput(OutputDirectory / "coverage.xml")
                    .SetTargetSettings(xunitSettings));
            }
            else
                Xunit2(s => xunitSettings);
        });

    string SpecificationsDirectory => BuildProjectDirectory / "specifications";
    string ReferencesDirectory => BuildProjectDirectory / "references";
    string GenerationDirectory => RootDirectory / "source" / "Nuke.Common" / "Tools";
    string ToolSchemaFile => SourceDirectory / "Nuke.CodeGeneration" / "schema.json";

    Target References => _ => _
        .Requires(() => !GitHasUncommitedChanges())
        .Executes(() =>
        {
            EnsureCleanDirectory(ReferencesDirectory);
            
            UpdateReferences(SpecificationsDirectory, ReferencesDirectory);
        });
    
    Target Generate => _ => _
        .Executes(() =>
        {
            GenerateSchema<Tool>(
                ToolSchemaFile,
                GitRepository.GetGitHubDownloadUrl(ToolSchemaFile, "master"),
                "Tool specification schema file by NUKE");

            GenerateCode(
                SpecificationsDirectory,
                GenerationDirectory,
                baseNamespace: "Nuke.Common.Tools",
                useNestedNamespaces: true,
                gitRepository: GitRepository.SetBranch("master"));
        });

    Target Full => _ => _
        .DependsOn(Test, Analysis, Push);
}
