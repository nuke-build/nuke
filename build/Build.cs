// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Git;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitLink;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.InspectCode;
using Nuke.Common.Tools.OpenCover;
using Nuke.Common.Tools.Xunit;
using Nuke.Core;
using Nuke.Core.Utilities.Collections;
using static Nuke.CodeGeneration.CodeGenerator;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.GitLink.GitLinkTasks;
using static Nuke.Common.Tools.InspectCode.InspectCodeTasks;
using static Nuke.Common.Tools.OpenCover.OpenCoverTasks;
using static Nuke.Common.Tools.Xunit.XunitTasks;
using static Nuke.Core.IO.FileSystemTasks;
using static Nuke.Core.IO.PathConstruction;
using static Nuke.Core.EnvironmentInfo;

class Build : NukeBuild
{
    [Parameter("ApiKey for the 'nukebuild' feed.")] readonly string MyGetApiKey;

    [GitVersion] readonly GitVersion GitVersion;
    [GitRepository] readonly GitRepository GitRepository;

    public static int Main () => Execute<Build>(x => x.Pack);

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
                DotNetRestore(s => DefaultDotNetRestore.SetProjectFile (SolutionFile));
            });

    Target Compile => _ => _
            .DependsOn(Restore)
            .Requires(() => IsUnix || GitVersion != null)
            .Executes(() =>
            {
                DotNetBuild(s => DefaultDotNetBuild.SetProjectFile(SolutionFile).EnableNoRestore());
            });

    Target Link => _ => _
            .OnlyWhen(() => false)
            .DependsOn(Compile)
            .Executes(() =>
            {
                GlobFiles(SolutionDirectory, $"*/bin/{Configuration}/*/*.pdb")
                        .Where(x => !x.Contains("ToolGenerator"))
                        .ForEach(x => GitLink3(s => DefaultGitLink3
                                .SetPdbFile(x)));
            });

    Target Pack => _ => _
            .DependsOn(Link)
            .Executes(() =>
            {
                DotNetPack(s => DefaultDotNetPack.SetProject(SolutionFile).EnableNoBuild());
            });

    Target Push => _ => _
            .DependsOn(Pack)
            .Requires(() => MyGetApiKey)
            .Executes(() =>
            {
                GlobFiles(OutputDirectory, "*.nupkg")
                        .Where(x => !x.EndsWith("symbols.nupkg"))
                        .ForEach(x => DotNetNuGetPush(s => s
                                .SetTargetPath(x)
                                .SetSource("https://www.myget.org/F/nukebuild/api/v2/package")
                                .SetApiKey(MyGetApiKey)));
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
                    => Xunit2(GlobFiles(SolutionDirectory, $"*/bin/{Configuration}/net4*/Nuke.*.Tests.dll"),
                        s => s.AddResultReport(ResultFormat.Xml, OutputDirectory / "tests.xml"));

                if (IsWin)
                    OpenCover(TestXunit, s => DefaultOpenCover
                            .SetOutput(OutputDirectory / "coverage.xml"));
                else
                    TestXunit();
            });

    Target Generate => _ => _
            .Executes(() =>
            {
                GenerateCode(
                    metadataDirectory: RootDirectory / ".." / "tools" / "metadata",
                    generationDirectory: RootDirectory / "source" / "Nuke.Common" / "Tools",
                    baseNamespace: "Nuke.Common.Tools",
                    useNestedNamespaces: true);
            });

    Target Full => _ => _
            .DependsOn(Test, Analysis, Push);
}
