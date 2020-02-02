// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.ProjectModel
{
    [PublicAPI]
    public class Solution
    {
        internal List<PrimitiveProject> PrimitiveProjects { get; } = new List<PrimitiveProject>();
        internal Dictionary<PrimitiveProject, SolutionFolder> PrimitiveProjectParents { get; } = new Dictionary<PrimitiveProject, SolutionFolder>();

        [CanBeNull]
        public AbsolutePath Path { get; internal set; }

        [CanBeNull]
        public string Name => System.IO.Path.GetFileNameWithoutExtension(Path);

        [CanBeNull]
        public string FileName => System.IO.Path.GetFileName(Path);

        [CanBeNull]
        public AbsolutePath Directory => Path?.Parent;

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

        public SolutionFolder GetSolutionFolder(Guid projectId)
        {
            return AllSolutionFolders.Single(x => x.ProjectId == projectId);
        }

        public Project GetProject(Guid projectId)
        {
            return AllProjects.Single(x => x.ProjectId == projectId);
        }

        [CanBeNull]
        public SolutionFolder GetSolutionFolder(string name)
        {
            return AllSolutionFolders.SingleOrDefault(x => name.Equals(x.Name, StringComparison.Ordinal));
        }

        [CanBeNull]
        public Project GetProject(string nameOrFullPath)
        {
            return AllProjects.SingleOrDefault(x => nameOrFullPath.Equals(x.Name, StringComparison.Ordinal)) ??
                   AllProjects.SingleOrDefault(x => x.Path.ToString().EqualsOrdinalIgnoreCase(nameOrFullPath));
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
            projectId ??= Guid.NewGuid();
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
            projectId ??= Guid.NewGuid();
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
            Path = (AbsolutePath) fileName;
            Save();
        }

        public void Save()
        {
            SolutionSerializer.Serialize(this);
        }

        public void AddSolution(Solution solution, SolutionFolder folder = null)
        {
            SolutionFolder GetParentFolder(PrimitiveProject solutionFolder) =>
                AllSolutionFolders.FirstOrDefault(x => x.ProjectId == solutionFolder.SolutionFolder?.ProjectId);

            IDictionary<string, string> GetItems(SolutionFolder solutionFolder)
                => solutionFolder.Items.Keys
                    .Select(x => (string) PathConstruction.GetWinRelativePath(Directory, solution.Directory / x))
                    .ToDictionary(x => x, x => x);

            solution.AllSolutionFolders.ForEach(x => AddSolutionFolder(x.Name, x.ProjectId, GetParentFolder(x) ?? folder));
            solution.AllSolutionFolders.ForEach(x => GetSolutionFolder(x.ProjectId).Items = GetItems(x));
            solution.AllProjects.ForEach(x => AddProject(x.Name, x.TypeId, x.Path, x.ProjectId, x.Configurations, GetParentFolder(x) ?? folder));
        }

        public void RandomizeProjectIds()
        {
            AllSolutionFolders.ForEach(x => x.ProjectId = Guid.NewGuid());
            AllProjects.ForEach(x => x.ProjectId = Guid.NewGuid());
        }
    }
}
