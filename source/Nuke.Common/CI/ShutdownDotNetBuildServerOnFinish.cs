// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.Tools.DotNet;

namespace Nuke.Common.CI
{
    [PublicAPI]
    public class ShutdownDotNetBuildServerOnFinish : BuildExtensionAttributeBase, IOnBuildFinished
    {
        public override float Priority => -50;

        public bool EnableLogging { get; set; }

        public void OnBuildFinished(NukeBuild build)
        {
            // Note https://github.com/dotnet/cli/issues/11424
            DotNetTasks.DotNet("build-server shutdown", logInvocation: EnableLogging, logOutput: EnableLogging);
        }
    }
}
