// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Docker;
using Nuke.Common.Tools.DotNet;
using Serilog;

namespace Nuke.Common.Execution
{
    internal class DockerExecutor
    {
        public static bool ShouldRunStepInDocker(ExecutableTarget target)
        {
            return IsDockerStep(target) && !NukeBuild.IsDockerExecution;
        }

        public static bool IsDockerStep(ExecutableTarget target)
        {
            return target.ExecuteInDockerSettings != null;
        }

        public static void Execute(NukeBuild build, ExecutableTarget target)
        {
            PullImageIfRequired(target);

            PublishBuildProject(target);

            CopyPackageReferences();

            RunDocker(target);
        }

        private static void RunDocker(ExecutableTarget target)
        {
            var workingDirectory = GetWorkingDirectory(target.ExecuteInDockerSettings.DockerPlatform);
            var path = GetPathToPublishedBuildProject(target.ExecuteInDockerSettings.DockerPlatform);
            var args = GetArgs(target, path, workingDirectory);
            var envFile = GetEnvFile(workingDirectory);
            var volumes = new[] { $"{NukeBuild.RootDirectory}:{workingDirectory}" };

            try
            {
                Log.Information("Executing target {Target} in a new docker container based on {Image}", target.Name, target.ExecuteInDockerSettings.Image);

                DockerTasks.DockerRun(settings => settings
                    .EnableRm()
                    .SetImage(target.ExecuteInDockerSettings.Image)
                    .SetVolume(volumes)
                    .SetCommand("dotnet")
                    .SetPlatform(target.ExecuteInDockerSettings.DockerPlatform)
                    .SetWorkdir(workingDirectory)
                    .SetEnvFile(envFile)
                    .SetArgs(args.Concat(target.ExecuteInDockerSettings.Args))); 
            }
            finally
            {
                File.Delete(envFile);
            }
        }

        private static string[] GetArgs(ExecutableTarget target, string path, string workingDirectory)
        {
            return new[]
                   {
                       path,
                       "--nologo",
                       "--skip",
                       "--target", $"\"{target.Name}\"",
                       "--root", workingDirectory
                   };
        }

        private static string GetPathToPublishedBuildProject(string platform)
        {
            return PathConstruction.Combine(
                GetWorkingDirectory(platform), 
                GetRelativePathToPublishedBuildProject(platform));
        }

        private static RelativePath GetRelativePathToPublishedBuildProject(string platform)
        {
            return IsWindowsContainer(platform)
                ? (RelativePath) NukeBuild.RootDirectory.GetWinRelativePathTo(PublishedBuildDirectory / Path.GetFileName(NukeBuild.BuildAssembly))
                : (RelativePath) NukeBuild.RootDirectory.GetUnixRelativePathTo(PublishedBuildDirectory / Path.GetFileName(NukeBuild.BuildAssembly));
        }

        private static string GetWorkingDirectory(string platform)
        {
            return IsWindowsContainer(platform) ? "c:\\Build" : "/build";
        }

        private static bool IsWindowsContainer(string platform)
        {
            return platform.StartsWith("win", StringComparison.OrdinalIgnoreCase);
        }

        private static void CopyPackageReferences()
        {
            //todo: Matthias to investigate if we can influence the publish self-contained to include this - see #822
            //todo: mattr: figure out if can we map the folder in instead
            Log.Information("Inlining PackageDownload references from build project");
            var buildProject = ProjectModelTasks.ParseProject(NukeBuild.BuildProjectFile).NotNull();
            foreach (var item in buildProject.Items.Where(x => x.ItemType == "PackageDownload"))
            {
                var version = item.Metadata.First(x => x.Name == "Version").EvaluatedValue.Replace("[", "").Replace("]", "");
                var packageId = item.EvaluatedInclude;
                Log.Information("Inlining {PackageId} {Version} reference from build project", packageId, version);
                var package = NuGetPackageResolver.GetLocalInstalledPackage(packageId, NukeBuild.BuildProjectFile, version);
                FileSystemTasks.CopyDirectoryRecursively(package.Directory, PublishedBuildDirectory / packageId);
            }
        }

        private static void PublishBuildProject(ExecutableTarget target)
        {
            Log.Information("Publishing a temporary copy of the build project (targeting {Platform}) for use within the docker container", target.ExecuteInDockerSettings.DotNetPublishRuntime);
            FileSystemTasks.EnsureCleanDirectory(PublishedBuildDirectory);
            DotNetTasks.DotNetPublish(p => p
                .SetProject(NukeBuild.BuildProjectFile)
                .SetOutput(PublishedBuildDirectory)
                .SetConfiguration("Release")
                .SetVerbosity(DotNetVerbosity.Quiet)
                .EnableNoLogo()
                .SetRuntime(target.ExecuteInDockerSettings.DotNetPublishRuntime)
                .EnableSelfContained()
            );
        }

        private static void PullImageIfRequired(ExecutableTarget target)
        {
            if (target.ExecuteInDockerSettings.PullImage)
            {
                Log.Information("Pulling image {Image}", target.ExecuteInDockerSettings.Image);
                DockerTasks.DockerPull(settings => settings
                    .SetName(target.ExecuteInDockerSettings.Image));
            }
        }

        private static string GetEnvFile(string workingDirectory)
        {
            //todo: this will probably fail with an env var value with an ampersand in it
            //todo: this will probably fail with an env var value with new lines in it
            var stringBuilder = new StringBuilder();
            var dictionaryEntries = Environment.GetEnvironmentVariables()
                .Cast<DictionaryEntry>()
                .Where(env =>
                {
                    var key = (string)env.Key;
                    return !key.Contains(" ")
                           && key != "USERPROFILE"
                           && key != "USERNAME"
                           && key != "LOCALAPPDATA"
                           && key != "APPDATA"
                           && key != "TEMP"
                           && key != "TMP"
                           && key != "HOMEPATH";
                });

            foreach (var env in dictionaryEntries)
                stringBuilder.AppendLine($"{env.Key}={env.Value}");

            stringBuilder.AppendLine("DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1");
            stringBuilder.AppendLine("DOTNET_CLI_TELEMETRY_OPTOUT=1");
            stringBuilder.AppendLine($"DOTNET_CLI_HOME={workingDirectory}");
            stringBuilder.AppendLine($"TEMP=/build/{NukeBuild.RootDirectory.GetUnixRelativePathTo(NukeBuild.TemporaryDirectory)}");
            stringBuilder.AppendLine($"TMP=/build/{NukeBuild.RootDirectory.GetUnixRelativePathTo(NukeBuild.TemporaryDirectory)}");
            stringBuilder.AppendLine($"{RunningInDockerEnvironmentVariable}=1");
            
            //without this, errors crash the process (on an m1 mac at least) with 
            //Failed to create CoreCLR, HRESULT: 0x80004005
            //https://github.com/PowerShell/PowerShell/issues/13166#issuecomment-713034137
            stringBuilder.AppendLine($"COMPlus_EnableDiagnostics=0"); 

            var tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, stringBuilder.ToString());
            return tempFile;
        }

        public static string RunningInDockerEnvironmentVariable = "NUKE_RUNNING_IN_DOCKER";
        private static AbsolutePath PublishedBuildDirectory = NukeBuild.TemporaryDirectory / "nukebuild";
    }
}
