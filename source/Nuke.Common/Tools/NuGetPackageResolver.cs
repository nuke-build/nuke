// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using NuGet.Packaging;
using NuGet.Versioning;
using Nuke.Common.IO;
using Nuke.Core;
using Nuke.Core.Utilities.Collections;

namespace Nuke.Common.Tools
{
    // TODO: add File/Directory.Exists assertions
    public static class NuGetPackageResolver
    {
        public static string GetToolPath (string packageId, string executableName, string packagesConfigFile = null)
        {
            packagesConfigFile = packagesConfigFile ?? GetBuildPackagesConfigFile();
            var installedPackage = GetLocalInstalledPackage(packagesConfigFile, packageId)
                    .NotNull($"Could not find package '{packageId}' via '{packagesConfigFile}'.");
            var packageDirectory = Path.GetDirectoryName(installedPackage.FileName).NotNull("packageDirectory != null");
            return Directory.GetFiles(packageDirectory, executableName, SearchOption.AllDirectories)
                    .SingleOrDefault()
                    .NotNull($"Could not find '{executableName}' inside '{packageDirectory}'.");
        }

        [CanBeNull]
        public static InstalledPackage GetLocalInstalledPackage (string packagesConfigFile, string packageId)
        {
            return GetLocalInstalledPackages(packagesConfigFile)
                    .FirstOrDefault(x => x.Id.Equals(packageId, StringComparison.OrdinalIgnoreCase));
        }

