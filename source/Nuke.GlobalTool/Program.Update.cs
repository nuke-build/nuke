// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using NuGet.Versioning;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities;
using static Nuke.Common.Constants;
using static Nuke.Common.Tooling.NuGetPackageResolver;

namespace Nuke.GlobalTool
{
    partial class Program
    {
        [UsedImplicitly]
        public static int Update(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            Assert.NotNull(rootDirectory);

            if (buildScript != null)
            {
                if (UserConfirms("Update build scripts?"))
                    UpdateBuildScripts(rootDirectory, buildScript);

                if (UserConfirms("Update build project?"))
                {
                    var configuration = GetConfiguration(buildScript, evaluate: true);
                    var buildProject = ProjectModelTasks.ParseProject(configuration[BUILD_PROJECT_FILE]).NotNull();

                    UpdateTargetFramework(buildProject);
                    UpdateNukeCommonPackage(buildProject, out var previousPackageVersion);

                    if (previousPackageVersion.MinVersion >= NuGetVersion.Parse("0.23.5"))
                        RemoveLegacyFileIncludes(buildProject);

                    buildProject.Save();
                }
            }

            if (UserConfirms("Update configuration file?"))
                UpdateConfigurationFile(rootDirectory);

            if (UserConfirms("Update global.json?"))
                UpdateGlobalJsonFile(rootDirectory);

            return 0;
        }

        private static void UpdateBuildScripts(AbsolutePath rootDirectory, AbsolutePath buildScript)
        {
            var configuration = GetConfiguration(buildScript, evaluate: true);
            var buildProjectFile = (AbsolutePath) configuration[BUILD_PROJECT_FILE];
            var solutionDirectory = (AbsolutePath) configuration.GetValueOrDefault(SOLUTION_DIRECTORY);

            WriteBuildScripts(
                scriptDirectory: buildScript.Parent,
                rootDirectory,
                solutionDirectory,
                buildDirectory: buildProjectFile.NotNull().Parent,
                buildProjectName: Path.GetFileNameWithoutExtension(buildProjectFile),
                solutionDirectory == null ? PLATFORM_NETCORE : PLATFORM_NETFX);
        }

        private static void UpdateTargetFramework(Microsoft.Build.Evaluation.Project buildProject)
        {
            buildProject.SetProperty("TargetFramework", "net5.0");
        }

        private static void UpdateNukeCommonPackage(Microsoft.Build.Evaluation.Project buildProject, out FloatRange previousPackageVersion)
        {
            var packageItem = buildProject.Items.SingleOrDefault(x => x.EvaluatedInclude == NukeCommonPackageId);
            previousPackageVersion = FloatRange.Parse(packageItem.NotNull().GetMetadataValue("Version"));

            var latestPackageVersion = GetLatestPackageVersion(NukeCommonPackageId, includePrereleases: false).GetAwaiter().GetResult();
            if (previousPackageVersion.Satisfies(NuGetVersion.Parse(latestPackageVersion)))
                return;

            packageItem.SetMetadataValue("Version", latestPackageVersion);
        }

        private static void UpdateConfigurationFile(AbsolutePath rootDirectory)
        {
            var configurationFile = rootDirectory / NukeDirectoryName;
            if (!File.Exists(configurationFile))
                return;

            var solutionFile = rootDirectory / File.ReadLines(configurationFile).FirstOrDefault(x => !x.IsNullOrEmpty());
            File.Delete(configurationFile);

            WriteConfigurationFile(rootDirectory, solutionFile);
            Host.Warning("The previous .nuke file was transformed to a .nuke directory.");
            Host.Warning("The .tmp directory can be cleared, as it is moved to .nuke/temp as well.");
            if (solutionFile != null)
                Host.Warning($"Verify the property referencing the solution has the same name as the member with the {nameof(SolutionAttribute)}.");
        }

        private static void RemoveLegacyFileIncludes(Microsoft.Build.Evaluation.Project buildProject)
        {
            var legacyIncludes =
                new[]
                {
                    "csproj.DotSettings",
                    "build.ps1",
                    "build.sh",
                    ".nuke",
                    "global.json",
                    "nuget.config",
                    "azure-pipelines.yml",
                    "Jenkinsfile",
                    "appveyor.yml",
                    ".travis.yml",
                    "GitVersion.yml"
                };

            buildProject.Xml.Items
                .Where(x => x.ItemType == "None").ToList()
                .Where(x => x.Include.ContainsAnyOrdinalIgnoreCase(legacyIncludes) ||
                            x.Remove.ContainsAnyOrdinalIgnoreCase(legacyIncludes)).ToList()
                .ForEach(x =>
                {
                    var itemGroupElement = x.Parent;
                    itemGroupElement.RemoveChild(x);
                    if (itemGroupElement.Children.Count == 0)
                        itemGroupElement.Parent.RemoveChild(itemGroupElement);
                });
        }

        private static void UpdateGlobalJsonFile(AbsolutePath rootDirectory)
        {
            var latestInstalledSdk = DotNetTasks.DotNet("--list-sdks", logInvocation: false, logOutput: false)
                .LastOrDefault().Text?.Split(" ").First();
            if (latestInstalledSdk == null)
                return;

            var globalJsonFile = rootDirectory / "global.json";
            var jobject = File.Exists(globalJsonFile)
                ? SerializationTasks.JsonDeserializeFromFile<JObject>(globalJsonFile)
                : new JObject();
            jobject["sdk"] ??= new JObject();
            jobject["sdk"].NotNull()["version"] = latestInstalledSdk;
            SerializationTasks.JsonSerializeToFile(jobject, globalJsonFile);
        }
    }
}
