// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Reflection;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;

namespace Nuke.Common.CI
{
    public abstract class ConfigurationGenerationAttributeBase : Attribute, IOnBeforeLogo
    {
        public const string ConfigurationParameterName = "configure-build-server";

        public bool AutoGenerate { get; set; } = true;

        public void OnBeforeLogo(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            if (!EnvironmentInfo.GetParameter<bool>(ConfigurationParameterName))
            {
                if (AutoGenerate)
                {
                    var assembly = Assembly.GetEntryAssembly().NotNull("assembly != null");
                    ProcessTasks.StartProcess(
                        assembly.Location,
                        $"--{ConfigurationParameterName} --host {HostType}",
                        logInvocation: false,
                        logOutput: false);
                }

                return;
            }

            Generate(build, executableTargets);

            Environment.Exit(0);
        }

        protected abstract HostType HostType { get; }

        protected abstract void Generate(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets);
    }
}
