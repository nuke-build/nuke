// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.ProjectModel
{
    [PublicAPI]
    [DebuggerDisplay("{" + nameof(Path) + "}")]
    public class Project
    {
        internal Project(
            Guid id,
            string name,
            string path,
            Guid typeId,
            [CanBeNull] Project parent,
            [CanBeNull] string configuration,
            [CanBeNull] string targetFramework)
        {
            Id = id;
            Name = name;
            Path = path;
            TypeId = typeId;
            Parent = parent;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Path { get; }
        public Guid TypeId { get; }

        [CanBeNull]
        public Project Parent { get; }

        public static implicit operator string(Project project)
        {
            return project.Path;
        }
    }
}
