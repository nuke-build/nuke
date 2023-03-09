// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.ProjectModel
{
    [PublicAPI]
    public static partial class ProjectExtensions
    {
        static ProjectExtensions()
        {
            ProjectModelTasks.Initialize();
        }

        /// <summary>
        /// Returns the <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-target-framework-and-target-platform">
        /// target frameworks</a> of the project.
        /// </summary>
        [CanBeNull]
        public static IReadOnlyCollection<string> GetTargetFrameworks(this Project project)
        {
            return project.GetSplittedPropertyValue("TargetFramework", "TargetFrameworks");
        }

        /// <summary>
        /// Returns the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">runtime identifiers</a> of the project.
        /// </summary>
        [CanBeNull]
        public static IReadOnlyCollection<string> GetRuntimeIdentifiers(this Project project)
        {
            return project.GetSplittedPropertyValue("RuntimeIdentifier", "RuntimeIdentifiers");
        }

        /// <summary>
        /// Returns the output type (<c>library</c>, <c>exe</c>, <c>module</c>, ...) of the project.
        /// </summary>
        public static string GetOutputType(this Project project)
        {
            var msbuildProject = project.GetMSBuildProject();
            return msbuildProject.GetProperty("OutputType").EvaluatedValue;
        }

        /// <summary>
        /// Indicates whether the project references a package ID.
        /// </summary>
        public static bool HasPackageReference(this Project project, string packageId)
        {
            return project.GetItems("PackageReference").Contains(packageId);
        }

        /// <summary>
        /// Returns the version of the referenced package ID.
        /// </summary>
        public static string GetPackageReferenceVersion(this Project project, string packageId)
        {
            return project.GetItemMetadataSingleOrDefault("PackageReference", packageId, "Version");
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
    }
}
