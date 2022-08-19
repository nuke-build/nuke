// Copyright 2021 Maintainers of NUKE.
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

        public static string GetOutputType(this Project project)
        {
            var msbuildProject = project.GetMSBuildProject();
            return msbuildProject.GetProperty("OutputType").EvaluatedValue;
        }

        public static bool HasPackageReference(this Project project, string packageId)
        {
            return project.GetItems("PackageReference").Contains(packageId);
        }

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
