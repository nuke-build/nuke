// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Core;

namespace Nuke.Common.ProjectModel
{
    [PublicAPI]
    public static class ProjectModelTasks
    {
        public static Solution ParseSolution(string solutionFile, string configuration = null, string targetFramework = null)
        {
            string GuidPattern(string text)
                => $@"\{{(?<{Regex.Escape(text)}>[0-9a-fA-F]{{8}}-[0-9a-fA-F]{{4}}-[0-9a-fA-F]{{4}}-[0-9a-fA-F]{{4}}-[0-9a-fA-F]{{12}})\}}";

            string TextPattern(string name)
                => $@"""(?<{Regex.Escape(name)}>[^""]*)""";

            string ProjectPattern()
                => $@"^Project\(""{GuidPattern("typeId")}""\)\s*=\s*{TextPattern("name")},\s*{TextPattern("path")},\s*""{GuidPattern("id")}""$";

            var lines = File.ReadAllLines(solutionFile);

            var childToParent = lines
                .SkipWhile(x => !Regex.IsMatch(x, @"^\s*GlobalSection\(NestedProjects\) = preSolution$"))
                .Skip(count: 1)
                .TakeWhile(x => !Regex.IsMatch(x, @"^\s*EndGlobalSection$"))
                .Select(x => Regex.Match(x, $@"^\s*{GuidPattern("child")}\s*=\s*{GuidPattern("parent")}$"))
                .ToDictionary(x => Guid.Parse(x.Groups["child"].Value), x => Guid.Parse(x.Groups["parent"].Value));

            var projectData = lines
                .Select(x => Regex.Match(x, ProjectPattern()))
                .Where(x => x.Success)
                .Select(x =>
                    new
                    {
                        Id = Guid.Parse(x.Groups["id"].Value),
                        Name = x.Groups["name"].Value,
                        TypeId = Guid.Parse(x.Groups["typeId"].Value),
                        Path = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(solutionFile).NotNull(), x.Groups["path"].Value))
                    }).ToList();

            var projects = new List<Project>();
            while (projectData.Count > 0)
            {
                var data = projectData.First();
                projectData.Remove(data);

                Project parent = null;
                if (childToParent.TryGetValue(data.Id, out var parentId))
                {
                    parent = projects.SingleOrDefault(x => x.Id == parentId);
                    if (parent == null)
                    {
                        projectData.Add(data);
                        continue;
                    }
                }

                projects.Add(new Project(data.Id, data.Name, data.Path, data.TypeId, parent, configuration, targetFramework));
            }

            return new Solution(solutionFile, projects.AsReadOnly());
        }
    }
}
