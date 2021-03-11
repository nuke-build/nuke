// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.Build.Evaluation;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.ProjectModel
{
    [PublicAPI]
    public static class ProjectModelTasks
    {
        public static Solution CreateSolution(string fileName = null, params Solution[] solutions)
        {
            return CreateSolution(fileName, solutions, folderNameProvider: null);
        }

        public static Solution CreateSolution(
            string fileName = null,
            IEnumerable<Solution> solutions = null,
            Func<Solution, string> folderNameProvider = null,
            bool randomizeProjectIds = true)
        {
            ControlFlow.Assert(folderNameProvider != null || solutions != null, "folderNameProvider != null || solutions!= null");

            var solution = SolutionSerializer.DeserializeFromContent<Solution>(
                new[]
                {
                    "Microsoft Visual Studio Solution File, Format Version 12.00",
                    "# Visual Studio 15",
                    "VisualStudioVersion = 15.0.26124.0",
                    "MinimumVisualStudioVersion = 15.0.26124.0"
                },
                fileName);

            solution.Configurations = new Dictionary<string, string>
                                      {
                                          { "Debug|Any CPU", "Debug|Any CPU" },
                                          { "Release|Any CPU", "Release|Any CPU" }
                                      };

            solutions?.ForEach(x =>
            {
                var folder = folderNameProvider != null && folderNameProvider(x) is { } folderName
                    ? solution.AddSolutionFolder(folderName)
                    : null;

                solution.AddSolution(x, folder);

                if (randomizeProjectIds)
                    solution.RandomizeProjectIds();
            });

            return solution;
        }

        public static Solution ParseSolution(string solutionFile)
        {
            return SolutionSerializer.DeserializeFromFile<Solution>(solutionFile);
        }

        private static Lazy<string> s_msbuildPathResolver = Lazy.Create(() =>
        {
            var dotnet = ToolPathResolver.TryGetEnvironmentExecutable("DOTNET_EXE") ??
                         ToolPathResolver.GetPathExecutable("dotnet");

            string TryFromBasePath()
            {
                var output = ProcessTasks.StartProcess(dotnet, "--info", logOutput: false).AssertZeroExitCode().Output;
                return output
                    .Select(x => x.Text.Trim())
                    .SingleOrDefault(x => x.StartsWith("Base Path:"))
                    ?.TrimStart("Base Path:").Trim();
            }

            string TryFromSdkList()
            {
                var output = ProcessTasks.StartProcess(dotnet, "--list-sdks", logOutput: false).AssertZeroExitCode().Output;
                var latestInstalledSdkParts = output.Last().Text.Split(' ');
                return (AbsolutePath) latestInstalledSdkParts.ElementAt(1).Trim('[', ']') / latestInstalledSdkParts.ElementAt(0);
            }

            var sdkDirectory = (AbsolutePath) (TryFromBasePath() ?? TryFromSdkList());
            return (string) (sdkDirectory / "MSBuild.dll");
        });

        public static Microsoft.Build.Evaluation.Project ParseProject(
            string projectFile,
            string configuration = null,
            string targetFramework = null)
        {
            var msbuildPath = Environment.GetEnvironmentVariable("MSBUILD_EXE_PATH");

            try
            {
                if (string.IsNullOrEmpty(msbuildPath))
                    Environment.SetEnvironmentVariable("MSBUILD_EXE_PATH", s_msbuildPathResolver.Value);

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

                    Logger.Warn($"Project '{projectFile}' has multiple target frameworks ({targetFrameworks.JoinComma()}).");
                    Logger.Warn($"Evaluating using '{targetFramework}'...");

                    msbuildProject = new Microsoft.Build.Evaluation.Project(
                        projectFile,
                        GetProperties(configuration, targetFramework),
                        projectCollection.DefaultToolsVersion,
                        projectCollection);
                }

                return msbuildProject;
            }
            finally
            {
                Environment.SetEnvironmentVariable("MSBUILD_EXE_PATH", msbuildPath);
            }
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
