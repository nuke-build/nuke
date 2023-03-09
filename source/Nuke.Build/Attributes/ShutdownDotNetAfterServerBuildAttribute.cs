// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;

namespace Nuke.Common.CI
{
    /// <summary>
    ///   See <a href="https://github.com/dotnet/cli/issues/11424">dotnet/cli#11424</a>.
    /// </summary>
    [PublicAPI]
    public class ShutdownDotNetAfterServerBuildAttribute : BuildExtensionAttributeBase, IOnBuildFinished
    {
        public override float Priority => -50;

        public bool EnableLogging { get; set; }

        public void OnBuildFinished()
        {
            if (Build.IsServerBuild &&
                // NOTE: this should only be necessary if the interceptor build has no .NET CLI installed
                !Build.IsInterceptorExecution)
            {
                var dotnet = ToolResolver.GetEnvironmentOrPathTool("dotnet");
                dotnet.Invoke($"build-server shutdown", logInvocation: EnableLogging, logOutput: EnableLogging, timeout: 15_000);
            }
        }
    }
}
