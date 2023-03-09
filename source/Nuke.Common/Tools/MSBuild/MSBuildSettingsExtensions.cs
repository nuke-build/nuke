// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tools.MSBuild
{
    public static partial class MSBuildSettingsExtensions
    {
        /// <summary><em>Sets <see cref="MSBuildSettings.TargetPath" />.</em></summary>
        public static MSBuildSettings SetSolutionFile(this MSBuildSettings toolSettings, string solutionFile)
        {
            return toolSettings.SetTargetPath(solutionFile);
        }

        /// <summary><em>Sets <see cref="MSBuildSettings.TargetPath" />.</em></summary>
        public static MSBuildSettings SetProjectFile(this MSBuildSettings toolSettings, string projectFile)
        {
            return toolSettings.SetTargetPath(projectFile);
        }
    }
}
