// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tools.MSBuild
{
    public static partial class MSBuildSettingsExtensions
    {
        /// <summary>Sets <see cref="MSBuildSettings.TargetPath" />.</summary>
        public static MSBuildSettings SetSolutionFile (this MSBuildSettings msbuildSettings, string solutionFile)
        {
            return msbuildSettings.SetTargetPath(solutionFile);
        }

        /// <summary>Sets <see cref="MSBuildSettings.TargetPath" />.</summary>
        public static MSBuildSettings SetProjectFile (this MSBuildSettings msbuildSettings, string projectFile)
        {
            return msbuildSettings.SetTargetPath(projectFile);
        }

        public static MSBuildSettings SetConfiguration(this MSBuildSettings msbuildSettings, string configuration)
        {
            return msbuildSettings.SetProperty("configuration", configuration);
        }
    }
}
