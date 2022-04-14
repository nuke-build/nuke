// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Docker;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities;
using Serilog;

namespace Nuke.Common.Execution
{
    internal class DockerExecutor
    {
        public static bool ShouldRunStepInDocker(NukeBuild build, ExecutableTarget target)
        {
            return IsDockerStep(build, target) && NukeBuild.Host is not NukeInDocker;
        }

        public static bool IsDockerStep(NukeBuild build, ExecutableTarget target)
        {
            var attribute = GetRunInDockerContainerAttribute(build, target);
            return attribute != null;
        }

        [CanBeNull]
        private static RunInDockerContainerAttribute GetRunInDockerContainerAttribute(NukeBuild nukeBuild, ExecutableTarget target)
        {
            var targetProperty = ExecutableTargetFactory.GetTargetProperties(nukeBuild.GetType()).FirstOrDefault(x => x.Name == target.Name);
            return targetProperty?.GetCustomAttribute<RunInDockerContainerAttribute>();
        }

        public static void Execute(NukeBuild build, ExecutableTarget target)
        {
            var attribute = GetRunInDockerContainerAttribute(build, target)!;

            PullImageIfRequired(attribute);

            PublishBuildProject(attribute);

            CopyPackageReferences();

            RunDocker(target, attribute);
        }

        private static void RunDocker(ExecutableTarget target, RunInDockerContainerAttribute attribute)
        {
            var workingDirectory = GetWorkingDirectory(attribute);
            var path = GetPath(attribute);
            var args = GetArgs(target, path, workingDirectory);
            var tempFile = GetEnvFile(workingDirectory);
            var volumes = new[] { $"{NukeBuild.RootDirectory}:{workingDirectory}" };

            try
            {
                DockerTasks.DockerRun(settings => settings
                    .EnableRm()
                    .SetImage(attribute.Image)
                    .SetVolume(volumes)
                    .SetCommand("dotnet")
                    .SetWorkdir(workingDirectory)
                    .SetEnvFile(tempFile)
                    .SetArgs(args.Concat(attribute.Args)));
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        private static string[] GetArgs(ExecutableTarget target, string path, string workingDirectory)
        {
            return new[]
                   {
                       path,
                       "--nologo",
                       "--skip",
                       "--host", "NukeInDocker",
                       "--target", $"\"{target.Name}\"",
                       "--root", workingDirectory
                   };
        }

        private static string GetPath(RunInDockerContainerAttribute attribute)
        {
            return attribute.Platform == PlatformFamily.Windows
                ? $"c:\\build\\{NukeBuild.RootDirectory.GetWinRelativePathTo(NukeBuild.TemporaryDirectory)}\\nukebuild\\{Path.GetFileName(NukeBuild.BuildAssembly)}"
                : $"/build/{NukeBuild.RootDirectory.GetUnixRelativePathTo(NukeBuild.TemporaryDirectory)}/nukebuild/{Path.GetFileName(NukeBuild.BuildAssembly)}";
        }

        private static string GetWorkingDirectory(RunInDockerContainerAttribute attribute)
        {
            return attribute.Platform == PlatformFamily.Windows ? "c:\\Build" : "/build";
        }

        private static void CopyPackageReferences()
        {
            Log.Information("Inlining PackageDownload references from build project");
            var buildProject = ProjectModelTasks.ParseProject(NukeBuild.BuildProjectFile).NotNull();
            foreach (var item in buildProject.Items)
            {
                if (item.ItemType == "PackageDownload")
                {
                    var version = item.Metadata.First(x => x.Name == "Version").EvaluatedValue.Replace("[", "").Replace("]", "");
                    var packageId = item.EvaluatedInclude;
                    Log.Information("Inlining {PackageId} {Version} reference from build project", packageId, version);
                    var package = NuGetPackageResolver.GetLocalInstalledPackage(packageId, NukeBuild.BuildProjectFile, version);
                    FileSystemTasks.CopyDirectoryRecursively(package.Directory, NukeBuild.TemporaryDirectory / "nukebuild" / packageId);
                }
            }
        }

        private static void PublishBuildProject(RunInDockerContainerAttribute attribute)
        {
            var runtime = attribute.Platform == PlatformFamily.Windows ? "win-x64" : "linux-x64";
            Log.Information("Publishing a temporary copy of the build project (targeting {Platform}) for use within the docker container", runtime);
            FileSystemTasks.EnsureCleanDirectory(NukeBuild.TemporaryDirectory / "nukebuild");
            DotNetTasks.DotNetPublish(p => p
                .SetProject(NukeBuild.BuildProjectFile)
                .SetOutput(NukeBuild.TemporaryDirectory / "nukebuild")
                .SetConfiguration("Release")
                .SetVerbosity(DotNetVerbosity.Quiet)
                .EnableNoLogo()
                .SetRuntime(runtime)
                .EnableSelfContained()
            );
        }

        private static void PullImageIfRequired(RunInDockerContainerAttribute attribute)
        {
            if (attribute.PullImage)
            {
                Log.Information("Pulling image {Image}", attribute.Image);
                DockerTasks.DockerPull(settings => settings
                    .SetName(attribute.Image));
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

            var tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, stringBuilder.ToString());
            return tempFile;
        }
    }
}
