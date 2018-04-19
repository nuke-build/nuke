#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Tooling
{
    [PublicAPI]
    public static class ToolPathResolver
    {
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

        public static string GetPackageExecutable(string packageId, string packageExecutable)
        {
            ControlFlow.Assert(packageId != null && packageExecutable != null, "packageId != null && packageExecutable != null");
            var packagesConfigFile = NuGetPackageResolver.GetBuildPackagesConfigFile();
            var installedPackage = NuGetPackageResolver.GetLocalInstalledPackage(packageId, packagesConfigFile)
                .NotNull($"Could not find package '{packageId}' via '{packagesConfigFile}'.");
            var packageDirectory = Path.GetDirectoryName(installedPackage.FileName).NotNull("packageDirectory != null");
            return Directory.GetFiles(packageDirectory, packageExecutable, SearchOption.AllDirectories)
                .SingleOrDefault()
                .NotNull($"Could not find '{packageExecutable}' inside '{packageDirectory}'.");
        }

        public static string GetPathExecutable(string pathExecutable)
        {
            var locateExecutable = EnvironmentInfo.IsWin
                ? @"C:\Windows\System32\where.exe"
                : "/usr/bin/which";

            var locateProcess = ProcessManager.StartProcessInternal(
                locateExecutable,
                pathExecutable,
                workingDirectory: null,
                environmentVariables: null,
                timeout: null,
                redirectOutput: true,
                outputFilter: null);
            locateProcess.AssertWaitForExit();

            return locateProcess.Output
                .Select(x => x.Text)
                .Where(x => EnvironmentInfo.IsWin && Path.HasExtension(x) || EnvironmentInfo.IsUnix)
                .FirstOrDefault(File.Exists)
                .NotNull($"Could not find '{pathExecutable}' via '{locateExecutable}'.");
        }
    }
}
