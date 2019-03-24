// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Common.IO;

namespace Nuke.Common.ProjectModel
{
    [PublicAPI]
    public class Solution
    {
        internal List<PrimitiveProject> PrimitiveProjects { get; } = new List<PrimitiveProject>();
        internal Dictionary<PrimitiveProject, SolutionFolder> PrimitiveProjectParents { get; } = new Dictionary<PrimitiveProject, SolutionFolder>();

        [CanBeNull]
        public PathConstruction.AbsolutePath Path { get; set; }

        [CanBeNull]
        public string Name => System.IO.Path.GetFileNameWithoutExtension(Path);

        [CanBeNull]
        public string FileName => System.IO.Path.GetFileName(Path);

        [CanBeNull]
        public PathConstruction.AbsolutePath Directory => Path?.Parent;

        public string[] Header { get; set; }
        public IDictionary<string, string> Properties { get; set; }
        public IDictionary<string, string> ExtensibilityGlobals { get; set; }
        public IDictionary<string, string> Configurations { get; set; }

        public IReadOnlyCollection<Project> AllProjects => PrimitiveProjects.OfType<Project>().ToList();
        public IReadOnlyCollection<SolutionFolder> AllSolutionFolders => PrimitiveProjects.OfType<SolutionFolder>().ToList();

        public IReadOnlyCollection<Project> Projects => AllProjects.Where(x => x.SolutionFolder == null).ToList();
        public IReadOnlyCollection<SolutionFolder> SolutionFolders => AllSolutionFolders.Where(x => x.SolutionFolder == null).ToList();

        public static implicit operator string(Solution solution)
        {
            return solution.Path;
        }

        public override string ToString()
        {
            return Path ?? "<in-memory solution>";
        }

        [CanBeNull]
        public SolutionFolder GetSolutionFolder(string name)
        {
            return AllSolutionFolders.SingleOrDefault(x => name.Equals(x.Name, StringComparison.Ordinal));
        }

        [CanBeNull]
        public Project GetProject(string name)
        {
            return AllProjects.SingleOrDefault(x => name.Equals(x.Name, StringComparison.Ordinal));
        }

        public IEnumerable<Project> GetProjects(string wildcardPattern)
        {
            wildcardPattern = $"^{wildcardPattern}$";
            var regex = new Regex(wildcardPattern
                .Replace(".", "\\.")
                .Replace("*", ".*"));
            return AllProjects.Where(x => regex.IsMatch(x.Name));
        }

        public SolutionFolder AddSolutionFolder(string name, Guid? projectId = null, SolutionFolder solutionFolder = null)
        {
            projectId = projectId ?? Guid.NewGuid();
            var project = new SolutionFolder(this, projectId.Value, name, items: new Dictionary<string, string>());
            AddPrimitiveProject(project, solutionFolder);
            return project;
        }

        public Project AddProject(
            string name,
            Guid typeId,
            string path,
            Guid? projectId = null,
            IDictionary<string, string> configurationPlatforms = null,
            SolutionFolder solutionFolder = null)
        {
            projectId = projectId ?? Guid.NewGuid();
            var project = new Project(this, projectId.Value, name, path, typeId, configurationPlatforms ?? new Dictionary<string, string>());
            AddPrimitiveProject(project, solutionFolder);
            return project;
        }

        internal void AddPrimitiveProject(PrimitiveProject primitiveProject, SolutionFolder solutionFolder = null)
        {
            var otherProject = PrimitiveProjects.FirstOrDefault(x => x.ProjectId.Equals(primitiveProject.ProjectId));
            ControlFlow.Assert(otherProject == null,
                $"Cannot add '{primitiveProject.Name}' because its id '{primitiveProject.ProjectId}' is already taken by '{otherProject?.Name}'.");

            PrimitiveProjects.Add(primitiveProject);
            PrimitiveProjectParents.Add(primitiveProject, solutionFolder);
        }

        public IReadOnlyCollection<PrimitiveProject> RemoveSolutionFolder(SolutionFolder solutionFolder)
        {
            var children = GetNestedPrimitiveProjects(solutionFolder);
            foreach (var child in children)
                SetSolutionFolder(solutionFolder.SolutionFolder, child);

            PrimitiveProjects.Remove(solutionFolder);

            return children;
        }

        internal IReadOnlyCollection<PrimitiveProject> GetNestedPrimitiveProjects(SolutionFolder solutionFolder)
        {
            return PrimitiveProjectParents.Where(x => x.Value == solutionFolder).Select(x => x.Key).ToList();
        }

        public void RemoveProject(Project project)
        {
            PrimitiveProjects.Remove(project);
            PrimitiveProjectParents.Remove(project);
        }

        [CanBeNull]
        internal SolutionFolder GetSolutionFolder(PrimitiveProject primitiveProject)
        {
            return PrimitiveProjectParents.TryGetValue(primitiveProject, out var parent) ? parent : null;
        }

        internal void SetSolutionFolder([CanBeNull] SolutionFolder solutionFolder, PrimitiveProject primitiveProject)
        {
            ControlFlow.Assert(solutionFolder == null || solutionFolder.Solution == primitiveProject.Solution,
                "Project and solution folder must belong to the same solution.");

            PrimitiveProjectParents[primitiveProject] = solutionFolder;
        }

        public void SaveAs(string fileName)
        {
            Path = (PathConstruction.AbsolutePath) fileName;
            Save();
        }

        public void Save()
        {
            SolutionSerializer.Serialize(this);
        }
    }
}
