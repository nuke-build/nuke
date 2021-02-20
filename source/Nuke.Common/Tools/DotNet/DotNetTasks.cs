// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.DotNet
{
    [PublicAPI]
    public class DotNetVerbosityMappingAttribute : VerbosityMappingAttribute
    {
        public DotNetVerbosityMappingAttribute()
            : base(typeof(DotNetVerbosity))
        {
            Quiet = nameof(DotNetVerbosity.Quiet);
            Minimal = nameof(DotNetVerbosity.Minimal);
            Normal = nameof(DotNetVerbosity.Minimal);
            Verbose = nameof(DotNetVerbosity.Detailed);
        }
    }

    partial class DotNetRunSettings
    {
        private string GetApplicationArguments()
        {
            return ApplicationArguments;
        }
    }

    public static partial class DotNetTasks
    {
        // ReSharper disable once CognitiveComplexity
        internal static void CustomLogger(OutputType type, string output)
        {
            if (type == OutputType.Err)
            {
                Logger.Error(output);
                return;
            }

            var spaces = 0;
            for (var i = 0; i < output.Length && spaces < 3; i++)
            {
                if (output[i] == ' ')
                {
                    spaces++;
                    continue;
                }

                if (i >= 4 &&
                    'e' == output[i - 4] &&
                    'r' == output[i - 3] &&
                    'r' == output[i - 2] &&
                    'o' == output[i - 1] &&
                    'r' == output[i])
                {
                    Logger.Error(output);
                    return;
                }

                if (i >= 6 &&
                    'w' == output[i - 6] &&
                    'a' == output[i - 5] &&
                    'r' == output[i - 4] &&
                    'n' == output[i - 3] &&
                    'i' == output[i - 2] &&
                    'n' == output[i - 1] &&
                    'g' == output[i])
                {
                    Logger.Warn(output);
                    return;
                }
            }

            Logger.Normal(output);
        }

        public static string EscapeMSBuild(this string str)
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
