// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;
using Serilog;
using static Nuke.Common.CI.BuildServerConfigurationGeneration;

namespace Nuke.Common.CI
{
    public class InvokeBuildServerConfigurationGenerationAttribute
        : BuildServerConfigurationGenerationAttributeBase, IOnBuildCreated
    {
        public void OnBuildCreated(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            if (NukeBuild.IsServerBuild)
                return;

            var hasConfigurationChanged = GetGenerators(build)
                .Where(x => x.AutoGenerate)
                .AsParallel()
                .Select(x => HasConfigurationChanged(x, build)).ToList();
            if (hasConfigurationChanged.All(x => !x))
                return;

            if (build.Help)
                return;

            Host.Information("Press any key to continue ...");
            Console.ReadKey();
        }

        private bool HasConfigurationChanged(IConfigurationGenerator generator, NukeBuild build)
        {
            generator.GeneratedFiles.ForEach(FileSystemTasks.EnsureExistingParentDirectory);
            var previousHashes = generator.GeneratedFiles
                .Where(File.Exists)
                .ToDictionary(x => x, FileSystemTasks.GetFileHash);

            var assembly = Assembly.GetEntryAssembly().NotNull("assembly != null");
            ProcessTasks.StartProcess(
                    assembly.Location,
                    $"--{ConfigurationParameterName} {generator.Id} --host {generator.HostName}",
                    logInvocation: false,
                    logOutput: false)
                .AssertZeroExitCode();

            var changedFiles = generator.GeneratedFiles
                .Where(x => FileSystemTasks.GetFileHash(x) != previousHashes.GetValueOrDefault(x))
                .Select(x => NukeBuild.RootDirectory.GetRelativePathTo(x)).ToList();

            if (changedFiles.Count == 0)
                return false;

            Telemetry.ConfigurationGenerated(generator.HostType, generator.Id, build);
            // TODO: multi-line logging
            Log.Warning("Configuration files for {Configuration} have changed.", generator.DisplayName);
            changedFiles.ForEach(x => Log.Verbose("Updated {File}", x));
            return true;
        }
    }
}
