// Copyright 2020 Maintainers of NUKE.
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

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public static class ToolPathResolver
    {
        public static string EmbeddedPackagesDirectory;
        public static string NuGetPackagesConfigFile;
        public static string NuGetAssetsConfigFile;
        public static string PaketPackagesConfigFile;

        internal const string MissingPackageDefaultVersion = "latest";

        [CanBeNull]
        public static string TryGetEnvironmentExecutable(string environmentExecutable)
        {
            var environmentExecutablePath = EnvironmentInfo.GetVariable<string>(environmentExecutable);
            if (environmentExecutablePath == null)
                return null;

            ControlFlow.Assert(File.Exists(environmentExecutablePath),
                $"Path '{environmentExecutablePath}' from environment variable '{environmentExecutable}' does not exist.");
            return environmentExecutablePath;
        }

        public static string GetPackageExecutable(string packageId, string packageExecutable, string version = null, string framework = null)
        {
            ControlFlow.Assert(packageId != null && packageExecutable != null, "packageId != null && packageExecutable != null");

            var packageDirectory = GetPackageDirectory(packageId.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries), version);
            var packageExecutables = packageExecutable.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            var packageExecutablePaths = packageExecutables
#if NETCORE
                .SelectMany(x => Directory.GetFiles(packageDirectory,
                    x,
                    new EnumerationOptions
                    {
                        RecurseSubdirectories = true,
                        MatchCasing = MatchCasing.CaseInsensitive,
                    }))
#else
                .SelectMany(x => Directory.GetFiles(packageDirectory, x, SearchOption.AllDirectories))
#endif
                .ToList();

            ControlFlow.Assert(packageExecutablePaths.Count > 0,
                $"Could not find {packageExecutables.Select(x => x.SingleQuote()).JoinCommaOr()} inside '{packageDirectory}'.");
            if (packageExecutablePaths.Count == 1 && framework == null)
                return packageExecutablePaths.Single();

            static string GetFramework(string file)
            {
                var directory = new FileInfo(file).Directory.NotNull();
                return !directory.Name.EqualsOrdinalIgnoreCase("any")
                    ? directory.Name
                    : directory.Parent.NotNull().Name;
            }

            var frameworks = packageExecutablePaths.ToLookup(GetFramework, x => x, StringComparer.OrdinalIgnoreCase);

            // TODO: filter dll for .NET Framework
            static string GetPackageExecutable(IEnumerable<string> executables)
                => executables
                    .OrderByDescending(x => x.EndsWithOrdinalIgnoreCase(".dll"))
                    .ThenByDescending(x => EnvironmentInfo.IsWin && x.EndsWithOrdinalIgnoreCase(".exe"))
                    .ThenByDescending(x => EnvironmentInfo.IsUnix && x.EndsWithOrdinalIgnoreCase(".sh")).ToList()
                    .First();

            ControlFlow.Assert(frameworks.Count > 0, "frameworks.Count > 0");
            if (frameworks.Count == 1)
                return GetPackageExecutable(frameworks.Single());

            ControlFlow.Assert(framework != null && frameworks.Contains(framework),
                $"Package executable {packageExecutables.JoinCommaOr()} [{packageId}] requires a framework:"
                    .Concat(frameworks.Select(x => $" - {x.Key}")).JoinNewLine());
            return GetPackageExecutable(frameworks[framework]);
        }

        private static string GetPackageDirectory(string[] packageIds, [CanBeNull] string version)
        {
            try
            {
                return packageIds
                    .SelectMany(x =>
                        new Func<string>[]
                        {
                            () => EmbeddedPackagesDirectory != null
                                ? Path.Combine(EmbeddedPackagesDirectory, x)
                                : null,
                            () => NuGetAssetsConfigFile != null
                                ? NuGetPackageResolver.GetLocalInstalledPackage(x, NuGetAssetsConfigFile, version)?.Directory
                                : null,
                            () => NuGetPackagesConfigFile != null
                                ? NuGetPackageResolver.GetLocalInstalledPackage(x, NuGetPackagesConfigFile, version)?.Directory
                                : null,
                            () => PaketPackagesConfigFile != null
                                ? PaketPackageResolver.GetLocalInstalledPackageDirectory(x, PaketPackagesConfigFile)
                                : null
                        })
                    .Select(x => x.Invoke())
                    .FirstOrDefault(Directory.Exists)
                    .NotNull(
                        new[]
                            {
                                $"Could not find package {packageIds.Select(x => x.SingleQuote()).JoinCommaOr()} " +
                                $"{(version != null ? $"({version}) " : string.Empty)}" +
                                "using:"
                            }
                            .Concat(
                                new[]
                                {
                                    NukeBuild.BuildProjectDirectory == null
                                        ? $"Embedded packages directory at '{EmbeddedPackagesDirectory}'"
                                        : null,
                                    NuGetAssetsConfigFile != null
                                        ? $"Project assets file '{NuGetAssetsConfigFile}'"
                                        : null,
                                    NuGetPackagesConfigFile != null
                                        ? $"NuGet packages config '{NuGetPackagesConfigFile}'"
                                        : null,
                                    PaketPackagesConfigFile != null
                                        ? $"Paket packages config '{PaketPackagesConfigFile}'"
                                        : null
                                }.WhereNotNull().Select(x => $" - {x}")).JoinNewLine());
            }
            catch (Exception exception)
            {
                if (!NuGetPackagesConfigFile.EndsWithOrdinalIgnoreCase(".csproj"))
                    throw;

                var packageCombinations =
                    from packageId in packageIds
                    from packageVersion in
                        new[]
                        {
                            NuGetPackageResolver.GetLatestPackageVersion(packageId, includePrereleases: false).GetAwaiter().GetResult(),
                            NuGetPackageResolver.GetLatestPackageVersion(packageId, includePrereleases: true).GetAwaiter().GetResult(),
                            NuGetPackageResolver.GetGlobalInstalledPackage(packageId, version: null, packagesConfigFile: null)?.Version.ToString()
                        }
                    where packageVersion != null
                    select (Id: packageId, Version: packageVersion);

                ControlFlow.Fail(
                    new[]
                        {
                            "Missing package reference/download.",
                            "Run one of the following commands:"
                        }.Concat(packageCombinations.Distinct().Select(x => $"  - nuke :add-package {x.Id} {x.Version}"))
                        .JoinNewLine(),
                    exception);
                throw new Exception("Not reachable");
            }
        }

        public static string GetPathExecutable(string pathExecutable)
        {
            var locateExecutable = EnvironmentInfo.IsWin
                ? @"C:\Windows\System32\where.exe"
                : "/usr/bin/which";

            var locateProcess = ProcessTasks.StartProcess(
                locateExecutable,
                pathExecutable,
                logOutput: false,
                logInvocation: false);
            locateProcess.AssertWaitForExit();

            return locateProcess.Output
                .Select(x => x.Text)
                .Where(x => EnvironmentInfo.IsWin && Path.HasExtension(x) || EnvironmentInfo.IsUnix)
                .FirstOrDefault(File.Exists)
                .NotNull($"Could not find '{pathExecutable}' via '{locateExecutable}'.");
        }
    }
}
