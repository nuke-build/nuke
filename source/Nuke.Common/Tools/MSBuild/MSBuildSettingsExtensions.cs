// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tools.MSBuild
{
    public static partial class MSBuildSettingsExtensions
    {
        /// <summary>Sets <see cref="MSBuildSettings.TargetPath" />.</summary>
        public static MSBuildSettings SetSolutionFile (this MSBuildSettings toolSettings, string solutionFile)
        {
            return toolSettings.SetTargetPath(solutionFile);
        }

        /// <summary>Sets <see cref="MSBuildSettings.TargetPath" />.</summary>
        public static MSBuildSettings SetProjectFile (this MSBuildSettings toolSettings, string projectFile)
        {
            return toolSettings.SetTargetPath(projectFile);
        }

        /// <summary>Sets the configuration in <see cref="MSBuildSettings.Properties"/>.</summary>
        public static MSBuildSettings SetConfiguration (this MSBuildSettings toolSettings, string configuration)
        {
            return toolSettings.SetProperty("configuration", configuration);
        }
    }
}
