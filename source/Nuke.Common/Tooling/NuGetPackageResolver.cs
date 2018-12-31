// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Packaging;
using NuGet.Versioning;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public static class NuGetPackageResolver
    {
        private const int c_defaultTimeout = 2000;
        
        public static async Task<string> GetLatestPackageVersion(string packageId, bool includePrereleases, int? timeout = null)
        {
            try
            {
                var url = $"https://api-v2v3search-0.nuget.org/query?q=packageid:{packageId}&prerelease={includePrereleases}";
                var response = await HttpTasks.HttpDownloadStringAsync(url, requestConfigurator: x => x.Timeout = timeout ?? c_defaultTimeout);
                var packageObject = JsonConvert.DeserializeObject<JObject>(response);
                return packageObject["data"].Single()["version"].ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        [CanBeNull]
        public static InstalledPackage TryGetLocalInstalledPackage(
            string packageId,
            string packagesConfigFile,
            bool includeDependencies = false)
        {
            return GetLocalInstalledPackages(packagesConfigFile, includeDependencies)
                .FirstOrDefault(x => x.Id.EqualsOrdinalIgnoreCase(packageId));
        }
        
        public static InstalledPackage GetLocalInstalledPackage(
            string packageId,
            string packagesConfigFile,
            bool resolveDependencies = true)
        {
            return TryGetLocalInstalledPackage(packageId, packagesConfigFile, resolveDependencies)
                .NotNull($"Could not find package '{packageId}' via '{packagesConfigFile}'.");
        }

        // TODO: add HasLocalInstalledPackage() ?
        // ReSharper disable once CyclomaticComplexity
        public static IEnumerable<InstalledPackage> GetLocalInstalledPackages(
            string packagesConfigFile,
            bool resolveDependencies = true)
        {
            var packagesDirectory = GetPackagesDirectory(packagesConfigFile);

            var packageIds = XmlTasks.XmlPeek(
                packagesConfigFile,
                IsLegacyFile(packagesConfigFile)
                    ? ".//package/@id"
                    : ".//*[local-name() = 'PackageReference']/@Include");

            var installedPackages = new HashSet<InstalledPackage>(InstalledPackage.Comparer.Instance);
            foreach (var packageId in packageIds)
            {
                // TODO: use xml namespaces
                // TODO: version as tag
                var version = XmlTasks.XmlPeekSingle(
                    packagesConfigFile,
                    IsLegacyFile(packagesConfigFile)
                        ? $".//package[@id='{packageId}']/@version"
                        : $".//*[local-name() = 'PackageReference'][@Include='{packageId}']/@Version");
                
                var packageData = GetGlobalInstalledPackage(packageId, version, packagesDirectory);
                if (packageData == null)
                    continue;

                installedPackages.Add(packageData);
                yield return packageData;
            }

            if (resolveDependencies && !IsLegacyFile(packagesConfigFile))
            {
                var packagesToCheck = new Queue<InstalledPackage>(installedPackages);
                while (packagesToCheck.Any())
                {
                    var packageToCheck = packagesToCheck.Dequeue();

                    foreach (var dependentPackage in GetDependentPackages(packageToCheck, packagesDirectory))
                    {
                        if (installedPackages.Contains(dependentPackage))
                            continue;

                        installedPackages.Add(dependentPackage);
                        packagesToCheck.Enqueue(dependentPackage);

                        yield return dependentPackage;
                    }
                }
            }
        }

        private static IEnumerable<InstalledPackage> GetDependentPackages(InstalledPackage packageToCheck, string packagesDirectory)
        {
            return packageToCheck.Metadata.GetDependencyGroups()
                .SelectMany(x => x.Packages)
                .Select(x => GetGlobalInstalledPackage(x.Id, x.VersionRange, packagesDirectory))
                .WhereNotNull()
                .Distinct(x => new { x.Id, x.Version });
        }

        [CanBeNull]
        public static InstalledPackage GetGlobalInstalledPackage(string packageId, [CanBeNull] string version, [CanBeNull] string packagesConfigFile)
        {
            VersionRange.TryParse(version != null && version.Contains("*") ? $"{version}" : $"[{version}]", out var versionRange);
            return GetGlobalInstalledPackage(packageId, versionRange, packagesConfigFile);
        }

        // TODO: add parameter for auto download?
        // TODO: add parameter for highest/lowest?
        [CanBeNull]
        public static InstalledPackage GetGlobalInstalledPackage(
            string packageId,
            [CanBeNull] VersionRange versionRange,
            [CanBeNull] string packagesConfigFile,
            bool? includePrereleases = null)
        {
            packageId = packageId.ToLowerInvariant();
            var packagesDirectory = GetPackagesDirectory(packagesConfigFile);

            var packagesDirectoryInfo = new DirectoryInfo(packagesDirectory);
            var packages = packagesDirectoryInfo
                .GetDirectories(packageId)
                .SelectMany(x => x.GetDirectories())
                .SelectMany(x => x.GetFiles($"{packageId}*.nupkg"))
                .Concat(packagesDirectoryInfo
                    .GetDirectories($"{packageId}*")
                    .SelectMany(x => x.GetFiles($"{packageId}*.nupkg")))
                .Select(x => x.FullName);

            var candidatePackages = packages.Select(x => new InstalledPackage(x))
                // packages can contain false positives due to present/missing version specification
                .Where(x => x.Id.EqualsOrdinalIgnoreCase(packageId))
                .Where(x => !x.Version.IsPrerelease || !includePrereleases.HasValue || includePrereleases.Value)
                .OrderByDescending(x => x.Version)
                .ToList();

            return versionRange == null
                ? candidatePackages.FirstOrDefault()
                : candidatePackages.SingleOrDefault(x => x.Version == versionRange.FindBestMatch(candidatePackages.Select(y => y.Version)));
        }

        [CanBeNull]
        public static string GetPackagesConfigFile(string projectDirectory)
        {
            var projectDirectoryInfo = new DirectoryInfo(projectDirectory);
            var packagesConfigFile = projectDirectoryInfo.GetFiles("packages.config").SingleOrDefault()
                                    ?? projectDirectoryInfo.GetFiles("*.csproj").SingleOrDefaultOrError("Directory contains multiple project files.");
            return packagesConfigFile?.FullName;
        }

        // TODO: check for config ( repositoryPath / globalPackagesFolder )
        public static string GetPackagesDirectory([CanBeNull] string packagesConfigFile)
        {
            string TryGetFromEnvironmentVariable()
                => EnvironmentInfo.Variable("NUGET_PACKAGES");

            string TryGetGlobalDirectoryFromConfig()
                => GetConfigFiles(packagesConfigFile)
                    .Select(x => new
                                 {
                                     File = x,
                                     Setting = XmlTasks.XmlPeekSingle(x, ".//add[@key='globalPackagesFolder']/@value")
                                 })
                    .Where(x => x.Setting != null)
                    .Select(x => Path.IsPathRooted(x.Setting)
                        ? x.Setting
                        : Path.Combine(Path.GetDirectoryName(x.File).NotNull(), x.Setting))
                    .FirstOrDefault();

            string TryGetDefaultGlobalDirectory()
                => packagesConfigFile == null || !IsLegacyFile(packagesConfigFile)
                    ? Path.Combine(
                        EnvironmentInfo.SpecialFolder(SpecialFolders.UserProfile)
                            .NotNull("EnvironmentInfo.SpecialFolder(SpecialFolders.UserProfile) != null"),
                        ".nuget",
                        "packages")
                    : null;

            string TryGetLocalDirectory()
                => packagesConfigFile != null
                    ? new FileInfo(packagesConfigFile).Directory.NotNull()
                        .DescendantsAndSelf(x => x.Parent)
                        .SingleOrDefault(x => x.GetFiles("*.sln").Any() && x.GetDirectories("packages").Any())
                        ?.FullName
                    : null;

            var packagesDirectory = TryGetFromEnvironmentVariable() ?? 
                                    TryGetGlobalDirectoryFromConfig() ?? 
                                    TryGetDefaultGlobalDirectory() ?? 
                                    TryGetLocalDirectory();
            ControlFlow.Assert(Directory.Exists(packagesDirectory), $"Directory.Exists({packagesDirectory})");
            return packagesDirectory;
        }

        public static bool IsLegacyFile(string packagesConfigFile)
        {
            return packagesConfigFile.EndsWithOrdinalIgnoreCase(".config");
        }

        private static bool IncludesDependencies(string packagesConfigFile)
        {
            return IsLegacyFile(packagesConfigFile);
        }

        private static IEnumerable<string> GetConfigFiles([CanBeNull] string packagesConfigFile)
        {
            var directories = new List<string>();

            if (packagesConfigFile != null)
            {
                directories.AddRange(Directory.GetParent(packagesConfigFile)
                    .DescendantsAndSelf(x => x.Parent)
                    .Select(x => x.FullName));
            }

            if (EnvironmentInfo.IsWin)
            {
                directories.Add(Path.Combine(
                    EnvironmentInfo.SpecialFolder(SpecialFolders.ApplicationData).NotNull(),
                    "NuGet"));

                directories.Add(Path.Combine(
                    EnvironmentInfo.SpecialFolder(SpecialFolders.ProgramFilesX86).NotNull(),
                    "NuGet",
                    "Config"));
            }

            if (EnvironmentInfo.IsUnix)
            {
                directories.Add(Path.Combine(
                    EnvironmentInfo.SpecialFolder(SpecialFolders.UserProfile).NotNull(),
                    ".config",
                    "NuGet"));

                directories.Add(Path.Combine(
                    EnvironmentInfo.SpecialFolder(SpecialFolders.UserProfile).NotNull(),
                    ".nuget",
                    "NuGet"));

                var dataHomeDirectoy = EnvironmentInfo.Variable("XDG_DATA_HOME");
                if (!string.IsNullOrEmpty(dataHomeDirectoy))
                {
                    directories.Add(dataHomeDirectoy);
                }
                else
                {
                    directories.Add(Path.Combine(
                        EnvironmentInfo.SpecialFolder(SpecialFolders.UserProfile).NotNull(),
                        ".local",
                        "share"));

                    // TODO: /usr/local/share
                }
            }

            return directories
                .Where(Directory.Exists)
                .SelectMany(x => Directory.GetFiles(x, "nuget.config", SearchOption.TopDirectoryOnly))
                .Where(File.Exists);
        }

        // TODO: move out of class
        public class InstalledPackage
        {
            public sealed class Comparer : IEqualityComparer<InstalledPackage>
            {
                public static readonly Comparer Instance = new Comparer();

                public bool Equals([CanBeNull] InstalledPackage x, [CanBeNull] InstalledPackage y)
                {
                    if (ReferenceEquals(x, y))
                        return true;
                    if (ReferenceEquals(x, objB: null))
                        return false;
                    if (ReferenceEquals(y, objB: null))
                        return false;
                    if (x.GetType() != y.GetType())
                        return false;
                    return Equals(x.Id, y.Id) && Equals(x.Version, y.Version);
                }

                public int GetHashCode([NotNull] InstalledPackage obj)
                {
                    return obj.Id.GetHashCode();
                }
            }

            public InstalledPackage(string fileName)
            {
                FileName = fileName;
                Metadata = new PackageArchiveReader(fileName).NuspecReader;
            }

            public string FileName { get; }
            public PathConstruction.AbsolutePath Directory => (PathConstruction.AbsolutePath) Path.GetDirectoryName(FileName).NotNull();
            public NuspecReader Metadata { get; }
            public string Id => Metadata.GetIdentity().Id;
            public NuGetVersion Version => Metadata.GetIdentity().Version;

            public override string ToString()
            {
                return $"{Id}.{Version.ToFullString()}";
            }
        }
    }
}
