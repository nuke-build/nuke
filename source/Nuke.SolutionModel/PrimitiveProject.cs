// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.ProjectModel
{
    /// <summary>
    /// Abstraction for <see cref="Project"/> and <see cref="SolutionFolder"/>.
    /// </summary>
    [PublicAPI]
    public abstract class PrimitiveProject
    {
        protected PrimitiveProject(
            Solution solution,
            Guid projectId,
            string name,
            Guid typeId)
        {
            Solution = solution;
            ProjectId = projectId;
            Name = name;
            TypeId = typeId;
        }

        public Solution Solution { get; }
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public Guid TypeId { get; set; }

        /// <summary>
        /// Returns the parent <see cref="SolutionFolder"/>.
        /// </summary>
        public SolutionFolder SolutionFolder
        {
            get => Solution.GetSolutionFolder(this);
            set => Solution.SetSolutionFolder(value, this);
        }

        internal abstract string RelativePath { get; }

        public bool Is(ProjectType projectType)
        {
            return projectType.Guids.Any(x => x.Equals(TypeId));
        }
    }
}