        public static IEnumerable<InstalledPackage> GetLocalInstalledPackages (
            string packagesConfigFile = null,
            bool includeDependencies = true)
        {
            packagesConfigFile = packagesConfigFile ?? GetBuildPackagesConfigFile();
            ControlFlow.Assert(
                includeDependencies || IncludesDependencies(packagesConfigFile),
                $"includeDependencies || IncludesDependencies({packagesConfigFile})");
            var packagesDirectory = GetPackagesDirectory(packagesConfigFile);

            var packageIds = XmlTasks.XmlPeek(
                packagesConfigFile,
                IsLegacyFile(packagesConfigFile)
                    ? ".//package/@id"
                    : ".//PackageReference/@Include");

            var installedPackages = new HashSet<InstalledPackage>(InstalledPackage.Comparer.Instance);
            foreach (var packageId in packageIds)
            {
                var version = XmlTasks.XmlPeekSingle(
                            packagesConfigFile,
                            IsLegacyFile(packagesConfigFile)
                                ? $".//package[@id='{packageId}']/@version"
                                : $".//PackageReference[@Include='{packageId}']/@Version")
                        .NotNull("version != null");

                var packageData = GetGlobalInstalledPackage(packageId, version, packagesDirectory)
                        .NotNull($"GetGlobalInstalledPackage({packageId}, {version}, {packagesDirectory}) != null");
                installedPackages.Add(packageData);

                yield return packageData;
            }

            if (includeDependencies)
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

        private static IEnumerable<InstalledPackage> GetDependentPackages (InstalledPackage packageToCheck, string packagesDirectory)
        {
            return packageToCheck.Metadata.GetDependencyGroups()
                    .SelectMany(x => x.Packages)
                    .Select(x => GetGlobalInstalledPackage(x.Id, x.VersionRange, packagesDirectory)
                            .NotNullWarn($"GetGlobalInstalledPackage({x.Id}, {x.VersionRange}, {packagesDirectory}) != null"))
                    .WhereNotNull()
                    .Distinct(x => new { x.Id, x.Version });
        }

        [CanBeNull]
        public static InstalledPackage GetGlobalInstalledPackage (string packageId, string version = null, string packagesDirectory = null)
        {
            var versionRange = version == null ? null : VersionRange.Parse(version.Contains("*") ? $"{version}" : $"[{version}]");
            return GetGlobalInstalledPackage(packageId, versionRange, packagesDirectory);
        }

        // TODO: add parameter for auto download?
        // TODO: add parameter for highest/lowest?
        [CanBeNull]
        public static InstalledPackage GetGlobalInstalledPackage (
            string packageId,
            VersionRange versionRange = null,
            string packagesDirectory = null,
            bool? includePrereleases = null)
        {
            packageId = packageId.ToLowerInvariant();
            packagesDirectory = packagesDirectory ?? GetPackagesDirectory(GetBuildPackagesConfigFile());

            var packagesDirectoryInfo = new DirectoryInfo(packagesDirectory);
            var packageFiles = packagesDirectoryInfo
                    .GetDirectories(packageId)
                    .SelectMany(x => x.GetDirectories())
                    .SelectMany(x => x.GetFiles($"{packageId}*.nupkg"))
                    .Concat(packagesDirectoryInfo
                            .GetDirectories($"{packageId}*")
                            .SelectMany(x => x.GetFiles($"{packageId}*.nupkg")))
                    .Select(x => x.FullName);

            var candidatePackages = packageFiles.Select(x => new InstalledPackage(x))
                    .Where(x => x.Id.Equals(packageId, StringComparison.OrdinalIgnoreCase)) // packageFiles can contain wrong packages
                    .Where(x => !x.Version.IsPrerelease || !includePrereleases.HasValue || includePrereleases.Value)
                    .OrderByDescending(x => x.Version)
                    .ToList();

            return versionRange == null
                ? candidatePackages.FirstOrDefault()
                : candidatePackages.SingleOrDefault(x => x.Version == versionRange.FindBestMatch(candidatePackages.Select(y => y.Version)));
        }


        // TODO: support for multiple projects per folder
        [CanBeNull]
        private static string GetPackageConfigFile (string projectDirectory)
        {
            var projectDirectoryInfo = new DirectoryInfo(projectDirectory);
            return (projectDirectoryInfo.GetFiles("packages.config").SingleOrDefault() ??
                    projectDirectoryInfo.GetFiles("*.csproj").SingleOrDefault())
                    ?.FullName;
        }

        // TODO: check for config ( repositoryPath / globalPackagesFolder )
        public static string GetPackagesDirectory (string packagesConfigFile)
        {
            if (!IsLegacyFile(packagesConfigFile))
                return Path.Combine(
                    EnvironmentInfo.SpecialFolder(SpecialFolders.UserProfile)
                            .NotNull("EnvironmentInfo.SpecialFolder(SpecialFolders.UserProfile) != null"),
                    ".nuget",
                    "packages");

            if (Build.Instance != null)
                return Path.Combine(Path.GetDirectoryName(Build.Instance.SolutionFile).NotNull(), "packages");

            var packagesDirectory = new FileInfo(packagesConfigFile).Directory.NotNull()
                    .DescendantsAndSelf(x => x.Parent)
                    .SingleOrDefault(x => x.GetFiles("*.sln").Any() && x.GetDirectories("packages").Any())
                    ?.FullName;

            return packagesDirectory.NotNull("GetPackagesDirectory != null");
        }

        public static string GetBuildPackagesConfigFile ()
        {
            var assemblyLocation = EnvironmentInfo.BuildAssembly.Location.NotNull();
            return new DirectoryInfo(Path.GetDirectoryName(assemblyLocation).NotNull())
                    .DescendantsAndSelf(x => x.Parent)
                    .Select(x => GetPackageConfigFile(x.FullName))
                    .FirstOrDefault(x => x != null)
                    .NotNull("GetBuildPackagesConfigFile != null");
        }

        private static bool IsLegacyFile (string packagesConfigFile)
        {
            return packagesConfigFile.EndsWith(".config");
        }

        private static bool IncludesDependencies (string packagesConfigFile)
        {
            return IsLegacyFile(packagesConfigFile);
        }


        public class InstalledPackage
        {
            public sealed class Comparer : IEqualityComparer<InstalledPackage>
            {
                public static readonly Comparer Instance = new Comparer();

                public bool Equals ([CanBeNull] InstalledPackage x, [CanBeNull] InstalledPackage y)
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

                public int GetHashCode ([NotNull] InstalledPackage obj)
                {
                    return obj.Id.GetHashCode();
                }
            }

            public InstalledPackage (string fileName)
            {
                FileName = fileName;
                Metadata = new PackageArchiveReader(fileName).NuspecReader;
            }

            public string FileName { get; }
            public NuspecReader Metadata { get; }
            public string Id => Metadata.GetIdentity().Id;
            public NuGetVersion Version => Metadata.GetIdentity().Version;

            public override string ToString ()
            {
                return $"{Id}.{Version.ToFullString()}";
            }
        }
    }
}
