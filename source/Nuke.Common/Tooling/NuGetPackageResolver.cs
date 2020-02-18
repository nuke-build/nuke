// Copyright 2019 Maintainers of NUKE.
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
        private static Dictionary<string, InstalledPackage[]> s_candidatePackageCache = new Dictionary<string, InstalledPackage[]>();

        [ItemCanBeNull]
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
        public static InstalledPackage GetLocalInstalledPackage(
            string packageId,
            string packagesConfigFile,
            string version = null,
            bool resolveDependencies = true)
        {
            return GetLocalInstalledPackages(packagesConfigFile, resolveDependencies)
                .SingleOrDefaultOrError(
                    x => x.Id.EqualsOrdinalIgnoreCase(packageId) && (x.Version.ToString() == version || version == null),
                    $"Package '{packageId}' is referenced with multiple versions. Use NuGetPackageResolver and SetToolPath.");
        }

        // TODO: add HasLocalInstalledPackage() ?
        public static IEnumerable<InstalledPackage> GetLocalInstalledPackages(
            string packagesConfigFile,
            bool resolveDependencies = true)
        {
            return packagesConfigFile.EndsWithOrdinalIgnoreCase("json")
                ? GetLocalInstalledPackagesFromAssetsFile(packagesConfigFile, resolveDependencies)
                : GetLocalInstalledPackagesFromConfigFile(packagesConfigFile, resolveDependencies);
        }

        [ItemNotNull]
        private static IEnumerable<InstalledPackage> GetLocalInstalledPackagesFromAssetsFile(
            string packagesConfigFile,
            bool resolveDependencies = true)
        {
            var assetsObject = SerializationTasks.JsonDeserializeFromFile<JObject>(packagesConfigFile);

            // ReSharper disable HeapView.BoxingAllocation
            var directReferences =
                assetsObject["project"]["frameworks"]
                    .Single().Single()["dependencies"]
                    ?.Children<JProperty>()
                    .Select(x => x.Name).ToList()
                ?? new List<string>();

            var allReferences =
                assetsObject["libraries"]
                    .Children<JProperty>()
                    .Where(x => x.Value["type"].ToString() == "package")
                    .Select(x => x.Name.Split('/'))
                    .Select(x => (PackageId: x.First(), Version: x.Last())).ToList();
            // ReSharper restore HeapView.BoxingAllocation

            foreach (var (name, version) in allReferences)
            {
                if (!resolveDependencies && !directReferences.Contains(name))
                    continue;

                var package = GetGlobalInstalledPackage(name, version, packagesConfigFile);
                if (package == null)
                    continue;

                yield return package;
            }
        }

        [ItemNotNull]
        private static IEnumerable<InstalledPackage> GetLocalInstalledPackagesFromConfigFile(
            string packagesConfigFile,
            bool resolveDependencies = true)
        {
            var packageIds = XmlTasks.XmlPeek(
                    packagesConfigFile,
                    IsLegacyFile(packagesConfigFile)
                        ? ".//package/@id"
                        : ".//*[local-name() = 'PackageReference' or local-name() = 'PackageDownload']/@Include")
                .Distinct();

            var installedPackages = new HashSet<InstalledPackage>(InstalledPackage.Comparer.Instance);
            foreach (var packageId in packageIds)
            {
                // TODO: use xml namespaces
                // TODO: version as tag
                var versions = XmlTasks.XmlPeek(
                        packagesConfigFile,
                        IsLegacyFile(packagesConfigFile)
                            ? $".//package[@id='{packageId}']/@version"
                            : $".//*[local-name() = 'PackageReference' or local-name() = 'PackageDownload'][@Include='{packageId}']/@Version")
                    .SelectMany(x => x.Split(';'));

                foreach (var version in versions)
                {
                    var package = GetGlobalInstalledPackage(packageId, version, packagesConfigFile);
                    if (package == null)
                        continue;

                    installedPackages.Add(package);
                    yield return package;
                }
            }

            if (resolveDependencies && !IsLegacyFile(packagesConfigFile))
            {
                var packagesToCheck = new Queue<InstalledPackage>(installedPackages);
                while (packagesToCheck.Any())
                {
                    var packageToCheck = packagesToCheck.Dequeue();

                    foreach (var dependentPackage in GetDependentPackages(packageToCheck, packagesConfigFile))
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

        private static IEnumerable<InstalledPackage> GetDependentPackages(InstalledPackage packageToCheck, string packagesConfigFile)
        {
            return packageToCheck.Metadata.GetDependencyGroups()
                .SelectMany(x => x.Packages)
                .Select(x => GetGlobalInstalledPackage(x.Id, x.VersionRange, packagesConfigFile))
                .WhereNotNull()
                .Distinct(x => new { x.Id, x.Version });
        }

        [CanBeNull]
        public static InstalledPackage GetGlobalInstalledPackage(string packageId, [CanBeNull] string version, [CanBeNull] string packagesConfigFile)
        {
            if (version != null &&
                !version.Contains("*") &&
                !version.StartsWith("[") &&
                !version.EndsWith("]"))
                version = $"[{version}]";

            VersionRange.TryParse(version, out var versionRange);
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
            var candidatePackages = GetCandidatePackages(packageId, packagesConfigFile, includePrereleases);

            return versionRange == null
                ? candidatePackages.FirstOrDefault()
                : candidatePackages.SingleOrDefault(x => x.Version == versionRange.FindBestMatch(candidatePackages.Select(y => y.Version)));
        }

        private static InstalledPackage[] GetCandidatePackages(
            string packageId,
            [CanBeNull] string packagesConfigFile,
            bool? includePrereleases = null)
        {
            var key = $"{packageId}-{packagesConfigFile}-{includePrereleases}";

            if (s_candidatePackageCache.TryGetValue(key, out var candidatePackages))
            {
                return candidatePackages;
            }

            packageId = packageId.ToLowerInvariant();
            var packagesDirectory = GetPackagesDirectory(packagesConfigFile);
            if (packagesDirectory == null)
                return null;

            var packagesDirectoryInfo = new DirectoryInfo(packagesDirectory);
            var packages = packagesDirectoryInfo
                .GetDirectories(packageId)
                .SelectMany(x => x.GetDirectories())
                .SelectMany(x => x.GetFiles($"{packageId}*.nupkg"))
                .Concat(packagesDirectoryInfo
                    .GetDirectories($"{packageId}*")
                    .SelectMany(x => x.GetFiles($"{packageId}*.nupkg")))
                .Select(x => x.FullName);

            candidatePackages = packages.Select(x => new InstalledPackage(x))
                // packages can contain false positives due to present/missing version specification
                .Where(x => x.Id.EqualsOrdinalIgnoreCase(packageId))
                .Where(x => !x.Version.IsPrerelease || !includePrereleases.HasValue || includePrereleases.Value)
                .OrderByDescending(x => x.Version)
                .ToArray();

            s_candidatePackageCache.Add(key, candidatePackages);

            return candidatePackages;
        }

        [CanBeNull]
        public static string GetPackagesConfigFile(string projectDirectory)
        {
            var projectDirectoryInfo = new DirectoryInfo(projectDirectory);
            var packagesConfigFile = projectDirectoryInfo.GetFiles("packages.config").SingleOrDefault()
                                     ?? projectDirectoryInfo.GetFiles("*.csproj")
                                         .SingleOrDefaultOrError("Directory contains multiple project files.");
            return packagesConfigFile?.FullName;
        }

        // TODO: check for config ( repositoryPath / globalPackagesFolder )
        [CanBeNull]
        private static string GetPackagesDirectory([CanBeNull] string packagesConfigFile)
        {
            string TryGetFromEnvironmentVariable()
                => EnvironmentInfo.GetVariable<string>("NUGET_PACKAGES");

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
                        .Where(x => x.GetFiles("*.sln").Any())
                        .Select(x => Path.Combine(x.FullName, "packages"))
                        .FirstOrDefault(Directory.Exists)
                    : null;

            var packagesDirectory = TryGetFromEnvironmentVariable() ??
                                    TryGetGlobalDirectoryFromConfig() ??
                                    TryGetDefaultGlobalDirectory() ??
                                    TryGetLocalDirectory();
            return packagesDirectory != null && Directory.Exists(packagesDirectory)
                ? packagesDirectory
                : null;
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

                var dataHomeDirectoy = EnvironmentInfo.GetVariable<string>("XDG_DATA_HOME");
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
            public AbsolutePath Directory => (AbsolutePath) Path.GetDirectoryName(FileName).NotNull();
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
