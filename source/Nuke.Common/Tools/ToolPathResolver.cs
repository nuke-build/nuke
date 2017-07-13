// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using Nuke.Core;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools
{
    public static class ToolPathResolver
    {
        // ReSharper disable once CyclomaticComplexity
        public static string GetToolPath (
            string packageId = null,
            string packageExecutable = null,
            string environmentExecutable = null,
            string pathExecutable = null)
        {
            ControlFlow.Assert(packageId != null && packageExecutable != null || environmentExecutable != null || pathExecutable != null,
                "(packageId != null && packageExecutable != null) || environmentExecutable != null || pathExecutable != null");

            if (environmentExecutable != null)
            {
                var environmentExecutablePath = EnvironmentInfo.EnsureVariable(environmentExecutable);
                ControlFlow.Assert(File.Exists(environmentExecutablePath),
                    $"Path '{environmentExecutablePath}' from environment variable '{environmentExecutable}' does not exist.");
                return environmentExecutablePath;
            }

            if (packageExecutable != null)
            {
                var environmentVariableFriendly = packageExecutable.Replace(oldChar: '.', newChar: '_').ToUpperInvariant();
                var environmentExecutablePath = EnvironmentInfo.Variable(environmentVariableFriendly);
                if (environmentExecutablePath != null)
                {
                    ControlFlow.Assert(File.Exists(environmentExecutablePath),
                        $"Path for '{packageExecutable}' was set via environment variable '{environmentVariableFriendly}' but does not exist.");
                    return environmentExecutablePath;
                }
            }

            if (packageId != null || packageExecutable != null)
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
