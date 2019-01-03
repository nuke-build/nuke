// Copyright 2018 Maintainers of NUKE.
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

namespace Nuke.Common.ProjectModel
{
    [PublicAPI]
    public static class ProjectExtensions
    {
        private static void Initialize(string workingDirectory)
        {
            var dotnet = ToolPathResolver.TryGetEnvironmentExecutable("DOTNET_EXE") ??
                         ToolPathResolver.GetPathExecutable("dotnet");
            var output = ProcessTasks.StartProcess(dotnet, "--info", workingDirectory, logOutput: false).AssertZeroExitCode().Output;
            var basePath = (PathConstruction.AbsolutePath) output
                .Select(x => x.Text.Trim())
                .Single(x => x.StartsWith("Base Path:"))
                .TrimStart("Base Path:").Trim();

            EnvironmentInfo.SetVariable("MSBUILD_EXE_PATH", basePath / "MSBuild.dll");
        }

        public static Microsoft.Build.Evaluation.Project GetMSBuildProject(
            this Project project,
            string configuration = null,
            string targetFramework = null)
        {
            Initialize(project.Directory);

            var projectCollection = new ProjectCollection();
            var msbuildProject = new Microsoft.Build.Evaluation.Project(
                project.Path,
                GetProperties(configuration, targetFramework),
                projectCollection.DefaultToolsVersion,
                projectCollection);
            var targetFrameworks = msbuildProject.AllEvaluatedItems
                .Where(x => x.ItemType == "_TargetFrameworks")
                .Select(x => x.EvaluatedInclude)
                .OrderBy(x => x).ToList();

            if (targetFramework == null && targetFrameworks.Count > 1)
            {
                projectCollection.UnloadProject(msbuildProject);
                targetFramework = targetFrameworks.First();

                Logger.Warn($"Project '{project.Path}' has multiple target frameworks ({targetFrameworks.JoinComma()}).");
                Logger.Warn($"Evaluating using '{targetFramework}'...");

                msbuildProject = new Microsoft.Build.Evaluation.Project(
                    project.Path,
                    GetProperties(configuration, targetFramework),
                    projectCollection.DefaultToolsVersion,
                    projectCollection);
            }

            return msbuildProject;
        }

        [CanBeNull]
        public static string GetProperty(this Project project, string propertyName)
        {
            var property = project.GetMSBuildProject().GetProperty(propertyName);
            return property?.EvaluatedValue;
        }

        [CanBeNull]
        public static IEnumerable<string> GetItemIncludes(this Project project, string itemGroupName)
        {
            var items = project.GetMSBuildProject().GetItems(itemGroupName);
            return items.Select(x => x.EvaluatedInclude);
        }

        public static IReadOnlyCollection<string> GetTargetFrameworks(this Microsoft.Build.Evaluation.Project project)
        {
            var targetFrameworkProperty = project.GetProperty("TargetFramework");
            if (targetFrameworkProperty != null)
                return new[]{ targetFrameworkProperty.EvaluatedValue };
            
            var targetFrameworksProperty = project.GetProperty("TargetFrameworks");
            if (targetFrameworksProperty != null)
                return targetFrameworksProperty.EvaluatedValue.Split(';');

            return new string[0];
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
