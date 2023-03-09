// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Execution;

namespace Nuke.Common.CI
{
    internal class SerializeBuildServerStateAttribute : BuildServerConfigurationGenerationAttributeBase, IOnBuildFinished
    {
        public void OnBuildFinished()
        {
            GetGenerators(Build)
                // TODO: bool IsRunning
                .FirstOrDefault(x => x.HostType == Build.Host.GetType())
                ?.SerializeState();
        }
    }
}
