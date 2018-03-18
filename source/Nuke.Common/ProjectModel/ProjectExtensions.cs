// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.ProjectModel
{
    public static class ProjectExtensions
    {
        public static bool Is(this Project project, ProjectType projectType)
        {
            return projectType.Guids.Any(x => x.Equals(project.TypeId));
        }
    }
}
