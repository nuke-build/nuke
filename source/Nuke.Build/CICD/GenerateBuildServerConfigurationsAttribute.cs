// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.Execution;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.CI.BuildServerConfigurationGeneration;

namespace Nuke.Common.CI
{
    public class GenerateBuildServerConfigurationsAttribute
        : BuildServerConfigurationGenerationAttributeBase, IOnBuildCreated
    {
        public void OnBuildCreated(IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            var configurationId = ParameterService.GetParameter<string>(ConfigurationParameterName);
            if (configurationId == null)
                return;

            Assert.NotNull(Build.RootDirectory);

            var generator = GetGenerators(Build)
                .Where(x => x.Id == configurationId)
                .SingleOrDefaultOrError($"Found multiple {nameof(IConfigurationGenerator)} with same ID '{configurationId}'.")
                .NotNull("generator != null");

            generator.Generate(executableTargets);

            Environment.Exit(0);
        }
    }
}
