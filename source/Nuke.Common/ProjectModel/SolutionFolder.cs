// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.ProjectModel
{
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

        public IDictionary<string, string> Items { get; }

        internal override string RelativePath => Name;
    }
}
