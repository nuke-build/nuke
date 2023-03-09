// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.ProjectModel
{
    public static partial class ProjectExtensions
    {
        /// <summary>
        /// Returns all included items of a project, including <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-items">
        /// common MSBuild project items</a> and custom items defined in
        /// <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/itemgroup-element-msbuild"><c>ItemGroup</c> elements</a>.
        /// </summary>
        public static IEnumerable<string> GetItems(this Project project, string itemGroupName)
        {
            var items = project.GetMSBuildProject().GetItems(itemGroupName);
            return items.Select(x => x.EvaluatedInclude);
        }

        /// <summary>
        /// Returns all converted items of a project, including <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-items">
        /// common MSBuild project items</a> and custom items defined in
        /// <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/itemgroup-element-msbuild"><c>ItemGroup</c> elements</a>.
        /// </summary>
        public static IEnumerable<T> GetItems<T>(this Project project, string itemGroupName)
        {
            return project.GetItems(itemGroupName).Select(ReflectionUtility.Convert<T>);
        }

        /// <summary>
        /// Returns the metadata of all included items of a project, including <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-items">
        /// common MSBuild project items</a> and custom items defined in
        /// <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/itemgroup-element-msbuild"><c>ItemGroup</c> elements</a>.
        /// </summary>
        public static IEnumerable<string> GetItemMetadata(this Project project, string itemGroupName, string metadataName)
        {
            var items = project.GetMSBuildProject().GetItems(itemGroupName);
            return items.Select(x => x.GetMetadataValue(metadataName));
        }

        /// <summary>
        /// Returns the converted metadata of all included items of a project, including <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-items">
        /// common MSBuild project items</a> and custom items defined in
        /// <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/itemgroup-element-msbuild"><c>ItemGroup</c> elements</a>.
        /// </summary>
        public static IEnumerable<T> GetItemMetadata<T>(this Project project, string itemGroupName, string metadataName)
        {
            return project.GetItemMetadata(itemGroupName, metadataName).Select(ReflectionUtility.Convert<T>);
        }

        [CanBeNull]
        public static string GetItemMetadataSingleOrDefault(this Project project, string itemGroupName, string includeName, string metadataName)
        {
            var items = project.GetMSBuildProject().GetItems(itemGroupName);
            return items.SingleOrDefault(x => x.EvaluatedInclude == includeName)?.GetMetadataValue(metadataName);
        }

        [CanBeNull]
        public static T GetItemMetadataSingleOrDefault<T>(this Project project, string itemGroupName, string includeName, string metadataName)
        {
            return ReflectionUtility.Convert<T>(project.GetItemMetadataSingleOrDefault(itemGroupName, includeName, metadataName));
        }
    }
}
