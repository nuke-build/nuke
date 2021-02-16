// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.Common
{
    internal static class Constants
    {
        internal static readonly string[] KnownWords =
        {
            "GitHub",
            "GitVersion",
            "MSBuild",
            "NuGet",
            "ReSharper",
            "AppVeyor",
            "TeamCity",
            "GitLab"
        };

        internal const string ConfigurationFileName = ".nuke";

        internal const string TargetsSeparator = "+";
        internal const string InvokedTargetsParameterName = "Target";
        internal const string SkippedTargetsParameterName = "Skip";
        internal const string LoadedLocalProfilesParameterName = "Profile";

        public const string VisualStudioDebugParameterName = "visual-studio-debug";
        internal const string CompletionParameterName = "shell-completion";
        internal const string ParametersFilePrefix = "parameters";

        internal static AbsolutePath GlobalTemporaryDirectory => (AbsolutePath) Path.GetTempPath();

        [CanBeNull]
        internal static AbsolutePath TryGetRootDirectoryFrom(string startDirectory)
        {
            return (AbsolutePath) FileSystemTasks.FindParentDirectory(
                startDirectory,
                predicate: x => x.GetFiles(ConfigurationFileName).Any());
        }

        internal static AbsolutePath GetTemporaryDirectory(AbsolutePath rootDirectory)
        {
            return rootDirectory / ".tmp";
        }

        internal static AbsolutePath GetCompletionFile(AbsolutePath rootDirectory)
        {
            var completionFileName = CompletionParameterName + ".yml";
            return File.Exists(rootDirectory / completionFileName)
                ? rootDirectory / completionFileName
                : GetTemporaryDirectory(rootDirectory) / completionFileName;
        }

        internal static AbsolutePath GetBuildAttemptFile(AbsolutePath rootDirectory)
        {
            return GetTemporaryDirectory(rootDirectory) / "build-attempt.log";
        }

        public static AbsolutePath GetVisualStudioDebugFile(AbsolutePath rootDirectory)
        {
            return GetTemporaryDirectory(rootDirectory) / $"{VisualStudioDebugParameterName}.log";
        }

        internal static AbsolutePath GetMissingPackageFile(AbsolutePath rootDirectory)
        {
            return GetTemporaryDirectory(rootDirectory) / "missing-package.log";
        }

        internal static AbsolutePath GetBuildSchemaFile(AbsolutePath rootDirectory)
        {
            return GetTemporaryDirectory(rootDirectory) / "build.schema.json";
        }

        internal static AbsolutePath GetDefaultParametersFile(AbsolutePath rootDirectory)
        {
            return GetTemporaryDirectory(rootDirectory) / $"{ParametersFilePrefix}.json";
        }

        internal static IEnumerable<AbsolutePath> GetParametersProfileFiles(AbsolutePath rootDirectory)
        {
            return GetTemporaryDirectory(rootDirectory).GlobFiles($"{ParametersFilePrefix}.*.json");
        }

        internal static AbsolutePath GetParametersProfileFile(AbsolutePath rootDirectory, string name)
        {
            return GetTemporaryDirectory(rootDirectory) / $"{ParametersFilePrefix}.{name}.json";
        }

        public static IEnumerable<string> GetProfileNames(AbsolutePath rootDirectory)
        {
            return GetParametersProfileFiles(rootDirectory)
                .Select(x => x.ToString())
                .Select(Path.GetFileNameWithoutExtension)
                .Select(x => x.TrimStart(ParametersFilePrefix).TrimStart("."));
        }
    }
}
