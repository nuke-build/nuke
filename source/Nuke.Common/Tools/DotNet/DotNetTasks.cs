// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Serilog;

namespace Nuke.Common.Tools.DotNet;

[PublicAPI]
public class DotNetVerbosityMappingAttribute : VerbosityMappingAttribute
{
    public DotNetVerbosityMappingAttribute()
        : base(typeof(DotNetVerbosity))
    {
        Quiet = nameof(DotNetVerbosity.quiet);
        Minimal = nameof(DotNetVerbosity.minimal);
        Normal = nameof(DotNetVerbosity.minimal);
        Verbose = nameof(DotNetVerbosity.detailed);
    }
}

partial class DotNetRunSettings
{
    private string GetApplicationArguments()
    {
        return ApplicationArguments;
    }
}

public partial class DotNetTasks
{
    // ReSharper disable once CognitiveComplexity
    internal static void CustomLogger(OutputType type, string output)
    {
        if (type == OutputType.Err)
        {
            Log.Error(output);
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
                Log.Error(output);
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
                Log.Warning(output);
                return;
            }
        }

        Log.Debug(output);
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
