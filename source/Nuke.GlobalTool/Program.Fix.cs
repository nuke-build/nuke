// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.Utilities.ConsoleUtility;

namespace Nuke.GlobalTool
{
    partial class Program
    {
        private const string PACKAGE_TYPE_DOWNLOAD = "PackageDownload";
        private const string PACKAGE_TYPE_REFERENCE = "PackageReference";

        [UsedImplicitly]
        private static int Fix(string[] args, [CanBeNull] string rootDirectory, [CanBeNull] string buildScript)
        {
            PrintInfo();

            if (rootDirectory == null)
                return 0;

            var missingPackageFile = Constants.GetMissingPackageFile((AbsolutePath) rootDirectory);
            if (!File.Exists(missingPackageFile))
                return 0;

            Logger.Info("During last execution a package was found to be missing.");

            var missingPackageContents = File.ReadAllLines(missingPackageFile);
            var buildProjectFile = missingPackageContents.FirstOrDefault();
            ControlFlow.Assert(File.Exists(buildProjectFile), $"File.Exists({buildProjectFile})");

            var packages = missingPackageContents
                .Skip(1)
                .Select(x => x.Split("@", StringSplitOptions.RemoveEmptyEntries))
                .ForEachLazy(x => ControlFlow.Assert(x.Length == 2, "x.Length == 2"))
                .Select(x => (packageName: x[0], version: x[1])).ToList();
            ControlFlow.Assert(packages.Count > 0, "packages.Count > 0");

            var (selectedPackageId, selectedPackageVersion) = packages.Count == 1
                ? packages.Single()
                : PromptForChoice("Which package should be added?",
                    packages.Select(x => (x, x.packageName)).ToArray());

            if (selectedPackageVersion == ToolPathResolver.MissingPackageDefaultVersion)
            {
                var latestReleaseVersion = NuGetPackageResolver.GetLatestPackageVersion(selectedPackageId, includePrereleases: false);
                var latestPrereleaseVersion = NuGetPackageResolver.GetLatestPackageVersion(selectedPackageId, includePrereleases: true);
                var latestLocalVersion = NuGetPackageResolver.GetGlobalInstalledPackage(selectedPackageId, version: null, packagesConfigFile: null)
                    ?.Version.ToString();

                var packageVersions = new[]
                                      {
                                          ("latest release", latestReleaseVersion.GetAwaiter().GetResult()),
                                          ("latest prerelease", latestPrereleaseVersion.GetAwaiter().GetResult()),
                                          ("latest local", latestLocalVersion),
                                          ("tbd elsewhere", null)
                                      }
                    .Where(x => x.Item2 != null)
                    .Distinct(x => x.Item2)
                    .Select(x => (x.Item2, $"{x.Item2 ?? "<null>"} ({x.Item1})")).ToArray();

                selectedPackageVersion = packageVersions.Length == 1
                    ? packageVersions.Single().Item1
                    : PromptForChoice($"Which version of {selectedPackageId.SingleQuote()} should be added?", packageVersions);
            }

            var project = ProjectModelTasks.ParseProject(buildProjectFile).NotNull();
            var referenceType = PACKAGE_TYPE_DOWNLOAD;
            // var msbuildBinPath = project.GetProperty("MSBuildBinPath").EvaluatedValue;
            // var sdkVersion = msbuildBinPath.Split("/", StringSplitOptions.RemoveEmptyEntries).Last();
            // var referenceType = int.TryParse(sdkVersion.Split(".").First(), out var majorVersion) && majorVersion >= 3
            //     ? PACKAGETYPE_DOWNLOAD
            //     : PACKAGETYPE_REFERENCE;

            var item = project.AddItem(referenceType, selectedPackageId).Single();
            if (selectedPackageVersion != null)
            {
                item.Xml.AddMetadata(
                    "Version",
                    referenceType == PACKAGE_TYPE_DOWNLOAD
                        ? $"[{selectedPackageVersion}]"
                        : selectedPackageVersion,
                    expressAsAttribute: true);
            }

            // if (referenceType == PACKAGE_TYPE_REFERENCE)
            //     item.Xml.AddMetadata("ExcludeAssets", "All", expressAsAttribute: true);

            project.Save();

            File.Delete(missingPackageFile);
            Logger.Success($"Added {item.EvaluatedInclude.SingleQuote()} to {buildProjectFile.SingleQuote()}.");

            return 0;
        }
    }
}
