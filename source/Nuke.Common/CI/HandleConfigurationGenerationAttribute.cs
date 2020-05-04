// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class)]
    public class HandleConfigurationGenerationAttribute : Attribute, IOnBeforeLogo, IOnAfterLogo, IOnBuildFinished
    {
        public const string ConfigurationParameterName = "generate-configuration";

        public void OnBeforeLogo(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            var configurationId = EnvironmentInfo.GetParameter<string>(ConfigurationParameterName);
            if (configurationId == null)
                return;

            ControlFlow.Assert(NukeBuild.RootDirectory != null, "NukeBuild.RootDirectory != null");

            var generator = GetGenerators(build)
                .Where(x => x.Id == configurationId)
                .SingleOrDefaultOrError($"Found multiple {nameof(IConfigurationGenerator)} with same ID '{configurationId}'.")
                .NotNull("generator != null");

            generator.Generate(build, executableTargets);

            Environment.Exit(0);
        }

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

        public void OnBuildFinished(NukeBuild build)
        {
            GetGenerators(build)
                .FirstOrDefault(x => x.HostType == NukeBuild.Host)
                ?.SerializeState();
        }

        private static IEnumerable<IConfigurationGenerator> GetGenerators(NukeBuild build)
        {
            return build.GetType().GetCustomAttributes<ConfigurationAttributeBase>();
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
