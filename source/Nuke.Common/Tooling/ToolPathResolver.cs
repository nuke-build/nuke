// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public static class ToolPathResolver
    {
        public static string ExecutingAssemblyDirectory;
        public static string NuGetPackagesConfigFile;
        public static string NuGetAssetsConfigFile;
        public static string PaketPackagesConfigFile;

        internal const string MissingPackageDefaultVersion = "latest";

        [CanBeNull]
        public static string TryGetEnvironmentExecutable(string environmentExecutable)
        {
            var environmentExecutablePath = EnvironmentInfo.GetVariable<string>(environmentExecutable);
            if (environmentExecutablePath == null)
                return null;

            ControlFlow.Assert(File.Exists(environmentExecutablePath),
                $"Path '{environmentExecutablePath}' from environment variable '{environmentExecutable}' does not exist.");
            return environmentExecutablePath;
        }

        public static string GetPackageExecutable(string packageId, string packageExecutable, string version = null, string framework = null)
        {
            ControlFlow.Assert(packageId != null && packageExecutable != null, "packageId != null && packageExecutable != null");

            var packageDirectory = GetPackageDirectory(packageId.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries), version);
            var packageExecutables = packageExecutable.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            var packageExecutablePaths = packageExecutables
                .Select(x => Directory.GetFiles(packageDirectory, x, SearchOption.AllDirectories))
                .FirstOrDefault(x => x.Length > 0)?.ToList();

            ControlFlow.Assert(packageExecutablePaths != null,
                $"Could not find {packageExecutables.Select(x => x.SingleQuote()).JoinCommaOr()} inside '{packageDirectory}'.");
            if (packageExecutablePaths.Count == 1 && framework == null)
                return packageExecutablePaths.Single();

            string GetFramework(string file)
            {
                var directory = new FileInfo(file).Directory.NotNull();
                return !directory.Name.EqualsOrdinalIgnoreCase("any")
                    ? directory.Name
                    : directory.Parent.NotNull().Name;
            }

            var frameworks = packageExecutablePaths.ToDictionary(GetFramework, x => x, StringComparer.OrdinalIgnoreCase);
            ControlFlow.Assert(frameworks.Count > 0, "frameworks.Count > 0");
            if (frameworks.Count == 1)
                return frameworks.Values.Single();

            ControlFlow.Assert(framework != null && frameworks.ContainsKey(framework),
                $"Package executable {packageExecutables.JoinCommaOr()} [{packageId}] requires a framework:"
                    .Concat(frameworks.Keys.Select(x => $" - {x}")).JoinNewLine());
            return frameworks[framework];
        }

        private static string GetPackageDirectory(string[] packageIds, [CanBeNull] string version)
        {
            try
            {
                return packageIds
                    .SelectMany(x =>
                        new Func<string>[]
                        {
                            () => ExecutingAssemblyDirectory != null
                                ? Path.Combine(ExecutingAssemblyDirectory, x)
                                : null,
                            () => NuGetAssetsConfigFile != null
                                ? NuGetPackageResolver.GetLocalInstalledPackage(x, NuGetAssetsConfigFile, version)?.Directory
                                : null,
                            () => NuGetPackagesConfigFile != null
                                ? NuGetPackageResolver.GetLocalInstalledPackage(x, NuGetPackagesConfigFile, version)?.Directory
                                : null,
                            () => PaketPackagesConfigFile != null
                                ? PaketPackageResolver.GetLocalInstalledPackageDirectory(x, PaketPackagesConfigFile)
                                : null
                        })
                    .Select(x => x.Invoke())
                    .FirstOrDefault(Directory.Exists)
                    .NotNull(
                        new[]
                            {
                                $"Could not find package {packageIds.Select(x => x.SingleQuote()).JoinCommaOr()} " +
                                $"{(version != null ? $"({version}) " : string.Empty)}" +
                                "using:"
                            }
                            .Concat(
                                new[]
                                {
                                    NukeBuild.BuildProjectDirectory == null
                                        ? $"Embedded packages directory at '{ExecutingAssemblyDirectory}'"
                                        : null,
                                    NuGetAssetsConfigFile != null
                                        ? $"Project assets file '{NuGetAssetsConfigFile}'"
                                        : null,
                                    NuGetPackagesConfigFile != null
                                        ? $"NuGet packages config '{NuGetPackagesConfigFile}'"
                                        : null,
                                    PaketPackagesConfigFile != null
                                        ? $"Paket packages config '{PaketPackagesConfigFile}'"
                                        : null
                                }.WhereNotNull().Select(x => $" - {x}")).JoinNewLine());
            }
            catch (Exception exception)
            {
                if (!NuGetPackagesConfigFile.EndsWithOrdinalIgnoreCase(".csproj"))
                    throw;

                TextTasks.WriteAllLines(
                    Constants.GetMissingPackageFile(NukeBuild.RootDirectory),
                    lines: new[] { NuGetPackagesConfigFile }
                        .Concat(packageIds.Select(x => $"{x}@{version ?? MissingPackageDefaultVersion}"))
                        .ToList());

                throw new Exception(new[] { exception.Message, "Run 'nuke :fix' to add missing references." }.JoinNewLine(), exception);
            }
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
