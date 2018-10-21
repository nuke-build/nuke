// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;

namespace Nuke.Common.ProjectModel
{
    [PublicAPI]
    public class Project : PrimitiveProject
    {
        internal Project(
            Solution solution,
            Guid projectId,
            string name,
            string path,
            Guid typeId,
            IDictionary<string, string> configurations)
            : base(solution, projectId, name, typeId)
        {
            Path = (PathConstruction.AbsolutePath) path;
            Configurations = configurations;
        }

        public PathConstruction.AbsolutePath Path { get; }
        public PathConstruction.AbsolutePath Directory => (PathConstruction.AbsolutePath) System.IO.Path.GetDirectoryName(Path).NotNull();
        
        public IDictionary<string, string> Configurations { get; }

        public static implicit operator string(Project project)
        {
            return project.Path;
        }

        internal override string RelativePath => PathConstruction.GetRelativePath(Solution.Directory, Path);
    }
}
