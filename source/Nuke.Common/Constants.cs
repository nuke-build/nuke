// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using Nuke.Common.IO;

namespace Nuke.Common
{
    internal class Constants
    {
        internal const string ConfigurationFileName = ".nuke";
        
        internal const string TargetsSeparator = "+";
        internal const string InvokedTargetsParameterName = "Target";
        internal const string SkippedTargetsParameterName = "Skip";
        
        internal const string CompletionParameterName = "shell-completion";

        internal static PathConstruction.AbsolutePath GetTemporaryDirectory(PathConstruction.AbsolutePath rootDirectory)
        {
            return rootDirectory / ".tmp";
        }

        internal static PathConstruction.AbsolutePath GetCompletionFile(PathConstruction.AbsolutePath rootDirectory)
        {
            var completionFileName = CompletionParameterName + ".yml";
            return File.Exists(rootDirectory / completionFileName)
                ? rootDirectory / completionFileName
                : GetTemporaryDirectory(rootDirectory) / completionFileName;
        }
        
        internal static PathConstruction.AbsolutePath GetBuildAttemptFile(PathConstruction.AbsolutePath rootDirectory)
        {
            return GetTemporaryDirectory(rootDirectory) / "build-attempt.log";
        }
    }
}
