// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.ProjectModel
{
    public static partial class ProjectExtensions
    {
        /// <summary>
        /// Returns the value of a project property, including <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties">
        /// common MSBuild project properties</a> and custom properties defined in
        /// <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/propertygroup-element-msbuild"><c>PropertyGroup</c> elements</a>.
        /// </summary>
        [CanBeNull]
        public static string GetProperty(this Project project, string propertyName)
        {
            var property = project.GetMSBuildProject().GetProperty(propertyName);
            return property?.EvaluatedValue;
        }

        /// <summary>
        /// Returns the converted value of a project property, including <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties">
        /// common MSBuild project properties</a> and custom properties defined in
        /// <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/propertygroup-element-msbuild"><c>PropertyGroup</c> elements</a>.
        /// </summary>
        [CanBeNull]
        public static T GetProperty<T>(this Project project, string propertyName)
        {
            return ReflectionUtility.Convert<T>(project.GetProperty(propertyName));
        }
    }
}
