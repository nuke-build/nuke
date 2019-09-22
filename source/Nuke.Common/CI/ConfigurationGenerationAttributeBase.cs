// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class ConfigurationGenerationAttributeBase : Attribute, IOnBeforeLogo
    {
        public const string ConfigurationParameterName = "configure-build-server";

        public bool AutoGenerate { get; set; } = true;
        protected abstract IEnumerable<string> GeneratedFiles { get; }

        public void OnBeforeLogo(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            if (!EnvironmentInfo.GetParameter<bool>(ConfigurationParameterName))
            {
                if (NukeBuild.IsLocalBuild && AutoGenerate)
                {
                    Logger.LogLevel = LogLevel.Trace;
                    var previousHash = GetCurrentHash();

                    var assembly = Assembly.GetEntryAssembly().NotNull("assembly != null");
                    ProcessTasks.StartProcess(
                            assembly.Location,
                            $"--{ConfigurationParameterName} --host {HostType}",
                            logInvocation: false,
                            logOutput: true)
                        .AssertZeroExitCode();

                    if (GetCurrentHash() != previousHash)
                        Logger.Warn($"Configuration files for {HostType} have changed.");
                }

                return;
            }

            if (NukeBuild.Host == HostType)
            {
                Generate(build, executableTargets);
                Environment.Exit(0);
            }
        }

        private string GetCurrentHash()
        {
            return GeneratedFiles.Select(FileSystemTasks.GetFileHash).JoinComma();
        }

        protected abstract HostType HostType { get; }

        protected abstract void Generate(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets);
    }
}
