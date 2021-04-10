// Copyright 2020 Maintainers of NUKE.
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
                .Select(HasConfigurationChanged).ToList();
            if (hasConfigurationChanged.All(x => !x))
                return;

            if (build.Help)
                return;

            Logger.Info("Press any key to continue...");
            Console.ReadKey();
        }

        private bool HasConfigurationChanged(IConfigurationGenerator generator)
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
                    logOutput: true)
                .AssertZeroExitCode();

            var changedFiles = generator.GeneratedFiles
                .Where(x => FileSystemTasks.GetFileHash(x) != previousHashes.GetValueOrDefault(x))
                .Select(x => NukeBuild.RootDirectory.GetRelativePathTo(x)).ToList();

            if (changedFiles.Count == 0)
                return false;

            Logger.Warn($"{generator.DisplayName} configuration files have changed.");
            changedFiles.ForEach(x => Logger.Trace($"Updated {x}"));
            return true;
        }
    }
}
