// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tools.MSBuild;

[PublicAPI]
public class MSBuildVerbosityMappingAttribute : VerbosityMappingAttribute
{
    public MSBuildVerbosityMappingAttribute()
        : base(typeof(MSBuildVerbosity))
    {
        Quiet = nameof(MSBuildVerbosity.Quiet);
        Minimal = nameof(MSBuildVerbosity.Minimal);
        Normal = nameof(MSBuildVerbosity.Minimal);
        Verbose = nameof(MSBuildVerbosity.Detailed);
    }
}

partial class MSBuildTasks
{
    protected override string GetToolPath(ToolOptions options = null)
    {
        var msbuildOptions = options as MSBuildSettings;
        return MSBuildToolPathResolver.Resolve(msbuildOptions?.MSBuildVersion, msbuildOptions?.MSBuildPlatform);
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

partial class MSBuildSettings
{
    [CanBeNull]
    private string FormatPlatform(MSBuildTargetPlatform value, PropertyInfo property)
    {
        if (value == null)
            return null;

        if (Equals(value, MSBuildTargetPlatform.MSIL))
        {
            return TargetPath == null || TargetPath.EndsWithOrdinalIgnoreCase(".sln")
                ? "Any CPU".DoubleQuote()
                : "AnyCPU";
        }

        return value.ToString();
    }
}
