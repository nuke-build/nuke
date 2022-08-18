// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Execution
{
    internal class TelemetryAttribute
        : BuildExtensionAttributeBase,
            IOnBuildInitialized,
            IOnTargetSucceeded
    {
        public void OnBuildInitialized(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            if (NukeBuild.IsInterceptorExecution)
                return;

            Telemetry.BuildStarted(build);
        }

        public void OnTargetSucceeded(NukeBuild build, ExecutableTarget target)
        {
            if (NukeBuild.IsInterceptorExecution)
                return;

            Telemetry.TargetSucceeded(target, build);
        }
    }
}
