// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Execution;

namespace Nuke.Common.CI
{
    public class SerializeBuildServerStateAttribute
        : BuildServerConfigurationGenerationAttributeBase, IOnBuildFinished
    {
        public void OnBuildFinished(NukeBuild build)
        {
            GetGenerators(build)
                // TODO: bool IsRunning
                .FirstOrDefault(x => x.HostType == NukeBuild.Host.GetType())
                ?.SerializeState();
        }
    }
}
