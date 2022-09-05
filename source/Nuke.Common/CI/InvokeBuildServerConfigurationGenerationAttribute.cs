// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
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
            if (NukeBuild.IsServerBuild || NukeBuild.IsInterceptorExecution)
                return;

            var hasConfigurationChanged = GetGenerators(build)
                .Where(x => x.AutoGenerate)
                .AsParallel()
                .Select(x => HasConfigurationChanged(x, build)).ToList();
            if (hasConfigurationChanged.All(x => !x))
                return;

            if (build.Help)
                return;

            if (Console.IsInputRedirected)
                return;

            Host.Information("Press any key to continue ...");
            Console.ReadKey();
        }

        private bool HasConfigurationChanged(IConfigurationGenerator generator, NukeBuild build)
        {
            var generatedFiles = generator.GeneratedFiles.ToList();
            generatedFiles.ForEach(x => x.Parent.CreateDirectory());

            var previousHashes = generatedFiles
                .Where(x => x.FileExists())
                .ToDictionary(x => x, x => x.GetFileHash());

            ProcessTasks.StartProcess(
                    NukeBuild.BuildAssemblyFile,
                    $"--{ConfigurationParameterName} {generator.Id} --host {generator.HostName}",
                    logInvocation: false,
                    logOutput: false)
                .AssertZeroExitCode();

            var changedFiles = generatedFiles
                .Where(x => x.GetFileHash() != previousHashes.GetValueOrDefault(x))
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
