// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;
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
        [CanBeNull]
        public static InstalledPackage GetLocalInstalledPackage(
            string packageId,
            AbsolutePath packagesConfigFile,
            string version = null,
            bool resolveDependencies = true)
        {
            return GetLocalInstalledPackages(
                    packagesConfigFile,
                    resolveDependencies,
                    x => x.PackageId.EqualsOrdinalIgnoreCase(packageId))
                .SingleOrDefaultOrError(
                    x => x.Id.EqualsOrdinalIgnoreCase(packageId) && (x.Version.ToString() == version || version == null),
                    $"Package '{packageId}' is referenced with multiple versions. Use NuGetPackageResolver and SetToolPath.");
        }

        // TODO: add HasLocalInstalledPackage() ?
        public static IEnumerable<InstalledPackage> GetLocalInstalledPackages(
            AbsolutePath packagesConfigFile,
            bool resolveDependencies = true,
            Func<(string PackageId, string Version), bool> preFilter = null)
        {
            return packagesConfigFile.HasExtension("json")
                ? GetLocalInstalledPackagesFromAssetsFile(packagesConfigFile, resolveDependencies, preFilter)
                : GetLocalInstalledPackagesFromConfigFile(packagesConfigFile, resolveDependencies);
        }

        private static IEnumerable<(string PackageId, string Version)> GetLocalInstalledPackagesFromAssetsFileWithoutLoading(
            AbsolutePath packagesConfigFile,
            bool resolveDependencies = true)
        {
            var assetsContent = packagesConfigFile.ReadAllText();
            var assetsObject = JObject.Parse(assetsContent);

            // ReSharper disable HeapView.BoxingAllocation
            var directPackageReferences =
                assetsObject["project"].NotNull()["frameworks"].NotNull()
                    .Single().Single()["dependencies"]
                    ?.Children<JProperty>()
                    .Select(x => x.Name).ToList()
                ?? new List<string>();

            var packageReferences =
                assetsObject["libraries"].NotNull()
                    .Children<JProperty>()
                    .Where(x => x.Value["type"].NotNull().ToString() == "package")
                    .Select(x => x.Name.Split('/'))
                    .Select(x => (
                        PackageId: x.First(),
                        Version: x.Last()
                    ))
                    .Where(x => resolveDependencies || directPackageReferences.Contains(x.PackageId))
                    .OrderByDescending(x => directPackageReferences.Contains(x.PackageId))
                    .ToList();

            var packageDownloads =
                assetsObject["project"].NotNull()["frameworks"].NotNull()
                    .Single().Single()["downloadDependencies"]
                    ?.Children<JObject>()
                    .Select(x => (
                        PackageId: x.Property("name").NotNull().Value.ToString(),
                        Version: x.Property("version").NotNull().Value.ToString().Trim('[', ']').Split(',').First().Trim()
                    )).ToList()
                ?? new List<(string, string)>();
            // ReSharper restore HeapView.BoxingAllocation

            return packageDownloads.Concat(packageReferences);
        }

        [ItemNotNull]
        private static IEnumerable<InstalledPackage> GetLocalInstalledPackagesFromAssetsFile(
            AbsolutePath packagesConfigFile,
            bool resolveDependencies = true,
            Func<(string PackageId, string Version), bool> preFilter = null)
        {
            return GetLocalInstalledPackagesFromAssetsFileWithoutLoading(packagesConfigFile, resolveDependencies)
                .Where(x => preFilter == null || preFilter.Invoke(x))
                .Select(x => GetGlobalInstalledPackage(x.PackageId, x.Version, packagesConfigFile))
                .WhereNotNull();
        }

        // ReSharper disable once CognitiveComplexity
        [ItemNotNull]
        private static IEnumerable<InstalledPackage> GetLocalInstalledPackagesFromConfigFile(
            AbsolutePath packagesConfigFile,
            bool resolveDependencies = true)
        {
            var document = XDocument.Load(packagesConfigFile);
            var packageIds = document.XPathSelectAttributeValues(
                    IsLegacyFile(packagesConfigFile)
                        ? ".//package/@id"
                        : ".//*[local-name() = 'PackageReference' or local-name() = 'PackageDownload']/@Include")
                .Distinct();

            var installedPackages = new HashSet<InstalledPackage>(InstalledPackage.Comparer.Instance);
            foreach (var packageId in packageIds)
            {
                // TODO: use xml namespaces
                // TODO: version as tag
                var versions = document.XPathSelectAttributeValues(
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

        private static IEnumerable<InstalledPackage> GetDependentPackages(InstalledPackage packageToCheck, AbsolutePath packagesConfigFile)
        {
            return packageToCheck.Metadata.GetDependencyGroups()
                .SelectMany(x => x.Packages)
                .Select(x => GetGlobalInstalledPackage(x.Id, x.VersionRange, packagesConfigFile))
                .WhereNotNull()
                .Distinct(x => new { x.Id, x.Version });
        }

        [CanBeNull]
        public static InstalledPackage GetGlobalInstalledPackage(
            string packageId,
            [CanBeNull] string version,
            [CanBeNull] AbsolutePath packagesConfigFile)
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
            [CanBeNull] AbsolutePath packagesConfigFile,
            bool? includePrereleases = null)
        {
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
                .Where(x => x.Name.StartsWithOrdinalIgnoreCase(packageId))
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
                                     ?? projectDirectoryInfo.GetFiles("*.csproj")
                                         .SingleOrDefaultOrError($"Directory '{projectDirectory}' contains multiple project files.");
            return packagesConfigFile?.FullName;
        }

        // TODO: check for config ( repositoryPath / globalPackagesFolder )
        [CanBeNull]
        public static AbsolutePath GetPackagesDirectory([CanBeNull] AbsolutePath packagesConfigFile)
        {
            string TryGetFromEnvironmentVariable()
                => EnvironmentInfo.GetVariable("NUGET_PACKAGES");

            string TryGetGlobalDirectoryFromConfig()
                => GetConfigFiles(packagesConfigFile)
                    .Select(x => new
                                 {
                                     File = x,
                                     Setting = XDocument.Load(x).XPathSelectAttributeValues(".//add[@key='globalPackagesFolder']/@value").SingleOrDefault()
                                 })
                    .Where(x => x.Setting != null)
                    .Select(x => Path.IsPathRooted(x.Setting)
                        ? x.Setting
                        : Path.Combine(Path.GetDirectoryName(x.File).NotNull(), x.Setting))
                    .FirstOrDefault();

            string TryGetDefaultGlobalDirectory()
                => packagesConfigFile == null || !IsLegacyFile(packagesConfigFile)
                    ? Path.Combine(
                        EnvironmentInfo.SpecialFolder(SpecialFolders.UserProfile).NotNull(),
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

        public static bool IsLegacyFile(AbsolutePath packagesConfigFile)
        {
            return packagesConfigFile.HasExtension("config");
        }

        private static bool IncludesDependencies(AbsolutePath packagesConfigFile)
        {
            return IsLegacyFile(packagesConfigFile);
        }

        private static IEnumerable<string> GetConfigFiles([CanBeNull] AbsolutePath packagesConfigFile)
        {
            var directories = new List<AbsolutePath>();

            if (packagesConfigFile != null)
                directories.AddRange(packagesConfigFile.Descendants(x => x.Parent));

            if (EnvironmentInfo.IsWin)
            {
                directories.Add(EnvironmentInfo.SpecialFolder(SpecialFolders.ApplicationData).NotNull() / "NuGet");
                directories.Add(EnvironmentInfo.SpecialFolder(SpecialFolders.ProgramFilesX86).NotNull() / "NuGet" / "Config");
            }

            if (EnvironmentInfo.IsUnix)
            {
                directories.Add(EnvironmentInfo.SpecialFolder(SpecialFolders.UserProfile).NotNull() / ".config" / "NuGet");
                directories.Add(EnvironmentInfo.SpecialFolder(SpecialFolders.UserProfile).NotNull() / ".nuget" / "NuGet");

                var dataHomeDirectoy = EnvironmentInfo.GetVariable("XDG_DATA_HOME");
                if (!string.IsNullOrEmpty(dataHomeDirectoy))
                    directories.Add(dataHomeDirectoy);
                else
                    // TODO: /usr/local/share
                    directories.Add(EnvironmentInfo.SpecialFolder(SpecialFolders.UserProfile).NotNull() / ".local" / "share");
            }

            return directories
                .WhereDirectoryExists()
                .SelectMany(x => new[] { x / "nuget.config", x / "NuGet.config" })
                // TODO: Add AbsolutePathComparer
                .Select(x => x.ToString())
                .Distinct(EnvironmentInfo.IsLinux ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase)
                .Where(File.Exists);
        }

        // TODO: move out of class
        public class InstalledPackage
        {
            public sealed class Comparer : IEqualityComparer<InstalledPackage>
            {
                public static readonly Comparer Instance = new();

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

            private readonly Lazy<NuspecReader> _metadata;

            public InstalledPackage(AbsolutePath file)
            {
                File = file;
                _metadata = new Lazy<NuspecReader>(() =>
                {
                    var directory = new DirectoryInfo(Path.GetDirectoryName(file));
                    return directory.GetFiles("*.nuspec").Length == 1
                        ? new PackageFolderReader(directory).NuspecReader
                        : new PackageArchiveReader(file).NuspecReader;
                });
            }

            public AbsolutePath File { get; }
            public AbsolutePath Directory => File.Parent.NotNull();
            public NuspecReader Metadata => _metadata.Value;
            public string Id => Metadata.GetIdentity().Id;
            public NuGetVersion Version => Metadata.GetIdentity().Version;

            public override string ToString()
            {
                return $"{Id}.{Version.ToFullString()}";
            }
        }
    }
}
