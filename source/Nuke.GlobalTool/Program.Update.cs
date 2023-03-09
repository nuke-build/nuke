// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities;
using static Nuke.Common.Constants;

namespace Nuke.GlobalTool
{
    partial class Program
    {
        [UsedImplicitly]
        public static int Update(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            PrintInfo();
            Logging.Configure();

            Assert.NotNull(rootDirectory);

            if (buildScript != null)
            {
                ConfirmExecution("Update build scripts", () => UpdateBuildScripts(rootDirectory, buildScript));
                ConfirmExecution("Update build project", () => UpdateBuildProject(buildScript));
            }

            ConfirmExecution("Update configuration file", () => UpdateConfigurationFile(rootDirectory));
            ConfirmExecution("Update global.json", () => UpdateGlobalJsonFile(rootDirectory));

            ShowCompletion("Updates");

            return 0;
        }

        private static void UpdateBuildScripts(AbsolutePath rootDirectory, AbsolutePath buildScript)
        {
            var configuration = GetConfiguration(buildScript, evaluate: true);
            var buildProjectFile = (AbsolutePath) configuration[BUILD_PROJECT_FILE];

            WriteBuildScripts(
                scriptDirectory: buildScript.Parent,
                rootDirectory,
                buildDirectory: buildProjectFile.NotNull().Parent,
                buildProjectName: Path.GetFileNameWithoutExtension(buildProjectFile));
        }

        private static void UpdateBuildProject(AbsolutePath buildScript)
        {
            var configuration = GetConfiguration(buildScript, evaluate: true);
            var projectFile = configuration[BUILD_PROJECT_FILE];
            ProjectModelTasks.Initialize();
            ProjectUpdater.Update(projectFile);
        }

        private static void UpdateConfigurationFile(AbsolutePath rootDirectory)
        {
            var configurationFile = rootDirectory / NukeDirectoryName;
            if (!configurationFile.Exists())
                return;

            var solutionFile = rootDirectory / configurationFile.ReadAllLines().FirstOrDefault(x => !x.IsNullOrEmpty());
            configurationFile.DeleteFile();

            WriteConfigurationFile(rootDirectory, solutionFile);
            Host.Warning("The previous .nuke file was transformed to a .nuke directory.");
            Host.Warning("The .tmp directory can be cleared, as it is moved to .nuke/temp as well.");
            if (solutionFile != null)
                Host.Warning($"Verify the property referencing the solution has the same name as the member with the {nameof(SolutionAttribute)}.");
        }

        private static void UpdateGlobalJsonFile(AbsolutePath rootDirectory)
        {
            var latestInstalledSdk = DotNetTasks.DotNet($"--list-sdks", logInvocation: false, logOutput: false)
                .LastOrDefault().Text?.Split(" ").First();
            if (latestInstalledSdk == null)
                return;

            var globalJsonFile = rootDirectory / "global.json";
            var jobject = globalJsonFile.Existing()?.ReadJson() ?? new JObject();
            jobject["sdk"] ??= new JObject();
            jobject["sdk"].NotNull()["version"] = latestInstalledSdk;
            globalJsonFile.WriteJson(jobject);
        }
    }
}
