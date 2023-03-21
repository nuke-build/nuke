// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common
{
    /// <summary>
    /// Set of constants shared between libraries and IDE extensions.
    /// </summary>
    internal static class Constants
    {
        internal const string NukeFileName = NukeDirectoryName;
        internal const string NukeDirectoryName = ".nuke";
        internal const string NukeCommonPackageId = nameof(Nuke) + "." + nameof(Common);
        internal const string BuildSchemaFileName = "build.schema.json";
        internal const string VisualStudioDebugFileName = $"{VisualStudioDebugParameterName}.log";

        internal const string TargetsSeparator = "+";
        internal const string RootDirectoryParameterName = "Root";
        internal const string InvokedTargetsParameterName = "Target";
        internal const string SkippedTargetsParameterName = "Skip";
        internal const string LoadedLocalProfilesParameterName = "Profile";

        public const string VisualStudioDebugParameterName = "visual-studio-debug";
        internal const string CompletionParameterName = "shell-completion";
        internal const string ParametersFilePrefix = "parameters";
        internal const string DefaultProfileName = "$default";

        internal const string GlobalToolVersionEnvironmentKey = "NUKE_GLOBAL_TOOL_VERSION";
        internal const string GlobalToolStartTimeEnvironmentKey = "NUKE_GLOBAL_TOOL_START_TIME";
        internal const string InterceptorEnvironmentKey = "NUKE_INTERNAL_INTERCEPTOR";

        internal static AbsolutePath GlobalTemporaryDirectory => Path.GetTempPath();
        internal static AbsolutePath GlobalNukeDirectory =>  EnvironmentInfo.SpecialFolder(SpecialFolders.UserProfile) / ".nuke";

        [CanBeNull]
        internal static AbsolutePath TryGetRootDirectoryFrom(AbsolutePath startDirectory, bool includeLegacy = true)
        {
            var rootDirectory = new DirectoryInfo(startDirectory)
                .DescendantsAndSelf(x => x.Parent)
                .FirstOrDefault(x => x.GetDirectories(NukeDirectoryName).Any() ||
                                     includeLegacy && x.GetFiles(NukeFileName).Any())
                ?.FullName;
            return rootDirectory != GlobalNukeDirectory.Parent ? (AbsolutePath) rootDirectory : null;
        }

        internal static bool IsLegacy(AbsolutePath rootDirectory)
        {
            return File.Exists(rootDirectory / NukeFileName);
        }

        internal static AbsolutePath GetNukeDirectory(AbsolutePath rootDirectory)
        {
            return rootDirectory / NukeDirectoryName;
        }

        internal static AbsolutePath GetTemporaryDirectory(AbsolutePath rootDirectory)
        {
            return !IsLegacy(rootDirectory)
                ? GetNukeDirectory(rootDirectory) / "temp"
                : rootDirectory / ".tmp";
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

        internal static AbsolutePath GetBuildSchemaFile(AbsolutePath rootDirectory)
        {
            return GetNukeDirectory(rootDirectory) / BuildSchemaFileName;
        }

        internal static AbsolutePath GetDefaultParametersFile(AbsolutePath rootDirectory)
        {
            return GetNukeDirectory(rootDirectory) / GetParametersFileName(DefaultProfileName);
        }

        internal static IEnumerable<AbsolutePath> GetParametersProfileFiles(AbsolutePath rootDirectory)
        {
            return new DirectoryInfo(GetNukeDirectory(rootDirectory)).GetFiles($"{ParametersFilePrefix}.*.json", SearchOption.TopDirectoryOnly)
                .Select(x => (AbsolutePath)x.FullName);
        }

        internal static AbsolutePath GetParametersProfileFile(AbsolutePath rootDirectory, string profile)
        {
            return GetNukeDirectory(rootDirectory) / GetParametersFileName(profile);
        }

        internal static string GetParametersFileName(string profile)
        {
            return profile == DefaultProfileName ? $"{ParametersFilePrefix}.json" : $"{ParametersFilePrefix}.{profile}.json";
        }

        public static IEnumerable<string> GetProfileNames(AbsolutePath rootDirectory)
        {
            return GetParametersProfileFiles(rootDirectory)
                .Select(x => x.ToString())
                .Select(Path.GetFileNameWithoutExtension)
                .Select(x => x.TrimStart(ParametersFilePrefix).TrimStart("."));
        }

        internal static string GetCredentialStoreName(AbsolutePath rootDirectory, [CanBeNull] string profile)
        {
            return $"NUKE: {rootDirectory} ({profile ?? DefaultProfileName})";
        }

        internal static string GetProfilePasswordParameterName(string profile)
        {
            return $"PARAMS_{profile.TrimStart(DefaultProfileName).ToUpperInvariant().Replace(".", "_")}_KEY".Replace("_", string.Empty);
        }
    }
}
