using System.Linq;
using Nuke.CodeGeneration;
using Nuke.Common.Git;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Core;
using Nuke.Core.Utilities.Collections;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Core.IO.FileSystemTasks;
using static Nuke.Core.IO.PathConstruction;

class Build : NukeBuild
{
    public static int Main () => Execute<Build>(x => x.Compile);

    const string Source = "https://www.myget.org/F/nuke-plugins/api/v2/package";

    [GitRepository] readonly GitRepository GitRepository;
    [GitVersion] readonly GitVersion GitVersion;
    [Parameter] readonly string MyGetApiKey;

    Target Clean => _ => _
            .Executes(() =>
            {
                DeleteDirectories(GlobDirectories(SourceDirectory, "**/bin", "**/obj"));
                EnsureCleanDirectory(OutputDirectory);
            });

    Target Restore => _ => _
            .DependsOn(Clean)
            .Executes(() =>
            {
                DotNetRestore(s => DefaultDotNetRestore);
            });

    string MetaDataDirectory => SourceDirectory / "Nuke.NSwag" / "metadata";
    string GenerationDirectory => SourceDirectory / "Nuke.NSwag";

    Target Generate => _ => _
        .Executes(() =>
        {
           CodeGenerator.GenerateCode(MetaDataDirectory,GenerationDirectory,false,"Nuke.NSwag");
        });
        
    Target Compile => _ => _
            .DependsOn(Restore, Generate)
            .Executes(() =>
            {
                DotNetBuild(s => DefaultDotNetBuild);
            });

    Target Pack => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetPack(s => DefaultDotNetPack);
        });

    Target Push => _ => _
        .DependsOn(Pack)
        .Requires(() => MyGetApiKey != null, () => GitRepository.Branch == "master" || GitRepository.Branch == "develop")
        .OnlyWhen(() => GitRepository.Branch == "master")
        .Executes(() =>
        {
            GlobFiles(OutputDirectory,"*.nupkg").NotEmpty()
                .Where(f => !f.EndsWith("symbols.nupkg"))
                .ForEach(p => DotNetNuGetPush(c => c
                .SetSource(Source)
                .SetApiKey(MyGetApiKey)
                .SetTargetPath(p)));
        });
}
