// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Core;

namespace Nuke.Common.ProjectModel
{
    [PublicAPI]
    public class Solution
    {
        internal Solution(string path, IReadOnlyCollection<Project> projects)
        {
            Path = path;
            Projects = projects;
        }

        public string Path { get; }
        public IReadOnlyCollection<Project> Projects { get; }

        public static implicit operator string(Solution solution)
        {
            return solution.Path;
        }

        [CanBeNull]
        public Project GetProject(string wildcardPattern)
        {
            var projects = GetProjects(wildcardPattern).ToList();
            ControlFlow.Assert(projects.Count <= 1, "projects.Count <= 1");
            return projects.SingleOrDefault();
        }

        public IEnumerable<Project> GetProjects(string wildcardPattern)
        {
            wildcardPattern = $"^{wildcardPattern}$";
            var regex = new Regex(wildcardPattern
                .Replace(".", "\\.")
                .Replace("*", ".*"));
            return Projects.Where(x => regex.IsMatch(x.Name));
        }
    }
}
