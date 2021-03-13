// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using static Nuke.Common.Utilities.ReflectionUtility;

namespace Nuke.Common.ProjectModel
{
    [PublicAPI]
    public static class ProjectExtensions
    {
        public static Microsoft.Build.Evaluation.Project GetMSBuildProject(
            this Project project,
            string configuration = null,
            string targetFramework = null)
        {
            return ProjectModelTasks.ParseProject(project.Path, configuration, targetFramework);
        }

        [CanBeNull]
        public static string GetProperty(this Project project, string propertyName)
        {
            var property = project.GetMSBuildProject().GetProperty(propertyName);
            return property?.EvaluatedValue;
        }

        [CanBeNull]
        public static T GetProperty<T>(this Project project, string propertyName)
        {
            return Convert<T>(project.GetProperty(propertyName));
        }

        public static IEnumerable<string> GetItems(this Project project, string itemGroupName)
        {
            var items = project.GetMSBuildProject().GetItems(itemGroupName);
            return items.Select(x => x.EvaluatedInclude);
        }

        public static IEnumerable<T> GetItems<T>(this Project project, string itemGroupName)
        {
            return project.GetItems(itemGroupName).Select(Convert<T>);
        }

        public static IEnumerable<string> GetItemMetadata(this Project project, string itemGroupName, string metadataName)
        {
            var items = project.GetMSBuildProject().GetItems(itemGroupName);
            return items.Select(x => x.GetMetadataValue(metadataName));
        }

        public static IEnumerable<T> GetItemMetadata<T>(this Project project, string itemGroupName, string metadataName)
        {
            return project.GetItemMetadata(itemGroupName, metadataName).Select(Convert<T>);
        }

        [CanBeNull]
        public static IReadOnlyCollection<string> GetTargetFrameworks(this Project project)
        {
            return project.GetSplittedPropertyValue("TargetFramework", "TargetFrameworks");
        }

        [CanBeNull]
        public static IReadOnlyCollection<string> GetRuntimeIdentifiers(this Project project)
        {
            return project.GetSplittedPropertyValue("RuntimeIdentifier", "RuntimeIdentifiers");
        }

        [CanBeNull]
        private static IReadOnlyCollection<string> GetSplittedPropertyValue(
            this Project project,
            params string[] names)
        {
            var msbuildProject = project.GetMSBuildProject();
            foreach (var name in names)
            {
                var property = msbuildProject.GetProperty(name);
                if (property != null)
                    return property.EvaluatedValue.Split(';');
            }

            return null;
        }

        public static string GetOutputType(this Project project)
        {
            var msbuildProject = project.GetMSBuildProject();
            return msbuildProject.GetProperty("OutputType").EvaluatedValue;
        }
    }
}
