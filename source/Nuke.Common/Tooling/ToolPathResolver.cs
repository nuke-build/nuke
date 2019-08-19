// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public static class ToolPathResolver
    {
        public static string NuGetPackagesConfigFile;
        public static string PaketPackagesConfigFile;

        [CanBeNull]
        public static string TryGetEnvironmentExecutable(string environmentExecutable)
        {
            var environmentExecutablePath = EnvironmentInfo.Variable(environmentExecutable);
            if (environmentExecutablePath == null)
                return null;

            ControlFlow.Assert(File.Exists(environmentExecutablePath),
                $"Path '{environmentExecutablePath}' from environment variable '{environmentExecutable}' does not exist.");
            return environmentExecutablePath;
        }

        public static string GetPackageExecutable(string packageId, string packageExecutable, string version = null, string framework = null)
        {
            ControlFlow.Assert(packageId != null && packageExecutable != null, "packageId != null && packageExecutable != null");

            string GetEmbeddedPackagesDirectory(string singlePackageId)
            {
                var assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var embeddedDirectory = (PathConstruction.AbsolutePath) assemblyDirectory / singlePackageId;
                return Directory.Exists(embeddedDirectory) ? embeddedDirectory : null;
            }

            string GetNuGetPackagesDirectory(string singlePackageId) =>
                NuGetPackagesConfigFile != null
                    ? NuGetPackageResolver.GetLocalInstalledPackage(
                            singlePackageId,
                            NuGetPackagesConfigFile,
                            version,
                            resolveDependencies: false)
                        ?.Directory
                    : null;

            string GetPaketPackagesDirectory(string singlePackageId) =>
                PaketPackagesConfigFile != null
                    ? PaketPackageResolver.GetLocalInstalledPackageDirectory(
                        singlePackageId,
                        PaketPackagesConfigFile)
                    : null;

            var packageIds = packageId.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            var packageDirectory = packageIds
                .Select(x =>
                    GetEmbeddedPackagesDirectory(x) ??
                    GetNuGetPackagesDirectory(x) ??
                    GetPaketPackagesDirectory(x))
                .FirstOrDefault().NotNull("packageDirectory != null");

            var packageExecutables = packageExecutable.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            var absolutePackageExecutables = packageExecutables
                .Select(x => Directory.GetFiles(packageDirectory, x, SearchOption.AllDirectories))
                .FirstOrDefault(x => x.Length > 0)?.ToList();

            ControlFlow.Assert(absolutePackageExecutables != null,
                $"Could not find {packageExecutables.Select(x => x.SingleQuote()).Join(", or")} inside '{packageDirectory}'.");
            if (absolutePackageExecutables.Count == 1 && framework == null)
                return absolutePackageExecutables.Single();

            var frameworks = absolutePackageExecutables.Select(x => new FileInfo(x).Directory.NotNull().Name).ToList();
            ControlFlow.Assert(frameworks.Contains(framework, StringComparer.OrdinalIgnoreCase),
                $"Package executable {packageExecutable} [{packageId}] requires a framework: {frameworks.JoinComma()}");

            return absolutePackageExecutables.Single(x => new FileInfo(x).Directory.NotNull().Name.EqualsOrdinalIgnoreCase(framework));
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
