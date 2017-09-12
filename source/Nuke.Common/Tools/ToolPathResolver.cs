// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tools;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.Tooling;

[assembly: IconClass(typeof(ToolPathResolver), "search3")]

namespace Nuke.Common.Tools
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
            // TODO UB: move to Core and call ProcessManager.Instance ? would require moving NuGetPackageResolver too and reference NuGet packages
            var locateExecutable = EnvironmentInfo.IsWin
                ? @"C:\Windows\System32\where.exe"
                : "/usr/bin/which";
            var locateProcess = ProcessTasks.StartProcess(
                locateExecutable,
                pathExecutable,
                redirectOutput: true);
            locateProcess.AssertWaitForExit();

            return locateProcess.Output
                    .Select(x => x.Text)
                    .FirstOrDefault(File.Exists)
                    .NotNull($"Could not find '{pathExecutable}' via '{locateExecutable}'.");
        }
    }
}
