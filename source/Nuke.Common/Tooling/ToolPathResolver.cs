// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public static class ToolPathResolver
    {
        public static string PackagesConfigFile;
        
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

        public static string GetPackageExecutable(string packageId, string packageExecutable, string framework = null)
        {
            ControlFlow.Assert(packageId != null && packageExecutable != null, "packageId != null && packageExecutable != null");
            var installedPackage = NuGetPackageResolver.GetLocalInstalledPackages(PackagesConfigFile)
                .FirstOrDefault(x => x.Id.EqualsOrdinalIgnoreCase(packageId))
                .NotNull($"Could not find package '{packageId}' via '{PackagesConfigFile}'.");
            var packageDirectory = Path.GetDirectoryName(installedPackage.FileName).NotNull("packageDirectory != null");

            var executables = Directory.GetFiles(packageDirectory, packageExecutable, SearchOption.AllDirectories);
            ControlFlow.Assert(executables.Length > 0, $"Could not find '{packageExecutable}' inside '{packageDirectory}'.");
            if (executables.Length == 1 && framework == null)
                return executables.Single();

            var frameworks = executables.Select(x => new FileInfo(x).Directory.NotNull().Name).ToList();
            ControlFlow.Assert(frameworks.Contains(framework, StringComparer.OrdinalIgnoreCase),
                $"Package executable {packageExecutable} [{packageId}] requires a framework: {frameworks.JoinComma()}");

            return executables.Single(x => new FileInfo(x).Directory.NotNull().Name.EqualsOrdinalIgnoreCase(framework));
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
                logOutput: false,
                logLevelParser: null,
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
