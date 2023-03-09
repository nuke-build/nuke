// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public static class NuGetToolPathResolver
    {
        public static string EmbeddedPackagesDirectory;
        public static string NuGetPackagesConfigFile;
        public static string NuGetAssetsConfigFile;
        public static string PaketPackagesConfigFile;

        public static string GetPackageExecutable(string packageId, string packageExecutable, string version = null, string framework = null)
        {
            Assert.True(packageId != null && packageExecutable != null);

            var packageDirectory = GetPackageDirectory(packageId.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries), version);
            var packageExecutables = packageExecutable.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
#if !NETSTANDARD2_0
            var enumerationOptions = new EnumerationOptions { RecurseSubdirectories = true, MatchCasing = MatchCasing.CaseInsensitive };
#endif
            var packageExecutablePaths = packageExecutables
#if !NETSTANDARD2_0
                .SelectMany(x => Directory.GetFiles(packageDirectory, x, enumerationOptions))
#else
                .SelectMany(x => Directory.EnumerateFiles(packageDirectory, "*", SearchOption.AllDirectories)
                    .Where(y => Path.GetFileName(y).EqualsOrdinalIgnoreCase(x)))
#endif
                .ToList();

            Assert.NotEmpty(packageExecutablePaths,
                $"Could not find {packageExecutables.Select(x => x.SingleQuote()).JoinCommaOr()} inside '{packageDirectory}'");
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

            Assert.True(frameworks.Count > 0);
            if (frameworks.Count == 1)
                return GetPackageExecutable(frameworks.Single());

            framework ??= Assembly.GetEntryAssembly().NotNull().GetCustomAttribute<TargetFrameworkAttribute>()
                .FrameworkDisplayName.Replace(".NET ", "net");
            var sortedFrameworks = frameworks.Select(x => x.Key)
                .OrderBy(x => x == framework)
                .ThenBy(x => x.Contains("."))
                .ThenBy(x => !x.StartsWith("netcore"))
                .ThenBy(x => x)
                .Reverse();
            return GetPackageExecutable(frameworks[sortedFrameworks.First()]);
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
                                    EmbeddedPackagesDirectory != null
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
                if (NuGetPackagesConfigFile != null && !NuGetPackagesConfigFile.EndsWithOrdinalIgnoreCase(".csproj"))
                    throw;

                var packageCombinations =
                    from packageId in packageIds
                    from packageVersion in
                        new[]
                        {
                            NuGetVersionResolver.GetLatestVersion(packageId, includePrereleases: false).GetAwaiter().GetResult(),
                            NuGetVersionResolver.GetLatestVersion(packageId, includePrereleases: true).GetAwaiter().GetResult(),
                            NuGetPackageResolver.GetGlobalInstalledPackage(packageId, version: null, packagesConfigFile: null)?.Version.ToString()
                        }
                    where packageVersion != null
                    select (Id: packageId, Version: packageVersion);

                Assert.Fail(
                    new[]
                        {
                            "Missing package reference/download.",
                            "Run one of the following commands:"
                        }.Concat(packageCombinations.Distinct().Select(x => $"  - nuke :add-package {x.Id} --version {x.Version}"))
                        .JoinNewLine(),
                    exception);
                throw new Exception("Not reachable");
            }
        }
    }
}
