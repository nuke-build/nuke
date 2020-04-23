// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.ProjectModel
{
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
