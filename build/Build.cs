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
using Nuke.Core.Utilities;
using Nuke.Core.Utilities.Collections;
using static Nuke.CodeGeneration.CodeGenerator;
using static Nuke.Common.Gitter.GitterTasks;
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
    public static int Main () => Execute<Build>(x => x.Pack);

    [Parameter("Source for Push target.")] readonly string Source = "https://www.myget.org/F/nukebuild/api/v2/package";
    [Parameter("ApiKey for the specified source.")] readonly string ApiKey;
    [Parameter("Gitter authentication token")] readonly string GitterAuthToken;

    [GitVersion] readonly GitVersion GitVersion;

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

    Target Pack => _ => _
            .DependsOn(Compile, Publish)
            .Executes(() =>
            {
                DotNetPack(s => DefaultDotNetPack);
            });

    Target Push => _ => _
            .DependsOn(Pack)
            .Requires(() => ApiKey)
            .Executes(() =>
            {
                GlobFiles(OutputDirectory, "*.nupkg")
                        .Where(x => !x.EndsWith("symbols.nupkg"))
                        .ForEach(x => DotNetNuGetPush(s => s
                                .SetTargetPath(x)
                                .SetSource(Source)
                                .SetApiKey(ApiKey)));

                if (Source.Contains("nuget.org"))
                {
                    SendGitterMessage (
                        $"@/all Version {GitVersion.SemVer} has been published.",
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
                void TestXunit ()
                    => Xunit2(GlobFiles(SolutionDirectory, $"*/bin/{Configuration}/net4*/Nuke.*.Tests.dll").NotEmpty(),
                        s => s.AddResultReport(ResultFormat.Xml, OutputDirectory / "tests.xml"));

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
