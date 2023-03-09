// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tools.MSBuild
{
    partial class MSBuildTasks
    {
        private static string GetToolPath()
        {
            return MSBuildToolPathResolver.Resolve();
        }

        public static string EscapeMSBuild(string str)
        {
            // https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-special-characters
            return str
                .Replace("%", "%25")  // Referencing metadata
                .Replace("$", "%24")  // Referencing properties
                .Replace("@", "%40")  // Referencing item lists
                .Replace("'", "%27")  // Conditions and other expressions
                .Replace(";", "%3B")  // List separator
                .Replace("?", "%3F")  // Wildcard character for file names in Include and Exclude attributes
                .Replace("*", "%2A"); // Wildcard character for use in file names in Include and Exclude attributes
        }
    }
}
