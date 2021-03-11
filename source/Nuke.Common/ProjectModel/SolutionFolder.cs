// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.ProjectModel
{
    [PublicAPI]
    public class SolutionFolder : PrimitiveProject
    {
        internal static readonly Guid Guid = Guid.Parse("2150E333-8FDC-42A3-9474-1A3956D46DE8");

        public SolutionFolder(
            Solution solution,
            Guid projectId,
            string name,
            IDictionary<string, string> items)
            : base(solution, projectId, name, Guid)
        {
            Items = items;
        }

        public IDictionary<string, string> Items { get; set; }

        public IReadOnlyCollection<SolutionFolder> SolutionFolders => Solution.AllSolutionFolders.Where(x => x.SolutionFolder == this).ToList();
        public IReadOnlyCollection<Project> Projects => Solution.AllProjects.Where(x => x.SolutionFolder == this).ToList();

        [CanBeNull]
        public SolutionFolder GetSolutionFolder(string name)
        {
            return SolutionFolders.SingleOrDefault(x => name.Equals(x.Name, StringComparison.Ordinal));
        }

        [CanBeNull]
        public Project GetProject(string name)
        {
            return Projects.SingleOrDefault(x => name.Equals(x.Name, StringComparison.Ordinal));
        }

        internal override string RelativePath => Name;
    }
}
