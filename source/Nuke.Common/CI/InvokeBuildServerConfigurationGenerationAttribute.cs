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
        : BuildServerConfigurationGenerationAttributeBase, IOnAfterLogo
    {
        public void OnAfterLogo(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            if (NukeBuild.IsServerBuild)
                return;

            GetGenerators(build)
                .Where(x => x.AutoGenerate)
                .AsParallel()
                .ForAll(InvokeGeneration);
        }

        private void InvokeGeneration(IConfigurationGenerator generator)
        {
            generator.GeneratedFiles.ForEach(FileSystemTasks.EnsureExistingParentDirectory);
            var previousHashes = generator.GeneratedFiles
                .Where(File.Exists)
                .ToDictionary(x => x, FileSystemTasks.GetFileHash);

            var assembly = Assembly.GetEntryAssembly().NotNull("assembly != null");
            ProcessTasks.StartProcess(
                    assembly.Location,
                    $"--{ConfigurationParameterName} {generator.Id} --host {generator.HostType}",
                    logInvocation: false,
                    logOutput: true)
                .AssertZeroExitCode();

            var changedFiles = generator.GeneratedFiles
                .Where(x => FileSystemTasks.GetFileHash(x) != previousHashes.GetValueOrDefault(x))
                .Select(x => NukeBuild.RootDirectory.GetRelativePathTo(x)).ToList();

            if (changedFiles.Count > 0)
            {
                Logger.Warn($"{generator.Name} configuration files have changed.");
                changedFiles.ForEach(x => Logger.Trace($"Updated {x}"));
            }
        }
    }
}
