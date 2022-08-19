// Copyright 2022 Maintainers of NUKE.
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
        public static IEnumerable<string> GetItems(this Project project, string itemGroupName)
        {
            var items = project.GetMSBuildProject().GetItems(itemGroupName);
            return items.Select(x => x.EvaluatedInclude);
        }

        public static IEnumerable<T> GetItems<T>(this Project project, string itemGroupName)
        {
            return project.GetItems(itemGroupName).Select(ReflectionUtility.Convert<T>);
        }

        public static IEnumerable<string> GetItemMetadata(this Project project, string itemGroupName, string metadataName)
        {
            var items = project.GetMSBuildProject().GetItems(itemGroupName);
            return items.Select(x => x.GetMetadataValue(metadataName));
        }

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
