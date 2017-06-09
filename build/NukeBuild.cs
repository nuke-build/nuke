// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Net;
using Nuke.Common;
using Nuke.Common.Tools.DocFx;
using Nuke.Common.Tools.GitLink;
using Nuke.Common.Tools.NuGet;
using Nuke.Common.Tools.Xunit;
using Nuke.Core;
using Nuke.Core.Utilities.Collections;
using static Documentation;
using static Nuke.Common.Ftp.FtpTasks;
using static Nuke.Common.Tools.DocFx.DocFxTasks;
using static Nuke.Common.Tools.GitLink.GitLinkTasks;
using static Nuke.Common.Tools.InspectCode.InspectCodeTasks;
using static Nuke.Common.Tools.MSBuild.MSBuildTasks;
using static Nuke.Common.Tools.NuGet.NuGetTasks;
using static Nuke.Common.Tools.Xunit.XunitTasks;
using static Nuke.Core.EnvironmentInfo;
using static Nuke.Common.FileSystem.FileSystemTasks;

class NukeBuild : GitHubBuild
{
    public static int Main () => Execute<NukeBuild>(x => x.Pack);

    Target Clean => _ => _
            .OnlyWhen(() => IsServerBuild)
            .Executes(() => PrepareCleanDirectory(OutputDirectory));

    Target Restore => _ => _
            .Executes(() => MSBuild(s => DefaultSettings.MSBuildRestore));

    Target Compile => _ => _
            .DependsOn(Clean, Restore)
            .Executes(() => MSBuild(s => IsWin ? DefaultSettings.MSBuildCompileWithAssemblyInfo : DefaultSettings.MSBuildCompile));

    Target Link => _ => _
            .OnlyWhen(() => false)
            .DependsOn(Compile)
            .Executes(() => GlobFiles(SolutionDirectory, $"*/bin/{Configuration}/*/*.pdb")
                    .Where(x => !x.Contains("ToolGenerator"))
                    .ForEach(x => GitLink3(s => DefaultSettings.GitLink3.SetPdbFile(x))));

    Target Pack => _ => _
            .DependsOn(Restore, Link)
            .Executes(() => MSBuild(s => DefaultSettings.MSBuildPack));

    bool IsMasterBranch => GitVersion.BranchName == "master";

    Target Publish => _ => _
            .OnlyWhen(() => GitVersion.BranchName == "master" || GitVersion.BranchName == "dev")
            .DependsOn(Pack)
            .Executes(() => GlobFiles(OutputDirectory, "*.nupkg")
                    .ForEach(x => NuGetPush(s => s
                            .SetVerbosity(NuGetVerbosity.Detailed)
                            .SetTargetPath(x)
                            .SetApiKey(EnsureVariable(IsMasterBranch ? "NUGET_API_KEY" : "MYGET_API_KEY"))
                            .SetSource(IsMasterBranch
                                ? null /* default */
                                : "https://www.myget.org/F/nukebuild/api/v2/package"))));

    Target Analysis => _ => _
            .DependsOn(Restore)
            .Executes(() => InspectCode(s => DefaultSettings.InspectCode));

    string DocsDirectory => Path.Combine(RootDirectory, "docs");
    string DocFxJsonFile => Path.Combine(DocsDirectory, "docfx.json");

    Target GenerateDocs => _ => _
            .DependsOn(Compile)
            .Executes(
                () => DocFxMetadata(DocFxJsonFile, s => s.EnableForce()),
                () => WriteCustomToc(Path.Combine(DocsDirectory, "api", "toc.yml"),
                    GlobFiles(SolutionDirectory, $"*/bin/{Configuration}/*/Nuke.*.dll")),
                () => DocFxBuild(DocFxJsonFile, s => s.EnableForce()));

    Target UploadDocs => _ => _
            .DependsOn(GenerateDocs)
            .Executes(() => FtpUploadDirectoryRecursively(
                Path.Combine(RootDirectory, "docs", "_site"),
                "ftp://www58.world4you.com",
                new NetworkCredential(EnsureVariable("FTP_USERNAME"), EnsureVariable("FTP_PASSWORD"))));

    Target Test => _ => _
            .DependsOn(Compile)
            .Executes(() => Xunit2(GlobFiles(SolutionDirectory, $"*/bin/{Configuration}/net4*/Nuke.*.Tests.dll"), new XunitSettings()));

    Target Full => _ => _
            .DependsOn(Compile, Test, Analysis, Publish, UploadDocs);
}
