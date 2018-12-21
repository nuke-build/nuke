﻿// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;

namespace Nuke.Common.ProjectModel
{
    [PublicAPI]
    public static class ProjectModelTasks
    {
        public static Solution ParseSolution(string solutionFile)
        {
            return SolutionSerializer.Deserialize(solutionFile);
        }
    }
}
