// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.ProjectModel
{
    public static partial class ProjectExtensions
    {
        [CanBeNull]
        public static string GetProperty(this Project project, string propertyName)
        {
            var property = project.GetMSBuildProject().GetProperty(propertyName);
            return property?.EvaluatedValue;
        }

        [CanBeNull]
        public static T GetProperty<T>(this Project project, string propertyName)
        {
            return ReflectionUtility.Convert<T>(project.GetProperty(propertyName));
        }
    }
}
