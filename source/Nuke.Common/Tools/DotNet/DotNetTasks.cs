// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Serilog.Events;

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

[LogLevelPattern(LogEventLevel.Warning, @": warning \w{2,5}\d{1,5}:")]
[LogLevelPattern(LogEventLevel.Error, @": error \w{2,5}\d{1,5}:")]
partial class DotNetTasks;

public partial class DotNetTasks
{
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
