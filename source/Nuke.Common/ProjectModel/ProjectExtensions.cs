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
    }
}
