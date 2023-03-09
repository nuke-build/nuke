// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Locator;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Serilog;
#pragma warning disable CA2255

namespace Nuke.Common.ProjectModel
{
    [PublicAPI]
    public static class ProjectModelTasks
    {
        // TODO: Remove usages
        // https://docs.microsoft.com/en-us/visualstudio/msbuild/updating-an-existing-application?view=vs-2019#use-microsoftbuildlocator
        [ModuleInitializer]
        public static void Initialize()
        {
            if (!MSBuildLocator.CanRegister)
                return;

            var msbuildExtensionPath = Environment.GetEnvironmentVariable("MSBuildExtensionsPath");
            var msbuildExePath = Environment.GetEnvironmentVariable("MSBUILD_EXE_PATH");
            var msbuildSdkPath = Environment.GetEnvironmentVariable("MSBuildSDKsPath");

            static void RegisterMSBuildFromDotNet()
            {
                var dotnet = ToolResolver.GetEnvironmentOrPathTool("dotnet");

                string TryFromBasePath()
                {
                    var output = dotnet.Invoke($"--info", logInvocation: false, logOutput: false);
                    return output
                        .Select(x => x.Text.Trim())
                        .SingleOrDefault(x => x.StartsWith("Base Path:"))
                        ?.TrimStart("Base Path:").Trim();
                }

                string TryFromSdkList()
                {
                    var output = dotnet.Invoke($"--list-sdks", logInvocation: false, logOutput: false);
                    var latestInstalledSdkParts = output.Last().Text.Split(' ');
                    return (AbsolutePath)latestInstalledSdkParts.ElementAt(1).Trim('[', ']') / latestInstalledSdkParts.ElementAt(0);
                }

                var sdkDirectory = (AbsolutePath)(TryFromBasePath() ?? TryFromSdkList());
                MSBuildLocator.RegisterMSBuildPath(sdkDirectory);
            }

            static void TriggerAssemblyResolution()
            {
                var _ = new ProjectCollection();
            }

            try
            {
                try
                {
                    MSBuildLocator.RegisterDefaults();
                }
                catch (Exception)
                {
                    Log.Warning($"Attempting second-chance registration of MSBuild after {nameof(MSBuildLocator.RegisterDefaults)} failed");
                    RegisterMSBuildFromDotNet();
                }

                TriggerAssemblyResolution();
            }
            catch (Exception exception)
            {
                Log.Warning("Could not register MSBuild: {Message}", exception.Message);
            }
            finally
            {
                Environment.SetEnvironmentVariable("MSBuildExtensionsPath", msbuildExtensionPath);
                Environment.SetEnvironmentVariable("MSBUILD_EXE_PATH", msbuildExePath);
                Environment.SetEnvironmentVariable("MSBuildSDKsPath", msbuildSdkPath);
            }
        }

        public static Microsoft.Build.Evaluation.Project ParseProject(
            string projectFile,
            string configuration = null,
            string targetFramework = null)
        {
            var projectCollection = new ProjectCollection();
            var projectRoot = Microsoft.Build.Construction.ProjectRootElement.Open(projectFile, projectCollection, preserveFormatting: true);
            var msbuildProject = Microsoft.Build.Evaluation.Project.FromProjectRootElement(projectRoot,
                new Microsoft.Build.Definition.ProjectOptions
                {
                    GlobalProperties = GetProperties(configuration, targetFramework),
                    ToolsVersion = projectCollection.DefaultToolsVersion,
                    ProjectCollection = projectCollection
                });

            var targetFrameworks = msbuildProject.AllEvaluatedItems
                .Where(x => x.ItemType == "_TargetFrameworks")
                .Select(x => x.EvaluatedInclude)
                .OrderBy(x => x).ToList();

            if (targetFramework == null && targetFrameworks.Count > 1)
            {
                projectCollection.UnloadProject(msbuildProject);
                targetFramework = targetFrameworks.First();

                Log.Warning("Project {Project} has multiple target frameworks {TargetFrameworks}", projectFile, targetFrameworks.JoinCommaSpace());
                Log.Warning("Evaluating using {TargetFramework} ...", targetFramework);

                msbuildProject = new Microsoft.Build.Evaluation.Project(
                    projectFile,
                    GetProperties(configuration, targetFramework),
                    projectCollection.DefaultToolsVersion,
                    projectCollection);
            }

            return msbuildProject;
        }

        [Obsolete($"Use {nameof(SolutionModelTasks)}")]
        public static Solution CreateSolution(string fileName = null, params Solution[] solutions)
        {
            return SolutionModelTasks.CreateSolution(fileName, solutions);
        }

        [Obsolete($"Use {nameof(SolutionModelTasks)}")]
        public static Solution CreateSolution(
            string fileName = null,
            IEnumerable<Solution> solutions = null,
            Func<Solution, string> folderNameProvider = null,
            bool randomizeProjectIds = true)
        {
            return SolutionModelTasks.CreateSolution(fileName, solutions, folderNameProvider, randomizeProjectIds);
        }

        [Obsolete($"Use {nameof(SolutionModelTasks)}")]
        public static Solution ParseSolution(string solutionFile)
        {
            return SolutionModelTasks.ParseSolution(solutionFile);
        }

        private static Dictionary<string, string> GetProperties([CanBeNull] string configuration, [CanBeNull] string targetFramework)
        {
            var properties = new Dictionary<string, string>();
            if (configuration != null)
                properties.Add("Configuration", configuration);
            if (targetFramework != null)
                properties.Add("TargetFramework", targetFramework);
            return properties;
        }
    }
}
