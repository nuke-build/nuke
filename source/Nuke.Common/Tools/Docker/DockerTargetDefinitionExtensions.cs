// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Serilog;
using Serilog.Formatting.Compact.Reader;
using static Nuke.Common.Tools.Docker.DockerTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

namespace Nuke.Common.Tools.Docker
{
    [PublicAPI]
    public static class DockerTargetDefinitionExtensions
    {
        private static readonly AbsolutePath WindowsRootDirectory = @"C:\nuke";
        private static readonly AbsolutePath WindowsNuGetDirectory = @"C:\nuget";

        private static readonly AbsolutePath UnixRootDirectory = @"/nuke";
        private static readonly AbsolutePath UnixNuGetDirectory = @"/nuget";

        /// <summary>
        /// Execute this target within a Docker container
        /// </summary>
        public static ITargetDefinition DockerRun(this ITargetDefinition targetDefinition, Configure<DockerRunTargetSettings> configurator)
        {
            var definition = (TargetDefinition)targetDefinition;
            var build = definition.Build;

            definition.Intercept = () =>
            {
                if (build.IsInterceptorExecution)
                    return false;

                var settings = configurator.InvokeSafe(new DockerRunTargetSettings());
                settings.DotNetRuntime.NotNull();
                settings.Platform.NotNull();

                var buildAssemblyDirectory = build.BuildAssemblyDirectory.NotNull().Parent / settings.DotNetRuntime;
                var buildAssembly = buildAssemblyDirectory / build.BuildAssemblyFile.NotNull().NameWithoutExtension;

                bool IsUpToDate() => build.BuildAssemblyDirectory.GlobFiles("*.dll")
                    .Select(x => build.BuildAssemblyDirectory.GetRelativePathTo(x))
                    .All(x => File.Exists(buildAssemblyDirectory / x) &&
                              File.GetLastWriteTime(buildAssemblyDirectory / x) >= File.GetLastWriteTime(build.BuildAssemblyDirectory / x));

                if ((!settings.BuildCaching ?? true) || !IsUpToDate())
                {
                    Log.Information("Preparing build executable for {DotNetRuntime}...", settings.DotNetRuntime);
                    DotNetPublish(p => p
                        .SetProject(build.BuildProjectFile)
                        .SetOutput(buildAssemblyDirectory)
                        .SetRuntime(settings.DotNetRuntime)
                        .EnableSelfContained()
                        .DisableProcessLogInvocation()
                        .DisableProcessLogOutput());
                }
                else
                {
                    Log.Information("Reusing previously compiled build executable for {DotNetRuntime}...", settings.DotNetRuntime);
                }

                if (settings.PullImage ?? false)
                {
                    Log.Information("Pulling image {Image}...", settings.Image);
                    DockerTasks.Docker($"pull {settings.Image}", logInvocation: false, logOutput: false);
                }

                var (rootDirectory, nugetDirectory) = settings.Platform.StartsWithOrdinalIgnoreCase("win")
                    ? (WindowsRootDirectory, WindowsNuGetDirectory)
                    : (UnixRootDirectory, UnixNuGetDirectory);
                var localTempDirectory = build.TemporaryDirectory / "docker" / definition.Name;
                var tempDirectory = rootDirectory / build.RootDirectory.GetRelativePathTo(localTempDirectory);
                var envFile = buildAssemblyDirectory / $".env.{definition.Name}";
                var environmentVariables = GetEnvironmentVariables(settings, rootDirectory, tempDirectory);

                envFile.WriteAllLines(environmentVariables.Select(x => $"{x.Key}={x.Value}"));
                localTempDirectory.CreateOrCleanDirectory();

                if (!settings.Username.IsNullOrEmpty())
                {
                    Log.Information("Logging into {Server}...", settings.Server);
                    DockerLogin(_ => _
                        .SetUsername(settings.Username)
                        .SetPassword(settings.Password)
                        .SetServer(settings.Server)
                        .DisableProcessLogInvocation()
                        .DisableProcessLogOutput());
                }

                try
                {
                    using (DelegateDisposable.SetAndRestore(() => DockerLogger, (_, message) => Log.Write(LogEventReader.ReadFromString(message))))
                    {
                        Log.Information("Launching target in {Image}...", settings.Image);
                        DockerTasks.DockerRun(_ => settings
                            .When(!settings.Rm.HasValue, _ => _
                                .EnableRm())
                            .AddVolume($"{build.RootDirectory}:{rootDirectory}")
                            .AddVolume($"{NuGetPackageResolver.GetPackagesDirectory(NuGetToolPathResolver.NuGetPackagesConfigFile)}:{nugetDirectory}")
                            .SetPlatform(settings.Platform)
                            .SetWorkdir(rootDirectory)
                            .SetEnvFile(envFile)
                            .SetEntrypoint(rootDirectory / build.RootDirectory.GetRelativePathTo(buildAssembly))
                            .SetArgs(new[]
                            {
                                definition.Target.Name,
                                $"--{ParameterService.GetParameterDashedName(Constants.SkippedTargetsParameterName)}"
                            }.Concat(settings.Args))
                            .DisableProcessLogInvocation());
                    }
                }
                finally
                {
                    if (!settings.KeepEnvFile ?? true)
                        File.Delete(envFile);
                }

                return true;
            };

            return definition;
        }

        private static IReadOnlyDictionary<string, string> GetEnvironmentVariables(
            ToolSettings settings,
            AbsolutePath rootDirectory,
            AbsolutePath tempDirectory)
        {
            var customEnvironmentVariables = new Dictionary<string, string>()
                .AddPair(Constants.InterceptorEnvironmentKey, value: 1)
                // Note: Add this explicitly to avoid loss through clearing of environment variables on user side
                .AddPairWhenValueNotNull("TERM", Logging.SupportsAnsiOutput ? "xterm" : null)
                .AddPair("NUKE_ROOT", rootDirectory)
                .AddPair("NUGET_PACKAGES", "/nuget")
                .AddPair("DOTNET_SKIP_FIRST_TIME_EXPERIENCE", value: 1)
                .AddPair("DOTNET_CLI_TELEMETRY_OPTOUT", value: 1)
                .AddPair("DOTNET_CLI_HOME", rootDirectory)
                .AddPair("TEMP", tempDirectory)
                .AddPair("TMP", tempDirectory)
                // Otherwise: Failed to create CoreCLR, HRESULT: 0x80004005
                // https://github.com/actions/runner/issues/619
                .AddPair("COMPlus_EnableDiagnostics", value: 0);

            var excludedEnvironmentVariables =
                new[]
                {
                    "APPDATA",
                    "DOTNET_EXE",
                    "HOMEPATH",
                    "LOCALAPPDATA",
                    "USERNAME",
                    "USERPROFILE",
                };

            return customEnvironmentVariables
                .AddDictionary(settings.ProcessEnvironmentVariables
                    .Where(x =>
                        !customEnvironmentVariables.Keys.Contains(x.Key, StringComparer.OrdinalIgnoreCase) &&
                        // TODO: Copy from TeamCity?
                        !x.Key.Contains(' ') &&
                        !x.Key.EqualsAnyOrdinalIgnoreCase(excludedEnvironmentVariables))
                    .ToDictionary(x => x.Key, x => x.Value).AsReadOnly())
                .ToImmutableSortedDictionary();
        }
    }
}
