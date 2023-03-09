// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;

namespace Nuke.GlobalTool
{
    partial class Program
    {
        public const string PACKAGE_TYPE_DOWNLOAD = "PackageDownload";
        public const string PACKAGE_TYPE_REFERENCE = "PackageReference";

        [UsedImplicitly]
        public static int AddPackage(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            PrintInfo();
            Logging.Configure();
            Telemetry.AddPackage();
            ProjectModelTasks.Initialize();

            var packageId = args.ElementAt(0);
            var packageVersion =
                (EnvironmentInfo.GetNamedArgument<string>("version") ??
                 args.ElementAtOrDefault(1) ??
                 NuGetVersionResolver.GetLatestVersion(packageId, includePrereleases: false).GetAwaiter().GetResult() ??
                 NuGetPackageResolver.GetGlobalInstalledPackage(packageId, version: null, packagesConfigFile: null)?.Version.ToString())
                .NotNull("packageVersion != null");

            var configuration = GetConfiguration(buildScript, evaluate: true);
            var buildProjectFile = configuration[BUILD_PROJECT_FILE];
            Host.Information($"Installing {packageId}/{packageVersion} to {buildProjectFile} ...");
            AddOrReplacePackage(packageId, packageVersion, PACKAGE_TYPE_DOWNLOAD, buildProjectFile);
            DotNetTasks.DotNet($"restore {buildProjectFile}");

            var installedPackage = NuGetPackageResolver.GetGlobalInstalledPackage(packageId, packageVersion, packagesConfigFile: null)
                .NotNull("installedPackage != null");
            var hasToolsDirectory = installedPackage.Directory.GlobDirectories("tools").Any();
            if (!hasToolsDirectory)
                AddOrReplacePackage(packageId, packageVersion, PACKAGE_TYPE_REFERENCE, buildProjectFile);

            Host.Information($"Done installing {packageId}/{packageVersion} to {buildProjectFile}");
            return 0;
        }

        private static void AddOrReplacePackage(string packageId, string packageVersion, string packageType, string buildProjectFile)
        {
            var buildProject = ProjectModelTasks.ParseProject(buildProjectFile).NotNull();

            var previousPackage = buildProject.Items.SingleOrDefault(x => x.EvaluatedInclude == packageId);
            if (previousPackage != null)
                buildProject.RemoveItem(previousPackage);

            var packageDownloadItem = buildProject.AddItem(packageType, packageId).Single();
            packageDownloadItem.Xml.AddMetadata(
                "Version",
                packageType == PACKAGE_TYPE_REFERENCE ? packageVersion : $"[{packageVersion}]",
                expressAsAttribute: true);
            buildProject.Save();
        }
    }
}
